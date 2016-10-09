using System.Linq;
using Paladin.Helpers;
using Paladin.Settings;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace Paladin.SpellBooks.Global
{
    public static class Rebuke
    {
        public static WoWUnit RebukeTarget(Spell Rebuke)
        {
            if (!PaladinSettings.Instance.RebukeUse)
                return null;

            if (Rebuke.CRSpell.Cooldown)
                return null;

            if (Globals.Arena && Globals.CurrentTarget != null && Globals.CurrentTarget.HealthPercent < 70)
            {
                var target = PlayerToInterrupt();
                if (target != null && ShouldInterrupt(target)) return target;
            }

            if (Globals.CurrentTarget == null) return null;

            if (Globals.CurrentTarget.IsPet)
                return null;

            if (!Globals.CurrentTarget.IsCasting)
                return null;

            // Get the spell ID our target is casting
            if (!Globals.Pvp) return Globals.CurrentTarget;

            if (ShouldInterrupt(Globals.CurrentTarget))
                return Globals.CurrentTarget;

            return null;
        }

        public static WoWUnit PlayerToInterrupt()
        {
            return Unit.UnfriendlyPlayers.FirstOrDefault(u => u.IsWithinMeleeRange && ((u.IsCastingHealingSpell && u.CurrentTarget == Globals.CurrentTarget) || u.IsCastingCCSpell()));
        }

        public static bool ShouldInterrupt(WoWUnit target)
        {
            var spell = Globals.CurrentTarget.CastingSpell;
            if (!PaladinCR.InterruptDict.ContainsKey(spell.Id))
                return false;

            if (PaladinSettings.Instance.RebukeRandomTimerUse)
            {
                var castTime = Globals.CurrentTarget.CastingSpell.CastTime;
                var timeLeft = Globals.CurrentTarget.CurrentCastTimeLeft.TotalMilliseconds;

                var percentage = 100 - (timeLeft * 100 / castTime);

                if (!spell.IsChanneled)
                {
                    if (percentage > PaladinSettings.Instance.RebukeRandomTimerMax)
                        return false;

                    if (percentage < PaladinSettings.Instance.RebukeRandomTimerMin)
                        return false;

                    return true;
                }
            }

            return true;
        }
    }
}
