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
        public async Task<bool> ExecutionSentenceMethod()
        {
            if (Globals.CurrentTarget == null) return false;

            if (!MyTalents.ExecutionSentence.IsActive())
                return false;

            if (!Globals.CurrentTarget.IsPlayer)
            {
                if (Globals.CurrentTarget.CurrentHealth < 100000)
                    return false;
            }

            if (ExecutionSentence.CRSpell.Cooldown)
                return false;

            // If we're using Burst we want to use this when we have cooldowns active or if we're not gonna have our cooldowns up for a while
            if (PaladinSettings.Instance.BurstUse && !Cooldowns)
                return false;

            // We need to do this check because if we're in combat and the user targets a friendly unit, it might use the spell
            if (Globals.CurrentTarget.IsFriendly)
                return false;

            Helpers.Logger.DiagnosticLog("Execution Sentence on {0}, Distance: {1}, LOS: {2}", StyxWoW.Me.CurrentTarget.SafeName, StyxWoW.Me.CurrentTarget.Distance, StyxWoW.Me.CurrentTarget.InLineOfSight);


            return await ExecutionSentenceCast(Globals.CurrentTarget);
        }

        private async Task<bool> ExecutionSentenceCast(WoWUnit unit)
        {
            if (!await ExecutionSentence.Cast(unit))
                return false;

            Helpers.Logger.PrintLog("Casting Execution Sentence on {0}", unit.SafeName);

            LastSpell = ExecutionSentence;
            return true;
        }
    }
}