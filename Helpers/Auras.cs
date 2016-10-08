using System;
using System.Collections.Generic;
using Styx;
using Styx.WoWInternals;
using System.Linq;
using Styx.WoWInternals.WoWObjects;

namespace Paladin.Helpers
{
    public static class Auras
    {
        public static bool ResetAuraCache = false;
        private static Dictionary<WoWGuid, WoWAuraCollection> _auraCache;
        public static WoWAuraCollection AuraCache(this WoWUnit unit)
        {
            if (_auraCache == null || ResetAuraCache)
            {
                _auraCache = new Dictionary<WoWGuid, WoWAuraCollection>();
            }

            if (_auraCache.ContainsKey(unit.Guid))
                return _auraCache[unit.Guid];

            _auraCache[unit.Guid] = unit.GetAllAuras();
            return _auraCache[unit.Guid];
        }

        public static bool HasAnyAura(this WoWUnit unit, IEnumerable<int> ids)
        {
            var auras = unit.AuraCache();
            var hashes = new HashSet<int>(ids);
            return auras.Any(a => hashes.Contains(a.SpellId));
        }

        public static WoWAura GetAuraWithMechanic(this WoWUnit unit, params WoWSpellMechanic[] mechanics)
        {
            if (unit == null) return null;

            var auras = unit.AuraCache();
            return auras.FirstOrDefault(a => mechanics.Contains(a.Spell.Mechanic));
        }

        public static bool HasAuraWithMechanic(this WoWUnit unit, params WoWSpellMechanic[] mechanics)
        {
            if (unit == null)
                return false;

            var auras = unit.AuraCache();
            return auras.Any(a => mechanics.Contains(a.Spell.Mechanic));
        }

        public static int AuraWithMechanicCount(this WoWUnit unit, params WoWSpellMechanic[] mechanics)
        {
            if (unit == null)
                return 0;

            var auras = unit.AuraCache();
            return auras.Count(a => mechanics.Contains(a.Spell.Mechanic));
        }

        public static TimeSpan AuraTimeLeft(this WoWUnit unit, string auraName)
        {
            if (unit == null)
                return TimeSpan.Zero;

            var aura = unit.AuraCache().FirstOrDefault(a => a.Name == auraName && a.TimeLeft > TimeSpan.Zero);

            return (aura == null) ? TimeSpan.Zero : aura.TimeLeft;
        }

        public static TimeSpan AuraTimeLeft(this WoWUnit unit, int auraId)
        {
            if (unit == null)
                return TimeSpan.Zero;

            var aura = unit.AuraCache().FirstOrDefault(a => a.SpellId == auraId && a.TimeLeft > TimeSpan.Zero);

            return (aura == null) ? TimeSpan.Zero : aura.TimeLeft;
        }

        public static WoWAura GetAura(uint auraId)
        {
            return StyxWoW.Me.AuraCache().FirstOrDefault(u => u.SpellId == auraId && u.TimeLeft.TotalSeconds > 0);
        }

        public static uint GetAuraStacks(this WoWUnit unit, int auraId)
        {
            if (unit == null)
                return 0;

            var aura = unit.AuraCache().FirstOrDefault(a => a.SpellId == auraId && a.TimeLeft > TimeSpan.Zero);

            return (aura == null) ? 0 : aura.StackCount;
        }

        private static readonly HashSet<int> Stats = new HashSet<int> {
            117666,     //  Legacy of the Emperor
            1126,       //  Mark of The Wild
            20217,      //  Blessing Of Kings
            90363,      //  Embrace of the Shale Spider
        };


        private static readonly HashSet<int> Mastery = new HashSet<int> {
            116956,     //  Grace of Air
            19740,      //  Blessing of Might
            93435,      //  Roar of Courage
            128997,     //  Spirit Beast Blessing
        };

        public static bool HasMasteryBuff(this WoWUnit unit)
        {
            return unit.AuraCache().Any(u => Mastery.Contains(u.SpellId));
        }

        public static bool HasStatsBuff(this WoWUnit unit)
        {
            return unit.AuraCache().Any(u => Stats.Contains(u.SpellId));
        }

        public static bool HasForbearance(this WoWUnit unit)
        {
            return unit.HasAura(25771);
        }

        private static bool HasAuraWithEffect(this WoWUnit unit, params WoWApplyAuraType[] applyType)
        {
            var hashes = new HashSet<WoWApplyAuraType>(applyType);
            return unit.AuraCache().Any(a => a.Spell != null && a.Spell.SpellEffects.Any(se => hashes.Contains(se.AuraType)));
        }

        public static bool IsCrowdControlled(this WoWUnit unit)
        {
            return unit.Stunned ||
                   unit.Rooted ||
                   unit.Fleeing ||
                   unit.HasAuraWithEffect(WoWApplyAuraType.ModConfuse,
                                           WoWApplyAuraType.ModCharm,
                                           WoWApplyAuraType.ModFear,
                                           WoWApplyAuraType.ModPossess,
                                           WoWApplyAuraType.ModRoot,
                                           WoWApplyAuraType.ModStun);
        }

        public static List<int> Defensives = new List<int>()
            {
                45438, // Ice Block
                19263, // Deterence
                871, // Shield Wall
                642, // Divine Shield
                33206 // Pain Suppression
            };
    }
}
