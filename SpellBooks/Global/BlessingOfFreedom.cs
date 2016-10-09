using Paladin.Helpers;
using Paladin.Settings;
using System.Collections.Generic;
using Styx;
using Styx.WoWInternals;
using System.Linq;
using Styx.WoWInternals.WoWObjects;

namespace Paladin.SpellBooks.Global
{
    public static class BlessingOfFreedom
    {
        public static WoWUnit Check(Spell spell)
        {
            if (!PaladinSettings.Instance.UseBoF) return null;
            if (spell.CRSpell.Cooldown) return null;

            WoWUnit target = null;
            if (StyxWoW.Me.HasAuraWithMechanic(WoWSpellMechanic.Rooted, WoWSpellMechanic.Slowed, WoWSpellMechanic.Snared))
            {
                Helpers.Logger.DiagnosticLog("Hand of Freedom using on self");
                return StyxWoW.Me;
            }

            if (!Globals.Arena) return null;

            if (PaladinSettings.Instance.UseBoFGroup && Globals.InParty)
            {
                if (!Unit.GroupMembers.Any(x => x.IsAlive && x.Distance <= 40 && x.InLineOfSpellSight && x != StyxWoW.Me)) return null;

                IEnumerable<WoWPlayer> targets = Unit.GroupMembers.Where(u =>
                    !u.HasAura(spell.CRSpell.Id) &&
                    u.HasAuraWithMechanic(WoWSpellMechanic.Dazed,
                                          WoWSpellMechanic.Disoriented,
                                          WoWSpellMechanic.Frozen,
                                          WoWSpellMechanic.Incapacitated,
                                          WoWSpellMechanic.Rooted,
                                          WoWSpellMechanic.Slowed,
                                          WoWSpellMechanic.Snared) &&
                                          u.Distance <= 40 &&
                                          u.InLineOfSight).OrderBy(u => u.HealthPercent);

                if (PaladinSettings.Instance.UseBoFDPS && PaladinSettings.Instance.UseBoFHeal && PaladinSettings.Instance.UseBoFTank)
                    target = targets.FirstOrDefault();

                if (target == null && PaladinSettings.Instance.UseBoFDPS)
                    target = targets.FirstOrDefault(u => u.IsDps);

                if (target == null && PaladinSettings.Instance.UseBoFHeal)
                    target = targets.FirstOrDefault(u => u.IsHealer);

                if (target == null && PaladinSettings.Instance.UseBoFTank)
                    target = targets.FirstOrDefault(u => u.IsTank);
            }

            return target;
        }
    }
}
