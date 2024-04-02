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
            heavyCurse.base_stats[S.speed] = -2f;
            heavyCurse.base_stats[S.attack_speed] = -2f;
            heavyCurse.base_stats[S.armor] = -2f;
            AssetManager.status.add(heavyCurse);
        }
    }
}