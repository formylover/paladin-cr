using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using Paladin.Helpers;
using Paladin.Settings;
using Styx;
using Styx.Common;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace Paladin.SpellBooks.Global
{
    public static class HammerOfJustice
    {
        public static WoWUnit Check(Spell spell)
        {
            if (!PaladinSettings.Instance.HoJUse) return null;
            if (spell.CRSpell.Cooldown) return null;

            // Use HoJ on cooldown
            if (PaladinSettings.Instance.HoJUseOnCooldown)
            {
                if (Globals.CurrentTarget != null)
                    return Globals.CurrentTarget;
            }

            if (!Globals.Pvp) return null;

            int range = 10;
            if (Managers.Talents.HasPassivHonorTalent(204979))
                range = 20;

            // Create a list of targets we can use HoJ on
            var hojList = Unit.UnfriendlyUnits.Where(u => u.InLineOfSpellSight && u.Distance <= range && !u.HasAuraWithMechanic(WoWSpellMechanic.Dazed,
                                          WoWSpellMechanic.Disoriented,
                                          WoWSpellMechanic.Frozen,
                                          WoWSpellMechanic.Incapacitated,
                                          WoWSpellMechanic.Fleeing,
                                          WoWSpellMechanic.Stunned,
                                          WoWSpellMechanic.Sapped,
                                          WoWSpellMechanic.Polymorphed,
                                          WoWSpellMechanic.Horrified,
                                          WoWSpellMechanic.Charmed)).ToList();

            if (PaladinSettings.Instance.HoJInterrupt && Globals.CurrentTarget.HealthPercent < PaladinSettings.Instance.HoJTargetBelow)
            {
                var unit = hojList.FirstOrDefault(u => ((PaladinSettings.Instance.HoJInterruptHeal && u.Distance <= range && u.IsCastingHealingSpell)
                                          || (PaladinSettings.Instance.HoJInterruptCC && u.IsCastingCCSpell())));

                return unit;
            }

            // Enemy casting on us
            /*if (PaladinSettings.Instance.HoJUseEnemyCastingOnMe)
            {
                var unit = hojList.FirstOrDefault(u => u.CurrentTarget == StyxWoW.Me && u.IsCasting);

                if (unit != null)
                    return await CastHoj(unit);
            }*/

            return null;
        }
    }
}
