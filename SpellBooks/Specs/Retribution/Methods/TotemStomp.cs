using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using Paladin.Helpers;
using Paladin.Settings;
using Styx.Common;
using Styx.CommonBot;
using Styx.WoWInternals.WoWObjects;

namespace Paladin.SpellBooks.Specs.Retribution
{
    public partial class RetributionSpells : PaladinSpells<RetributionTalents>
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

            if (SpellManager.CanCast(BladeOfWrath.CRSpell, totem, true))
                return await BladeOfWrath.Cast(totem);

            if (SpellManager.CanCast(CrusaderStrike.CRSpell, totem, true))
                return await CrusaderStrike.Cast(totem);

            if (SpellManager.CanCast(Zeal.CRSpell, totem, true))
                return await Zeal.Cast(totem);

            return false;
        }
    }
}
