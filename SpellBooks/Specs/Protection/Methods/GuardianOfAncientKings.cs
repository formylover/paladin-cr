using Styx.WoWInternals.WoWObjects;
using System.Threading.Tasks;
using Styx;
using Paladin.Helpers;
using Paladin.Managers;

namespace Paladin.SpellBooks.Specs.Protection
{
    public partial class ProtectionSpells : PaladinSpells<ProtectionTalents>
    {
        public async Task<bool> GuardianOfAncientKingsMethod()
        {
            if (GuardianOfAncientKings.CRSpell.Cooldown) return false;

            if (Globals.MyHp > Paladin.Settings.PaladinSettings.Instance.GuardianOfAncientKings) return false;
            if (Unit.EnemiesAttackingTarget(StyxWoW.Me) <= 0) return false;
            
            if (!await GuardianOfAncientKings.Cast(StyxWoW.Me))
                return false;

            LastSpell = GuardianOfAncientKings;
            return true;
        }
    }
}