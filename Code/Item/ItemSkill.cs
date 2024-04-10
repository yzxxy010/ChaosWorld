﻿using System.Collections.Generic;
using NeoModLoader.General;
using NeoModLoader.General.Game;
using NeoModLoader.api;
using ReflectionUtility;
using UnityEngine;

namespace ChaosWorld.Item
{
    internal class ItemSkill
    {
        public static bool chaosDivineSword_AttackAction(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile = null)
        {
            if (pSelf != null)
            {
                Actor attacker = pSelf.a;
                Actor victim = pTarget.a;
                if (victim == null)
                {
                    return false;
                }
                if (Toolbox.randomChance(0.2f))
                {
                    float totalInjury = attacker.stats[S.damage] * 1.2f;
                    victim.data.health = victim.data.health - (int)(totalInjury * 3);
                    if (victim.data.health <= 0)
                    {
                        victim._alive = false;
                    }
                    return true;
                }
            }
            return false;
        }

        public static bool knitter_AttackAction(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile = null)
        {
            if (pSelf != null)
            {
                Actor victim = pTarget.a;
                if (victim == null)
                {
                    return false;
                }
                if (Toolbox.randomChance(0.3f))
                {
                    victim.data.health = victim.data.health - 100;
                    victim.addStatusEffect("heavyCurse");
                    if (victim.data.health <= 0)
                    {
                        victim._alive = false;
                    }
                    return true;
                }
            }
            return false;
        }

        public static bool dwarfKingGoldDraft_WorldAction(BaseSimObject pTarget, WorldTile pTile = null)
        {
            if (pTarget != null)
            {
                Actor holders = pTarget.a;
                holders.addStatusEffect("invincible", 2f);
                return true;
            }
            return false;
        }

        public static bool heartOfTheFore_stStaff_AttackAction(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile = null)
        {
            WorldTile worldTile = World.world.GetTile(pTarget.a.data.x, pTarget.a.data.y);

            World.world.getObjectsInChunks(worldTile, 3, MapObjectType.Actor);
            for (int i = 0; i < World.world.temp_map_objects.Count; i++)
            {
                Debug.Log("heartOfTheFore_stStaff_AttackAction");

                Actor actor = (Actor)World.world.temp_map_objects[i];
                Debug.Log(actor.getName());
                actor.setAlive(false);
            }
            return false;
        }
    }
}