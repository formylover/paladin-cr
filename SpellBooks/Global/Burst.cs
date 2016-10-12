using Paladin.Helpers;
using Paladin.Settings;
using Styx;

namespace Paladin.SpellBooks.Global
{
    public static class Burst
    {
        public static bool Check(Spell spell)
        {
            if (Globals.ActivateBurst)
            {
                Globals.ActivateBurst = false;
                return true;
            }

            if (!PaladinSettings.Instance.BurstUse)
                return false;

            if (!StyxWoW.Me.GotTarget)
                return false;

            if (Globals.CurrentTarget.Distance > Globals.MeleeRange)
                return false;

            if (StyxWoW.Me.Specialization != WoWSpec.PaladinHoly && Globals.CurrentTarget.HasAnyAura(Auras.Defensives))
                return false;

            // Burst on cooldown
            if (PaladinSettings.Instance.BurstOnCooldown)
                return true;

            // Burst if our current target is a boss
            if (PaladinSettings.Instance.BurstOnBoss && (Globals.CurrentTarget.IsBoss || Globals.CurrentTarget.IsPlayer))
                return true;

            // Burst if our target is below a certain amount of hp
            if (PaladinSettings.Instance.BurstOnTargetBelow && Globals.CurrentTarget.HealthPercent < PaladinSettings.Instance.BurstOnTargetBelowHp)
                return true;

            /*if (StyxWoW.Me.Specialization == WoWSpec.PaladinHoly && Globals.CurrentTarget.HealthPercent < 50 && Globals.CurrentTarget.IsFriendly)
                return true;*/

            return false;
        }
    }
}
