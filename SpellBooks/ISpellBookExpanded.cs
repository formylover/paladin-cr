using Paladin.SpellBooks.Talents;

namespace Paladin.SpellBooks
{
    public interface ISpellBookExpanded<T> : ISpellBook
        where T : ITalents
    {
        T MyTalents { get; set; }
        Spell LastSpell { get; set; }
    }
}
