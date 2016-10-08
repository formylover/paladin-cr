using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using Paladin.Settings;
using Styx;
using Styx.Common;
using Styx.CommonBot.Coroutines;
using Styx.WoWInternals.DB;
using Styx.WoWInternals.WoWObjects;

namespace Paladin.Helpers
{
    public static class Items
    {
        public static bool CanUseItem(WoWItem item)
        {
            if (item == null)
                return false;

            // Check if we can even use the item
            if (item.Effects.Any(u => u.TriggerType != ItemEffectTriggerType.OnUse))
                return false;

            return item.Usable && item.Cooldown <= 0;
        }

        public static WoWItem FindItem(int id)
        {
            return StyxWoW.Me.CarriedItems.FirstOrDefault(u => u.Entry == id);
        }

        public static WoWItem Trinket1
        {
            get
            {
                return StyxWoW.Me.Inventory.GetItemBySlot(12);
            }
        }

        public static WoWItem Trinket2
        {
            get
            {
                return StyxWoW.Me.Inventory.GetItemBySlot(13);
            }
        }

        public static async Task<bool> Healthstone()
        {
            if (!PaladinSettings.Instance.HealthstoneUse)
                return false;

            if (StyxWoW.Me.HealthPercent > PaladinSettings.Instance.HealthstoneHp)
                return false;

            var healthstone = FindItem(5512);

            if (!CanUseItem(healthstone))
                return false;

            healthstone.UseContainerItem();
            await CommonCoroutines.SleepForRandomUiInteractionTime();
            Helpers.Logger.PrintLog("Using Healthstone");
            return true;
        }
    }
}
