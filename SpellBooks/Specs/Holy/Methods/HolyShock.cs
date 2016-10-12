using System.Threading.Tasks;
using System.Windows.Media;
using Paladin.Helpers;
using Paladin.Managers;
using Styx;
using Styx.Common;
using Styx.CommonBot;
using Styx.WoWInternals.WoWObjects;
using Paladin.Settings;

namespace Paladin.SpellBooks.Specs.Holy
{
    public partial class HolySpells : PaladinSpells<HolyTalents>
    {
        public async Task<bool> HolyShockMethod()
        {
            if (HolyShock.CRSpell.Cooldown) return false;

            var target = Healing.HealTarget(PaladinSettings.Instance.HolyShock, true);
            if (target == null || target.IsDead || target.IsGhost) return false;

            Helpers.Logger.DiagnosticLog("Holy Shock on {0}, Distance: {1}, LOS: {2}", target.SafeName, target.Distance, target.InLineOfSpellSight);
            
            return await HolyShockCast(target);
        }

        private async Task<bool> HolyShockCast(WoWUnit unit)
        {
            if (!await HolyShock.Cast(unit))
                return false;

            Helpers.Logger.PrintLog("Holy Shock on {0}", unit.SafeName);

            LastSpell = HolyShock;
            return true;
        }
    }
}
