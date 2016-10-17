using Styx.Common;
using Styx.Helpers;
using System.IO;
using Paladin.Helpers;
using Styx;
using Styx.WoWInternals.WoWObjects;
using System.Windows.Forms;

namespace Paladin.Settings
{
    public class PaladinSettings : Styx.Helpers.Settings
    {
        public static PaladinSettings Instance = new PaladinSettings();

        public PaladinSettings()
            : base(Path.Combine(Utilities.AssemblyDirectory, @"Settings/GGWP/Global_Settings.xml")) { }

        #region Auto attack and targeting
        [Setting, DefaultValue(false)]
        public bool AutoAttack { get; set; }

        [Setting, DefaultValue(false)]
        public bool AutoTarget { get; set; }

        [Setting, DefaultValue(true)]
        public bool AutoAcceptQueue { get; set; }

        [Setting, DefaultValue(true)]
        public bool LosCheck { get; set; }
        #endregion

        #region Burst
        [Setting, DefaultValue(true)]
        public bool BurstUse { get; set; }

        [Setting, DefaultValue(false)]
        public bool BurstOnCooldown { get; set; }

        [Setting, DefaultValue(true)]
        public bool BurstOnBoss { get; set; }

        [Setting, DefaultValue(false)]
        public bool BurstOnTargetBelow { get; set; }

        [Setting, DefaultValue(70)]
        public int BurstOnTargetBelowHp { get; set; }

        [Setting, DefaultValue(Keys.None)]
        public Keys BurstHotkey { get; set; }

        [Setting, DefaultValue(ModifierKeys.NoRepeat)]
        public ModifierKeys BurstModifierKey { get; set; }
        #endregion

        #region Hotkeys
        [Setting, DefaultValue(Keys.None)]
        public Keys DivineSteedHotkey { get; set; }

        [Setting, DefaultValue(ModifierKeys.NoRepeat)]
        public ModifierKeys DivineSteedModifierKey { get; set; }
        #endregion

        #region Cleanse
        [Setting, DefaultValue(true)]
        public bool UseCleanse { get; set; }

        [Setting, DefaultValue(true)]
        public bool UseCleanseGroup { get; set; }
        #endregion

        #region PvPTrinket
        [Setting, DefaultValue(true)]
        public bool UseTrinket { get; set; }
        #endregion

        #region BoP
        [Setting, DefaultValue(true)]
        public bool UseBoP { get; set; }

        [Setting, DefaultValue(true)]
        public bool UseBoPSelf { get; set; }

        [Setting, DefaultValue(30)]
        public int UseBoPHp { get; set; }

        [Setting, DefaultValue(true)]
        public bool UseBoPKarma { get; set; }

        [Setting, DefaultValue(true)]
        public bool UseBoPBurst { get; set; }
        #endregion

        #region Divine Shield
        [Setting, DefaultValue(true)]
        public bool UseDivineShield { get; set; }

        [Setting, DefaultValue(20)]
        public int UseDivineShieldHp { get; set; }
        #endregion

        #region FoL
        [Setting, DefaultValue(true)]
        public bool RetFoLMe { get; set; }

        [Setting, DefaultValue(false)]
        public bool RetFoLOther { get; set; }

        // Hp percent to use FoL
        [Setting, DefaultValue(60)]
        public int RetFoLSelfHp { get; set; }

        // Hp percent to use FoL
        [Setting, DefaultValue(60)]
        public int RetFoLOtherHp { get; set; }

        [Setting, DefaultValue(true)]
        public bool ProtFoLMe { get; set; }

        [Setting, DefaultValue(false)]
        public bool ProtFoLOther { get; set; }

        // Hp percent to use FoL
        [Setting, DefaultValue(60)]
        public int ProtFoLSelfHp { get; set; }

        // Hp percent to use FoL
        [Setting, DefaultValue(60)]
        public int ProtFoLOtherHp { get; set; }
        #endregion

        #region LoH
        [Setting, DefaultValue(false)]
        public bool RetLoHUse { get; set; }

        [Setting, DefaultValue(true)]
        public bool RetLoHUseOnSelf { get; set; }

        [Setting, DefaultValue(20)]
        public int RetLoHUseHp { get; set; }

