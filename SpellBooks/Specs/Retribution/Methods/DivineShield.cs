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
        public async Task<bool> DivineShieldMethod()
        {
            if (!PaladinSettings.Instance.UseDivineShield)
                return false;

            // autobubble we dont need to bubble
            if (MyTalents.DivineIntervention.IsActive())
                return false;

            if (PaladinSettings.Instance.UseDivineShieldHp <= 0 || Globals.MyHp > PaladinSettings.Instance.UseDivineShieldHp)
                return false;

            Helpers.Logger.DiagnosticLog("Attempting to cast Divine Shield at {0}", Globals.MyHp);
            
            if (!await DivineShield.Cast(StyxWoW.Me))
                return false;

            LastSpell = DivineShield;
            return true;
        }
    }
}