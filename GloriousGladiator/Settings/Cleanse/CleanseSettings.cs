using Styx.Common;
using Styx.Helpers;
using System.IO;
using Paladin.CRUtilities;
using System.Collections.Generic;
using System;

namespace Paladin.Settings
{
    public class CleanseSettings : Styx.Helpers.Settings
    {
        public static readonly CleanseSettings Instance = new CleanseSettings();

        private CleanseSettings()
            : base(Path.Combine(Utilities.AssemblyDirectory, string.Format(@"Settings/GGWP/Cleanses/CleanseSettings.xml"))) { }

        public Dictionary<int, Tuple<bool, string, string, string>> CleaseDictionary()
        {
            return SettingsUtilities.GetPropertyDictionary(this);
        }

        #region PvP
        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(145206)]
        [SettingName("Aqua Bomb")]
        [Setting, DefaultValue(true)]
        public bool AquaBomb { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(192706)]
        [SettingName("Arcane Bomb")]
        [Setting, DefaultValue(true)]
        public bool ArcaneBomb { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(710)]
        [SettingName("Banish")]
        [Setting, DefaultValue(true)]
        public bool Banish { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(117526)]
        [SettingName("BindingShotStun")]
        [Setting, DefaultValue(true)]
        public bool BindingShotStun { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(105421)]
        [SettingName("BlindingLight")]
        [Setting, DefaultValue(true)]
        public bool BlindingLight { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(207167)]
        [SettingName("BlindingSleet")]
        [Setting, DefaultValue(true)]
        public bool BlindingSleet { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(179057)]
        [SettingName("ChaosNova")]
        [Setting, DefaultValue(true)]
        public bool ChaosNova { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(605)]
        [SettingName("DominateMind")]
        [Setting, DefaultValue(true)]
        public bool DominateMind { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(31661)]
        [SettingName("DragonsBreath")]
        [Setting, DefaultValue(true)]
        public bool DragonsBreath { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(5782)]
        [SettingName("Fear")]
        [Setting, DefaultValue(true)]
        public bool Fear { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(118699)]
        [SettingName("Fear2")]
        [Setting, DefaultValue(true)]
        public bool Fear2 { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(130616)]
        [SettingName("FearGlyphofFear")]
        [Setting, DefaultValue(true)]
        public bool FearGlyphofFear { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(209790)]
        [SettingName("FreezingArrow")]
        [Setting, DefaultValue(true)]
        public bool FreezingArrow { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(3355)]
        [SettingName("FreezingTrap")]
        [Setting, DefaultValue(true)]
        public bool FreezingTrap { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(853)]
        [SettingName("HammerofJustice")]
        [Setting, DefaultValue(true)]
        public bool HammerofJustice { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(51514)]
        [SettingName("Hex")]
        [Setting, DefaultValue(true)]
        public bool Hex { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(211015)]
        [SettingName("HexCockroach")]
        [Setting, DefaultValue(true)]
        public bool HexCockroach { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(210873)]
        [SettingName("HexRaptor")]
        [Setting, DefaultValue(true)]
        public bool HexRaptor { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(211010)]
        [SettingName("HexSnake")]
        [Setting, DefaultValue(true)]
        public bool HexSnake { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(211004)]
        [SettingName("HexSpider")]
        [Setting, DefaultValue(true)]
        public bool HexSpider { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(200196)]
        [SettingName("HolyWordChastiseIncapacitate")]
        [Setting, DefaultValue(true)]
        public bool HolyWordChastiseIncapacitate { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(200200)]
        [SettingName("HolyWordChastiseStun")]
        [Setting, DefaultValue(true)]
        public bool HolyWordChastiseStun { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(5484)]
        [SettingName("HowlofTerror")]
        [Setting, DefaultValue(true)]
        public bool HowlofTerror { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(205630)]
        [SettingName("IllidansGraspPrimary")]
        [Setting, DefaultValue(true)]
        public bool IllidansGraspPrimary { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(208618)]
        [SettingName("IllidansGraspSecondary")]
        [Setting, DefaultValue(true)]
        public bool IllidansGraspSecondary { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(202274)]
        [SettingName("IncendiaryBrew")]
        [Setting, DefaultValue(true)]
        public bool IncendiaryBrew { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(115268)]
        [SettingName("MesmerizeShivarra")]
        [Setting, DefaultValue(true)]
        public bool MesmerizeShivarra { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(200166)]
        [SettingName("Metamorphosis")]
        [Setting, DefaultValue(true)]
        public bool Metamorphosis { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(226943)]
        [SettingName("MindBomb")]
        [Setting, DefaultValue(true)]
        public bool MindBomb { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(6789)]
        [SettingName("MortalCoil")]
        [Setting, DefaultValue(true)]
        public bool MortalCoil { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(118)]
        [SettingName("Polymorph")]
        [Setting, DefaultValue(true)]
        public bool Polymorph { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(197105)]
        [SettingName("Polymorph: Fish")]
        [Setting, DefaultValue(true)]
        public bool PolymorphFish { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(161353)]
        [SettingName("PolymorphBearCub")]
        [Setting, DefaultValue(true)]
        public bool PolymorphBearCub { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(61305)]
        [SettingName("PolymorphBlackCat")]
        [Setting, DefaultValue(true)]
        public bool PolymorphBlackCat { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(161354)]
        [SettingName("PolymorphMonkey")]
        [Setting, DefaultValue(true)]
        public bool PolymorphMonkey { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(161372)]
        [SettingName("PolymorphPeacock")]
        [Setting, DefaultValue(true)]
        public bool PolymorphPeacock { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(161355)]
        [SettingName("PolymorphPenguin")]
        [Setting, DefaultValue(true)]
        public bool PolymorphPenguin { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(28272)]
        [SettingName("PolymorphPig")]
        [Setting, DefaultValue(true)]
        public bool PolymorphPig { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(126819)]
        [SettingName("PolymorphProcupine")]
        [Setting, DefaultValue(true)]
        public bool PolymorphProcupine { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(61721)]
        [SettingName("PolymorphRabbit")]
        [Setting, DefaultValue(true)]
        public bool PolymorphRabbit { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(61780)]
        [SettingName("PolymorphTurkey")]
        [Setting, DefaultValue(true)]
        public bool PolymorphTurkey { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(28271)]
        [SettingName("PolymorphTurtle")]
        [Setting, DefaultValue(true)]
        public bool PolymorphTurtle { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(64044)]
        [SettingName("PsychicHorrorHorrorEffect")]
        [Setting, DefaultValue(true)]
        public bool PsychicHorrorHorrorEffect { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(8122)]
        [SettingName("PsychicScream")]
        [Setting, DefaultValue(true)]
        public bool PsychicScream { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(20066)]
        [SettingName("Repentance")]
        [Setting, DefaultValue(true)]
        public bool Repentance { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(82691)]
        [SettingName("RingofFrost")]
        [Setting, DefaultValue(true)]
        public bool RingofFrost { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(6358)]
        [SettingName("SeductionSuccubus")]
        [Setting, DefaultValue(true)]
        public bool SeductionSuccubus { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(30283)]
        [SettingName("Shadowfury")]
        [Setting, DefaultValue(true)]
        public bool Shadowfury { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(198909)]
        [SettingName("SongofChiji")]
        [Setting, DefaultValue(true)]
        public bool SongofChiji { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(200084)]
        [SettingName("Soul Blade")]
        [Setting, DefaultValue(true)]
        public bool SoulBlade { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(225909)]
        [SettingName("Soul Venom")]
        [Setting, DefaultValue(true)]
        public bool SoulVenom { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(118905)]
        [SettingName("StaticChargeCapacitorTotem")]
        [Setting, DefaultValue(true)]
        public bool StaticChargeCapacitorTotem { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(22703)]
        [SettingName("SummonInferal")]
        [Setting, DefaultValue(true)]
        public bool SummonInferal { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(197262)]
        [SettingName("Taint of the Sea")]
        [Setting, DefaultValue(true)]
        public bool TaintoftheSea { get; set; }

        [SettingCategoryName("Cleanse")]
        [SettingGroupName("PvP")]
        [SettingSpellID(19386)]
        [SettingName("WyvernSting")]
        [Setting, DefaultValue(true)]
        public bool WyvernSting { get; set; }
        #endregion
    }
}
