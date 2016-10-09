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

            if (Globals.CurrentTarget.HealthPercent > 75) return false; // TODO setting

            if (PaladinSettings.Instance.BurstUse && !Cooldowns)
                return false;

            if (!await HammerOfReckoning.Cast())
                return false;

            LastSpell = HammerOfReckoning;
            return true;
        }
    }
}
