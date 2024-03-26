using NeoModLoader.api;
using NeoModLoader.General;

namespace ChoasWorld
{
    internal class ChoasWorld : BasicMod<ChoasWorld>
    {
        protected override void OnModLoad()
        {
            string temp = LM.Get("temp");
            LogInfo(temp);
        }
    }
}