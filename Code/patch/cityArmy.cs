using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

using HarmonyLib;

namespace ChaosWorld.Code.patch
{
    internal class cityArmy
    {
        [HarmonyPrefix, HarmonyPatch(typeof(City), "getArmyMaxTotalPercentage")]
        public static bool getArmyMaxTotalPercentage_Prefix(ref float __result)
        {
            __result = 0.95f;
            return false;
        }

        [HarmonyPrefix, HarmonyPatch(typeof(City), "tryToMakeWarrior")]
        public static bool tryToMakeWarrior_Prefix(ref bool __result, ref Actor pActor, City __instance)
        {
            if (__instance.isArmyFull())
            {
                __result = false;
                return false;
            }
            if (__instance.blacksmith == null)
            {
                __result = false;
                return false;
            }
            pActor.setProfession(UnitProfession.Warrior, true);
            if (pActor.equipment.weapon.isEmpty())
            {
                City.giveItem(pActor, __instance.getEquipmentList(EquipmentType.Weapon), __instance);
            }
            __instance.status.warriors_current++;
            __instance._timer_warrior = 0f;
            __result = true;
            return false;
        }
    }
}