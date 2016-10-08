using Paladin.Helpers;
using Paladin.Settings;
using Styx;

namespace Paladin.SpellBooks.Global
{
    public static class BlindingLight
    {
        public static bool Check(Spell spell, Talents.Talent talent)
        {
            if (!talent.IsActive()) return false;

            // TODO add DR tracker
            return Unit.EnemiesAroundTarget(Styx.StyxWoW.Me, 10) >= Paladin.Settings.PaladinSettings.Instance.BlindingLightTargets;
        }
    }
}
