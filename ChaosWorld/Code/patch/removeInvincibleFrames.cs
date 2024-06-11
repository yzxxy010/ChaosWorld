using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HarmonyLib;

namespace ChaosWorld.patch
{
    internal class removeInvincibleFrames
    {
        [HarmonyPrefix, HarmonyPatch(typeof(Actor), "getHit")]
        public static bool removeInvincibleFrames_Prefix(ref bool pSkipIfShake)
        {
            pSkipIfShake = !ChoasWorld.ChaosWorld.removeInvincibleFrames;

            return true;
        }
    }
}