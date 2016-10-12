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
        public async Task<bool> HolyLightMethod()
        {
            if (StyxWoW.Me.IsMoving) return false;
                                    
            var target = Healing.HealTarget(PaladinSettings.Instance.HolyLight, true);
            if (target == null || target.IsDead || target.IsGhost) return false;

            Helpers.Logger.DiagnosticLog("Holy Light on {0}, Distance: {1}, LOS: {2}", target.SafeName, target.Distance, target.InLineOfSpellSight);
            
            return await HolyLightCast(target);
        }

        private async Task<bool> HolyLightCast(WoWUnit unit)
        {
            if (!await HolyLight.Cast(unit))
                return false;

            Helpers.Logger.PrintLog("Holy Light on {0}", unit.SafeName);

            LastSpell = HolyLight;
            return true;
        }
    }
}
