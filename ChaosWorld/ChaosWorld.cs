using System.Diagnostics;

using ChaosWorld.Code;
using ChaosWorld.Item;
using ChaosWorld.patch;
using ChaosWorld.status;

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
            removeInvincibleFrames = GetConfig()["chaosWorld config"]["invincible frame"].BoolVal;
            Wepons.Init();
            Effects.init();
            patchAll.Init();
            newButton.init();
        }
    }
}