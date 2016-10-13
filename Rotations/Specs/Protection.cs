using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Paladin.Helpers;
using Paladin.Settings;
using Paladin.SpellBooks.Specs.Protection;

using Styx;
using Styx.Common;
using Styx.CommonBot;

namespace Paladin.Rotations.Specs
{
    public class Protection : Rotation<ProtectionSpells>
    {
        #region Behavior Methods
        
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
                {
                    if (await MySpells.AvengersShieldMethod()) return true;
                    if (await MySpells.JudgmentMethod()) return true;

                    return await MySpells.BlessedHammerMethod();
                }

            }

            if (!StyxWoW.Me.IsActuallyInCombat)
            {
                // allow hotkeys out of combat
                if (await MySpells.HotkeysMethod()) return true;
            }

            return false;
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

            if (await MySpells.AvengersShieldMethod()) return true;
            if (await MySpells.JudgmentMethod()) return true;

            return await MySpells.BlessedHammerMethod();
        }
        public async override Task<bool> Heal()
        {
            Globals.Update();

            if (await MySpells.DivineShieldMethod()) return true;
            if (await MySpells.LayOnHandsMethod()) return true;

            if (await MySpells.HotkeysMethod()) return true;

            if (SpellManager.GlobalCooldown) return false;

            if (await MySpells.FlashOfLightMethod()) return true;

            if (await MySpells.BlessingOfProtectionMethod()) return true;
            if (await MySpells.BlessingOfSacrificeMethod()) return true;
            if (await MySpells.BlessingOfFreedomMethod()) return true;

            if (await MySpells.HandOfTheProtectordMethod()) return true;

            /*if (Settings.UseCleanse && await MySpells.CleanseMethod()) return true;*/

            return false;
        }

        public async override Task<bool> CombatBuff()
        {
            // Auto Focus in PVP
            if (Globals.Pvp && PaladinSettings.Instance.AutoFocusUse && SpellBooks.Global.AutoFocus.AutoFocusMethod()) return true;

            if (await MySpells.HotkeysMethod()) return true;

            if (await MySpells.BurstMethod()) return true;

            // if (await MySpells.GuardianOfTheForgottenQueenMethod()) return true; // Honor Talent

            if (await MySpells.GuardianOfAncientKingsMethod()) return true;

            if (await MySpells.ArdentDefenderMethod()) return true;

            return false;
        }

        public async override Task<bool> Combat()
        {
            if (Settings.AutoTarget) AutoTarget();

            if (Settings.EnableMovement || Settings.EnableFacing)
                await MoveToTarget();

            Globals.UpdateCombatProt();

            if (!StyxWoW.Me.GotTarget) return false;

            if (await MySpells.HotkeysMethod()) return true;

            if (await MySpells.RacialsMethod()) return true;

            if (await MySpells.TotemStompMethod()) return true;

            if (Globals.Pvp && PvP.PvPCheck()) return true;

            if (await MySpells.RacialsMethod()) return true;

            if (await MySpells.TotemStompMethod()) return true;

            // if (await MySpells.ShieldOfVirtue()) return true; // Honor Talent silence
            if (await MySpells.RebukeMethod()) return true;

            if (await MySpells.HammerOfJusticeMethod()) return true;
            if (await MySpells.BlindingLightMethod()) return true;

            if (await MySpells.EyeOfTyrMethod()) return true;

            if (await MySpells.AvengersShieldMethod()) return true;
            if (await MySpells.JudgmentMethod()) return true;
            if (await MySpells.ConsecrationMethod()) return true;
            if (await MySpells.ShieldOfRighteousMethod()) return true;
            if (await MySpells.BlessedHammerMethod()) return true;
            if (await MySpells.HammerOfRighteousMethod()) return true;

            return false;
        }
        #endregion
    }
}
