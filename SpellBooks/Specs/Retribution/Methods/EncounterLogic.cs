using System.Threading.Tasks;
using Paladin.Helpers;
using Styx;

namespace Paladin.SpellBooks.Specs.Retribution
{
    public partial class RetributionSpells : PaladinSpells<RetributionTalents>
    {
        public async Task<bool> EncounterLogic()
        {
            // Fleshrender Nok'gar
            // Reckless Provocation causes you to get feared if you hit into it
            if (Globals.CurrentTarget.HasAura(164426))
                return true;

            return false;
        }
    }
}
