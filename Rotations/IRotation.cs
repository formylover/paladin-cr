using System.Threading.Tasks;
using Paladin.SpellBooks;

namespace Paladin.Rotations
{
    public interface IRotation
    {
        ISpellBook GetSpells();

        Task<bool> Death();
        Task<bool> Rest();
        Task<bool> MoveToTarget();
        Task<bool> PreCombatBuff();
        Task<bool> PullBuff();
        Task<bool> Pull();
        Task<bool> Heal();
        Task<bool> CombatBuff();
        Task<bool> Combat();
    }
}
