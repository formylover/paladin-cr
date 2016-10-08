using Paladin.Helpers;
using System.Threading.Tasks;

namespace Paladin.SpellBooks.Specs.Protection
{
    public partial class ProtectionSpells : PaladinSpells<ProtectionTalents>
    {
        public async Task<bool> BlessedHammerMethod()
        {
            if (!MyTalents.BlessedHammer.IsActive()) return false;
            if (Globals.CurrentTarget == null || Globals.CurrentTarget.Distance > 6) return false;

            if (!await BlessedHammer.Cast()) return false;

            LastSpell = BlessedHammer;
            return true;
        }
    }
}
