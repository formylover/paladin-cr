using System.Threading.Tasks;
using Paladin.SpellBooks;

namespace Paladin.Rotations.Specs
{
    public class None :IRotation
    {
        public ISpellBook GetSpells()
        {
            return null;
        }

        public async Task<bool> MoveToTarget() { return false; }

        public async Task<bool> Death() { return false; }
        public async Task<bool> Rest() { return false; }
        public async Task<bool> PreCombatBuff() { return false; }
        public async Task<bool> PullBuff() { return false; }
        public async Task<bool> Pull() { return false; }
        public async Task<bool> Heal() { return false; }
        public async Task<bool> CombatBuff() { return false; }
        public async Task<bool> Combat() { return false; }
    }
}
