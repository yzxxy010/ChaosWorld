using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ChaosWorld_Debug;
using ReflectionUtility;

using UnityEngine;

namespace ChaosWorld.status
{
    internal class EffectAction
    {
        public static bool heavyCurse_WorldAction(BaseSimObject pTarget, WorldTile pTile)
        {
            DEBUG_MODE.instance.Log(pTarget.a.getName());
            if (pTarget != null)
            {
                Actor actor = pTarget.a;

                actor.stats[S.attack_speed] = actor.stats[S.attack_speed] * 0.5f;
                return true;
            }
            return false;
        }
        public static bool bloodSucking_WorldAction(BaseSimObject pTarget, WorldTile pTile)
        {
           
            if (pTarget != null)
            {
                Actor actor = pTarget.a;

                if(actor.attackTarget != null){
                    return false;
                }
                //攻击加吸血而且吸的血数值越来越高
                if(actor.tryToAttack(actor.attackTarget))
                {
                    Actor victim = actor.attackTarget.a;
                    double damage = actor.stats[S.damage] - actor.stats[S.damage] *victim.stats[S.armor] / 100;
                    double time = 0;
                    if (actor.activeStatus_dict.TryGetValue("bloodSucking", out StatusEffectData statusEffectData))
                    {
                        
                        var statusEffectAsset = statusEffectData.asset;
                        time= statusEffectData.getRemainingTime();
                    }
                    double resumption =damage * (20-time) *(0.8/20);
                    if (resumption < 0)
                    {
                        resumption = 1;
                    }
                    actor.data.health = actor.data.health + (int)(resumption);
                    return true;
                }
                
                return true;
            }
            return false;
        }
    }
}