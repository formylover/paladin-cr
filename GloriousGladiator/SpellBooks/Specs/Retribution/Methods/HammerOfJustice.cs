using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using Paladin.Helpers;
using Paladin.Settings;
using Styx;
using Styx.Common;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace Paladin.SpellBooks.Specs.Retribution
{
    public partial class RetributionSpells : PaladinSpells<RetributionTalents>
    {
        public async Task<bool> HammerOfJusticeMethod()
        {
            var target = Global.HammerOfJustice.Check(HammerOfJustice);
            if (target == null) return false;

            return await CastHoj(target);
        }  
  
        private async Task<bool> CastHoj(WoWUnit unit)
        {
            if (!await HammerOfJustice.Cast(unit))
                return false;

            Helpers.Logger.PrintLog("Stunning {0}", unit.SafeName);

            LastSpell = HammerOfJustice;
            return true;
        }
    }
}
