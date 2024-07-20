using System.Collections.Generic;
using NeoModLoader.General;
using NeoModLoader.General.Game;
using NeoModLoader.api;
using ReflectionUtility;
using UnityEngine;

namespace ChaosWorld.Item
{
    internal class ItemSkill
    {
        public static bool chaosDivineSword_AttackAction(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile)
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

        public static bool knitter_AttackAction(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile)
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

        public static bool prophetSShepherdSStaff_AttackAction(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile)
        {
            //10%的概率，敌方血量上限-50%
            if(pSelf != null)
            {
                Actor victim = pTarget.a;
                Actor attacker = pSelf.a;
                if (Toolbox.randomChance(0.1f))
                {
                    victim.stats[S.health] = victim.stats[S.health] * 0.5f;
                }
            }
            return false;

        }
        public static bool dwarfKingGoldDraft_WorldAction(BaseSimObject pTarget, WorldTile pTile)
        {
            if (pTarget != null)
            {
                Actor holders = pTarget.a;
                holders.addStatusEffect("invincible", 2f);
                return true;
            }
            return false;
        }

        public static bool heartOfTheFore_stStaff_WorldAction(BaseSimObject pTarget, WorldTile pTile)
        {
            World.world.getObjectsInChunks(pTarget.currentTile, 3, MapObjectType.Actor);
            for (int i = 0; i < World.world.temp_map_objects.Count; i++)
            {
                Actor actor = (Actor)World.world.temp_map_objects[i];
                if (actor != pTarget.a && actor.kingdom == pTarget.a.kingdom)
                {
                    actor.stats[S.health] += actor.getMaxHealth() * 0.1f;
                }
            }
            return false;
        }

    }
}