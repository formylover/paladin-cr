using Paladin.Helpers;
using System.Threading.Tasks;
using Styx;

namespace Paladin.SpellBooks.Specs.Protection
{
    public partial class ProtectionSpells : PaladinSpells<ProtectionTalents>
    {
        public async Task<bool> AvengersShieldMethod()
        {
            if (!await AvengersShield.Cast(Globals.CurrentTarget))
                return false;

            LastSpell = AvengersShield;
            return true;
        }
    }
}