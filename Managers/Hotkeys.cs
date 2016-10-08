using System.Windows.Media;
using System.Linq;
using Paladin.Settings;
using Styx.Common;

using Styx;
using Paladin.Helpers;

namespace Paladin.Managers
{
    public static class Hotkeys
    {
        public static void RegisterHotkeys()
        {
            if (PaladinSettings.Instance.BurstHotkey != System.Windows.Forms.Keys.None)
            {
                HotkeysManager.Register("GGWPBurst", PaladinSettings.Instance.BurstHotkey, PaladinSettings.Instance.BurstModifierKey, x =>
                {
                    Helpers.Logger.PrintLog("Burst Hotkey Detected");
                    Globals.ActivateBurst = true;
                });
            }

            if (PaladinSettings.Instance.HoJHotKey != System.Windows.Forms.Keys.None)
            {
                HotkeysManager.Register("GGWPHoJ", PaladinSettings.Instance.HoJHotKey, PaladinSettings.Instance.HoJModifierKey, x =>
                {
                    Helpers.Logger.PrintLog("HoJ Hotkey Detected");
                    Globals.HoJTarget = Globals.CurrentTarget;
                });
            }

            if (PaladinSettings.Instance.HoJHealerHotKey != System.Windows.Forms.Keys.None)
            {
                HotkeysManager.Register("GGWPHoJHealer", PaladinSettings.Instance.HoJHealerHotKey, PaladinSettings.Instance.HoJHealerModifierKey, x =>
                {
                    Helpers.Logger.PrintLog("HoJ Healer Hotkey Detected");
                    Globals.HoJTarget = Unit.UnfriendlyPlayers.Where(u => u.IsHealer()).OrderBy(u => u.Distance).FirstOrDefault();
                });
            }
        }

        public static void UnRegisterHotkeys()
        {
            HotkeysManager.Unregister("GGWPBurst");
            HotkeysManager.Unregister("GGWPHoJ");
            HotkeysManager.Unregister("GGWPHoJHealer");
        }
    }        
}
