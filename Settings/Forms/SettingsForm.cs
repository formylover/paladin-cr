using System;
using System.Windows.Forms;

using Styx.Common;
using Paladin.Settings;

namespace Paladin.Settings.Forms
{
    public partial class SettingsForm : Form
    {
        #region Accessors
        private PaladinSettings _settings;
        private PaladinSettings Settings
        {
            get
            {
                if (_settings == null)
                {
                    _settings = PaladinSettings.Instance;
                }
                return _settings;
            }
            set
            {
                _settings = value;
            }
        }
        #endregion

        public SettingsForm(PaladinSettings _settings)
        {
            InitializeComponent();
            InitializeDropdowns();

            Settings = _settings;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            LoadSettings();

            versionLabel.Text = string.Format("Local Version: {0}, Remote: {1}", Helpers.Version.CurrentLocalVersion, Helpers.Version.CurrentRemoteVersion);
            changelogText.Text = Helpers.Version.Changelog;
        }

        #region Settings Loading
        private void LoadSettings()
        {

            #region General
            #region Automation
            autoAttackCheckbox.Checked = Settings.AutoAttack;
            autoTargetCheckbox.Checked = Settings.AutoTarget;
            movementCheckbox.Checked = Settings.EnableMovement;
            facingCheckbox.Checked = Settings.EnableFacing;
            autoFocusCheckbox.Checked = Settings.AutoFocusUse;

            autoAcceptQueuePopCheckbox.Checked = Settings.AutoAcceptQueue;
            #endregion

            #region Burst
            useBurstCheckbox.Checked = Settings.BurstUse;
            burstOnCooldownCheckbox.Checked = Settings.BurstOnCooldown;
            burstOnBossCheckbox.Checked = Settings.BurstOnBoss;
            burstOnTargetBelowCheckbox.Checked = Settings.BurstOnTargetBelow;
            burstHealthBelowInput.Value = Settings.BurstOnTargetBelowHp;

            // TODO hotkeys
            #endregion
            #endregion

            #region PvP Settings
            useRacialsCheckbox.Checked = Settings.RacialUse;
            usePvpTrinketCheckbox.Checked = Settings.UseTrinket;
            useHealthstoneCheckbox.Checked = Settings.HealthstoneUse;
            useHealthstoneInput.Value = Settings.HealthstoneHp;

            ignoreCCTargetCheckbox.Checked = Settings.PvpIgnoreCCTarget;

            useRebukeCheckbox.Checked = Settings.RebukeUse;
            delayKickCheckbox.Checked = Settings.RebukeRandomTimerUse;
            kickMinInput.Value = (int)Settings.RebukeRandomTimerMin;
            kickMaxInput.Value = (int)Settings.RebukeRandomTimerMax;
            useTotemStompCheckbox.Checked = Settings.PvpDestroyTotems;
            #endregion

            #region Defensive
            blessingOfProtectionCheckbox.Checked = Settings.UseBoP;
            blessingOfProtectionMeCheckbox.Checked = Settings.UseBoPSelf;
            blessingOfProtectionKarmaCheckbox.Checked = Settings.UseBoPKarma;
            blessingOfProtectionHpInput.Value = Settings.UseBoPHp;

            useDivineShieldCheckbox.Checked = Settings.UseDivineShield;
            divineShieldHpInput.Value = Settings.UseDivineShieldHp;

            useBlessingOfProtectionOnBurstCheckbox.Checked = Settings.UseBoPBurst;
            #endregion

            #region Offensive
            useBlessingOfFreedomMeCheckbox.Checked = Settings.UseBoF;
            useBlessingOfFreedomGroupCheckbox.Checked = Settings.UseBoFGroup;
            useBlessingOfFreedomTankCheckbox.Checked = Settings.UseBoFTank;
            useBlessingOfFreedomHealCheckbox.Checked = Settings.UseBoFHeal;
            useBlessingOfFreedomDpsCheckbox.Checked = Settings.UseBoFDPS;

            useHammerOfJusticeCheckbox.Checked = Settings.HoJUse;
            hammerOfJusticeInterruptCheckbox.Checked = Settings.HoJInterrupt;
            hammerOfJusticeInterruptCCCheckbox.Checked = Settings.HoJInterruptCC;
            hammerOfJusticeInterruptHealCheckbox.Checked = Settings.HoJInterruptHeal;
            hammerOfJusticeTargetBelowInput.Value = Settings.HoJTargetBelow;
            hammerOfJusticeOnCooldownCheckbox.Checked = Settings.HoJUseOnCooldown;
            #endregion

            useBlindingLightCheckbox.Checked = Settings.UseBlindingLight;
            blindingLightsTargetsInput.Value = Settings.BlindingLightTargets;

            #region Retribution
            useShieldOfVengeanceCheckbox.Checked = Settings.UseShieldOfVengeance;
            shieldOfVengeanceHpInput.Value = Settings.ShieldOfVengeanceLife;
            shieldOfVengeanceIncomingCheckbox.Checked = Settings.ShieldOfVengeanceIncomingDamage;

            divineStormEnemyCountInput.Value = Settings.DivineStormEnemies;
            divineStormHolyPowerInput.Value = Settings.DivineStormHolyPower;

            holyWrathHealthPercentInput.Value = Settings.HolyWrathLife;
            intelligentHolyWrathUsageCheckbox.Checked = Settings.IntelligentHolyWrath;

            handOfHindranceCheckbox.Checked = Settings.UseHandOfHindrance;

            justicarsVengeanceInput.Value = Settings.JusticarsVengeanceLife;

            #region Healing
            retUseFlashOfLightMeCheckbox.Checked = Settings.RetFoLMe;
            retFlashOfLightMeInput.Value = Settings.RetFoLSelfHp;
            retUseFlashOfLightOtherCheckbox.Checked = Settings.RetFoLOther;
            retFlashOfLightOtherInput.Value = Settings.RetFoLOtherHp;

            retLayOnHandsHpInput.Value = Settings.RetLoHUseHp;
            retUseLayOnHandsCheckbox.Checked = Settings.RetLoHUseOnSelf;
            retUseLayOnHandsOnGroupCheckbox.Checked = Settings.RetLoHUse;

            useWordOfGloryCheckbox.Checked = Settings.WoGUse;
            eyeForAnEyeInput.Value = Settings.EyeForAnEyeHP;
            #endregion
            #endregion
        }

