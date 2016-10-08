using System.Threading.Tasks;
using Styx.WoWInternals.WoWObjects;

namespace Paladin.SpellBooks.Specs.Protection
{
    public partial class ProtectionSpells : PaladinSpells<ProtectionTalents>
    {
        public async Task<bool> HammerOfJusticeMethod()
        {
            var target = Global.HammerOfJustice.Check(HammerOfJustice);
            if (target == null) return false;

            return await CastHoj(target);
        }  
  
        private async Task<bool> CastHoj(WoWUnit unit)
        {
            if (!await HammerOfJustice.Cast(unit))
                return false;

            Helpers.Logger.PrintLog("Stunning {0}", unit.SafeName);

            LastSpell = HammerOfJustice;
            return true;
        }
    }
}
