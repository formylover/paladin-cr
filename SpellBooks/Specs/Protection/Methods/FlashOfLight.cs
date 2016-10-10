using System.Threading.Tasks;
using System.Windows.Media;
using Paladin.Helpers;
using Paladin.Managers;
using Styx;
using Styx.Common;
using Styx.CommonBot;
using Styx.WoWInternals.WoWObjects;
using Paladin.Settings;

namespace Paladin.SpellBooks.Specs.Protection
{
    public partial class ProtectionSpells : PaladinSpells<ProtectionTalents>
    {
        public async Task<bool> FlashOfLightMethod()
        {
            // TODO unify
            if (!PaladinSettings.Instance.ProtFoLMe && !PaladinSettings.Instance.ProtFoLOther)
                return false;

            if (StyxWoW.Me.IsMoving)
                return false;

            if (Globals.InParty && !Globals.Pvp) return false; // if we are in a pvp party dont heal TODO check if healer is alive

            // We check ourself first
            if (StyxWoW.Me.HealthPercent <= PaladinSettings.Instance.ProtFoLSelfHp)
                return await FlashOfLightCast(StyxWoW.Me);

            if (!Globals.Arena) return false;

            if (!PaladinSettings.Instance.ProtFoLOther || !Globals.InParty)
                return false;
            // Look for a group target TODO
            var target = Healing.HealTarget(PaladinSettings.Instance.ProtFoLOtherHp);

            if (target == null || target.IsDead)
                return false;

            Helpers.Logger.DiagnosticLog("Flash of Light on {0}, Distance: {1}, LOS: {2}", target.SafeName, target.Distance, target.InLineOfSpellSight);
            Helpers.Logger.PrintLog("Flash Of Light on " + target.SafeName);

            if (!await FlashOfLight.Cast(target))
                return false;

            LastSpell = FlashOfLight;
            return await FlashOfLightCast(target);
        }

        private async Task<bool> FlashOfLightCast(WoWUnit unit)
        {
            if (!await FlashOfLight.Cast(unit))
                return false;

            Helpers.Logger.PrintLog("Flash Of Light on " + unit.SafeName);

            LastSpell = FlashOfLight;
            return true;
        }
    }
}
