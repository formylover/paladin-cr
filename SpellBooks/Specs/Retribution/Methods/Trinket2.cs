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
        /*public async Task<bool> Trinket2Method()
        {
            if (!Items.CanUseItem(Items.Trinket2))
                return false;

            if (PaladinSettings.Instance.Trinket2LossOfControl)
            {
                if (StyxWoW.Me.IsCrowdControlled())
                    await UseTrinket2();

                return false;
            }

            if (PaladinSettings.Instance.Trinket2OnCooldown)
                return await UseTrinket2();

            if (PaladinSettings.Instance.Trinket2OnBurst && StyxWoW.Me.HasAura(AvengingWrath.CRSpell.Id))
                return await UseTrinket2();

            if (PaladinSettings.Instance.Trinket2EnemyAdd && Unit.EnemyAdd)
                return await UseTrinket2();

            if (StyxWoW.Me.GotTarget && PaladinSettings.Instance.Trinket2EnemyHealthBelow && StyxWoW.Me.CurrentTarget.HealthPercent <= PaladinSettings.Instance.Trinket2EnemyHealth)
                return await UseTrinket2();

            if (PaladinSettings.Instance.Trinket2MyHealthBelow && Globals.MyHp <= PaladinSettings.Instance.Trinket2MyHealth)
                return await UseTrinket2();

            return false;
        }

        private async Task<bool> UseTrinket2()
        {
            Items.Trinket2.Use();
            Helpers.Logger.PrintLog(Colors.SpringGreen, "Using {0}", Items.Trinket2.Name);
            await CommonCoroutines.SleepForRandomUiInteractionTime();
            return true;
        }*/
    }
}