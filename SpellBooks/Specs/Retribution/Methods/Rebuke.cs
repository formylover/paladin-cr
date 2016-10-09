using System;
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
        public async Task<bool> RebukeMethod()
        {
            var target = SpellBooks.Global.Rebuke.RebukeTarget(Rebuke);
            if (target == null) return false;

            if (!await Rebuke.Cast(target))
                return false;

            Helpers.Logger.PrintLog("Interrupting {0} on {1}", target.CastingSpell.Name, target.SafeName);

            LastSpell = Rebuke;
            return true;
        }
    }
}
