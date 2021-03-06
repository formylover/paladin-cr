﻿using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using Paladin.Helpers;
using Paladin.Managers;
using Paladin.Settings;
using Styx;
using Styx.Common;
using Styx.WoWInternals.WoWObjects;

namespace Paladin.SpellBooks.Specs.Holy
{
    public partial class HolySpells : PaladinSpells<HolyTalents>
    {
        public async Task<bool> BlessingOfSacrificeMethod()
        {
            if (LastSpell == BlessingOfSacrifice) return false;

            // TODO setting for HP
            var target = Managers.Healing.HealList.FirstOrDefault(u => u.HealthPercent <= 80 && Unit.EnemiesAttackingTarget(u) > 0 && u != StyxWoW.Me);
            if (target == null) return false;

            Helpers.Logger.DiagnosticLog("Blessing of Sacrifice on {0}, Distance: {1}, LOS: {2}", target.SafeName, target.Distance, target.InLineOfSpellSight);

            return await BlessingOfSacrificeCast(target);
        }

        private async Task<bool> BlessingOfSacrificeCast(WoWUnit unit)
        {
            if (!await BlessingOfSacrifice.Cast(unit))
                return false;

            Helpers.Logger.PrintLog("Cast Hand of Sacrifice on {0} at {1}% health", unit.SafeName, unit.HealthPercent);

            LastSpell = BlessingOfSacrifice;
            return true;
        }
    }
}