        private void SaveSettings()
        {
            #region Hotkeys
            Settings.BurstModifierKey = GetSelectedModifierKey(burstModifierKeySelect);
            Settings.BurstHotkey = GetSelectedKey(burstKeySelect);

            Settings.HoJModifierKey = GetSelectedModifierKey(hammerOfJusticeModifierSelect);
            Settings.HoJHotKey = GetSelectedKey(hammerOfJusticeKeySelect);

            Settings.HoJHealerModifierKey = GetSelectedModifierKey(hammerOfJusticeHealerModifierSelect);
            Settings.HoJHealerHotKey = GetSelectedKey(hammerOfJusticeHealerKeySelect);

            #endregion

            #region General
            #region Automation
            Settings.AutoAttack = autoAttackCheckbox.Checked;
            Settings.AutoTarget = autoTargetCheckbox.Checked;
            Settings.EnableMovement = movementCheckbox.Checked;
            Settings.EnableFacing = facingCheckbox.Checked;
            Settings.AutoFocusUse = autoFocusCheckbox.Checked;

            Settings.AutoAcceptQueue = autoAcceptQueuePopCheckbox.Checked;
            #endregion

            #region Burst
            Settings.BurstUse = useBurstCheckbox.Checked;
            Settings.BurstOnCooldown = burstOnCooldownCheckbox.Checked;
            Settings.BurstOnBoss = burstOnBossCheckbox.Checked;
            Settings.BurstOnTargetBelow = burstOnTargetBelowCheckbox.Checked;
            Settings.BurstOnTargetBelowHp = (int)burstHealthBelowInput.Value;

            // TODO hotkeys
            #endregion
            #endregion

            #region PvP Settings
            Settings.RacialUse = useRacialsCheckbox.Checked;
            Settings.UseTrinket = usePvpTrinketCheckbox.Checked;
            Settings.HealthstoneUse = useHealthstoneCheckbox.Checked;
            Settings.HealthstoneHp = (int)useHealthstoneInput.Value;

            Settings.PvpIgnoreCCTarget = ignoreCCTargetCheckbox.Checked;

            Settings.RebukeUse = useRebukeCheckbox.Checked;
            Settings.RebukeRandomTimerUse = delayKickCheckbox.Checked;
            Settings.RebukeRandomTimerMin = (int)kickMinInput.Value;
            Settings.RebukeRandomTimerMax = (int)kickMaxInput.Value;
            Settings.PvpDestroyTotems = useTotemStompCheckbox.Checked;
            #endregion

            #region Defensive
            Settings.UseBoP = blessingOfProtectionCheckbox.Checked;
            Settings.UseBoPSelf = blessingOfProtectionMeCheckbox.Checked;
            Settings.UseBoPKarma = blessingOfProtectionKarmaCheckbox.Checked;
            Settings.UseBoPHp = (int)blessingOfProtectionHpInput.Value;
            Settings.UseBoPBurst = useBlessingOfProtectionOnBurstCheckbox.Checked;


            Settings.UseDivineShield = useDivineShieldCheckbox.Checked;
            Settings.UseDivineShieldHp = (int)divineShieldHpInput.Value;
            #endregion

            #region Offensive
            Settings.UseBoF = useBlessingOfFreedomMeCheckbox.Checked;
            Settings.UseBoFGroup = useBlessingOfFreedomGroupCheckbox.Checked;
            Settings.UseBoFTank = useBlessingOfFreedomTankCheckbox.Checked;
            Settings.UseBoFHeal = useBlessingOfFreedomHealCheckbox.Checked;
            Settings.UseBoFDPS = useBlessingOfFreedomDpsCheckbox.Checked;

            Settings.HoJUse = useHammerOfJusticeCheckbox.Checked;
            Settings.HoJInterrupt = hammerOfJusticeInterruptCheckbox.Checked;
            Settings.HoJInterruptCC = hammerOfJusticeInterruptCCCheckbox.Checked;
            Settings.HoJInterruptHeal = hammerOfJusticeInterruptHealCheckbox.Checked;
            Settings.HoJTargetBelow = (int)hammerOfJusticeTargetBelowInput.Value;
            Settings.HoJUseOnCooldown = hammerOfJusticeOnCooldownCheckbox.Checked;
            #endregion

            Settings.UseBlindingLight = useBlindingLightCheckbox.Checked;
            Settings.BlindingLightTargets = (int)blindingLightsTargetsInput.Value;

            #region Retribution
            Settings.UseShieldOfVengeance = useShieldOfVengeanceCheckbox.Checked;
            Settings.ShieldOfVengeanceLife = (int)shieldOfVengeanceHpInput.Value;
            Settings.ShieldOfVengeanceIncomingDamage = shieldOfVengeanceIncomingCheckbox.Checked;

            Settings.DivineStormEnemies = (int)divineStormEnemyCountInput.Value;
            Settings.DivineStormHolyPower = (int)divineStormHolyPowerInput.Value;

            Settings.HolyWrathLife = (int)holyWrathHealthPercentInput.Value;

            Settings.IntelligentHolyWrath = intelligentHolyWrathUsageCheckbox.Checked;

            Settings.UseHandOfHindrance = handOfHindranceCheckbox.Checked;

            Settings.JusticarsVengeanceLife = (int)justicarsVengeanceInput.Value;

            #region Healing
            Settings.RetFoLMe = retUseFlashOfLightMeCheckbox.Checked;
            Settings.RetFoLSelfHp = (int)retFlashOfLightMeInput.Value;
            Settings.RetFoLOther = retUseFlashOfLightOtherCheckbox.Checked;
            Settings.RetFoLOtherHp = (int)retFlashOfLightOtherInput.Value;

            Settings.RetLoHUseHp = (int)retLayOnHandsHpInput.Value;
            Settings.RetLoHUseOnSelf = retUseLayOnHandsCheckbox.Checked;
            Settings.RetLoHUse = retUseLayOnHandsOnGroupCheckbox.Checked;

            Settings.WoGUse = useWordOfGloryCheckbox.Checked;
            Settings.EyeForAnEyeHP = (int)eyeForAnEyeInput.Value;
            #endregion
            #endregion

            Settings.Save();

            PaladinSettings.Instance = Settings;

            Paladin.Managers.Hotkeys.UnRegisterHotkeys();
            Paladin.Managers.Hotkeys.RegisterHotkeys();
        }
        #endregion

