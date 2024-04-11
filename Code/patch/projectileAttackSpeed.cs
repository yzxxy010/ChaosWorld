using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosWorld.Code.patch
{
    internal class projectileAttackSpeed
    {
        public static void init()
        {
            AssetManager.projectiles.list.ForEach(projectile =>
            {
                projectile.speed = 90f;
            });
        }
    }
}