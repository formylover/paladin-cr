using System.Threading.Tasks;

namespace Paladin.SpellBooks.Specs.Protection
{
    public partial class ProtectionSpells: PaladinSpells<ProtectionTalents>
    {
        public async Task<bool> HammerOfRighteousMethod()
        {
            if (MyTalents.BlessedHammer.IsActive()) return false;

            if (!await HammerOfRighteous.Cast()) return false;

            LastSpell = HammerOfRighteous;
            return true;
        }
    }
}
