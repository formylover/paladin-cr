using Styx.WoWInternals;

namespace Paladin.SpellBooks.Talents
{
    public class Talent
    {
        public string Name;
        public int Row;
        public int Column;
        public int ID;

        public bool IsActive()
        {
            return Lua.GetReturnVal<bool>(string.Format("local t = select(4, GetTalentInfo({0}, {1}, GetActiveSpecGroup())) if t then return 1 end return nil", Row, Column), 0);
        }
    }
}
