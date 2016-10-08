using System.Linq;
using System.Threading.Tasks;
using Paladin.Helpers;
using Styx;

namespace Paladin.SpellBooks.Global
{
    public static class AutoFocus
    {
        public static bool AutoFocusMethod()
        {
            if (Globals.HasFocus) return false;

            // Set our focus variable to a healer
            Globals.FocusedUnit = Unit.UnfriendlyPlayers.FirstOrDefault(u => u.IsHealer() && u.Distance <= 30);

            if (Globals.FocusedUnit != null)
                StyxWoW.Me.SetFocus(Globals.FocusedUnit);

            return false;
        }
    }
}