using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using Paladin.Helpers;
using Paladin.Settings;
using Styx;
using Styx.Common;

namespace Paladin.SpellBooks.Specs.Retribution
{
    public partial class RetributionSpells : PaladinSpells<RetributionTalents>
    {
        public async Task<bool> DivineHammerMethod()
        {
            // autobubble we dont need to bubble
            if (MyTalents.DivineHammer.IsActive()) return false;
            if (Globals.CurrentTarget == null || Globals.CurrentTarget.Distance > 6) return false;

            if (!await DivineHammer.Cast())
                return false;

            LastSpell = DivineHammer;
            return true;
        }
    }
}