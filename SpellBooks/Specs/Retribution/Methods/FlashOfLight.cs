using System.Threading.Tasks;
using System.Windows.Media;
using Paladin.Helpers;
using Paladin.Managers;
using Styx;
using Styx.Common;
using Styx.CommonBot;
using Styx.WoWInternals.WoWObjects;
using Paladin.Settings;

namespace Paladin.SpellBooks.Specs.Retribution
{
    public partial class RetributionSpells : PaladinSpells<RetributionTalents>
    {
        public async Task<bool> FlashOfLightMethod()
        {
            if (!PaladinSettings.Instance.RetFoLMe && !PaladinSettings.Instance.RetFoLOther)
                return false;

            if (StyxWoW.Me.IsMoving)
                return false;

            // We check ourself first
            if (StyxWoW.Me.HealthPercent <= PaladinSettings.Instance.RetFoLSelfHp)
                return await FlashOfLightCast(StyxWoW.Me);

            if (!Globals.Arena) return false;

            if (!PaladinSettings.Instance.RetFoLOther || !Globals.InParty)
                return false;

            // Look for a group target TODO
            var target = Healing.HealTarget(PaladinSettings.Instance.RetFoLOtherHp);

            if (target == null || target.IsDead)
                return false;

            Helpers.Logger.DiagnosticLog("Flash of Light on {0}, Distance: {1}, LOS: {2}", target.SafeName, target.Distance, target.InLineOfSpellSight);
                        
            return await FlashOfLightCast(target);
        }

        private async Task<bool> FlashOfLightCast(WoWUnit unit)
        {
            if (!await FlashOfLight.Cast(unit))
                return false;

            Helpers.Logger.PrintLog("Flash Of Light on {0}", unit.SafeName);

            LastSpell = FlashOfLight;
            return true;
        }
    }
}
