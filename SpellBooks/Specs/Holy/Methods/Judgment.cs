using Paladin.Helpers;
using System.Threading.Tasks;
using Styx;
using System.Linq;

namespace Paladin.SpellBooks.Specs.Holy
{
    public partial class HolySpells : PaladinSpells<HolyTalents>
    {
        public async Task<bool> JudgmentMethod()
        {
            var target = Globals.CurrentTarget;
            if (target == null || target.IsFriendly || !target.IsAlive)
                target = Unit.UnfriendlyPlayers.OrderBy(u => u.HealthPercent).FirstOrDefault(u => u.HealthPercent < 80 && Unit.EnemiesAttackingTarget(u) > 0);

            if (target == null || !target.IsAlive) return false;

            if (!await Judgment.Cast(target))
                return false;

            LastSpell = Judgment;
            return true;
        }
    }
}