using Paladin.Helpers;
using System.Threading.Tasks;

namespace Paladin.SpellBooks.Specs.Protection
{
    public partial class ProtectionSpells : PaladinSpells<ProtectionTalents>
    {
        public async Task<bool> ConsecrationMethod()
        {
            if (Unit.EnemiesAroundTarget(Styx.StyxWoW.Me, 6) < 1) return false;

            if (!await Consecration.Cast(Styx.StyxWoW.Me)) return false;

            LastSpell = BlindingLight;
            return true;
        }
    }
}
