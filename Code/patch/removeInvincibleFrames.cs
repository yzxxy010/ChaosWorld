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
        public static bool removeInvincibleFrames_Prefix(float pDamage, ref bool pFlash, AttackType pAttackType, ref BaseSimObject pAttacker, bool pSkipIfShake, bool pMetallicWeapon)
        {
            pSkipIfShake = !ChoasWorld.ChaosWorld.removeInvincibleFrames;
            return true;
        }
    }
}