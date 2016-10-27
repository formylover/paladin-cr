using System.Linq;
using System.Threading.Tasks;
using Paladin.Helpers;
using Styx.CommonBot;

namespace Paladin.SpellBooks.Global
{
    public static class Hotkeys
    {
        public static bool HoJCheck(Spell spell)
        {
            if (Globals.HoJTarget == null) return false;

            var target = Globals.HoJTarget;

            // Hoj on cooldown, reset bool and return false to continue
            if (!SpellManager.GlobalCooldown && spell.CRSpell.CooldownTimeLeft.TotalSeconds > 1)
            {
                Globals.HoJTarget = null;
                Helpers.Logger.PrintLog("HoJ is on cooldown");
                return false;
            }

            int range = 10;
            if (Managers.Talents.HasPassivHonorTalent(204979))
                range = 20;

            // Out of range, reset bool and return false to continue
            if (!target.IsValid || target.IsDead || target.Distance > range || !target.InLineOfSpellSight)
            {
                Globals.HoJTarget = null;
                Helpers.Logger.PrintLog("Target is out of range or spell LOS");
                return false;
            }

            return true;
        }
    }
}