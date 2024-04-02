using System.Collections.Generic;
using NeoModLoader.General;
using NeoModLoader.General.Game;
using NeoModLoader.api;
using ReflectionUtility;
using UnityEngine;

namespace ChaosWorld.Item
{
    internal class Wepons
    {
        public static void Init()
        {
            ItemAsset chaosDivineSword = AssetManager.items.clone("chaosDivineSword", "sword");
            chaosDivineSword.id = "chaosDivineSword";
            chaosDivineSword.pool = "melee";
            chaosDivineSword.attackType = WeaponType.Melee;
            chaosDivineSword.equipmentType = EquipmentType.Weapon;
            chaosDivineSword.name_class = "item_class_weapon";
            chaosDivineSword.materials = List.Of<string>(new string[] { "base" });
            chaosDivineSword.path_slash_animation = "effects/slashes/slash_sword";
            chaosDivineSword.rarity = 9999;
            chaosDivineSword.equipment_value = 9999;
            chaosDivineSword.base_stats[S.damage] = 300f;
            chaosDivineSword.base_stats[S.attack_speed] = 0.5f;
            chaosDivineSword.base_stats[S.health] = 1000f;
            chaosDivineSword.base_stats[S.range] = 0.5f;
            chaosDivineSword.action_attack_target = ItemSkill.chaosDivineSword_AttackAction;
            chaosDivineSword.name_templates = Toolbox.splitStringIntoList(new string[]
          {
            "sword_name#30"
          });
            chaosDivineSword.path_icon = "Weapons/w_chaosDivineSword_base";
            AssetManager.items.add(chaosDivineSword);
            addItemSprite(chaosDivineSword.id, chaosDivineSword.materials[0]);

            ItemAsset knitter = AssetManager.items.clone("knitter", "bow");
            knitter.id = "knitter";
            knitter.pool = "range";
            knitter.attackType = WeaponType.Range;
            knitter.equipmentType = EquipmentType.Weapon;
            knitter.name_class = "item_class_weapon";
            knitter.materials = List.Of<string>(new string[] { "base" });
            knitter.path_slash_animation = "effects/slashes/slash_bow";
            knitter.rarity = 9999;
            knitter.equipment_value = 9999;
            knitter.base_stats[S.damage] = 45f;
            knitter.base_stats[S.attack_speed] = 0.5f;
            knitter.base_stats[S.health] = 150f;
            knitter.base_stats[S.range] = 8f;
            knitter.base_stats[S.armor] = 20f;
            knitter.action_attack_target = ItemSkill.knitter_AttackAction;
            chaosDivineSword.name_templates = Toolbox.splitStringIntoList(new string[]
          {
            "bow_name#30"
          });
            knitter.path_icon = "Weapons/w_knitter_base";
            AssetManager.items.add(knitter);
            addItemSprite(knitter.id, knitter.materials[0]);
        }

        public static void addItemSprite(string id, string material)
        {
            var dictItems = Reflection.GetField(typeof(ActorAnimationLoader), null, "dictItems") as Dictionary<string, Sprite>;
            var sprite = Resources.Load<Sprite>("Weapons/w_" + id + "_" + material);
            dictItems.Add(sprite.name, sprite);
        }
    }
}