using System.Threading.Tasks;
using System.Linq;
using Paladin.Helpers;
using Styx;

namespace Paladin.SpellBooks.Specs.Holy
{
    public partial class HolySpells : PaladinSpells<HolyTalents>
    {
        public async Task<bool> BeaconOfLightMethod()
        {
            return false; // TODO

            var target = Globals.FocusedUnit;
            if (target == null && Globals.LastKnownGroupMemberSize > 0)
                target = Unit.GroupMembers.FirstOrDefault();
            if (target == null)
                target = StyxWoW.Me;

            if (target.GetAuraById(53563) != null)
                return false;

            if (!await BeaconOfLight.Cast(target))
                return false;
            
            Helpers.Logger.PrintLog("Beacon of Light on {0}", target.SafeName);

            LastSpell = BeaconOfLight;
            return true;
        }
    }
}
