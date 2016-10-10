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
            if (Globals.MyHp > Paladin.Settings.PaladinSettings.Instance.EyeOfTyrHP) return false;

            if (Unit.EnemiesAttackingTarget(StyxWoW.Me) <= 0) return false;

            if (!await EyeOfTyr.Cast(StyxWoW.Me))
                return false;

            LastSpell = EyeOfTyr;
            return true;
        }
    }
}