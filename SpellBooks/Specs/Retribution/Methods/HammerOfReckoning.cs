using System.Threading.Tasks;
using Paladin.Helpers;
using Paladin.Settings;

using System;

namespace Paladin.SpellBooks.Specs.Retribution
{
    public partial class RetributionSpells : PaladinSpells<RetributionTalents>
    {
        public async Task<bool> HammerOfReckoningMethod()
        {
            if (!Styx.CommonBot.SpellManager.HasSpell(HammerOfReckoning.ID)) return false;
            if (Globals.CurrentTarget == null) return false;
            if (HammerOfReckoning.CRSpell.Cooldown) return false;

            if (Globals.CurrentTarget.HealthPercent > PaladinSettings.Instance.HammerOfReckoningHealth) return false;

            var aura = Styx.StyxWoW.Me.GetAuraById(204940);
            if (aura == null || aura.TimeLeft <= TimeSpan.Zero) return false;
            
            if (!Cooldowns && aura.StackCount < 75) return false;

            Helpers.Logger.DiagnosticLog("Casting Hammer of Reckoning on {0} with {1} stacks", Globals.CurrentTarget.SafeName, aura.StackCount);

            if (!await HammerOfReckoning.Cast(Globals.CurrentTarget))
                return false;

            LastSpell = HammerOfReckoning;
            return true;
        }
    }
}
