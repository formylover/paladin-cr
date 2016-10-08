using System.Threading.Tasks;

using Paladin.Helpers;
using Paladin.Settings;
using Paladin.SpellBooks.Specs.Retribution;

using Styx;
using Styx.CommonBot;

namespace Paladin.Rotations.Specs
{
    public class Retribution : Rotation<RetributionSpells>
    {
        #region Behavior Methods
        //TODO: Implement Behavior Methods
        public async override Task<bool> Death()
        {
            return false;
        }

        public async override Task<bool> PreCombatBuff()
        {
            if (!StyxWoW.Me.IsAlive)
                return true;

            if (PaladinSettings.Instance.AutoAttack && StyxWoW.Me.GotTarget && StyxWoW.Me.CurrentTarget.Attackable)
            {
                if (StyxWoW.Me.CurrentTarget.Distance <= 30 && StyxWoW.Me.CurrentTarget.InLineOfSight)
                    return await MySpells.Judgment.Cast();
            }
            
            return await MySpells.BlessingsMethod();
        }
        
        public async override Task<bool> PullBuff()
        {
            return false;
        }

        public async override Task<bool> Pull()
        {
            if (PaladinSettings.Instance.EnableMovement || PaladinSettings.Instance.EnableFacing)
                await MoveToTarget();

            if (!StyxWoW.Me.GotTarget)
                return false;

            if (await MySpells.JudgmentMethod()) return true;
            if (await MySpells.BladeOfWrathMethod()) return true;

            return await MySpells.CrusaderStrikeMethod();
        }

        public async override Task<bool> Heal()
        {
            Globals.HealPulsed = true;
            
            Globals.Update();

            if (await MySpells.DivineShieldMethod()) return true;
            if (await MySpells.ShieldOfVengeanceMethod()) return true;

            if (await MySpells.HotkeysMethod()) return true;

            if (Settings.HealthstoneUse && await Items.Healthstone()) return true;

            if (await MySpells.LayOnHandsMethod()) return true;

            // Global Cooldown
            if (SpellManager.GlobalCooldown) return false;

            if (await MySpells.BlessingOfProtectionMethod()) return true;

            if (await MySpells.BlessingOfSanctuaryMethod()) return true;

            if (await MySpells.EyeForAnEyeMethod()) return true;

            if (await MySpells.WordOfGloryMethod()) return true;

            if (await MySpells.FlashOfLightMethod()) return true;
            
            if (await MySpells.BlessingOfFreedomMethod()) return true;

            if (await MySpells.SealOfLightMethod()) return true;
            
            /*if (Settings.UseCleanse && await MySpells.CleanseMethod()) return true;*/

            return false;
        }

        public async override Task<bool> CombatBuff()
        {
            if (!Globals.HealPulsed)
            {
                await Heal();

                if (Globals.HealPulsed)
                    Globals.HealPulsed = false;
            }

            // Auto Focus in PVP
            if (Globals.Pvp && PaladinSettings.Instance.AutoFocusUse && SpellBooks.Global.AutoFocus.AutoFocusMethod()) return true;
            
            if (await MySpells.HotkeysMethod()) return true;
            
            if (await MySpells.BurstMethod()) return true;

            return false;
        }

        public async override Task<bool> Combat()
        {
            if (Settings.AutoTarget) AutoTarget();

            if (Settings.EnableMovement || Settings.EnableFacing)
                await MoveToTarget();

            Globals.UpdateCombat();

            if (!StyxWoW.Me.GotTarget) return false;

            if (await MySpells.HotkeysMethod()) return true;
            
            if (await MySpells.RacialsMethod()) return true;

            if (await MySpells.TotemStompMethod()) return true;

            if (Globals.Pvp && await MySpells.PvpChecksMethod()) return true;

            if (await MySpells.RebukeMethod()) return true;
            
            if (SpellManager.GlobalCooldownLeft.TotalMilliseconds > 200) return true;

            if (await MySpells.HammerOfJusticeMethod()) return true;
            if (await MySpells.BlindingLightMethod()) return true;
            if (await MySpells.RepentanceMethod()) return true;
            
            if (await MySpells.HolyWrathMethod()) return true;

            if (await MySpells.WakeOfAshesMethod()) return true;
            
            if (await MySpells.HammerOfReckoningMethod()) return true;

            if (await MySpells.ExecutionSentenceMethod()) return true;

            if (await MySpells.JusticarsVengeanceMethod()) return true;

            if (await MySpells.HandOfHindranceMethod()) return true;

            if (await MySpells.DivineStormMethod()) return true;

            if (await MySpells.TemplarsVerdictMethod()) return true;

            if (await MySpells.ConsecrationMethod()) return true;

            if (await MySpells.JudgmentMethod()) return true;
            if (await MySpells.DivineHammerMethod()) return true;
            if (await MySpells.BladeOfWrathMethod()) return true;
            if (await MySpells.CrusaderStrikeMethod()) return true;

            return false;
        }
        #endregion
    }
}
