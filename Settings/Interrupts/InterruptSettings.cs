using Styx.Common;
using Styx.Helpers;
using System.IO;
using Paladin.CRUtilities;
using System.Collections.Generic;
using System;

namespace Paladin.Settings
{
    public class InterruptSettings : Styx.Helpers.Settings
    {
        public static readonly InterruptSettings Instance = new InterruptSettings();

        private InterruptSettings()
            : base(Path.Combine(Utilities.AssemblyDirectory, string.Format(@"Settings/GGWP/Interrupts/InterruptSettings.xml"))) { }

        public Dictionary<int, Tuple<bool, string, string, string>> InterruptDictionary()
        {
            return SettingsUtilities.GetPropertyDictionary(this);
        }
        
        #region PVP

        #region Mage
        [SettingCategoryName("PVP")]
        [SettingGroupName("Mage")]
        [SettingName("Evocation")]
        [SettingSpellID(12051)]
        [Setting, DefaultValue(true)]
        public bool Evocation { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Mage")]
        [SettingName("Frostbolt")]
        [SettingSpellID(116)]
        [Setting, DefaultValue(false)]
        public bool Frostbolt { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Mage")]
        [SettingName("Frost Bomb")]
        [SettingSpellID(112948)]
        [Setting, DefaultValue(true)]
        public bool FrostBomb { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Mage")]
        [SettingName("Blizzard")]
        [SettingSpellID(190356)]
        [Setting, DefaultValue(true)]
        public bool Blizzard { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Mage")]
        [SettingName("Fireball")]
        [SettingSpellID(133)]
        [Setting, DefaultValue(true)]
        public bool Fireball { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Mage")]
        [SettingName("Pyroblast")]
        [SettingSpellID(11366)]
        [Setting, DefaultValue(true)]
        public bool Pyroblast { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Mage")]
        [SettingName("Arcane Blast")]
        [SettingSpellID(30451)]
        [Setting, DefaultValue(true)]
        public bool ArcaneBlast { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Mage")]
        [SettingName("Arcane Missles")]
        [SettingSpellID(5143)]
        [Setting, DefaultValue(true)]
        public bool ArcaneMissles { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Mage")]
        [SettingName("Polymorph")]
        [SettingSpellID(118)]
        [Setting, DefaultValue(true)]
        public bool Polymorph { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Mage")]
        [SettingName("Glacial Spike")]
        [SettingSpellID(199786)]
        [Setting, DefaultValue(true)]
        public bool GlacialSpike { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Mage")]
        [SettingName("Glacial Spike")]
        [SettingSpellID(228600)]
        [Setting, DefaultValue(true)]
        public bool GlacialSpikeTalent { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Mage")]
        [SettingName("Polymorph: Penguin")]
        [SettingSpellID(161355)]
        [Setting, DefaultValue(true)]
        public bool PolymorphPenguin { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Mage")]
        [SettingName("Polymorph: Pig")]
        [SettingSpellID(126819)]
        [Setting, DefaultValue(true)]
        public bool PolymorphPig { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Mage")]
        [SettingName("Polymorph: Monkey")]
        [SettingSpellID(161354)]
        [Setting, DefaultValue(true)]
        public bool PolymorphMonkey { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Mage")]
        [SettingName("Polymorph: Polar Bear Cub")]
        [SettingSpellID(161353)]
        [Setting, DefaultValue(true)]
        public bool PolymorphPolarBearCub { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Mage")]
        [SettingName("Polymorph: Rabbit")]
        [SettingSpellID(61721)]
        [Setting, DefaultValue(true)]
        public bool PolymorphRabbit { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Mage")]
        [SettingName("Polymorph: Turtle")]
        [SettingSpellID(161372)]
        [Setting, DefaultValue(true)]
        public bool PolymorphTurtle { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Mage")]
        [SettingName("Polymorph: Turkey")]
        [SettingSpellID(61780)]
        [Setting, DefaultValue(true)]
        public bool PolymorphTurkey { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Mage")]
        [SettingName("Polymorph: Black Cat")]
        [SettingSpellID(61305)]
        [Setting, DefaultValue(true)]
        public bool PolymorphBlackCat { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Mage")]
        [SettingName("Polymorph: Turtle 2")]
        [SettingSpellID(28271)]
        [Setting, DefaultValue(true)]
        public bool PolymorphTurtle2 { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Mage")]
        [SettingName("Polymorph: Pig 2")]
        [SettingSpellID(28272)]
        [Setting, DefaultValue(true)]
        public bool PolymorphPig2 { get; set; }

        #endregion

        #region Warlock
        [SettingCategoryName("PVP")]
        [SettingGroupName("Warlock")]
        [SettingName("Banish")]
        [SettingSpellID(710)]
        [Setting, DefaultValue(true)]
        public bool Banish { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Warlock")]
        [SettingName("Fear")]
        [SettingSpellID(5782)]
        [Setting, DefaultValue(true)]
        public bool Fear { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Warlock")]
        [SettingName("Haunt")]
        [SettingSpellID(48181)]
        [Setting, DefaultValue(true)]
        public bool Haunt { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Warlock")]
        [SettingName("Chaos Bolt")]
        [SettingSpellID(116858)]
        [Setting, DefaultValue(true)]
        public bool ChaosBolt { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Warlock")]
        [SettingName("Incinerate")]
        [SettingSpellID(29722)]
        [Setting, DefaultValue(true)]
        public bool Incinerate { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Warlock")]
        [SettingName("Immolate")]
        [SettingSpellID(348)]
        [Setting, DefaultValue(true)]
        public bool Immolate { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Warlock")]
        [SettingName("Rain of Fire")]
        [SettingSpellID(5740)]
        [Setting, DefaultValue(true)]
        public bool RainOfFire { get; set; }
        
        [SettingCategoryName("PVP")]
        [SettingGroupName("Warlock")]
        [SettingName("Drain Life")]
        [SettingSpellID(689)]
        [Setting, DefaultValue(true)]
        public bool DrainLife { get; set; }
        #endregion

        #region Priest
        [SettingCategoryName("PVP")]
        [SettingGroupName("Priest")]
        [SettingName("Dominate Mind")]
        [SettingSpellID(605)]
        [Setting, DefaultValue(true)]
        public bool DominateMind { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Priest")]
        [SettingName("Penance")]
        [SettingSpellID(47540)]
        [Setting, DefaultValue(true)]
        public bool Penance { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Priest")]
        [SettingName("PrayerOfHealing")]
        [SettingSpellID(596)]
        [Setting, DefaultValue(true)]
        public bool PrayerOfHealing { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Priest")]
        [SettingName("Heal")]
        [SettingSpellID(2060)]
        [Setting, DefaultValue(true)]
        public bool Heal { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Priest")]
        [SettingName("Charity of Will")]
        [SettingSpellID(152118)]
        [Setting, DefaultValue(true)]
        public bool CharityOfWill { get; set; }
        
        [SettingCategoryName("PVP")]
        [SettingGroupName("Priest")]
        [SettingName("Binding Heal")]
        [SettingSpellID(32546)]
        [Setting, DefaultValue(true)]
        public bool BindingHeal { get; set; }
        
        [SettingCategoryName("PVP")]
        [SettingGroupName("Priest")]
        [SettingName("Halo")]
        [SettingSpellID(120517)]
        [Setting, DefaultValue(true)]
        public bool Halo { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Priest")]
        [SettingName("Void Entropy")]
        [SettingSpellID(155361)]
        [Setting, DefaultValue(true)]
        public bool VoidEntropy { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Priest")]
        [SettingName("Mind Spike")]
        [SettingSpellID(73510)]
        [Setting, DefaultValue(true)]
        public bool PriestMindSpike { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Priest")]
        [SettingName("Vampiric Touch")]
        [SettingSpellID(34914)]
        [Setting, DefaultValue(true)]
        public bool VampiricTouch { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Priest")]
        [SettingName("Mind Blast")]
        [SettingSpellID(8092)]
        [Setting, DefaultValue(true)]
        public bool MindBlast { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Priest")]
        [SettingName("Mind Flay")]
        [SettingSpellID(15407)]
        [Setting, DefaultValue(true)]
        public bool MindFlay { get; set; }
        
        #endregion

        #region Druid
        [SettingCategoryName("PVP")]
        [SettingGroupName("Druid")]
        [SettingName("Cyclone")]
        [SettingSpellID(33786)]
        [Setting, DefaultValue(true)]
        public bool Cyclone { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Druid")]
        [SettingName("Regrowth")]
        [SettingSpellID(8936)]
        [Setting, DefaultValue(true)]
        public bool Regrowth { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Druid")]
        [SettingName("Wild Growth")]
        [SettingSpellID(48438)]
        [Setting, DefaultValue(true)]
        public bool WildGrowth { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Druid")]
        [SettingName("Wrath")]
        [SettingSpellID(5176)]
        [Setting, DefaultValue(true)]
        public bool Wrath { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Druid")]
        [SettingName("Starfire")]
        [SettingSpellID(2912)]
        [Setting, DefaultValue(true)]
        public bool Starfire { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Druid")]
        [SettingName("Starsurge")]
        [SettingSpellID(78674)]
        [Setting, DefaultValue(true)]
        public bool Starsurge { get; set; }

        #endregion

        #region Shaman
        [SettingCategoryName("PVP")]
        [SettingGroupName("Shaman")]
        [SettingName("Hex")]
        [SettingSpellID(51514)]
        [Setting, DefaultValue(true)]
        public bool Hex { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Shaman")]
        [SettingName("Healing Wave")]
        [SettingSpellID(77472)]
        [Setting, DefaultValue(true)]
        public bool HealingWave { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Shaman")]
        [SettingName("Healing Surge")]
        [SettingSpellID(8004)]
        [Setting, DefaultValue(true)]
        public bool HealingSurge { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Shaman")]
        [SettingName("Chain Heal")]
        [SettingSpellID(1064)]
        [Setting, DefaultValue(true)]
        public bool ChainHeal { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Shaman")]
        [SettingName("Healing Rain")]
        [SettingSpellID(73920)]
        [Setting, DefaultValue(true)]
        public bool HealingRain { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Shaman")]
        [SettingName("Lightning Bolt")]
        [SettingSpellID(403)]
        [Setting, DefaultValue(true)]
        public bool LightningBolt { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Shaman")]
        [SettingName("Lava Burst")]
        [SettingSpellID(51505)]
        [Setting, DefaultValue(true)]
        public bool ShamanLavaBurst { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Shaman")]
        [SettingName("Chain Lightning")]
        [SettingSpellID(421)]
        [Setting, DefaultValue(true)]
        public bool ChainLightning { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Shaman")]
        [SettingName("Earthquake")]
        [SettingSpellID(61882)]
        [Setting, DefaultValue(true)]
        public bool Earthquake { get; set; }
        #endregion

        #region Monk
        [SettingCategoryName("PVP")]
        [SettingGroupName("Monk")]
        [SettingName("Soothing Mist")]
        [SettingSpellID(115175)]
        [Setting, DefaultValue(true)]
        public bool SoothingMist { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Monk")]
        [SettingName("Enveloping Mist")]
        [SettingSpellID(124682)]
        [Setting, DefaultValue(true)]
        public bool EnvelopingMist { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Monk")]
        [SettingName("Surging Mist")]
        [SettingSpellID(116694)]
        [Setting, DefaultValue(true)]
        public bool SurgingMist { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Monk")]
        [SettingName("Uplift")]
        [SettingSpellID(116670)]
        [Setting, DefaultValue(true)]
        public bool Uplift { get; set; }
        #endregion

        #region Paladin
        [SettingCategoryName("PVP")]
        [SettingGroupName("Paladin")]
        [SettingName("Repentance")]
        [SettingSpellID(20066)]
        [Setting, DefaultValue(true)]
        public bool Repentance { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Paladin")]
        [SettingName("Holy Light")]
        [SettingSpellID(82326)]
        [Setting, DefaultValue(true)]
        public bool HolyLight { get; set; }

        [SettingCategoryName("PVP")]
        [SettingGroupName("Paladin")]
        [SettingName("Flash of Light")]
        [SettingSpellID(19750)]
        [Setting, DefaultValue(true)]
        public bool FlashOfLight { get; set; }
        
        [SettingCategoryName("PVP")]
        [SettingGroupName("Paladin")]
        [SettingName("Eternal Flame")]
        [SettingSpellID(114163)]
        [Setting, DefaultValue(true)]
        public bool EternalFlame { get; set; }
        
        [SettingCategoryName("PVP")]
        [SettingGroupName("Paladin")]
        [SettingName("Light of Dawn")]
        [SettingSpellID(85222)]
        [Setting, DefaultValue(true)]
        public bool LightOfDawn { get; set; }
        #endregion

        #endregion
    }
}
