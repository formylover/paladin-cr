using System.Threading.Tasks;
using System.Windows.Media;
using Paladin.Helpers;
using Paladin.Settings;
using System;
using Styx;
using Styx.Common;

namespace Paladin.SpellBooks.Specs.Protection
{
    public partial class ProtectionSpells : PaladinSpells<ProtectionTalents>
    {
        public async Task<bool> BurstMethod()
        {
            if (Global.Burst.Check(AvengingWrath))
                return await CastBurst();

            if (StyxWoW.Me.HasAura(AvengingWrath.CRSpell.Id))
                return await CastBastionOfLight();

            return false;
        }

        private async Task<bool> CastBurst()
        {
            if (!await AvengingWrath.Cast(StyxWoW.Me))
                return false;
            
            Helpers.Logger.PrintLog("Activating Burst");

            LastSpell = AvengingWrath;
            return true;
        }

        private async Task<bool> CastBastionOfLight()
        {
            if (ShieldOfTheRighteous.CRSpell.GetChargeInfo().ChargesLeft > 0)
                return false;

            if (!await BastionOfLight.Cast(StyxWoW.Me))
                return false;

            LastSpell = BastionOfLight;
            return true;
        }
    }
}
