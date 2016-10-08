using System.Threading.Tasks;
using System.Windows.Media;
using Paladin.Helpers;
using Paladin.Settings;
using Styx;
using Styx.Common;
using Styx.CommonBot.Coroutines;

namespace Paladin.SpellBooks.Specs.Retribution
{
    public partial class RetributionSpells : PaladinSpells<RetributionTalents>
    {
        /*public async Task<bool> Trinket1Method()
        {
            if (!Items.CanUseItem(Items.Trinket1))
                return false;

            if (PaladinSettings.Instance.Trinket1LossOfControl)
            {
                if (StyxWoW.Me.IsCrowdControlled())
                    await UseTrinket1();
                
                return false;
            }

            if (PaladinSettings.Instance.Trinket1OnCooldown)
                return await UseTrinket1();

            if (PaladinSettings.Instance.Trinket1OnBurst && StyxWoW.Me.HasAura(AvengingWrath.CRSpell.Id))
                return await UseTrinket1();

            if (PaladinSettings.Instance.Trinket1EnemyAdd && Unit.EnemyAdd)
                return await UseTrinket1();

            if (StyxWoW.Me.GotTarget && PaladinSettings.Instance.Trinket1EnemyHealthBelow && StyxWoW.Me.CurrentTarget.HealthPercent <= PaladinSettings.Instance.Trinket1EnemyHealth)
                return await UseTrinket1();

            if (PaladinSettings.Instance.Trinket1MyHealthBelow && Globals.MyHp <= PaladinSettings.Instance.Trinket1MyHealth)
                return await UseTrinket1();
            
            return false;
        }

        private async Task<bool> UseTrinket1()
        {
            Items.Trinket1.Use();
            Helpers.Logger.PrintLog(Colors.SpringGreen, "Using {0}", Items.Trinket1.Name);
            await CommonCoroutines.SleepForRandomUiInteractionTime();
            return true;
        }*/
    }
}
