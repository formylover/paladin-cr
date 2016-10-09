using System.Threading.Tasks;
using Paladin.Helpers;
using Paladin.Settings;

namespace Paladin.SpellBooks.Specs.Retribution
{
    public partial class RetributionSpells : PaladinSpells<RetributionTalents>
    {
        public async Task<bool> HammerOfReckoningMethod()
        {
            if (!Styx.CommonBot.SpellManager.HasSpell(HammerOfReckoning.ID)) return false;
            if (Globals.CurrentTarget == null) return false;

            if (Globals.CurrentTarget.HealthPercent > PaladinSettings.Instance.HammerOfReckoningHealth) return false;

            if (PaladinSettings.Instance.BurstUse && !Cooldowns)
                return false;

            /*if (HammerOfReckoning.CRSpell == null)
            {
                Helpers.Logger.DiagnosticLog("No Hok Spell");
                return false;
            }

            var chargeInfo = HammerOfReckoning.CRSpell.GetChargeInfo();
            if (chargeInfo == null)
            {
                Helpers.Logger.DiagnosticLog("No Hok Chargeinfo");
                return false;
            }

            Helpers.Logger.DiagnosticLog("Hok Charges: {0}", chargeInfo.ChargesLeft);
            if (HammerOfReckoning.CRSpell.GetChargeInfo().ChargesLeft < 75) return false;*/

            if (!await HammerOfReckoning.Cast(Globals.CurrentTarget))
                return false;

            LastSpell = HammerOfReckoning;
            return true;
        }
    }
}
