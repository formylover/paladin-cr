using Paladin.Helpers;
using System.Threading.Tasks;
using Styx;

namespace Paladin.SpellBooks.Specs.Protection
{
    public partial class ProtectionSpells : PaladinSpells<ProtectionTalents>
    {
        public async Task<bool> EyeOfTyrMethod()
        {
            if (!Paladin.Settings.PaladinSettings.Instance.UseEyeOfTyr) return false;

            if (!await EyeOfTyr.Cast(StyxWoW.Me))
                return false;

            LastSpell = EyeOfTyr;
            return true;
        }
    }
}