using Paladin.Helpers;
using Paladin.Settings;
using Styx;

namespace Paladin.SpellBooks.Global
{
    public static class Rebuke
    {
        public static bool RebukeCheck(Spell Rebuke)
        {
            if (!PaladinSettings.Instance.RebukeUse)
                return false;

            if (Rebuke.CRSpell.Cooldown)
                return false;

            if (Globals.CurrentTarget == null) return false;

            if (Globals.CurrentTarget.IsPet)
                return false;

            if (!Globals.CurrentTarget.IsCasting)
                return false;

            // Get the spell ID our target is casting
            var spell = Globals.CurrentTarget.CastingSpell;
            if (spell == null) return false;

            if (!Globals.Pvp) return true;

            if (!PaladinCR.InterruptDict.ContainsKey(spell.Id))
                return false;

            var castTime = Globals.CurrentTarget.CastingSpell.CastTime;
            var timeLeft = Globals.CurrentTarget.CurrentCastTimeLeft.TotalMilliseconds;

            var percentage = 100 - (timeLeft * 100 / castTime);

            if (!spell.IsChanneled && PaladinSettings.Instance.RebukeRandomTimerUse)
            {
                if (percentage > PaladinSettings.Instance.RebukeRandomTimerMax)
                    return false;

                if (percentage < PaladinSettings.Instance.RebukeRandomTimerMin)
                    return false;

                return true;
            }

            return true;
        }
    }
}
