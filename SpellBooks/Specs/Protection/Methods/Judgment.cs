using Paladin.Helpers;
using System.Threading.Tasks;
using Styx;

namespace Paladin.SpellBooks.Specs.Protection
{
    public partial class ProtectionSpells : PaladinSpells<ProtectionTalents>
    {
        public async Task<bool> JudgmentMethod()
        {
            if (!await Judgment.Cast(Globals.CurrentTarget))
                return false;

            LastSpell = Judgment;
            return true;
        }
    }
}