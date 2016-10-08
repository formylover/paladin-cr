﻿using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using Paladin.Helpers;
using Paladin.Settings;
using Styx;
using Styx.Common;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace Paladin.SpellBooks.Global
{
    public static class HammerOfJustice
    {
        public static WoWUnit Check(Spell spell)
        {
            // TODO interrupt logic

            if (!PaladinSettings.Instance.HoJUse) return null;
            if (spell.CRSpell.Cooldown) return null;

            // Use HoJ on cooldown
            if (PaladinSettings.Instance.HoJUseOnCooldown)
            {
                if (Globals.CurrentTarget != null)
                    return Globals.CurrentTarget;
            }

            if (!Globals.Pvp) return null; // TODO

            // Create a list of targets we can use HoJ on
            var hojList = Unit.UnfriendlyUnits.Where(u => u.InLineOfSpellSight && u.Distance <= spell.CRSpell.MaxRange && !u.HasAuraWithMechanic(WoWSpellMechanic.Dazed,
                                          WoWSpellMechanic.Disoriented,
                                          WoWSpellMechanic.Frozen,
                                          WoWSpellMechanic.Incapacitated,
                                          WoWSpellMechanic.Fleeing,
                                          WoWSpellMechanic.Stunned,
                                          WoWSpellMechanic.Sapped,
                                          WoWSpellMechanic.Polymorphed,
                                          WoWSpellMechanic.Horrified,
                                          WoWSpellMechanic.Charmed)).ToList(); // TODO check this perhaps hardcode it to 10 without talent

            if (PaladinSettings.Instance.HoJInterrupt && Globals.CurrentTarget.HealthPercent < PaladinSettings.Instance.HoJTargetBelow)
            {
                var unit = hojList.FirstOrDefault(u => ((PaladinSettings.Instance.HoJInterruptHeal && u.IsCastingHealingSpell)
                                          || (PaladinSettings.Instance.HoJInterruptCC && u.IsCastingSpellWithEffect(WoWSpellMechanic.Dazed,
                                          WoWSpellMechanic.Disoriented,
                                          WoWSpellMechanic.Frozen,
                                          WoWSpellMechanic.Incapacitated,
                                          WoWSpellMechanic.Rooted,
                                          WoWSpellMechanic.Slowed,
                                          WoWSpellMechanic.Snared))));

                return unit;
            }

            // Enemy casting on us
            /*if (PaladinSettings.Instance.HoJUseEnemyCastingOnMe)
            {
                var unit = hojList.FirstOrDefault(u => u.CurrentTarget == StyxWoW.Me && u.IsCasting);

                if (unit != null)
                    return await CastHoj(unit);
            }*/

            return null;
        }
    }
}