using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using Paladin.Helpers;
using Paladin.Settings;
using Styx;
using Styx.Common;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;
using System;
using System.Collections.Generic;

namespace Paladin.SpellBooks.Specs.Retribution
{
    public partial class RetributionSpells : PaladinSpells<RetributionTalents>
    {
        private WoWPlayer CleanseTarget { get; set; }
        private WoWAura CleanseAuraToClear { get; set; }

        public async Task<bool> CleanseMethod()
        {
            // TODO UA 34439 http://www.wowhead.com/spell=34439/unstable-affliction
            // TODO Vampiric Touch 34914 http://www.wowhead.com/spell=34914/vampiric-touch

            if (!Globals.Pvp) return false;

            var auras = new Dictionary<WoWPlayer, WoWAuraCollection>();

            if (PaladinSettings.Instance.UseCleanseGroup && Globals.InParty)
            {
                foreach (var groupmember in Unit.GroupMembers.Where(x => x.Distance <= 40 && x.InLineOfSight))
                {
                    auras.Add(groupmember, new WoWAuraCollection(groupmember.GetAllAuras().Where(x => x.Spell.DispelType == WoWDispelType.Poison || x.Spell.DispelType == WoWDispelType.Disease)));
                }
            }
            else
            {
                auras.Add(StyxWoW.Me, new WoWAuraCollection(StyxWoW.Me.GetAllAuras().Where(x => x.Spell.DispelType == WoWDispelType.Poison || x.Spell.DispelType == WoWDispelType.Disease)));
            }

            foreach (var aura in auras)
            {
                int index = CheckForCleanse(aura.Value);

                if (aura.Value.Count == 0 || index == -1)
                {
                    continue;
                }

                CleanseTarget = aura.Key;
                CleanseAuraToClear = aura.Value[index];
                break;
            }

            if (CleanseTarget == null || CleanseAuraToClear == null)
            {
                return false;
            }

            Helpers.Logger.DiagnosticLog("Cleansing {0}, Distance: {1}, LOS: {2}", CleanseTarget.SafeName, CleanseTarget.Distance, CleanseTarget.InLineOfSpellSight);

            return await CleanseCast();

        }

        private int CheckForCleanse(WoWAuraCollection auras)
        {
            var retval = -1;
            Tuple<bool, string, string, string> cleanseInfo;
            foreach (var aura in auras)
            {
                PaladinCR.CleansesDict.TryGetValue(aura.SpellId, out cleanseInfo);

                if (cleanseInfo == null || cleanseInfo.Item3 != "Cleanse" || !cleanseInfo.Item1)
                {
                    continue;
                }
                retval = auras.IndexOf(aura);
                break;
            }
            return retval;
        }

        private async Task<bool> CleanseCast()
        {
            if (!await CleanseToxins.Cast(CleanseTarget))
                return false;

            Helpers.Logger.PrintLog("Cleansing: {0} on {1}", CleanseAuraToClear.Spell.LocalizedName, CleanseTarget.SafeName);

            CleanseTarget = null;
            CleanseAuraToClear = null;

            return true;
        }
    }
}
