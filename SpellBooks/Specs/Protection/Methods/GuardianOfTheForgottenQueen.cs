using Styx.WoWInternals.WoWObjects;
using System.Threading.Tasks;
using Styx;
using Paladin.Helpers;
using Paladin.Managers;

namespace Paladin.SpellBooks.Specs.Protection
{
    public partial class ProtectionSpells : PaladinSpells<ProtectionTalents>
    {
        public async Task<bool> GuardianOfTheForgottenQueenMethod()
        {
            // TODO
            if (!Styx.CommonBot.SpellManager.HasSpell(GuardianOfTheForgottenQueen.ID))
            if (GuardianOfTheForgottenQueen.CRSpell.Cooldown) return false;
            
            
            if (!await GuardianOfTheForgottenQueen.Cast(StyxWoW.Me))
                return false;

            LastSpell = GuardianOfAncientKings;
            return true;
        }
    }
}