using System.Threading.Tasks;

using Paladin.Helpers;
using Paladin.Settings;
using Paladin.SpellBooks.Specs.Holy;

using Styx;
using Styx.CommonBot;

namespace Paladin.Rotations.Specs
{
    public class Holy : Rotation<HolySpells>
    {
        public async override Task<bool> Death() { return false; }

        public async override Task<bool> PreCombatBuff()
        {
            if (await MySpells.BeaconOfLightMethod()) return true;

            if (!Globals.InCombat)
            {
                // allow hotkeys out of combat
                if (await MySpells.HotkeysMethod()) return true;
            }

            return false;
        }

        public async override Task<bool> PullBuff() { return false; }

        public async override Task<bool> Pull()
        {
            return false;
        }

        public async override Task<bool> Heal()
        {
            Globals.Update();
            Globals.UpdateCombatHoly();

            if (Settings.AutoTarget) AutoTarget();

            if (await MySpells.HotkeysMethod()) return true;

            // if (await MySpells.RacialsMethod()) return true;

            if (await MySpells.LayOnHandsMethod()) return true;

            if (StyxWoW.Me.IsCasting) return false;

            if (await MySpells.BlessingOfProtectionMethod()) return true;

            if (await MySpells.BlessingOfSacrificeMethod()) return true;

            if (await MySpells.LightOfDawnMethod()) return true;

            // Light of Martyr

            if (await MySpells.BestowFaithMethod()) return true; // TALENT

            if (await MySpells.HolyShockMethod()) return true;

            if (await MySpells.BlessingOfFreedomMethod()) return true;

            // if (await MySpells.CleanseMethod()) return true;

            if (await MySpells.FlashOfLightMethod()) return true;

            if (await MySpells.HolyLightMethod()) return true;

            return false;
        }

        public async override Task<bool> CombatBuff()
        {
            if (Globals.Pvp && PaladinSettings.Instance.AutoFocusUse && SpellBooks.Global.AutoFocus.AutoFocusMethod()) return true;

            if (await MySpells.DivineProtectionMethod()) return true;

            if (await MySpells.DivineShieldMethod()) return true;

            if (await MySpells.BeaconOfLightMethod()) return true;

            if (await MySpells.HotkeysMethod()) return true;

            if (await MySpells.BurstMethod()) return true;

            // Avenging Wrath, Holy Avenger, Tyrs Deliverance, Aura Mastery, Rule of Law,  46 Honor Talent

            return false;
        }

        public async override Task<bool> Combat()
        {
            if (Settings.EnableMovement || Settings.EnableFacing)
                await MoveToTarget();

            if (await MySpells.HammerOfJusticeMethod()) return true;
            // if (await MySpells.BlindingLightMethod()) return true;

            if (await MySpells.JudgmentMethod()) return true;

            if (await MySpells.CrusaderStrikeMethod()) return true;

            return false;
        }
    }
}
