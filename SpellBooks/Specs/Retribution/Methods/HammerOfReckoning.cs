using System.Threading.Tasks;
using Paladin.Helpers;
using Paladin.Settings;

namespace Paladin.SpellBooks.Specs.Retribution
{
    public partial class RetributionSpells : PaladinSpells<RetributionTalents>
    {
        public async Task<bool> HammerOfReckoningMethod()
        {
            if (Globals.CurrentTarget == null) return false;

            if (PaladinSettings.Instance.BurstUse && !Cooldowns)
                return false;

            if (!await HammerOfReckoning.Cast())
                return false;

            LastSpell = HammerOfReckoning;
            return true;
        }
    }
}
