using System.Threading.Tasks;

namespace Paladin.SpellBooks.Specs.Retribution
{
    public partial class RetributionSpells : PaladinSpells<RetributionTalents>
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
