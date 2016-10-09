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
            var target = SpellBooks.Global.Rebuke.RebukeTarget(Rebuke);
            if (target == null) return false;

            Helpers.Logger.PrintLog("Interrupting {0} on {1}", target.CastingSpell.Name, target.SafeName);

            if (!await Rebuke.Cast(target))
                return false;

            LastSpell = Rebuke;
            return true;
        }
    }
}