        private void InitializeDropdowns()
        {
            PopulateModifierKeys(hammerOfJusticeModifierSelect, Settings.HoJModifierKey);
            PopulateHotkeys(hammerOfJusticeKeySelect, Settings.HoJHotKey);

            PopulateModifierKeys(hammerOfJusticeHealerModifierSelect, Settings.HoJHealerModifierKey);
            PopulateHotkeys(hammerOfJusticeHealerKeySelect, Settings.HoJHealerHotKey);

            PopulateModifierKeys(burstModifierKeySelect, Settings.BurstModifierKey);
            PopulateHotkeys(burstKeySelect, Settings.BurstHotkey);
        }

        private void PopulateModifierKeys(ComboBox box, ModifierKeys selected)
        {
            box.Items.Add("None");
            box.Items.Add("Alt");
            box.Items.Add("Control");
            box.Items.Add("Shift");

            switch (selected)
            {
                case Styx.Common.ModifierKeys.Alt:
                    box.SelectedIndex = 1;
                    break;
                case Styx.Common.ModifierKeys.Control:
                    box.SelectedIndex = 2;
                    break;
                case Styx.Common.ModifierKeys.Shift:
                    box.SelectedIndex = 3;
                    break;
                default:
                    box.SelectedIndex = 0;
                    break;
            }
        }