        [Setting, DefaultValue(false)]
        public bool ProtLoHUse { get; set; }

        [Setting, DefaultValue(true)]
        public bool ProtLoHUseOnSelf { get; set; }

        [Setting, DefaultValue(20)]
        public int ProtLoHUseHp { get; set; }
        #endregion

        #region Blessing of Freedom
        // Use HoF on group members
        [Setting, DefaultValue(true)]
        public bool UseBoF { get; set; }

        [Setting, DefaultValue(true)]
        public bool UseBoFGroup { get; set; }

        [Setting, DefaultValue(true)]
        public bool UseBoFDPS { get; set; }

        [Setting, DefaultValue(true)]
        public bool UseBoFHeal { get; set; }

        [Setting, DefaultValue(false)]
        public bool UseBoFTank { get; set; }
        #endregion

        #region Divine Storm
        // Use Divine Storm >= enemies
        [Setting, DefaultValue(3)]
        public int DivineStormEnemies { get; set; }

        [Setting, DefaultValue(3)]
        public int DivineStormHolyPower { get; set; }
        #endregion

        #region Hammer of Justice
        [Setting, DefaultValue(true)]
        public bool HoJUse { get; set; }

        [Setting, DefaultValue(false)]
        public bool HoJUseOnCooldown { get; set; }
        
        [Setting, DefaultValue(true)]
        public bool HoJFocusHotkeyUse { get; set; }

        [Setting, DefaultValue(true)]
        public bool HoJInterrupt { get; set; }

        [Setting, DefaultValue(true)]
        public bool HoJInterruptHeal { get; set; }

        [Setting, DefaultValue(true)]
        public bool HoJInterruptCC { get; set; }

        [Setting, DefaultValue(60)]
        public int HoJTargetBelow { get; set; }

        [Setting, DefaultValue(Keys.None)]
        public Keys HoJHotKey { get; set; }

        [Setting, DefaultValue(ModifierKeys.NoRepeat)]
        public ModifierKeys HoJModifierKey { get; set; }

        [Setting, DefaultValue(Keys.None)]
        public Keys HoJHealerHotKey { get; set; }

        [Setting, DefaultValue(ModifierKeys.NoRepeat)]
        public ModifierKeys HoJHealerModifierKey { get; set; }
        #endregion

        #region Rebuke
        [Setting, DefaultValue(true)]
        public bool RebukeUse { get; set; }

        [Setting, DefaultValue(true)]
        public bool RebukeRandomTimerUse { get; set; }

        [Setting, DefaultValue(40)]
        public double RebukeRandomTimerMin { get; set; }

        [Setting, DefaultValue(75)]
        public double RebukeRandomTimerMax { get; set; }
        #endregion

        #region Word of Glory
        [Setting, DefaultValue(true)]
        public bool WoGUse { get; set; }

        [Setting, DefaultValue(true)]
        public bool WoGHealParty { get; set; }

        [Setting, DefaultValue(70)]
        public int WoGHealth { get; set; }

        [Setting, DefaultValue(50)]
        public int WoGPartyHealth { get; set; }
        #endregion

        #region Justicars Vengeance
        [Setting, DefaultValue(70)]
        public int JusticarsVengeanceLife { get; set; }
        #endregion

        #region Holy Wrath
        [Setting, DefaultValue(40)]
        public int HolyWrathLife { get; set; }

        [Setting, DefaultValue(true)]
        public bool IntelligentHolyWrath { get; set; }
        #endregion

        [Setting, DefaultValue(true)]
        public bool UseHandOfHindrance { get; set; }

        [Setting, DefaultValue(true)]
        public bool AutoCastBlessings { get; set; }

        [Setting, DefaultValue(70)]
        public int EyeForAnEyeHP { get; set; }

        [Setting, DefaultValue(70)]
        public int HammerOfReckoningHealth { get; set; }        

        #region Pvp
        [Setting, DefaultValue(true)]
        public bool AutoFocusUse { get; set; }

        [Setting, DefaultValue(true)]
        public bool PvpDestroyTotems { get; set; }

        [Setting, DefaultValue(true)]
        public bool PvpIgnoreCCTarget { get; set; }
        #endregion

        #region Racials
        #region Arcane Torrent
        [Setting, DefaultValue(true)]
        public bool ArcaneTorrentUse { get; set; }

