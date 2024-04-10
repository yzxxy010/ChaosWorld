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
            harmony.PatchAll(typeof(attackSpeedMax));
            AssetManager.base_stats_library.get(S.attack_speed).normalize_max = int.MaxValue;
        }
    }
}