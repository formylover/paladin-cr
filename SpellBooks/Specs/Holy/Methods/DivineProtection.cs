using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Media;
using Paladin.Helpers;
using Paladin.Settings;
using Styx;
using Styx.Common;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace Paladin.SpellBooks.Specs.Holy
{
    public partial class HolySpells : PaladinSpells<HolyTalents>
    {
        public async Task<bool> DivineProtectionMethod()
        {
            if (LastSpell == DivineProtection) return false;

            if (Globals.MyHp > PaladinSettings.Instance.DivineProtectionHealth) return false;

            if (!await DivineProtection.Cast(StyxWoW.Me))
                return false;

            LastSpell = DivineProtection;
            return true;
        }
    }
}