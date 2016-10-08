using System;
using System.Threading.Tasks;
using System.Windows.Media;
using Paladin.Helpers;
using Paladin.Settings;
using Styx;
using Styx.Common;

namespace Paladin.SpellBooks.Specs.Protection
{
    public partial class ProtectionSpells : PaladinSpells<ProtectionTalents>
    {
        public async Task<bool> RebukeMethod()
        {
            if (SpellBooks.Global.Rebuke.RebukeCheck(Rebuke))
                return await CastRebuke();

            return false;
        }

        public async Task<bool> CastRebuke()
        {
            if (!await Rebuke.Cast())
                return false;

            Helpers.Logger.PrintLog("Interrupting {0}", Globals.CurrentTarget.SafeName);

            LastSpell = Rebuke;
            return true;
        }
    }
}
