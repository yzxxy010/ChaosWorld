using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NCMS.Utils;

using NeoModLoader.General;

using UnityEngine;

namespace ChaosWorld.Code
{
    internal class newButton
    {
        public static void init()
        {
            newGodpower.init();

            var cutCity_LR_button = PowerButtons.CreateButton(
                "cutCity_LR",
                Resources.Load<Sprite>("ui/button/cutCity_LR"),
                LM.Get("button_cutCity_LR_name"),
                LM.Get("button_cutCity_LR_desc"),
                Vector2.zero,
                ButtonType.GodPower,
                null,
                null
            );
            PowerButtons.AddButtonToTab(cutCity_LR_button, PowerTab.Kingdoms, new Vector2(94f, 60f));
            cutCity_LR_button = PowerButtons.CreateButton(
                "cutCity_UD",
                Resources.Load<Sprite>("ui/button/cutCity_UD"),
                LM.Get("button_cutCity_UD_name"),
                LM.Get("button_cutCity_UD_desc"),
                Vector2.zero,
                ButtonType.GodPower,
                null,
                null
            );
            PowerButtons.AddButtonToTab(cutCity_LR_button, PowerTab.Kingdoms, new Vector2(94f, 94f));
        }
    }

    public class newGodpower
    {
        public static void init()
        {
            GodPower cutCity_LR = new GodPower();
            cutCity_LR.id = "cutCity_LR";
            cutCity_LR.name = "cutCity_LR";
            cutCity_LR.showToolSizes = false;
            cutCity_LR.unselectWhenWindow = true;
            cutCity_LR.holdAction = false;
            cutCity_LR.click_action += newGodpower_action.CutCity_LR_Action;
            AssetManager.powers.add(cutCity_LR);

            GodPower cutCity_UD = new GodPower();
            cutCity_UD.id = "cutCity_UD";
            cutCity_UD.name = "cutCity_UD";
            cutCity_UD.showToolSizes = false;
            cutCity_UD.unselectWhenWindow = true;
            cutCity_UD.holdAction = false;
            cutCity_UD.click_action += newGodpower_action.CutCity_UD_Action;
            AssetManager.powers.add(cutCity_UD);
        }
    }

    public class newGodpower_action
    {
        public static bool CutCity_LR_Action(WorldTile pTile, string pPowerID)
        {
            Config.paused = true;
            City city = pTile.zone.city;
            if (city == null)
            {
                return false;
            }
            if (city.kingdom == null)
            {
                return false;
            }

            // 计算城市区域的中心点
            float centerX = 0f;
            float centerY = 0f;
            List<TileZone> zones = city.zones;
            foreach (var zone in zones)
            {
                centerX += zone.x;
                centerY += zone.y;
            }
            centerX /= zones.Count;

            // 根据中心点分割成左右两半
            List<TileZone> leftHalf = new List<TileZone>();
            List<TileZone> rightHalf = new List<TileZone>();
            foreach (var zone in zones)
            {
                if (zone.x < centerX)
                {
                    leftHalf.Add(zone);
                }
                else
                {
                    rightHalf.Add(zone);
                }
            }
            if (leftHalf.Count > 1)
            {
                string name = NameGenerator.getName(city.race.name_template_city);
                City city2 = World.world.cities.buildNewCity(leftHalf[0], city.race, city.kingdom);
                city2.data.name = name;
                WorldLog.logNewCity(city2);
                TransferTheActor(city, leftHalf, city2);
            }

            return true;
        }

        public static bool CutCity_UD_Action(WorldTile pTile, string pPowerID)
        {
            Config.paused = true;
            City city = pTile.zone.city;
            if (city == null)
            {
                return false;
            }
            if (city.kingdom == null)
            {
                return false;
            }

            // 计算城市区域的中心点
            float centerX = 0f;
            float centerY = 0f;
            List<TileZone> zones = city.zones;
            foreach (var zone in zones)
            {
                centerX += zone.x;
                centerY += zone.y;
            }
            centerY /= zones.Count;
            List<TileZone> up = new List<TileZone>();

            foreach (var zone in zones)
            {
                if (zone.y < centerY)
                {
                    up.Add(zone);
                }
            }
            if (up.Count > 1)
            {
                string name = NameGenerator.getName(city.race.name_template_city);
                City city2 = World.world.cities.buildNewCity(up[0], city.race, city.kingdom);
                city2.data.name = name;
                WorldLog.logNewCity(city2);
                TransferTheActor(city, up, city2);
            }

            return true;
        }

        private static void TransferTheActor(City city, List<TileZone> leftHalf, City city2)
        {
            List<Actor> unitsToRemove = new();
            List<TileZone> TileZoneToAdd = new();
            foreach (var zone in leftHalf)
            {
                if (city == null || city?.zones.Count < 5 || city?.getPopulationUnits() < 10)
                {
                    break;
                }

                TileZoneToAdd.Add(zone);

                foreach (var t in zone.tiles)
                {
                    foreach (var a in t._units)
                    {
                        if (a.isKing() || a == city?.leader)
                        {
                            continue;
                        }
                        if (a.city != city)
                        {
                            continue;
                        }
                        if (city2 == null || city == null)
                        {
                            break;
                        }
                        unitsToRemove.Add(a);
                    }
                }
            }
            foreach (var add in TileZoneToAdd)
            {
                city?.removeZone(add);
                city2?.addZone(add);
            }
            foreach (var unitToRemove in unitsToRemove)
            {
                unitToRemove.joinCity(city2);
            }
        }
    }
}