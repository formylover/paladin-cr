using System.Threading.Tasks;
using System.Windows.Media;
using Paladin.Helpers;
using Paladin.Managers;
using Paladin.Settings;
using Styx;
using Styx.Common;
using Styx.WoWInternals.WoWObjects;

namespace Paladin.SpellBooks.Specs.Retribution
{
    public partial class RetributionSpells : PaladinSpells<RetributionTalents>
    {
        public async Task<bool> LayOnHandsMethod()
        {
            if (LayOnHands.CRSpell.Cooldown)
                return false;

            if (PaladinSettings.Instance.RetLoHUseOnSelf && !Globals.Forbearance && Globals.MyHp <= PaladinSettings.Instance.RetLoHUseHp)
                return await CastLayOnHands(StyxWoW.Me);

            if (!PaladinSettings.Instance.RetLoHUse || !Globals.InParty)
                return false;

            // Unit.LayOnHandsTarget already does the checks for tank/healer etc
            var target = Healing.LayOnHandsTarget(PaladinSettings.Instance.RetLoHUseHp);
            if (target == null || target.IsDead)
                return false;

            Helpers.Logger.DiagnosticLog("Lay on Hands on {0}, Distance: {1}, LOS: {2}", target.SafeName, target.Distance, target.InLineOfSpellSight);

            return await CastLayOnHands(target);
        }

        private async Task<bool> CastLayOnHands(WoWUnit unit)
        {
            if (!await LayOnHands.Cast(unit))
                return false;

            Helpers.Logger.PrintLog("Using Lay on Hands on {0} at {1}%", unit.SafeName, unit.HealthPercent);

            LastSpell = LayOnHands;
            return true;
        }
    }
}