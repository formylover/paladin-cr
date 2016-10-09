using System.Threading.Tasks;
using Paladin.Helpers;

namespace Paladin.SpellBooks.Specs.Retribution
{
    public partial class RetributionSpells : PaladinSpells<RetributionTalents>
    {
        public async Task<bool> HandOfHindranceMethod()
        {
            if (Globals.CurrentTarget == null) return false;

            if (!Paladin.Settings.PaladinSettings.Instance.UseHandOfHindrance)
                return false;

            if (!Globals.Pvp) return false;
            
            if (Globals.CurrentTarget.IsWithinMeleeRange)
                return false;

            if (Globals.CurrentTarget.IsMoving && Globals.CurrentTarget.HealthPercent < 90)
            {
                if (!await HandOfHindrance.Cast())
                    return false;

                LastSpell = HandOfHindrance;
                return true;
            }

            return false;
        }
    }
}
