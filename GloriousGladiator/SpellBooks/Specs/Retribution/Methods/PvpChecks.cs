using System.Linq;
using System.Threading.Tasks;
using Paladin.Helpers;
using Paladin.Settings;
using Styx;

namespace Paladin.SpellBooks.Specs.Retribution
{
    public partial class RetributionSpells : PaladinSpells<RetributionTalents>
    {
        public async Task<bool> PvpChecksMethod()
        {
            // Return true so that the bot stops trying to attack the target
            if (PaladinSettings.Instance.PvpIgnoreCCTarget)
            {
                if (StyxWoW.Me.CurrentTarget.HasAnyAura(Lists.CrowdControlSpellsWeCantAttackThrough))
                    return true;
            }

            // ignore target if it has an active karma
            if (Unit.GroupMembers.Any(p => p.IsAlive && p.HasAura(122470)) && Globals.CurrentTarget.Attackable && Globals.CurrentTarget.HasAura(122470))
                return true;

            return false;
        }
    }
}