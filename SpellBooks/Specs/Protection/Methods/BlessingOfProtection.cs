using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using Paladin.Helpers;
using Paladin.Managers;
using Paladin.Settings;
using Styx;
using Styx.Common;
using Styx.WoWInternals.WoWObjects;

namespace Paladin.SpellBooks.Specs.Protection
{
    public partial class ProtectionSpells : PaladinSpells<ProtectionTalents>
    {
        public async Task<bool> BlessingOfProtectionMethod()
        {
            if (LastSpell == BlessingOfProtection)
                return false;

            var target = Global.BlessingOfProtection.Check(BlessingOfProtection, DivineShield);
            if (target == null) return false;

            Helpers.Logger.DiagnosticLog("Blessing of Protection on {0}, Distance: {1}, LOS: {2}", target.SafeName, target.Distance, target.InLineOfSpellSight);

            return await BlessingOfProtectionCast(target);
        }

        private async Task<bool> BlessingOfProtectionCast(WoWUnit unit)
        {
            if (!await BlessingOfProtection.Cast(unit))
                return false;

            Helpers.Logger.PrintLog("Cast Hand of Protection on {0} at {1}% health", unit.SafeName, unit.HealthPercent);

            LastSpell = BlessingOfProtection;
            return true;
        }
    }
}