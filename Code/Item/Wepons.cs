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
            chaosDivineSword.base_stats[S.attack_speed] = 9999f;
            chaosDivineSword.base_stats[S.health] = 100000f;
            chaosDivineSword.base_stats[S.range] = 2f;
            chaosDivineSword.base_stats[S.knockback_reduction] = 99999f;
            chaosDivineSword.action_attack_target += ItemSkill.chaosDivineSword_AttackAction;
            chaosDivineSword.name_templates = Toolbox.splitStringIntoList(new string[]
          {
            "sword_name#30"
          });
            chaosDivineSword.path_icon = "Weapons/w_chaosDivineSword_base";
            AssetManager.items.add(chaosDivineSword);
            addItemSprite(chaosDivineSword.id, chaosDivineSword.materials[0]);

            ItemAsset knitter = AssetManager.items.clone("knitter", "spear");
            knitter.id = "knitter";
            knitter.pool = "melee";
            knitter.attackType = WeaponType.Melee;
            knitter.equipmentType = EquipmentType.Weapon;
            knitter.name_class = "item_class_weapon";
            knitter.materials = List.Of<string>(new string[] { "base" });
            knitter.path_slash_animation = "effects/slashes/slash_spear";
            knitter.rarity = 9999;
            knitter.equipment_value = 9999;
            knitter.base_stats[S.damage] = 45f;
            knitter.base_stats[S.health] = 150f;
            knitter.base_stats[S.range] = 6f;
            knitter.base_stats[S.knockback_reduction] = 0.2f;
            knitter.action_attack_target += ItemSkill.knitter_AttackAction;
            chaosDivineSword.name_templates = Toolbox.splitStringIntoList(new string[]
          {
            "bow_name#30"
          });
            knitter.path_icon = "Weapons/w_knitter_base";
            AssetManager.items.add(knitter);
            addItemSprite(knitter.id, knitter.materials[0]);

            ItemAsset dwarfKingGoldDraft = AssetManager.items.clone("dwarfKingGoldDraft", "axe");
            dwarfKingGoldDraft.id = "dwarfKingGoldDraft";
            dwarfKingGoldDraft.pool = "melee";
            dwarfKingGoldDraft.attackType = WeaponType.Melee;
            dwarfKingGoldDraft.equipmentType = EquipmentType.Weapon;
            dwarfKingGoldDraft.name_class = "item_class_weapon";
            dwarfKingGoldDraft.materials = List.Of<string>(new string[] { "base" });
            dwarfKingGoldDraft.path_slash_animation = "effects/slashes/slash_axe";
            dwarfKingGoldDraft.rarity = 9999;
            dwarfKingGoldDraft.equipment_value = 9999;
            dwarfKingGoldDraft.base_stats[S.damage] = 65;
            dwarfKingGoldDraft.base_stats[S.health] = 430;
            dwarfKingGoldDraft.base_stats[S.range] = 3f;
            dwarfKingGoldDraft.base_stats[S.knockback] = 2.5f;
            dwarfKingGoldDraft.base_stats[S.knockback_reduction] = 0.5f;
            dwarfKingGoldDraft.action_special_effect += ItemSkill.dwarfKingGoldDraft_WorldAction;
            dwarfKingGoldDraft.special_effect_interval = 10f;
            dwarfKingGoldDraft.name_templates = Toolbox.splitStringIntoList(new string[]
            {
                "axe_name#30"
            });
            dwarfKingGoldDraft.path_icon = "Weapons/w_dwarfKingGoldDraft_base";
            AssetManager.items.add(dwarfKingGoldDraft);
            addItemSprite(dwarfKingGoldDraft.id, dwarfKingGoldDraft.materials[0]);

            ItemAsset heartOfTheFore_stStaff = AssetManager.items.clone("heartOfTheFore_stStaff", "_range");
            heartOfTheFore_stStaff.id = "heartOfTheFore_stStaff";
            heartOfTheFore_stStaff.pool = "range";
            heartOfTheFore_stStaff.attackType = WeaponType.Range;
            heartOfTheFore_stStaff.projectile = "bone";
            heartOfTheFore_stStaff.equipmentType = EquipmentType.Weapon;
            heartOfTheFore_stStaff.name_class = "item_class_weapon";
            heartOfTheFore_stStaff.materials = List.Of<string>(new string[] { "base" });
            heartOfTheFore_stStaff.path_slash_animation = "effects/slashes/slash_punch";
            heartOfTheFore_stStaff.rarity = 9999;
            heartOfTheFore_stStaff.equipment_value = 9999;
            heartOfTheFore_stStaff.base_stats[S.damage] = 45f;
            heartOfTheFore_stStaff.base_stats[S.health] = 150f;
            heartOfTheFore_stStaff.base_stats[S.range] = 6f;
            heartOfTheFore_stStaff.base_stats[S.knockback_reduction] = 0.2f;
            heartOfTheFore_stStaff.base_stats[S.attack_speed] = 99999f;
            heartOfTheFore_stStaff.action_attack_target += ItemSkill.heartOfTheFore_stStaff_AttackAction;
            heartOfTheFore_stStaff.name_templates = Toolbox.splitStringIntoList(new string[]
            {
                "necromancer_staff_name"
            });
            heartOfTheFore_stStaff.path_icon = "Weapons/w_heartOfTheFore_stStaff_base";
            AssetManager.items.add(heartOfTheFore_stStaff);
            addItemSprite(heartOfTheFore_stStaff.id, heartOfTheFore_stStaff.materials[0]);
        }

        public static void addItemSprite(string id, string material)
        {
            var dictItems = Reflection.GetField(typeof(ActorAnimationLoader), null, "dictItems") as Dictionary<string, Sprite>;
            var sprite = Resources.Load<Sprite>("Weapons/w_" + id + "_" + material);
            dictItems.Add(sprite.name, sprite);
        }
    }
}