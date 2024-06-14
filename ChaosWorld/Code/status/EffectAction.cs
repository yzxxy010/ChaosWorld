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
    }
}