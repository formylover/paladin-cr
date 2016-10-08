using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using Paladin.Helpers;
using Paladin.Settings;
using Styx.Common;
using Styx.CommonBot;
using Styx.WoWInternals.WoWObjects;

namespace Paladin.SpellBooks.Specs.Protection
{
    public partial class ProtectionSpells : PaladinSpells<ProtectionTalents>
    {
        public async Task<bool> TotemStompMethod()
        {
            var target = Helpers.PvP.GetTotemToStomp();
            return await DestroyTotem(target);
        }

        public async Task<bool> DestroyTotem(WoWUnit totem)
        {
            if (totem == null)
                return false;

            Helpers.Logger.PrintLog("Totem Stomp on " + totem.Name);

            if (SpellManager.CanCast(Judgment.CRSpell, totem, true))
                return await Judgment.Cast(totem);

            if (SpellManager.CanCast(AvengersShield.CRSpell, totem, true))
                return await AvengersShield.Cast(totem);

            if (SpellManager.CanCast(HammerOfRighteous.CRSpell, totem, true))
                return await HammerOfRighteous.Cast(totem);

            if (SpellManager.CanCast(ShieldOfTheRighteous.CRSpell, totem, true))
                return await ShieldOfTheRighteous.Cast(totem);

            return false;
        }
    }
}
