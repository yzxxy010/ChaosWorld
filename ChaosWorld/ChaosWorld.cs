#define MOD_DEBUG_MODE
using ChaosWorld.Code;
using ChaosWorld.Item;
using ChaosWorld.patch;
using ChaosWorld.status;
using ChaosWorld_Debug;
using NeoModLoader.api;
using NeoModLoader.General;

using UnityEngine;

namespace ChoasWorld
{
    public class ChaosWorld : BasicMod<ChaosWorld>
    {
        public static bool removeInvincibleFrames;

        protected override void OnModLoad()
        {
            #if MOD_DEBUG_MODE
                DEBUG_MODE.isDEBUG = true;
            #endif
            DEBUG_MODE.Instance.Log("ChaosWorld loaded");
            removeInvincibleFrames = GetConfig()["chaosWorld config"]["invincible frame"].BoolVal;
            Wepons.Init();
            Effects.init();
            patchAll.Init();
            newButton.init();
        }
    }
}