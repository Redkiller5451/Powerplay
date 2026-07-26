using Demon_Bluff_Mods;
using HarmonyLib;
using Il2Cpp;
using Il2CppSystem;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static MelonLoader.MelonLogger;

public static class CharacterActingPatch
{
    // The 'this' keyword "adds" this method to TargetClass at compile-time
    [HarmonyPatch(typeof(Character), nameof(Character.Act))]
    public static class ProtectionPatch
    {
        static bool Prefix(Character __instance, ETriggerPhase trigger)
        {

            if (__instance == null)
                return true;

            if (__instance.statuses.Contains(Protected.protect))
            {
                MelonLogger.Msg("Blocked protected kill 1");
                __instance.revealed = false;
                // __instance.KillProtected();
                __instance.revealed = false;
                __instance.chName.text = __instance.dataRef.name.ToUpper();
                return false;
            }

            return true;
        }
    }
}
