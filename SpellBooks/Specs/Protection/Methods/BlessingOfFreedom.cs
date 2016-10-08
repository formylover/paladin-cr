using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Media;
using Paladin.Helpers;
using Paladin.Settings;
using Styx;
using Styx.Common;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace Paladin.SpellBooks.Specs.Protection
{
    public partial class ProtectionSpells : PaladinSpells<ProtectionTalents>
    {
        public async Task<bool> BlessingOfFreedomMethod()
        {
            if (LastSpell == BlessingOfFreedom) return false;

            var target = Global.BlessingOfFreedom.Check(BlessingOfFreedom);            
            if (target == null) return false;

            Helpers.Logger.DiagnosticLog("Hand of Freedom on {0}, Distance: {1}, LOS: {2}", target.SafeName, target.Distance, target.InLineOfSpellSight);

            if (!await BlessingOfFreedom.Cast(target))
                return false;

            Helpers.Logger.PrintLog("Used Hand of Freedom on {0}", target.SafeName);

            LastSpell = BlessingOfFreedom;
            return true;
        }
    }
}