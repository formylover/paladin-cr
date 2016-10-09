using System.Collections.Generic;
using System.Linq;
using Paladin.Helpers;
using Paladin.Settings;
using Styx;
using Styx.Common;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace Paladin.Managers
{
    public static class Healing
    {
        public static bool ResetHealList = false;
        private static IEnumerable<WoWPlayer> _healList;
        public static IEnumerable<WoWPlayer> HealList
        {
            get
            {
                if (_healList == null || ResetHealList)
                {
                    var list = Unit.GroupMembers.Where(u => !u.IsDead && u.InLineOfSpellSight).OrderBy(u => u.HealthPercent).ToList();

                    if (list.Contains(StyxWoW.Me))
                        list.Remove(StyxWoW.Me);

                    _healList = list;
                }

                return _healList;
            }
        }

        public static WoWPlayer HealTarget(int hp)
        {
            return HealList.FirstOrDefault(u => u.HealthPercent <= hp);
        }

        private static bool HasDefensiveBuff(this WoWUnit unit)
        {
            // Used to check if someone already has defensives
            // so we can avoid wasting a HoP or something
            return unit.HasAnyAura(Auras.Defensives);
        }

        public static WoWPlayer LayOnHandsTarget(int hp)
        {
            // If we're doing pvp we'll pick targets that meet the hp level
            // If we're not in pvp check settings
            if (StyxWoW.Me.IsInArena)
                return null;

            //if (StyxWoW.Me.GroupInfo.IsInBattlegroundParty || !PaladinSettings.Instance.LoHOnlyTankAndHealer)
            return HealList.FirstOrDefault(u => !u.HasForbearance() && u.HealthPercent <= hp);

            // Pick only a tank or a healer
            //return HealList.FirstOrDefault(u => u.InLineOfSpellSight && (u.IsTank() || u.IsHealer()) && !u.HasForbearance() && u.HealthPercent <= hp);
        }

        public static WoWPlayer HandOfProtectionTarget(int hp)
        {
            if (PaladinSettings.Instance.UseBoPKarma)
            {
                // HoP on Monk Karma to ignore it
                var target = HealList.FirstOrDefault(u => !u.HasDefensiveBuff() && u.HasAura(122470) && u.GetAuraById(122470).IsHarmful && u.Class != WoWClass.Paladin);
                if (target != null)
                    return target;
            }

            if (PaladinSettings.Instance.UseBoPBurst)
            {
                var target = HealList.FirstOrDefault(u => !u.HasDefensiveBuff() && Unit.EnemiesWithBurstAttackingTarget(u) && u.Class != WoWClass.Paladin);
                if (target != null)
                    return target;
            }

            // If we're in a BG we pick the first target available
            // Can't use Lay on Hands in an arena
            if (StyxWoW.Me.GroupInfo.IsInBattlegroundParty)
                return HealList.FirstOrDefault(u => !u.HasForbearance() && !u.HasDefensiveBuff() && u.HealthPercent <= hp && u.Class != WoWClass.Paladin);

            // At this point we don't want to use HoP on a tank
            return HealList.FirstOrDefault(u => !u.HasForbearance() && !u.IsTank() && u.HealthPercent <= hp && u.Class != WoWClass.Paladin);
        }

        public static WoWPlayer BlessingOfSanctuaryTarget()
        {
            return HealList.FirstOrDefault(u => u.HasAuraWithMechanic(
                                          WoWSpellMechanic.Silenced,
                                          WoWSpellMechanic.Horrified,
                                          WoWSpellMechanic.Fleeing,
                                          WoWSpellMechanic.Stunned));
        }

        public static WoWUnit HolyPrismTarget(int hp)
        {
            // Check if enemies are near someone who needs a heal in our group
            // This will return the ENEMY we need to use Holy Prism on

            var healtarget = HealTarget(hp);

            // If we don't have a target return null
            if (healtarget == null)
                return null;
            
            return Unit.UnfriendlyUnits.FirstOrDefault(u => !u.IsCrowdControlled() && StyxWoW.Me.IsFacing(u) && u.Location.DistanceSquared(healtarget.Location) <= 15);
        }
    }
}
