using Paladin.Helpers;
using System.Threading.Tasks;
using Styx;
using System.Linq;

namespace Paladin.SpellBooks.Specs.Holy
{
    public partial class HolySpells : PaladinSpells<HolyTalents>
    {
        public async Task<bool> CrusaderStrikeMethod()
        {
            var target = Globals.CurrentTarget;
            if (target == null || target.IsFriendly || !target.IsAlive || !target.IsWithinMeleeRange)
                target = Unit.UnfriendlyPlayers.OrderBy(u => u.HealthPercent).FirstOrDefault(u => u.HealthPercent < 80 && Unit.EnemiesAttackingTarget(u) > 0 && u.IsWithinMeleeRange);

            if (target == null || !target.IsAlive) return false;

            if (!await CrusaderStrike.Cast(target))
                return false;

            LastSpell = CrusaderStrike;
            return true;
        }
    }
}