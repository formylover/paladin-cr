using System.Threading.Tasks;
using System.Windows.Media;
using Paladin.Helpers;
using Paladin.Managers;
using Styx;
using Styx.Common;
using Styx.CommonBot;
using Styx.WoWInternals.WoWObjects;
using Paladin.Settings;

namespace Paladin.SpellBooks.Specs.Holy
{
    public partial class HolySpells : PaladinSpells<HolyTalents>
    {
        public async Task<bool> LightOfDawnMethod()
        {
            if (StyxWoW.Me.IsMoving) return false;

            if (!Globals.InParty) return false;

            if (!Healing.CastLightOfDawn(PaladinSettings.Instance.LightOfDawnHP)) return false;
            
            if (!await LightOfDawn.Cast(StyxWoW.Me))
                return false;

            LastSpell = LightOfDawn;
            return true;
        }
    }
}
