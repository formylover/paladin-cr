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
        public async Task<bool> BestowFaithMethod()
        {
            if (BestowFaith.CRSpell.Cooldown) return false;
                                    
            var target = Healing.HealTarget(PaladinSettings.Instance.BestowFaith, true);
            if (target == null || target.IsDead || target.IsGhost) return false;

            Helpers.Logger.DiagnosticLog("Bestow Faith on {0}, Distance: {1}, LOS: {2}", target.SafeName, target.Distance, target.InLineOfSpellSight);
            
            return await BestowFaithCast(target);
        }

        private async Task<bool> BestowFaithCast(WoWUnit unit)
        {
            if (!await BestowFaith.Cast(unit))
                return false;

            Helpers.Logger.PrintLog("Bestow Faith on {0}", unit.SafeName);

            LastSpell = FlashOfLight;
            return true;
        }
    }
}
