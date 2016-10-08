using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using Paladin.Helpers;
using Paladin.Settings;
using Styx;
using Styx.Common;

namespace Paladin.SpellBooks.Specs.Retribution
{
    public partial class RetributionSpells : PaladinSpells<RetributionTalents>
    {
        public async Task<bool> DivineStormMethod()
        {
            if (Globals.EnemiesInRange < 1)
                return false;
            
            // TODO check this if it is needed
            if (Globals.HolyPower < PaladinSettings.Instance.DivineStormHolyPower)
                return false;

            // only check players, no pets
            if (Globals.Pvp && Unit.UnfriendlyPlayers.Count(u => u.Distance < 8) < PaladinSettings.Instance.DivineStormEnemies)
                return false;
            else if (Globals.EnemiesInRange < PaladinSettings.Instance.DivineStormEnemies)
                return false;

            if (!await DivineStorm.Cast())
                return false;

            LastSpell = DivineStorm;
            return true;
        }
    }
}
