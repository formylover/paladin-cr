using System.Threading.Tasks;

namespace Paladin.SpellBooks.Specs.Retribution
{
    public partial class RetributionSpells : PaladinSpells<RetributionTalents>
    {
        public async Task<bool> BladeOfWrathMethod()
        {
            if (Helpers.Globals.CurrentTarget == null) return false;
            if (BladeOfWrath.CRSpell.Cooldown) return false;

            if (!Styx.StyxWoW.Me.IsFacing(Helpers.Globals.CurrentTarget)) return false;

            if (!MyTalents.BladeOfWrath.IsActive())
                return false;

            if (!await BladeOfWrath.Cast())
                return false;

            LastSpell = BladeOfWrath;
            return true;
        }
    }
}
