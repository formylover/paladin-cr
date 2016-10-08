using Paladin.Helpers;
using System.Threading.Tasks;

namespace Paladin.SpellBooks.Specs.Retribution
{
    public partial class RetributionSpells : PaladinSpells<RetributionTalents>
    {
        public async Task<bool> ConsecrationMethod()
        {
            if (!MyTalents.Consecration.IsActive()) return false;
            if (Globals.CurrentTarget == null || Globals.CurrentTarget.Distance > 6) return false;

            if (!await Consecration.Cast()) return false;

            LastSpell = BlindingLight;
            return true;
        }
    }
}
