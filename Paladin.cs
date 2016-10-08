using System;
using System.Collections.Generic;
using System.Linq;

using System.Windows.Media;

using Styx;
using Styx.Common;
using Styx.CommonBot;
using Styx.TreeSharp;
using Styx.WoWInternals;
using Styx.CommonBot.Routines;
using CommonBehaviors.Actions;

using Paladin.Settings;
using Paladin.Settings.Forms;
using Paladin.Rotations;
using Paladin.Rotations.Specs;
using Paladin.Managers;

namespace Paladin
{
    public class PaladinCR : CombatRoutine
    {
        #region Version
        private Version CurrentVersion = new Version(0, 1, 0);
        #endregion

        public bool LatestVersion = true;

        #region Required Overrides
        public override string Name
        {
            get
            {
                return "[Glorious Gaming] Wrathful Paladin v" + CurrentVersion;
            }
        }

        public override WoWClass Class { get { return WoWClass.Paladin; } }

        public override CapabilityFlags SupportedCapabilities
        {
            get
            {
                return CapabilityFlags.All; // TODO
            }
        }

        public override void Initialize()
        {
            LatestVersion = Helpers.Version.CheckVersion(CurrentVersion);

            HotkeysManager.Initialize(StyxWoW.Memory.Process.MainWindowHandle);
            PaladinSettings.Instance.Load();

            Lua.Events.AttachEvent("PLAYER_REGEN_DISABLED", OnCombatStarted);
            Lua.Events.AttachEvent("UPDATE_BATTLEFIELD_STATUS", BGArena);

            Hotkeys.RegisterHotkeys();
        }

        private void OnCombatStarted(object sender, LuaEventArgs e)
        {
            Helpers.Logger.PrintLog("Entered Combat");
            //Globals.CombatTime.Restart();
        }

        public override void ShutDown() { }

        public override void Pulse()
        {
            CheckSpec();
            Helpers.PvP.AcceptInvite();
            base.Pulse();
        }

        public override bool WantButton
        {
            get { return true; }
        }

        public override void OnButtonPress()
        {
            if (CRSettingsForm == null || CRSettingsForm.IsDisposed || CRSettingsForm.Disposing)
                CRSettingsForm = new SettingsForm(PaladinSettings.Instance);

            CRSettingsForm.Show();
        }
        #endregion

        #region Behaviors
        public override Composite DeathBehavior { get { return new ActionRunCoroutine(ctx => MyRotation.Death()); } }
        public override Composite RestBehavior { get { return new ActionRunCoroutine(ctx => MyRotation.Rest()); } }
        public override Composite MoveToTargetBehavior { get { return new ActionRunCoroutine(ctx => MyRotation.MoveToTarget()); } }
        public override Composite PreCombatBuffBehavior { get { return new ActionRunCoroutine(ctx => MyRotation.PreCombatBuff()); } }
        public override Composite PullBuffBehavior { get { return new ActionRunCoroutine(ctx => MyRotation.PullBuff()); } }
        public override Composite PullBehavior { get { return new ActionRunCoroutine(ctx => MyRotation.Pull()); } }
        public override Composite HealBehavior { get { return new ActionRunCoroutine(ctx => MyRotation.Heal()); } }
        public override Composite CombatBuffBehavior { get { return new ActionRunCoroutine(ctx => MyRotation.CombatBuff()); } }
        public override Composite CombatBehavior { get { return new ActionRunCoroutine(ctx => MyRotation.Combat()); } }
        #endregion

        #region Rotation/Spec Handling
        private IRotation _myRotation;
        private IRotation MyRotation
        {
            get
            {
                if (_myRotation == null)
                {
                    _myRotation = GetRotation(CurrentSpec);
                }
                return _myRotation;
            }
        }
        private IRotation GetRotation(WoWSpec spec)
        {
            if (!LatestVersion) return new None();

            switch (spec)
            {
                case WoWSpec.PaladinProtection:
                    return new Protection();
                case WoWSpec.PaladinHoly:
                    return new Retribution();
                case WoWSpec.PaladinRetribution:
                    return new Retribution();
                default:
                    return new Retribution();
            }
        }

        private WoWSpec _currentSpec;
        public WoWSpec CurrentSpec
        {
            get
            {
                if (_currentSpec != StyxWoW.Me.Specialization)
                {
                    _currentSpec = StyxWoW.Me.Specialization;
                    _myRotation = GetRotation(_currentSpec);
                    Helpers.Logger.PrintLog("Changed Specialization to: " + _currentSpec + ".");
                }
                return _currentSpec;
            }
        }
        private void CheckSpec()
        {
            var _spec = CurrentSpec;
        }
        #endregion

        #region Settings
        private static SettingsForm _crSettingsForm;
        public static SettingsForm CRSettingsForm
        {
            get
            {
                if (_crSettingsForm == null)
                {
                    _crSettingsForm = new SettingsForm(PaladinSettings.Instance);
                }
                return _crSettingsForm;
            }
            set
            {
                _crSettingsForm = value;
            }
        }
        #endregion

        #region Cleanses
        private static CleanseForm _crCleansesForm;
        public static CleanseForm CRCleansesForm
        {
            get
            {
                if (_crCleansesForm == null)
                {
                    _crCleansesForm = new CleanseForm();
                }
                return _crCleansesForm;
            }
            set
            {
                _crCleansesForm = value;
            }
        }

        private static Dictionary<int, Tuple<bool, string, string, string>> _cleansesDict;
        public static Dictionary<int, Tuple<bool, string, string, string>> CleansesDict
        {
            get
            {
                if (_cleansesDict == null)
                {
                    _cleansesDict = CleanseSettings.Instance.CleaseDictionary();
                }
                return _cleansesDict;
            }
            set
            {
                _cleansesDict = value;
            }
        }
        #endregion

        #region Interrupts
        private static InterruptForm _crInterruptsForm;
        public static InterruptForm CRInterruptsForm
        {
            get
            {
                if (_crInterruptsForm == null)
                {
                    _crInterruptsForm = new InterruptForm();
                }
                return _crInterruptsForm;
            }
            set
            {
                _crInterruptsForm = value;
            }
        }

        private static Dictionary<int, Tuple<bool, string, string, string>> _interruptDict;
        public static Dictionary<int, Tuple<bool, string, string, string>> InterruptDict
        {
            get
            {
                if (_interruptDict == null)
                {
                    _interruptDict = InterruptSettings.Instance.InterruptDictionary();
                }
                return _interruptDict;
            }
            set
            {
                _interruptDict = value;
            }
        }
        #endregion

        public void BGArena(object sender, LuaEventArgs args)
        {
            Helpers.PvP.CheckInvite();
        }
    }
}
