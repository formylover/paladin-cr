using Paladin.Helpers;
using Paladin.Settings;
using Styx;
using System.Linq;
using System.Threading.Tasks;

namespace Paladin.SpellBooks.Specs.Retribution
{
    public partial class RetributionSpells : PaladinSpells<RetributionTalents>
    {
        public async Task<bool> BlessingsMethod()
        {
            if (!PaladinSettings.Instance.AutoCastBlessings) return false;
            if (StyxWoW.Me.Mounted) return false;

            // TODO blessing of wisdom on arena mate if hammer of reckoning is specced
            foreach (Spell blessing in Blessings()) 
            {
                if (blessing != null && StyxWoW.Me.HasAura(blessing.CRSpell.Id))
                    continue;

                if (!await blessing.Cast(StyxWoW.Me))
                    continue;

                LastSpell = blessing;
                return true;
            }

            return false;
        }
    }
}