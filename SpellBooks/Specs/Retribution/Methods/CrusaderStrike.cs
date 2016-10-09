using System.Threading.Tasks;

namespace Paladin.SpellBooks.Specs.Retribution
{
    public partial class RetributionSpells : PaladinSpells<RetributionTalents>
    {
        public async Task<bool> CrusaderStrikeMethod()
        {
            if (Helpers.Globals.CurrentTarget == null || !Helpers.Globals.CurrentTarget.IsWithinMeleeRange) return false;

            if (MyTalents.Zeal.IsActive())
            {
                if (Zeal.CRSpell.GetChargeInfo().ChargesLeft == 0) return false;

                if (!await Zeal.Cast(Helpers.Globals.CurrentTarget)) return false;

                LastSpell = Zeal;
                return true;
            }

            if (CrusaderStrike.CRSpell.GetChargeInfo().ChargesLeft == 0) return false;

            if (!await CrusaderStrike.Cast(Helpers.Globals.CurrentTarget)) return false;
            
            LastSpell = CrusaderStrike;
            return true;
        }
    }
}
