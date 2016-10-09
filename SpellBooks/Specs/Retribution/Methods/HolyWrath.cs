using System.Threading.Tasks;
using Paladin.Settings;
using Paladin.Helpers;

namespace Paladin.SpellBooks.Specs.Retribution
{
    public partial class RetributionSpells : PaladinSpells<RetributionTalents>
    {
        public async Task<bool> HolyWrathMethod()
        {
            // PaladinSettings.Instance.IntelligentHolyWrath - TODO

            if (!MyTalents.HolyWrath.IsActive()) return false;
            if (Styx.StyxWoW.Me.HealthPercent > PaladinSettings.Instance.HolyWrathLife) return false;
            if (Globals.CurrentTarget.Distance > 9) return false;

            if (!await HolyWrath.Cast(Styx.StyxWoW.Me)) return false;

            LastSpell = HolyWrath;
            return true;
        }
    }
}
