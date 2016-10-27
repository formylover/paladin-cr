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
        private static IEnumerable<WoWPlayer> _healList;
        public static IEnumerable<WoWPlayer> HealList
        {
            get
            {                
                var list = Unit.GroupMembers.Where(u => !u.IsDead && u.InLineOfSpellSight).OrderBy(u => u.HealthPercent).ToList();
                
                if (list.Contains(StyxWoW.Me))
                    list.Remove(StyxWoW.Me);

                _healList = list;

                return _healList;
            }
        }

        public static WoWPlayer HealTarget(int hp, bool includeSelf = false)
        {
            if (StyxWoW.Me.Specialization == WoWSpec.PaladinHoly)
            {
                if (Globals.CurrentTarget != null && Globals.CurrentTarget.IsFriendly && Globals.CurrentTarget.ToPlayer() != null && Globals.CurrentTarget.HealthPercent < hp && Globals.CurrentTarget.Distance < 40)
                    return Globals.CurrentTarget.ToPlayer();
            }

            //return HealList.FirstOrDefault(u => u.HealthPercent <= hp);
            List<WoWPlayer> list = HealList.ToList();
            if (includeSelf)
                list.Add(StyxWoW.Me);
            
            return list
                .Where(t => t.IsAlive && t.HealthPercent < hp && t.SpellDistance() < 40 && t.GetPredictedHealthPercent() < (hp - 5))
                .OrderBy(k => k.HealthPercent)
                .FirstOrDefault();
        }

        public static bool CastLightOfDawn(int hp)
        {
            List<WoWPlayer> list = HealList.ToList();
            list.Add(StyxWoW.Me);

            return list
                .Count(t => t.IsAlive && t.HealthPercent < hp && t.Distance < 20 && (t == StyxWoW.Me || StyxWoW.Me.IsFacing(t))) > PaladinSettings.Instance.LightOfDawnTargets;
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
            var list = ObjectManager.GetObjectsOfTypeFast<WoWPlayer>().Where(u => (u.IsInMyParty || u.IsInMyRaid) && u.Distance < 40 && u.IsAlive);

            if (PaladinSettings.Instance.UseBoPKarma)
            {
                // HoP on Monk Karma to ignore it
                var target = list.FirstOrDefault(u => !u.HasDefensiveBuff() && u.HasAura(122470) && u.GetAuraById(122470).IsHarmful && u.Class != WoWClass.Paladin);
                if (target != null)
                    return target;
            }

            if (PaladinSettings.Instance.UseBoPBurst)
            {
                var target = list.FirstOrDefault(u => !u.HasDefensiveBuff() && Unit.EnemiesWithBurstAttackingTarget(u) && u.Class != WoWClass.Paladin);
                if (target != null)
                    return target;
            }

            // If we're in a BG we pick the first target available
            // Can't use Lay on Hands in an arena
            if (StyxWoW.Me.GroupInfo.IsInBattlegroundParty)
                return list.FirstOrDefault(u => !u.HasForbearance() && !u.HasDefensiveBuff() && u.HealthPercent <= hp && u.Class != WoWClass.Paladin);

            // At this point we don't want to use HoP on a tank
            return list.FirstOrDefault(u => !u.HasForbearance() && u.HealthPercent <= hp && u.Class != WoWClass.Paladin);
        }

        public static WoWPlayer BlessingOfSanctuaryTarget()
        {
            return HealList.FirstOrDefault(u => u.HasAuraWithMechanic(
                                          WoWSpellMechanic.Silenced,
                                          WoWSpellMechanic.Horrified,
                                          WoWSpellMechanic.Fleeing,
                                          WoWSpellMechanic.Stunned));
        }
    }
}
