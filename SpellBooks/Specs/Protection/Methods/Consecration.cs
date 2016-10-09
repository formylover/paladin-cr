using Paladin.Helpers;
using System.Threading.Tasks;

namespace Paladin.SpellBooks.Specs.Protection
{
    public partial class ProtectionSpells : PaladinSpells<ProtectionTalents>
    {
        public async Task<bool> ConsecrationMethod()
        {
            if (Globals.CurrentTarget == null || Globals.CurrentTarget.Distance > 6) return false;

            if (!await Consecration.Cast(Styx.StyxWoW.Me)) return false;

            LastSpell = BlindingLight;
            return true;
        }
    }
}
