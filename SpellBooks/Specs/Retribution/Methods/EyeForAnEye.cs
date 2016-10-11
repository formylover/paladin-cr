using System.Threading.Tasks;

namespace Paladin.SpellBooks.Specs.Retribution
{
    public partial class RetributionSpells : PaladinSpells<RetributionTalents>
    {
        public async Task<bool> EyeForAnEyeMethod()
        {
            if (Helpers.Unit.EnemiesAroundTarget(Styx.StyxWoW.Me, 20) <= 0) return false;
            if (Paladin.Helpers.Globals.MyHp > Paladin.Settings.PaladinSettings.Instance.EyeForAnEyeHP) return false;

            if (!MyTalents.EyeForAnEye.IsActive())
                return false;

            if (!await EyeForAnEye.Cast(Styx.StyxWoW.Me))
                return false;

            LastSpell = EyeForAnEye;
            return true;
        }
    }
}
