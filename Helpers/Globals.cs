using System;
using System.Diagnostics;
using System.Linq;
using Styx;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace Paladin.Helpers
{
    public static class Globals
    {
        public static double MyHp;
        public static uint HolyPower;
        public static bool InParty;
        public static bool HealPulsed;
        public static bool Mounted
        {
            get
            {
                var me = StyxWoW.Me;
                return !me.HasAura(164222) &&
                       !me.HasAura(165803) &&
                       !me.HasAura(178807) &&
                       !me.HasAura(157060) &&           //http://www.wowhead.com/spell=157060/rune-of-grasping-earth
                       !me.HasAura(157056) &&
                       (me.Mounted || me.InVehicle);
            }
        }
        
        public static Stopwatch ForceUpdateScanner = new Stopwatch();
        private static int ForceUpdateScanInterval = 500;

        public static bool InCombat;

        // Hotkeys
        public static WoWUnit HoJTarget;
        public static bool ActivateBurst;
        public static bool ActivateDivineSteed;

        // Zone
        public static bool Pvp;
        public static bool Arena;

        public static int LastKnownGroupMemberSize = 0;

        // Enemies
        public static WoWUnit CurrentTarget;
        public static int EnemiesInRange;
        public static float MeleeRange;

        // Auras
        public static bool Forbearance;
        public static WoWAura EyeForAnEye;
        public static WoWAura DivinePurpose;
        public static WoWAura ShieldOfRighteous;

        // Prot
        public static bool JudgmentAndAs;

        // PVP
        public static WoWUnit FocusedUnit;
        public static bool HasFocus;

        public static void ForceUpdate()
        {
            if (!ForceUpdateScanner.IsRunning) ForceUpdateScanner.Restart();
            if (ForceUpdateScanner.ElapsedMilliseconds < ForceUpdateScanInterval) return;

            Update();
        }

        public static void Update()
        {
            ForceUpdateScanner.Restart();
            
            Unit.ResetUnfriendlyUnits = true;
            Unit.ResetGroupMembers = true;
            
            InCombat = StyxWoW.Me.IsActuallyInCombat;

            MyHp = StyxWoW.Me.HealthPercent;
            CurrentTarget = StyxWoW.Me.CurrentTarget;

            EnemiesInRange = StyxWoW.Me.GotTarget
                ? Unit.EnemiesInRange(8 + (int)StyxWoW.Me.CurrentTarget.CombatReach)
                : EnemiesInRange = Unit.EnemiesInRange(8);

            MeleeRange = StyxWoW.Me.GotTarget
                ? Math.Max(4f, StyxWoW.Me.CombatReach + 1.3333334f + StyxWoW.Me.CurrentTarget.CombatReach)
                : 4f;

            HolyPower = StyxWoW.Me.CurrentHolyPower;
            Forbearance = StyxWoW.Me.HasAura(25771);
            Pvp = StyxWoW.Me.IsInArena || StyxWoW.Me.GroupInfo.IsInBattlegroundParty;
            InParty = StyxWoW.Me.GroupInfo.IsInRaid || StyxWoW.Me.GroupInfo.IsInParty || Pvp;
            LastKnownGroupMemberSize = StyxWoW.Me.GroupInfo.IsInRaid ? StyxWoW.Me.GroupInfo.NumRaidMembers : StyxWoW.Me.GroupInfo.NumPartyMembers;
            Arena = StyxWoW.Me.IsInArena;

            // If we're not in Pvp stop
            if (!Pvp) return;

            HasFocus = StyxWoW.Me.FocusedUnit != null;

            // If we're not using the focusing settings, stop
            if (!Paladin.Settings.PaladinSettings.Instance.AutoFocusUse) return;

            if (FocusedUnit == null && HasFocus)
                FocusedUnit = StyxWoW.Me.FocusedUnit;

            // Crowd Control
        }

        public static bool HasDivinePurpose
        {
            get { return DivinePurpose != null && DivinePurpose.TimeLeft.TotalMilliseconds > 0; }
        }

        public static bool HasShieldOfRighteous
        {
            get { return ShieldOfRighteous != null; }
        }

        public static void UpdateCombat()
        {
            using (StyxWoW.Memory.TemporaryCacheState(true))
            {
                EyeForAnEye = StyxWoW.Me.GetAuraById(205191);
                DivinePurpose = StyxWoW.Me.GetAuraById(223819);
            }
        }

        public static void UpdateCombatProt()
        {
            using (StyxWoW.Memory.TemporaryCacheState(true))
            {
                ShieldOfRighteous = StyxWoW.Me.GetAuraById(132403);
            }
        }

        public static void UpdateCombatHoly()
        {
            using (StyxWoW.Memory.TemporaryCacheState(true))
            {
                // TODO
            }
        }
    }
}
