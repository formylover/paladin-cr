using System.Threading.Tasks;
using Paladin.Managers;

namespace Paladin.SpellBooks.Specs.Retribution
{
    public partial class RetributionSpells : PaladinSpells<RetributionTalents>
    {
        public async Task<bool> BlessingOfSanctuaryMethod()
        {
            // TODO focus target
            if (!Helpers.Globals.Arena) return false;

            if (!Styx.CommonBot.SpellManager.HasSpell(BlessingOfSanctuary.ID))
                return false;

            var target = Healing.BlessingOfSanctuaryTarget();
            if (target == null) return false;

            Helpers.Logger.DiagnosticLog("Blessing of Sanctuary on {0}, Distance: {1}, LOS: {2}", target.SafeName, target.Distance, target.InLineOfSpellSight);

            if (!await BlessingOfSanctuary.Cast(target))
                return false;

            LastSpell = BlessingOfSanctuary;
            return true;
        }
    }
}
