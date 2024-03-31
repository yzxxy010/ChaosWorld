using System.IO;

using ChaosWorld.Item;

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
        }
    }
}