        [Setting, DefaultValue(true)]
        public bool ArcaneTorrentOnlyInterruptHealing { get; set; }
        #endregion

        [Setting, DefaultValue(true)]
        public bool RacialUse { get; set; }

        #region Every Man for Himself
        [Setting, DefaultValue(true)]
        public bool EveryManForHimselfUse { get; set; }
        #endregion

        #region Gift of the Naaru
        [Setting, DefaultValue(true)]
        public bool GiftOfTheNaaruUse { get; set; }

        [Setting, DefaultValue(true)]
        public bool GiftOfTheNaaruHealGroup { get; set; }

        [Setting, DefaultValue(60)]
        public int GiftOfTheNaaruHealHp { get; set; }
        #endregion

        #region Stoneform
        [Setting, DefaultValue(true)]
        public bool StoneformUse { get; set; }

        [Setting, DefaultValue(60)]
        public int StoneformUseHp { get; set; }

        [Setting, DefaultValue(true)]
        public bool StoneformUseOnlyToClearDot { get; set; }
        #endregion

        #region War Stomp
        [Setting, DefaultValue(true)]
        public bool WarStompUse { get; set; }

        [Setting, DefaultValue(2)]
        public int WarStompEnemiesToUse { get; set; }

        #endregion
        #endregion

        #region Resting
        [Setting, DefaultValue(true)]
        public bool RestingEatFood { get; set; }

        [Setting, DefaultValue(true)]
        public bool RestingDrinkWater { get; set; }

        [Setting, DefaultValue(60)]
        public int RestingEatFoodHp { get; set; }

        [Setting, DefaultValue(20)]
        public int RestingDrinkWaterMp { get; set; }
        #endregion

        #region Movement and Facing
        [Setting, DefaultValue(false)]
        public bool EnableMovement { get; set; }

        [Setting, DefaultValue(false)]
        public bool EnableFacing { get; set; }
        #endregion

        #region Healthstones
        [Setting, DefaultValue(true)]
        public bool HealthstoneUse { get; set; }

        [Setting, DefaultValue(50)]
        public int HealthstoneHp { get; set; }
        #endregion

        #region Shield of Vengeance
        [Setting, DefaultValue(true)]
        public bool UseShieldOfVengeance { get; set; }

        [Setting, DefaultValue(50)]
        public int ShieldOfVengeanceLife { get; set; }

        [Setting, DefaultValue(true)]
        public bool ShieldOfVengeanceIncomingDamage { get; set; }
        #endregion

        [Setting, DefaultValue(true)]
        public bool UseRepentance { get; set; }

        #region Protection
        [Setting, DefaultValue(true)]
        public bool UseLightOfTheProtector { get; set; }

        [Setting, DefaultValue(70)]
        public int LightOfTheProtector { get; set; }

        [Setting, DefaultValue(30)]
        public int GuardianOfAncientKings { get; set; }

        [Setting, DefaultValue(40)]
        public int ArdentDefender { get; set; }

        [Setting, DefaultValue(70)]
        public int LightOfTheProtectorOther { get; set; }

        [Setting, DefaultValue(true)]
        public bool UseBlindingLight { get; set; }

        [Setting, DefaultValue(3)]
        public int BlindingLightTargets { get; set; }

        [Setting, DefaultValue(true)]
        public bool UseEyeOfTyr { get; set; }

        [Setting, DefaultValue(70)]
        public int EyeOfTyrHP { get; set; }
        #endregion

        #region Holy
        [Setting, DefaultValue(70)]
        public int HolyFoL { get; set; }

        [Setting, DefaultValue(20)]
        public int HolyLoH { get; set; }

        [Setting, DefaultValue(80)]
        public int HolyShock { get; set; }

        [Setting, DefaultValue(90)]
        public int HolyLight { get; set; }

        [Setting, DefaultValue(70)]
        public int BestowFaith { get; set; }

        [Setting, DefaultValue(2)]
        public int LightOfDawnTargets { get; set; }

        [Setting, DefaultValue(80)]
        public int LightOfDawnHP { get; set; }

        [Setting, DefaultValue(70)]
        public int DivineProtectionHealth { get; set; }

        
        #endregion


    }
}