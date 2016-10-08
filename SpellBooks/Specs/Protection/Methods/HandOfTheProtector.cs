using Styx.WoWInternals.WoWObjects;
using System.Threading.Tasks;
using Styx;
using Paladin.Helpers;
using Paladin.Managers;

namespace Paladin.SpellBooks.Specs.Protection
{
    public partial class ProtectionSpells : PaladinSpells<ProtectionTalents>
    {
        public async Task<bool> HandOfTheProtectordMethod()
        {
            if (HandOfTheProtector.CRSpell.Cooldown) return false;

            if (Globals.MyHp < Paladin.Settings.PaladinSettings.Instance.HandOfTheProtector)
                return await CastHandOfTheProtector(StyxWoW.Me);

            var target = Healing.HealTarget(Paladin.Settings.PaladinSettings.Instance.HandOfTheProtectorOther);
            if (target == null) return false;

            return await CastHandOfTheProtector(target);
        }

        public async Task<bool> CastHandOfTheProtector(WoWUnit target)
        {
            if (!await HandOfTheProtector.Cast(target))
                return false;

            LastSpell = HandOfTheProtector;
            return true;
        }
    }
}