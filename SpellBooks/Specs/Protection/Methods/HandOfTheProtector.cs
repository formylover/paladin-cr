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
            if (!Paladin.Settings.PaladinSettings.Instance.UseLightOfTheProtector) return false;

            var spell = LightOfTheProtector;
            if (MyTalents.HandOfTheProtector.IsActive())
                spell = HandOfTheProtector;

            if (spell.CRSpell.Cooldown) return false;
            
            if (Globals.MyHp < Paladin.Settings.PaladinSettings.Instance.LightOfTheProtector)
                return await CastHandOfTheProtector(StyxWoW.Me, spell);

            var target = Healing.HealTarget(Paladin.Settings.PaladinSettings.Instance.LightOfTheProtectorOther);
            if (target == null) return false;

            return await CastHandOfTheProtector(target, spell);
        }

        public async Task<bool> CastHandOfTheProtector(WoWUnit target, Spell spell)
        {
            if (!await spell.Cast(target))
                return false;

            LastSpell = spell;
            return true;
        }
    }
}