using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paladin.Helpers
{
    public static class Lists
    {
        public static List<int> CrowdControlSpells = new List<int>()
        {
            // Magic
            49203, // Hungering Cold
            9484, // Shackle Undead
            87204, // Sin and Punishment
            6358, // Seduction (pet)
            30283, // Shadowfury
            2637, // Hibernate
            605, // Mind Control
            8122, // Psychic Scream
            64044, // Psychic Horror
            5782, // Fear
            1513, // Scare Beast
            5484, // Howl of Terror
            44572, // Deep Freeze
            82691, // Ring of Frost
            31661, // Dragon's Breath
            118, // Poly
            61305, // Poly
            28272, // Poly
            61780, // Poly
            28271, // Poly
            853, // Hammer of Justice
            20066, // Repentance
            6789, // Death Coil
            12355, // Impact
            76780, // Bind Elemental
            710, // Banish
            89605, // Aura of Foreboding
            89604, // Aura of Foreboding
            56626, // Sting (pet)

            // Curse
            51514, // Hex

            // Poison
            19386, // Wyvern Sting

            // Incapacitated
            33786, // Cyclone
            2094, // Blind
            5246, // Intimidating Shout
            6770, // Sap
            1833, // Cheap Shot
            408, // Kidney Shot
            5211, // Bash
            58861, // Bash (pet)
            22570, // Maim
            37506, // Scatter Shot
            89766, // Axe Toss (pet)
            50519, // Sonic Blast (pet)
            87194, // Paralysis
            87193 // Paralysis
        };

        public static List<int> CrowdControlSpellsWeCantAttackThrough = new List<int>()
        {
            // Magic
            9484, // Shackle Undead
            87204, // Sin and Punishment
            6358, // Seduction (pet)
            2637, // Hibernate
            605, // Mind Control
            8122, // Psychic Scream
            64044, // Psychic Horror
            5782, // Fear
            1513, // Scare Beast
            5484, // Howl of Terror
            44572, // Deep Freeze
            82691, // Ring of Frost
            31661, // Dragon's Breath
            118, // Poly
            61305, // Poly
            28272, // Poly
            61780, // Poly
            28271, // Poly
            20066, // Repentance
            6789, // Death Coil
            12355, // Impact
            76780, // Bind Elemental
            710, // Banish
            89605, // Aura of Foreboding
            89604, // Aura of Foreboding

            // Curse
            51514, // Hex

            // Poison
            19386, // Wyvern Sting

            // Incapacitated
            33786, // Cyclone
            2094, // Blind
            5246, // Intimidating Shout
            6770, // Sap
            50519, // Sonic Blast (pet)
            87194, // Paralysis
            87193 // Paralysis
        };

        public static List<int> CrowdControlSpellsWeCanAttackThrough = new List<int>()
        {
            // Magic
            49203, // Hungering Cold
            30283, // Shadowfury
            853, // Hammer of Justice
            56626, // Sting (pet)

            // Incapacitated
            1833, // Cheap Shot
            408, // Kidney Shot
            5211, // Bash
            58861, // Bash (pet)
            22570, // Maim
            89766, // Axe Toss (pet)
        };
    }
}
