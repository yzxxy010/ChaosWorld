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
                    float totalInjury = attacker.asset.base_stats[S.damage] * 1.2f;
                    victim.base_data.health = victim.base_data.health - (int)(totalInjury * 3);
                    if (victim.base_data.health <= 0)
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
                    victim.base_data.health = victim.base_data.health - 100;
                    victim.addStatusEffect("heavyCurse");
                    if (victim.base_data.health <= 0)
                    {
                        victim._alive = false;
                    }
                    return true;
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
    }
}