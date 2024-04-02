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
                Actor attacker = Reflection.GetField(pSelf.GetType(), pSelf, "a") as Actor;
                Actor victim = Reflection.GetField(pTarget.GetType(), pTarget, "a") as Actor;
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
                //Actor attacker = Reflection.GetField(pSelf.GetType(), pSelf, "a") as Actor;
                Actor victim = Reflection.GetField(pTarget.GetType(), pTarget, "a") as Actor;
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
    }
}