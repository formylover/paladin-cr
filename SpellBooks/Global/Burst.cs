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

            if (Globals.CurrentTarget.HasAnyAura(Auras.Defensives))
                return false;

            // Burst on cooldown
            if (PaladinSettings.Instance.BurstOnCooldown)
            {
                return true;
            }

            // Burst if our current target is a boss
            if (PaladinSettings.Instance.BurstOnBoss)
            {
                if (!Globals.CurrentTarget.IsBoss || !Globals.CurrentTarget.IsPlayer)
                    return false;

                return true;
            }

            // Burst if our target is below a certain amount of hp
            if (PaladinSettings.Instance.BurstOnTargetBelow)
            {
                if (Globals.CurrentTarget.HealthPercent > PaladinSettings.Instance.BurstOnTargetBelowHp)
                    return false;

                return true;
            }
            
            return false;
        }
    }
}
