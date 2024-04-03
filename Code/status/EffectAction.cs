using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ReflectionUtility;

using UnityEngine;

namespace ChaosWorld.status
{
    internal class EffectAction
    {
        public static bool heavyCurse_WorldAction(BaseSimObject pTarget, WorldTile pTile)
        {
            if (pTarget != null)
            {
                Actor actor = Reflection.GetField(pTarget.GetType(), pTarget, "a") as Actor;
                Debug.Log(actor.getName() + actor.asset.base_stats[S.attack_speed]);
                actor.asset.base_stats[S.attack_speed] = actor.asset.base_stats[S.attack_speed] * 0.5f;
                Debug.Log(actor.getName() + actor.asset.base_stats[S.attack_speed]);
                return true;
            }
            return false;
        }
    }
}