using System.Collections.Generic;
using NeoModLoader.General;
using NeoModLoader.General.Game;
using NeoModLoader.api;
using ReflectionUtility;
using UnityEngine;
using NCMS.Utils;

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
            chaosDivineSword.base_stats[S.damage] = 300;
            chaosDivineSword.base_stats[S.attack_speed] = 0f;
            chaosDivineSword.base_stats[S.health] = 100f;
            chaosDivineSword.base_stats[S.damage_range] = 0.5f;
            chaosDivineSword.action_attack_target = AttackAction;
            chaosDivineSword.name_templates = Toolbox.splitStringIntoList(new string[]
          {
            "chaosDivineSword_name"
          });
            chaosDivineSword.path_icon = "Weapons/w_chaosDivineSword_base";
            AssetManager.items.add(chaosDivineSword);
            addItemSprite(chaosDivineSword.id, chaosDivineSword.materials[0]);
            LM.Add("cz", "item_chaosDivineSword", "混沌神剑");
        }

        public static void addItemSprite(string id, string material)
        {
            var dictItems = Reflection.GetField(typeof(ActorAnimationLoader), null, "dictItems") as Dictionary<string, Sprite>;
            var sprite = Resources.Load<Sprite>("Weapons/w_" + id + "_" + material);
            dictItems.Add(sprite.name, sprite);
        }

        public static bool AttackAction(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile = null)
        {
            if (pSelf != null)
            {
                Actor attacker = Reflection.GetField(pSelf.GetType(), pSelf, "a") as Actor;
                Actor victim = Reflection.GetField(pTarget.GetType(), pTarget, "a") as Actor;
                if (victim == null)
                {
                    return false;
                }
                float totalInjury = attacker.asset.base_stats[S.damage] * 1.2f;
                victim.base_data.health = victim.base_data.health - (int)(totalInjury * 3);
                return true;
            }
            return false;
        }
    }
}