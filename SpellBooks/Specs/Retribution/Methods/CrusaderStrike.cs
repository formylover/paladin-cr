using System.Threading.Tasks;

namespace Paladin.SpellBooks.Specs.Retribution
{
    public partial class RetributionSpells : PaladinSpells<RetributionTalents>
    {
        public async Task<bool> CrusaderStrikeMethod()
        {
            if (Helpers.Globals.CurrentTarget == null) return false;

            if (MyTalents.Zeal.IsActive())
            {
                if (!await Zeal.Cast()) return false;

                LastSpell = Zeal;
                return true;
            }

            if (!await CrusaderStrike.Cast()) return false;
            
            LastSpell = CrusaderStrike;
            return true;
        }
    }
}
