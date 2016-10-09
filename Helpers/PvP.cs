using System;
using System.Collections.Generic;
using Styx;
using Styx.WoWInternals;
using System.Linq;
using Styx.WoWInternals.WoWObjects;
using System.Diagnostics;
using Paladin.Settings;

namespace Paladin.Helpers
{
    public static class PvP
    {
        public static bool IsCastingSpellWithEffect(this WoWUnit unit, params WoWSpellMechanic[] mechanics)
        {
            if (!unit.IsCasting) return false;

            if (mechanics.Contains(unit.CastingSpell.Mechanic)) return true;

            return false;
        }

        public static bool IsCastingBigDamageSpell(this WoWUnit unit)
        {
            if (!unit.IsCasting) return false;

            int[] badSpells = new int[]
            {
                199786, // mage - glacial spikle
                116858, // lock - chaos bolt
                203286, // mage - greater pyroblast
                202771, // druid - full moon
            };

            return badSpells.Contains(unit.CastingSpell.Id);
        }

        public static bool HasCooldownsRunning(this WoWUnit unit)
        {
            int[] cooldowns = new int[]
            {
                31884, // pala - avanging wrath
                224668, // pala - crusade
                191427, // dh - metamorphosis
                19574, // hunter - bestial wrath
                193526, // hunter - trueshot
                106951, // feral - berserk
                190319, // mage - combustion
                80353, // mage - timewarp
                198144, // mage - ice form
                //137639, // monk - storm ice and fire TODO no aura?
                13750, // rogue - adrenaline rush
                202665, // rogue - curse of the dreadblades
                121471, // rogue - shadow blades
                185313, // rogue - shadow dance
                79140, // rogue - vendetta
                192759, // rogue - kingsbane
                204945, // shaman - doom winds
                114050, // shaman - ascendance
                16166, // shaman - elemental mastery
                1719, // warrior - battle cry
                107574, // warrior - avatar
                118000, // warrior - dragon roar
                12292, // warrior - bloodbath
            };

            return unit.HasAnyAura(cooldowns);
        }

        public static WoWUnit GetTotemToStomp()
        {
            if (!Globals.Pvp) return null;
            if (!PaladinSettings.Instance.PvpDestroyTotems) return null;

            var totems = Unit.UnfriendlyUnits.Where(u => u.IsTotem && u.Distance < 40).ToList();

            var counterStrike = totems.FirstOrDefault(t => t.SafeName == "Counterstrike Totem");
            if (counterStrike != null) return counterStrike;

            return totems.FirstOrDefault(t => t.SafeName == "Earthbind Totem" || t.SafeName == "Windfury Totem");
        }

        private static readonly Stopwatch AcceptTimer = new Stopwatch();
        private static int AcceptingTime;
        private static int InviteIndex = -1;
        private static string QueueType;

        public static void CheckInvite()
        {
            if (!PaladinSettings.Instance.AutoAcceptQueue) return;
            if (!StyxWoW.IsInGame) return;
            if (InviteIndex > 0) return;
            
            for (int i = 1; i <= 3; i++)
            {
                List<string> BGStatus = Lua.GetReturnValues("return GetBattlefieldStatus(" + i + ")");
                
                if (BGStatus[0] == "confirm")
                {
                    QueueType = BGStatus[5];

                    switch (BGStatus[5])
                    {
                        case "BATTLEGROUND":
                            break;
                        case "ARENASKIRMISH":
                            break;
                    }
                    int delay = new Random().Next(2000, 10000);
                    Helpers.Logger.PrintLog("Queue Pop, accepting in " + delay.ToString());
                    AcceptingTime = delay;
                    InviteIndex = i;

                    if (!AcceptTimer.IsRunning)
                        AcceptTimer.Start();

                    break;
                }
            }
        }

        public static void AcceptInvite()
        {
            if (!StyxWoW.IsInGame) return;
            if (InviteIndex < 0) return;
            if (AcceptTimer.ElapsedMilliseconds < AcceptingTime) return;

            Lua.DoString("AcceptBattlefieldPort(" + InviteIndex + ", 1)");
            switch (QueueType)
            {
                case "ARENASKIRMISH":
                    Lua.DoString("StaticPopup_Hide(\"ARENA_TEAM_INVITE\")");
                    break;
                default:
                    Lua.DoString("StaticPopup_Hide(\"CONFIRM_BATTLEFIELD_ENTRY\")");
                    break;
            }

            AcceptTimer.Stop();
            AcceptTimer.Reset();
            AcceptingTime = 0;
            InviteIndex = -1;
            QueueType = null;
        }
    }
}
