using System.Threading.Tasks;
using System.Windows.Media;
using Paladin.Helpers;
using Paladin.Settings;
using System;
using Styx;
using Styx.Common;

namespace Paladin.SpellBooks.Specs.Retribution
{
    public partial class RetributionSpells : PaladinSpells<RetributionTalents>
    {
        public async Task<bool> BurstMethod()
        {
            var spell = AvengingWrath;
            if (MyTalents.Crusade.IsActive())
                spell = Crusade;

            if (Global.Burst.Check(spell))
                return await CastBurst(spell);

            return false;
        }

        private async Task<bool> CastBurst(Spell spell)
        {
            if (await spell.Cast(StyxWoW.Me))
            {
                Helpers.Logger.PrintLog("Activating Burst");

                LastSpell = spell;
                return true;
            }

            return false;
        }
    }
}
