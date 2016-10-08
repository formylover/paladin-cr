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

            return false;
        }

        private async Task<bool> CastBurst()
        {
            if (await AvengingWrath.Cast(StyxWoW.Me))
            {
                Helpers.Logger.PrintLog("Activating Burst");

                LastSpell = AvengingWrath;
                return true;
            }

            return false;
        }
    }
}
