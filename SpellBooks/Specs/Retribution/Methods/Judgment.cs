using Paladin.Helpers;
using System.Threading.Tasks;
using Styx;

namespace Paladin.SpellBooks.Specs.Retribution
{
    public partial class RetributionSpells : PaladinSpells<RetributionTalents>
    {
        public async Task<bool> JudgmentMethod()
        {
            if (Globals.CurrentTarget == null) return false;

            if (!await Judgment.Cast(Globals.CurrentTarget))
                return false;

            LastSpell = Judgment;
            return true;
        }
    }
}