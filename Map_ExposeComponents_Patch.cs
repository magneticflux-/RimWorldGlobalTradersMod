using Harmony;
using JetBrains.Annotations;
using Verse;

// ReSharper disable InconsistentNaming

namespace Global_Traders
{
    [HarmonyPatch(typeof(Map), "ExposeComponents")]
    [UsedImplicitly]
    public class Map_ExposeComponents_Patch
    {
        [HarmonyPrefix]
        [UsedImplicitly]
        public static bool ReplaceExposeComponents(Map __instance)
        {
            Scribe_Deep.Look(ref __instance.weatherManager, "weatherManager", __instance);
            Scribe_Deep.Look(ref __instance.reservationManager, "reservationManager", __instance);
            Scribe_Deep.Look(ref __instance.physicalInteractionReservationManager,
                "physicalInteractionReservationManager");
            Scribe_Deep.Look(ref __instance.designationManager, "designationManager", __instance);
            Scribe_Deep.Look(ref __instance.pawnDestinationReservationManager, "pawnDestinationReservationManager");
            Scribe_Deep.Look(ref __instance.lordManager, "lordManager", __instance);

            // Begin edit

            if (__instance == __instance.passingShipManager.map) // If this is the main map, save/load the ship manager
                Scribe_Deep.Look(ref __instance.passingShipManager, "visitorManager", __instance);
            // Else, use the default one

            // End edit

            Scribe_Deep.Look(ref __instance.gameConditionManager, "gameConditionManager", __instance);
            Scribe_Deep.Look(ref __instance.fogGrid, "fogGrid", __instance);
            Scribe_Deep.Look(ref __instance.roofGrid, "roofGrid", __instance);
            Scribe_Deep.Look(ref __instance.terrainGrid, "terrainGrid", __instance);
            Scribe_Deep.Look(ref __instance.zoneManager, "zoneManager", __instance);
            Scribe_Deep.Look(ref __instance.temperatureCache, "temperatureCache", __instance);
            Scribe_Deep.Look(ref __instance.snowGrid, "snowGrid", __instance);
            Scribe_Deep.Look(ref __instance.areaManager, "areaManager", __instance);
            Scribe_Deep.Look(ref __instance.lordsStarter, "lordsStarter", __instance);
            Scribe_Deep.Look(ref __instance.attackTargetReservationManager, "attackTargetReservationManager",
                __instance);
            Scribe_Deep.Look(ref __instance.deepResourceGrid, "deepResourceGrid", __instance);
            Scribe_Deep.Look(ref __instance.weatherDecider, "weatherDecider", __instance);
            Scribe_Deep.Look(ref __instance.damageWatcher, "damageWatcher");
            Scribe_Deep.Look(ref __instance.rememberedCameraPos, "rememberedCameraPos", __instance);
            Scribe_Deep.Look(ref __instance.mineStrikeManager, "mineStrikeManager");
            Scribe_Deep.Look(ref __instance.retainedCaravanData, "retainedCaravanData", __instance);
            Scribe_Deep.Look(ref __instance.storyState, "storyState", __instance);
            Scribe_Deep.Look(ref __instance.wildPlantSpawner, "wildPlantSpawner", __instance);
            Scribe_Collections.Look(ref __instance.components, "components", LookMode.Deep, __instance);

            //__instance.FillComponents();
            Traverse.Create(__instance).Method("FillComponents").GetValue();

            if (Scribe.mode != LoadSaveMode.PostLoadInit)
                return false;
            BackCompatibility.MapPostLoadInit(__instance);

            // Cancel original method
            return false;
        }
    }
}