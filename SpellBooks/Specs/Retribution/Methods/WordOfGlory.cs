using System.Threading.Tasks;
using System.Windows.Media;
using Paladin.Helpers;
using Paladin.Managers;
using Paladin.Settings;
using Styx;
using Styx.Common;
using Styx.WoWInternals.WoWObjects;

namespace Paladin.SpellBooks.Specs.Retribution
{
    public partial class RetributionSpells : PaladinSpells<RetributionTalents>
    {
        public async Task<bool> WordOfGloryMethod()
        {
            if (!PaladinSettings.Instance.WoGUse)
                return false;

            if (!MyTalents.WordOfGLory.IsActive())
                return false;

            // We check ourself first
            if (Globals.MyHp <= PaladinSettings.Instance.WoGHealth)
                return await WordOfGloryCast();

            if (!PaladinSettings.Instance.WoGHealParty)
                return false;

            if (!Globals.InParty)
                return false;

            // Find a group target
            var target = Healing.HealTarget(PaladinSettings.Instance.WoGPartyHealth);
            if (target == null || target.IsDead)
                return false;

            if (target.Distance > 15) return false;

            return await WordOfGloryCast();
        }

        private async Task<bool> WordOfGloryCast()
        {
            if (!await WordOfGlory.Cast())
                return false;

            Helpers.Logger.PrintLog("Using Word Of Glory on {0} at {1}%", StyxWoW.Me.SafeName, StyxWoW.Me.HealthPercent);

            LastSpell = WordOfGlory;
            return true;
        }
    }
}
