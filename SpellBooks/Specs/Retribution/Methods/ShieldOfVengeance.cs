using System.Linq;
using System.Threading.Tasks;
using Paladin.Helpers;
using Paladin.Settings;
using Styx;

namespace Paladin.SpellBooks.Specs.Retribution
{
    public partial class RetributionSpells : PaladinSpells<RetributionTalents>
    {
        public async Task<bool> ShieldOfVengeanceMethod()
        {
            if (LastSpell == ShieldOfVengeance) return false;

            if (StyxWoW.Me.HealthPercent <= PaladinSettings.Instance.ShieldOfVengeanceLife)
                return await CastShieldOfVengeance();

            if (PaladinSettings.Instance.ShieldOfVengeanceIncomingDamage && Globals.Pvp)
            {
                if ((StyxWoW.Me.HealthPercent > 90 && Unit.EnemiesWithBurstAttackingMe >= 2) || (StyxWoW.Me.HealthPercent > 70 && Unit.EnemiesWithBurstAttackingMe >= 1))
                    return await CastShieldOfVengeance();

                var unit = Unit.UnfriendlyUnits.FirstOrDefault(u => u.CurrentTarget == StyxWoW.Me && u.IsCastingBigDamageSpell());
                if (unit != null)
                    return await CastShieldOfVengeance();
            }

            return false;
        }

        public async Task<bool> CastShieldOfVengeance()
        {
            if (!await ShieldOfVengeance.Cast(Styx.StyxWoW.Me))
                return false;

            LastSpell = ShieldOfVengeance;
            return true;
        }
    }
}
