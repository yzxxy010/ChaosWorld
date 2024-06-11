using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosWorld.status
{
    internal class Effects
    {
        public static void init()
        {
            StatusEffect heavyCurse = new StatusEffect();
            heavyCurse.id = "heavyCurse";
            heavyCurse.name = "status_title_heavyCurse";
            heavyCurse.description = "status_description_heavyCurse";
            heavyCurse.duration = 2f;
            heavyCurse.path_icon = "Effects/e_heavyCurse";
            heavyCurse.action = EffectAction.heavyCurse_WorldAction;
            heavyCurse.action_interval = 2f;
            AssetManager.status.add(heavyCurse);
        }
    }
}