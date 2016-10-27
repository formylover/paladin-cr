using System.Threading.Tasks;

namespace Paladin.SpellBooks.Specs.Retribution
{
    public partial class RetributionSpells : PaladinSpells<RetributionTalents>
    {
        public async Task<bool> BladeOfWrathMethod()
        {
            if (Helpers.Globals.CurrentTarget == null) return false;

            var spell = BladeOfJustice;

            if (spell.CRSpell.Cooldown) return false;

            if (!await spell.Cast(Helpers.Globals.CurrentTarget))
                return false;

            LastSpell = spell;
            return true;
        }
    }
}
