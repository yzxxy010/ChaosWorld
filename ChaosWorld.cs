using NeoModLoader.api;
using NeoModLoader.General;

namespace ChoasWorld
{
    internal class ChaosWorld : BasicMod<ChaosWorld>
    {
        protected override void OnModLoad()
        {
            string temp = LM.Get("temp");
            LogInfo(temp);
        }
    }
}