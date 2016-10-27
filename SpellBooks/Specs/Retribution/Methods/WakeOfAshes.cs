using System.Threading.Tasks;
using Paladin.Helpers;

namespace Paladin.SpellBooks.Specs.Retribution
{
    public partial class RetributionSpells : PaladinSpells<RetributionTalents>
    {
        public async Task<bool> WakeOfAshesMethod()
        {
            if (Globals.CurrentTarget == null)
            if (WakeOfAshes.CRSpell.Cooldown) return false;
            if (Globals.CurrentTarget.Distance > 8 || !Globals.CurrentTarget.Attackable) return false;
            if (Globals.HolyPower > 2) return false;
            
            if (!await WakeOfAshes.Cast(Styx.StyxWoW.Me)) return false;

            LastSpell = WakeOfAshes;
            return true;
        }
    }
}
