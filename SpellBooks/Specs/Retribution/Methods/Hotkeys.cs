using System.Threading.Tasks;
using System.Windows.Media;
using Paladin.Settings;
using Styx;
using Styx.Common;
using Styx.CommonBot;
using Styx.CommonBot.Coroutines;

using Paladin.Helpers;

namespace Paladin.SpellBooks.Specs.Retribution
{
    public partial class RetributionSpells : PaladinSpells<RetributionTalents>
    {
        public async Task<bool> HotkeysMethod()
        {
            // TODO unify methods
            // TODO hotkey for steed

            if (Globals.ActivateBurst)
            {
                Helpers.Logger.PrintLog("Cooldown Hotkey: activating");
                return await BurstMethod();
            }

            if (SpellBooks.Global.Hotkeys.HoJCheck(HammerOfJustice))
            {
                if (SpellManager.GlobalCooldown) return true;

                // Cast spell and set bool back to false
                // If it doesn't cast, return true for the tree to repeat
                if (!await HammerOfJustice.Cast(Globals.HoJTarget))
                    return true;

                Helpers.Logger.PrintLog("HoJ Hotkey on {0}", Globals.HoJTarget.SafeName);
                Globals.HoJTarget = null;
                await CommonCoroutines.SleepForLagDuration();
                return true;
            }

            return false;
        }
    }
}
