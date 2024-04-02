using System.IO;

using ChaosWorld.Item;
using ChaosWorld.status;

using NeoModLoader.api;
using NeoModLoader.General;

namespace ChoasWorld
{
    internal class ChaosWorld : BasicMod<ChaosWorld>
    {
        protected override void OnModLoad()
        {
            LogInfo("加载成功");
            Wepons.Init();
            Effects.init();
        }
    }
}