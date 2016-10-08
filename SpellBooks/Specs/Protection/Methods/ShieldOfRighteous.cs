using System.Threading.Tasks;

namespace Paladin.SpellBooks.Specs.Protection
{
    public partial class ProtectionSpells: PaladinSpells<ProtectionTalents>
    {
        public async Task<bool> ShieldOfRighteousMethod()
        {
            if (LastSpell == ShieldOfTheRighteous || Helpers.Globals.HasShieldOfRighteous) return false;

            // TODO bastion of light talent
            if (MyTalents.Seraphim.IsActive() && !Seraphim.CRSpell.Cooldown && ShieldOfTheRighteous.CRSpell.GetChargeInfo().ChargesLeft < 3) return false;

            if (!await ShieldOfTheRighteous.Cast()) return false;

            LastSpell = ShieldOfTheRighteous;
            return true;
        }
    }
}
