﻿using Styx;
using Styx.Common;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;
using System.Collections.Generic;
using System.Linq;

namespace Paladin.Helpers
{
    public static class Unit
    {
        #region Units and Groups
        public static IEnumerable<WoWUnit> UnfriendlyUnits
        {
            get
            {
                using (StyxWoW.Memory.AcquireFrame(true))
                {
                    return ObjectManager.GetObjectsOfTypeFast<WoWUnit>().Where(u => u.ValidAttackUnit() && u.Distance < 40).ToList();
                }
            }
        }

        public static IEnumerable<WoWUnit> UnfriendlyPlayers
        {
            get
            {
                using (StyxWoW.Memory.AcquireFrame(true))
                {
                    return ObjectManager.GetObjectsOfTypeFast<WoWPlayer>().Where(u => u.IsValid && !u.IsDead && u.Attackable && u.Distance < 40).ToList();
                }
            }
        }

        public static IEnumerable<WoWPlayer> GroupMembers
        {
            get
            {
                using (StyxWoW.Memory.AcquireFrame(true))
                {
                    return ObjectManager.GetObjectsOfTypeFast<WoWPlayer>().Where(u => u.IsInMyParty || u.IsInMyRaid && u.Distance < 40).ToList();
                }
            }
        }
        #endregion

        #region Validity
        public static bool ValidAttackUnit(this WoWUnit p)
        {
            if (p == null || !p.IsValid)
                return false;

            if (!p.Attackable)
                return false;

            if (p.IsFriendly)
                return false;

            if (p.IsDead)
                return false;

            if (p.IsTotem)
                return false;

            if (p.IsNonCombatPet)
                return false;

            if (!p.CanSelect)
                return false;

            if (p.IsCritter)
                return false;

            if (p.IsPlayer && !p.IsHostile)
                return false;

            if (p.IsPet && !p.IsHostile)
                return false;

            return true;
        }
        #endregion

        #region Enemies
        public static int EnemiesInRange(int range)
        {
            return UnfriendlyUnits.Count(u => u.Distance2DSqr <= range * range);
        }

        public static int EnemiesAroundTarget(WoWUnit target, int range)
        {
            return UnfriendlyUnits.Count(u => u.Location.Distance(target.Location) <= range);
        }

        public static bool EnemyAdd
        {
            get { return UnfriendlyUnits.Any(u => u.IsTargetingMeOrPet && StyxWoW.Me.CurrentTarget != u); }
        }

        public static int EnemiesWithBurstAttackingMe
        {
            get { return UnfriendlyPlayers.Count(u => u.CurrentTarget == StyxWoW.Me && u.HasCooldownsRunning()); }
        }

        public static bool EnemiesWithBurstAttackingTarget(WoWUnit target)
        {
            return UnfriendlyPlayers.Any(u => u.CurrentTarget == target && u.HasCooldownsRunning());
        }
        #endregion

        #region Specialization checks
        public static bool IsDps(this WoWUnit player)
        {
            return !player.IsHealer() && !player.IsTank();
        }

        public static bool IsTank(this WoWUnit player)
        {
            var unit = player.ToPlayer();

            switch (unit.Class)
            {
                case WoWClass.Druid:
                    {
                        if (unit.Specialization == WoWSpec.DruidGuardian)
                            return true;
                        break;
                    }

                case WoWClass.DeathKnight:
                    {
                        if (unit.Specialization == WoWSpec.DeathKnightBlood)
                            return true;
                        break;
                    }

                case WoWClass.Monk:
                    {
                        if (unit.Specialization == WoWSpec.MonkBrewmaster)
                            return true;
                        break;
                    }

                case WoWClass.Warrior:
                    {
                        if (unit.Specialization == WoWSpec.WarriorProtection)
                            return true;
                        break;
                    }

                case WoWClass.Paladin:
                    {
                        if (unit.Specialization == WoWSpec.PaladinProtection)
                            return true;
                        break;
                    }
            }

            return false;
        }

        public static bool IsHealer(this WoWUnit player)
        {
            var unit = player.ToPlayer();

            switch (unit.Class)
            {
                case WoWClass.Druid:
                    {
                        if (unit.Specialization == WoWSpec.DruidRestoration)
                            return true;
                        break;
                    }

                case WoWClass.Priest:
                    {
                        if (unit.Specialization == WoWSpec.PriestHoly || unit.Specialization == WoWSpec.PriestDiscipline)
                            return true;
                        break;
                    }

                case WoWClass.Monk:
                    {
                        if (unit.Specialization == WoWSpec.MonkMistweaver)
                            return true;
                        break;
                    }

                case WoWClass.Shaman:
                    {
                        if (unit.Specialization == WoWSpec.ShamanRestoration)
                            return true;
                        break;
                    }

                case WoWClass.Paladin:
                    {
                        if (unit.Specialization == WoWSpec.PaladinHoly)
                            return true;
                        break;
                    }
            }

            return false;
        }
        #endregion
    }
}