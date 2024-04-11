using ChaosWorld.Code.patch;

using HarmonyLib;

using UnityEngine;

namespace ChaosWorld.patch
{
    internal class patchAll
    {
        public static void Init()
        {
            Harmony harmony = new Harmony("xingyao.mod.worldbox.chaosWorld");
            harmony.PatchAll(typeof(removeInvincibleFrames));
            actorAttribute.init(harmony);
            projectileAttackSpeed.init();
        }
    }
}