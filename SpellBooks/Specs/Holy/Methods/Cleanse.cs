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
        public async Task<bool> CleanseMethod()
        {
            if (StyxWoW.Me.IsMoving) return false;

            if (!Globals.InParty) return false;

            return true;
        }
    }
}
