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
            ItemAsset temp = ItemAssetCreator.CreateMeleeWeapon("chaosSword");
        }
    }
}