        private ModifierKeys GetSelectedModifierKey(ComboBox box)
        {
            switch (box.SelectedItem.ToString())
            {
                case "Alt":
                    return Styx.Common.ModifierKeys.Alt;
                case "Control":
                    return Styx.Common.ModifierKeys.Control;
                case "Shift":
                    return Styx.Common.ModifierKeys.Shift;
            }

            return Styx.Common.ModifierKeys.NoRepeat;
        }

        private void PopulateHotkeys(ComboBox box, Keys selected)
        {
            box.Items.Add("None");

            var keyList = Enum.GetValues(typeof(Keys));
            foreach (Keys k in keyList)
            {
                if ((k >= Keys.A && k <= Keys.Z)
                    || (k >= Keys.F1 && k <= Keys.F19)
                    || (k >= Keys.D0 && k <= Keys.D9)
                    || (k >= Keys.NumPad0 && k <= Keys.NumPad9)
                    )
                {
                    box.Items.Add(k);
                }
            }

            int selectedIndex = box.Items.IndexOf(selected);

            box.SelectedIndex = selectedIndex < 0 ? 0 : selectedIndex;
        }

        private Keys GetSelectedKey(ComboBox box)
        {
            var selected = box.SelectedItem;
            if (selected.ToString() == "None") return Keys.None;
            return (Keys)selected;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveSettings();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void interruptListButton_Click(object sender, EventArgs e)
        {
            if (PaladinCR.CRInterruptsForm == null || PaladinCR.CRInterruptsForm.IsDisposed || PaladinCR.CRInterruptsForm.Disposing)
                PaladinCR.CRInterruptsForm = new InterruptForm();

            PaladinCR.CRInterruptsForm.Show();
        }

        private void cleanseListButton_Click(object sender, EventArgs e)
        {
            if (PaladinCR.CRCleansesForm == null || PaladinCR.CRCleansesForm.IsDisposed || PaladinCR.CRCleansesForm.Disposing)
                PaladinCR.CRCleansesForm = new CleanseForm();

            PaladinCR.CRCleansesForm.Show();
        }
    }
}
