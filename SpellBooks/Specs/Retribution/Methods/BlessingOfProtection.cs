using System.Threading.Tasks;
using Styx.WoWInternals.WoWObjects;

namespace Paladin.SpellBooks.Specs.Retribution
{
    public partial class RetributionSpells : PaladinSpells<RetributionTalents>
    {
        public async Task<bool> BlessingOfProtectionMethod()
        {
            if (BlessingOfFreedom.CRSpell.Cooldown) return false;
            if (LastSpell == BlessingOfProtection) return false;
            
            var target = Global.BlessingOfProtection.Check(BlessingOfProtection, DivineShield);
            if (target == null) return false;

            // sleep a short delay if target has karma
            if (target.HasAura(122470))
            {
                Helpers.Logger.PrintLog("{0} has Karma, casting BoP", target.SafeName);
                var delay = new System.Random().Next(250, 800);
                await Buddy.Coroutines.Coroutine.Sleep(delay);
            }

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