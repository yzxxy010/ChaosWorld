using System.Collections.Generic;

using NCMS.Utils;

using NeoModLoader.General;
using NeoModLoader.General.Game;

using ReflectionUtility;

using UnityEngine;

namespace ChaosWorld.Item
{
    internal class Wepons
    {
        public static void Init()
        {
            BaseStats chaosSwordStats = new BaseStats();
            chaosSwordStats[S.damage] = 300;
            chaosSwordStats[S.attack_speed] = 0f;
            chaosSwordStats[S.health] = 100f;
            chaosSwordStats[S.damage_range] = 0.5f;
            ItemAsset chaosDivineSword = ItemAssetCreator.CreateMeleeWeapon(
                id: "ChaosDivineSword",
                base_stats: chaosSwordStats,
                materials: new List<string> { "steel" },
                name_templates: new List<string> { "混沌神剑", "混沌de大剑", "面向混沌!我就是神!", "编不下去了🥵" },
                action_attack_target: AttackAction,
                equipment_value: 9999,
                name_class: "item_class_weapon"
                );
            Localization.addLocalization("item_" + chaosDivineSword.id, LM.Get(chaosDivineSword.id));
            addWeaponsSprite(chaosDivineSword);

            chaosDivineSword.id = "ChaosDivineSword";
            chaosDivineSword.equipmentType = EquipmentType.Weapon;
            chaosDivineSword.metallic = false;
            chaosDivineSword.quality = ItemQuality.Legendary;
            chaosDivineSword.name_templates = new List<string> { "混沌神剑", "混沌de大剑", "面向混沌!我就是神!", "编不下去了🥵" };
            chaosDivineSword.rarity = 9999;
            chaosDivineSword.equipment_value = 9999;
            chaosDivineSword.base_stats[S.damage] = 300;
            chaosDivineSword.base_stats[S.attack_speed] = 0f;
            chaosDivineSword.base_stats[S.health] = 100f;
            chaosDivineSword.base_stats[S.damage_range] = 0.5f;
        }

        private static void addWeaponsSprite(ItemAsset weapon)
        {
            Dictionary<string, Sprite> dictItems = Reflection.GetField(typeof(ActorAnimationLoader), null, "dictItems") as Dictionary<string, Sprite>;
            foreach (string mat in weapon.materials) dictItems.Add("w_" + weapon.id + "_" + mat, Resources.Load<Sprite>("Weapons/w_" + weapon.id + "_" + mat));
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