using System.Threading.Tasks;
using Paladin.Helpers;
using Paladin.Settings;
using System.Linq;

namespace Paladin.SpellBooks.Specs.Retribution
{
    public partial class RetributionSpells : PaladinSpells<RetributionTalents>
    {
        public async Task<bool> RepentanceMethod()
        {
            if (!PaladinSettings.Instance.UseRepentance) return false;
            if (!Globals.Pvp) return false;
            if (Styx.StyxWoW.Me.IsMoving) return false;

            var target = Unit.UnfriendlyPlayers.FirstOrDefault(u => u.IsCasting && (u.IsCastingHealingSpell || u.IsCastingBigDamageSpell()));
            if (target == null) return false;

            if (!await Repentance.Cast(target))
                return false;

            LastSpell = Repentance;

            return true;
        }
            
    }
}
