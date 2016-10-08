using System;
using System.Threading.Tasks;
using Paladin.Helpers;

namespace Paladin.SpellBooks.Specs.Retribution
{
    public partial class RetributionSpells : PaladinSpells<RetributionTalents>
    {
        public async Task<bool> SealOfLightMethod()
        {
            if (!MyTalents.SealOfLight.IsActive())
                return false;

            if (Styx.StyxWoW.Me.AuraTimeLeft(SealOfLight.ID) > TimeSpan.FromSeconds(2)) return false;

            if (!await SealOfLight.Cast())
                return false;

            LastSpell = SealOfLight;
            return true;
        }
    }
}
