using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using Buddy.Coroutines;
using Paladin.Helpers;
using Paladin.Settings;
using Styx;
using Styx.Common;
using Styx.WoWInternals;

namespace Paladin.SpellBooks.Specs.Protection
{
    public partial class ProtectionSpells : PaladinSpells<ProtectionTalents>
    {
        public async Task<bool> RacialsMethod()
        {
            // TODO unify all specs to one helper

            if (!PaladinSettings.Instance.RacialUse)
                return false;

            if (PaladinSettings.Instance.UseTrinket)
            {
                // TODO add PvP Trinket
                // Glad Med - ID 208683
            }

            switch (StyxWoW.Me.Race)
            {
                case WoWRace.Human:
                    return await Human();

                case WoWRace.Draenei:
                    return await Draenei();

                case WoWRace.Dwarf:
                    return await Drawf();

                case WoWRace.BloodElf:
                    return await BloodElf();

                case WoWRace.Tauren:
                    return await Tauren();
            }

            return false;
        }

        #region Human
        private async Task<bool> Human()
        {
            if (!PaladinSettings.Instance.EveryManForHimselfUse)
                return false;

            if (EveryManForHimself.CRSpell.Cooldown)
                return false;

            if (!StyxWoW.Me.HasAuraWithMechanic(WoWSpellMechanic.Stunned))
                return false;

            var aura = StyxWoW.Me.GetAuraWithMechanic(WoWSpellMechanic.Stunned);
            if (aura == null) return false;
            if (aura.TimeLeft.TotalSeconds < 3) return false;
            
            if (!await EveryManForHimself.Cast(StyxWoW.Me))
                return false;

            Helpers.Logger.PrintLog("Used Every Man for Himself");
            LastSpell = EveryManForHimself;

            return true;
        }
        #endregion

        #region Draenei
        private async Task<bool> Draenei()
        {
            if (!PaladinSettings.Instance.GiftOfTheNaaruUse)
                return false;

            if (GiftOfTheNaaru.CRSpell.Cooldown)
                return false;

            if (StyxWoW.Me.HealthPercent <= PaladinSettings.Instance.GiftOfTheNaaruHealHp)
            {
                if (!await GiftOfTheNaaru.Cast(StyxWoW.Me))
                    return false;

                Helpers.Logger.PrintLog("Used Gift of the Naaru on ourself at {0}%", StyxWoW.Me.HealthPercent);
            }

            if (!PaladinSettings.Instance.GiftOfTheNaaruHealGroup)
                return false;

            if (!StyxWoW.Me.GroupInfo.IsInParty || !StyxWoW.Me.GroupInfo.IsInRaid)
                return false;

            var target = Unit.GroupMembers.FirstOrDefault(u =>
                u.Distance <= 40 &&
                u.InLineOfSight &&
                u.HealthPercent <= PaladinSettings.Instance.GiftOfTheNaaruHealHp);

            if (target == null)
                return false;

            if (!await GiftOfTheNaaru.Cast(target))
                return false;

            Helpers.Logger.PrintLog("Used Gift of the Naaru on ourself on {0} at {1}%", target.SafeName, StyxWoW.Me.HealthPercent);

            return true;
        }
        #endregion

        #region Dwarf
        private async Task<bool> Drawf()
        {
            if (!PaladinSettings.Instance.StoneformUse)
                return false;

            if (!PaladinSettings.Instance.StoneformUseOnlyToClearDot && StyxWoW.Me.HealthPercent <= PaladinSettings.Instance.StoneformUseHp)
            {
                if (!await Stoneform.Cast(StyxWoW.Me))
                    return false;

                Helpers.Logger.PrintLog("Used Stoneform at {0}", StyxWoW.Me.HealthPercent);

                return true;
            }

            if (!PaladinSettings.Instance.StoneformUseOnlyToClearDot)
                return false;

            // If I don't have a bleed effect, poison, magic, curse or disease on me return false
            if (!StyxWoW.Me.HasAuraWithMechanic(WoWSpellMechanic.Bleeding) ||
                !StyxWoW.Me.Debuffs.Values.Any(u => u.Spell.DispelType == WoWDispelType.Poison ||
                                                   u.Spell.DispelType == WoWDispelType.Magic ||
                                                   u.Spell.DispelType == WoWDispelType.Curse ||
                                                   u.Spell.DispelType == WoWDispelType.Disease))
                return false;

            if (!await Stoneform.Cast(StyxWoW.Me))
                return false;

            Helpers.Logger.PrintLog("Used Stoneform to remove negative effect");

            return true;
        }
        #endregion

        #region Blood Elf
        private async Task<bool> BloodElf()
        {
            if (!PaladinSettings.Instance.ArcaneTorrentUse)
                return false;

            // We don't wanna waste both our interrupts
            if (PaladinSettings.Instance.RebukeUse && !Rebuke.CRSpell.Cooldown)
                return false;

            if (!StyxWoW.Me.GotTarget)
                return false;

            if (StyxWoW.Me.CurrentTarget.IsPet)
                return false;

            if (!StyxWoW.Me.CurrentTarget.IsCasting)
                return false;

            // Get the spell ID our target is casting
            var spell = StyxWoW.Me.CurrentTarget.CastingSpell;

            if (!PaladinCR.InterruptDict.ContainsKey(spell.Id))
                return false;

            var rnd = new Random();
            var delay = rnd.Next(50, 500);

            await Coroutine.Sleep(delay);

            if (StyxWoW.Me.CurrentTarget.Distance > 8)
                return false;

            if (!await ArcaneTorrent.Cast(StyxWoW.Me))
                return false;

            Helpers.Logger.PrintLog("Used Arcane Torrent on {0}", StyxWoW.Me.CurrentTarget.SafeName);

            return true;
        }
        #endregion

        #region Tauren
        private async Task<bool> Tauren()
        {
            if (!PaladinSettings.Instance.WarStompUse)
                return false;

            if (Unit.EnemiesInRange(8) < PaladinSettings.Instance.WarStompEnemiesToUse)
                return false;

            if (!await WarStomp.Cast(StyxWoW.Me))
                return false;

            Helpers.Logger.PrintLog("Used War Stomp");

            return true;
        }
        #endregion
    }
}
