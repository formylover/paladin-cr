using System.Threading.Tasks;
using System.Windows.Media;
using Paladin.Helpers;
using Paladin.Managers;
using Styx;
using Styx.Common;
using Styx.CommonBot;
using Styx.WoWInternals.WoWObjects;
using Paladin.Settings;

namespace Paladin.SpellBooks.Specs.Holy
{
    public partial class HolySpells : PaladinSpells<HolyTalents>
    {
        public async Task<bool> FlashOfLightMethod()
        {
            if (StyxWoW.Me.IsMoving) return false;

            // cast holy light with proc
            if (StyxWoW.Me.GetAuraById(54149) != null && Unit.EnemiesAttackingTarget(StyxWoW.Me) <= 0) return false;
            
            var target = Healing.HealTarget(PaladinSettings.Instance.HolyFoL, true);
            if (target == null || target.IsDead || target.IsGhost) return false;

            Helpers.Logger.DiagnosticLog("Flash of Light on {0}, Distance: {1}, LOS: {2}", target.SafeName, target.Distance, target.InLineOfSpellSight);
            
            return await FlashOfLightCast(target);
        }

        private async Task<bool> FlashOfLightCast(WoWUnit unit)
        {
            if (!await FlashOfLight.Cast(unit))
                return false;

            Helpers.Logger.PrintLog("Flash Of Light on {0}", unit.SafeName);

            LastSpell = FlashOfLight;
            return true;
        }
    }
}
