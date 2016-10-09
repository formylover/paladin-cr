using Paladin.Helpers;
using System.Threading.Tasks;

namespace Paladin.SpellBooks.Specs.Protection
{
    public partial class ProtectionSpells : PaladinSpells<ProtectionTalents>
    {
        public async Task<bool> BlindingLightMethod()
        {
            if (!Global.BlindingLight.Check(BlindingLight, MyTalents.BlindingLight)) return false;

            if (!await BlindingLight.Cast(Styx.StyxWoW.Me)) return false;

            LastSpell = BlindingLight;
            return true;
        }
    }
}
