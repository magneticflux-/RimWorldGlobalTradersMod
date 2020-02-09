using HugsLib;
using JetBrains.Annotations;
using RimWorld;
using Verse;

namespace Global_Traders
{
    [UsedImplicitly]
    public class GlobalTradersMod : ModBase
    {
        public override string ModIdentifier { get; } = "GlobalTraders";

        public override void MapLoaded(Map map)
        {
            var target = Find.Maps.MinBy(m => m.uniqueID);
            if (map == target)
            {
                Log.Message("Map is highest priority, don't replace passingShipManager");
            }
            else
            {
                Log.Message(
                    $"Map is lower priority, replacing passingShipManager with one from id {target.uniqueID.ToString()}");
                // Destroy the existing manager
                map.passingShipManager.map = null;
                map.passingShipManager = null;

                // Replace with the highest priority map's manager
                map.passingShipManager = target.passingShipManager;
            }
        }
    }
}