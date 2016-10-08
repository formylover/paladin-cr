using System.Threading.Tasks;
using System.Windows.Media;
using Paladin.Helpers;
using Paladin.Settings;
using Styx;
using Styx.Common;
using Styx.CommonBot;

namespace Paladin.SpellBooks.Specs.Retribution
{
    public partial class RetributionSpells : PaladinSpells<RetributionTalents>
    {
        public async Task<bool> TemplarsVerdictMethod()
        {
            if (Globals.CurrentTarget == null || !Globals.CurrentTarget.IsWithinMeleeRange) return false;

            if (Globals.HasDivinePurpose)
            {
                if (MyTalents.JusticarsVengeance.IsActive())
                    return false;

                return await CastTemplarsVerdict();
            }

            if (Globals.HolyPower < 3) return false;

            if (MyTalents.JusticarsVengeance.IsActive() && !MyTalents.DivinePurpose.IsActive())
            {
                if (StyxWoW.Me.HealthPercent < PaladinSettings.Instance.JusticarsVengeanceLife)
                    return false;
            }

            return await CastTemplarsVerdict();
        }

        private async Task<bool> CastTemplarsVerdict()
        {
            if (!await TemplarsVerdict.Cast())
                return false;

            LastSpell = TemplarsVerdict;
            return true;
        }
    }
}