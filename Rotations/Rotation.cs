using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

using Styx;
using Styx.Common;
using Styx.CommonBot;
using Styx.CommonBot.Coroutines;

using Paladin.Managers;
using Paladin.Helpers;
using Paladin.SpellBooks;
using Paladin.Settings;

namespace Paladin.Rotations
{
    public abstract class Rotation<S> : IRotation 
        where S : ISpellBook
    {
        public PaladinSettings Settings = PaladinSettings.Instance;

        private S _mySpells;
        public S MySpells
        {
            get
            {
                if (_mySpells == null)
                {
                    _mySpells = (S)Activator.CreateInstance(typeof(S));
                }
                return _mySpells;
            }
            set
            {
                _mySpells = value;
            }
        }

        public ISpellBook GetSpells()
        {
            return MySpells;
        }

        public abstract Task<bool> Death();

        public async Task<bool> Rest()
        {
            if (StyxWoW.Me.IsDead || StyxWoW.Me.IsGhost || Globals.Mounted)
                return false;

            // Check if we even need to rest
            if (StyxWoW.Me.HealthPercent >= PaladinSettings.Instance.RestingEatFoodHp && StyxWoW.Me.ManaPercent >= PaladinSettings.Instance.RestingDrinkWaterMp)
                return false;

            // Keep returning true if we're eating and don't have enough health yet
            if (StyxWoW.Me.HasAura("Food") && StyxWoW.Me.HealthPercent < PaladinSettings.Instance.RestingEatFoodHp)
                return true;

            // Keep returning true if we're drinking and don't have enough mana yet
            if (StyxWoW.Me.HasAura("Drink") && StyxWoW.Me.ManaPercent < PaladinSettings.Instance.RestingDrinkWaterMp)
                return true;

            // Flash of Light if we have more MP than setting but need a heal
            if (StyxWoW.Me.HealthPercent <= PaladinSettings.Instance.RestingEatFoodHp && StyxWoW.Me.ManaPercent > PaladinSettings.Instance.RestingDrinkWaterMp)
            {
                await MySpells.RestHealSpell.Cast(StyxWoW.Me);
                return true;
            }

            // Can't eat or drink if we're swimming
            if (StyxWoW.Me.IsSwimming)
                return false;

            // Eat food if our health is less than our setting
            if (PaladinSettings.Instance.RestingEatFood && StyxWoW.Me.HealthPercent < PaladinSettings.Instance.RestingEatFoodHp)
            {
                // Check if we even have food
                if (Styx.CommonBot.Rest.NoFood)
                {
                    Helpers.Logger.PrintLog("We don't have any food");
                    return false;
                }

                Styx.CommonBot.Rest.FeedImmediate();
                await CommonCoroutines.SleepForLagDuration();
                return true;
            }

            // Eat food if our health is less than our setting
            if (PaladinSettings.Instance.RestingDrinkWater && StyxWoW.Me.ManaPercent < PaladinSettings.Instance.RestingDrinkWaterMp)
            {
                // Check if we even have food
                if (Styx.CommonBot.Rest.NoDrink)
                {
                    Helpers.Logger.PrintLog("We don't have any drinks");
                    return false;
                }

                Styx.CommonBot.Rest.DrinkImmediate();
                await CommonCoroutines.SleepForLagDuration();
                return true;
            }

            return false;
        }

        public abstract Task<bool> PreCombatBuff();
        public abstract Task<bool> PullBuff();
        public abstract Task<bool> Pull();
        public abstract Task<bool> Heal();
        public abstract Task<bool> CombatBuff();
        public abstract Task<bool> Combat();

        public async Task<bool> MoveToTarget()
        {
            await Movement.MovementFacing();
            return false;
        }

        public void AutoTarget()
        {
            if (!PaladinSettings.Instance.AutoTarget) return;

            // TODO select best target in pvp
            if (Globals.CurrentTarget != null) return;

            var units = Unit.UnfriendlyUnits.Where(u => u.Aggro && u.Distance <= 30).OrderBy(u => u.Distance).ThenBy(u => u.HealthPercent).ToList();
            var target = units.FirstOrDefault();

            if (target == null) return;

            Helpers.Logger.DiagnosticLog("Selecting {0} as Target", target.SafeName);

            target.Target();
        }
    }
}
