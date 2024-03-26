using System.Collections.Generic;

using NeoModLoader.General.Game;

using UnityEngine;

namespace ChoasWorld.Item
{
    internal class Wepons
    {
        public static void Init()
        {
            ItemAsset chaosDivineSword = ItemAssetCreator.CreateMeleeWeapon(
                id: "ChaosDivineSword"
                );
            //chaosDivineSword.id = "ChaosDivineSword";
            //chaosDivineSword.equipmentType = EquipmentType.Weapon;
            //chaosDivineSword.metallic = false;
            //chaosDivineSword.quality = ItemQuality.Legendary;
            //chaosDivineSword.name_templates = new List<string> { "混沌神剑", "混沌de大剑", "面向混沌!我就是神!", "编不下去了🥵" };
            //chaosDivineSword.rarity = 9999;
            //chaosDivineSword.equipment_value = 9999;
            //chaosDivineSword.base_stats[S.damage] = 300;
            //chaosDivineSword.base_stats[S.attack_speed] = 0f;
            //chaosDivineSword.base_stats[S.health] = 100f;
            //chaosDivineSword.base_stats[S.damage_range] = 0.5f;
        }
    }
}