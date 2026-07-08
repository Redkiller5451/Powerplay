using Demon_Bluff_Mods;
using HarmonyLib;
using Il2Cpp;
using Il2CppSystem;
using MelonLoader;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Demon_Bluff_Mods.Pirate;
using static UnityEngine.GraphicsBuffer;
using System.Reflection.Metadata.Ecma335;

public static class TargetClassExtensions
{
    // The 'this' keyword "adds" this method to TargetClass at compile-time
    public static void GetFamine(this Role instance, Character charRef)
    {
        // You can now access public members of the instance
        if (charRef.statuses.statuses.Contains(Starved.starved) && charRef.revealed)
        {
            charRef.statuses.AddStatus(ECharacterStatus.KilledByEvil, charRef);
            charRef.KillByDemon(charRef);
        }
    }
}
[HarmonyPatch]
public static class Patch
{
    [HarmonyPatch(typeof(Character), nameof(Character.Kill))]
    public static class ProtectionPatch
    {
        static bool Prefix(Character __instance)
        {
            MelonLogger.Msg("Blocked protected kill");
            if (__instance == null)
                return true;

            if (__instance.statuses.Contains(Protected.protect))
            {
                MelonLogger.Msg("Blocked protected kill");
                __instance.KillProtected();
                return false;
            }

            return true;
        }
    }
    [HarmonyPatch(typeof(Character), nameof(Character.KillAndReveal))]
    public static class ProtectionPatch2
    {
        static bool Prefix(Character __instance)
        {
            MelonLogger.Msg("Blocked protected kill");
            if (__instance == null)
                return true;

            if (__instance.statuses.Contains(Protected.protect))
            {
                MelonLogger.Msg("Blocked protected kill");
                __instance.KillProtected();
                return false;
            }

            return true;
        }
    }
    [HarmonyPatch(typeof(Character), nameof(Character.ExecuteAndReveal))]
    public static class ProtectionPatch3
    {
        static bool Prefix(Character __instance)
        {
            MelonLogger.Msg("Blocked protected kill");
            if (__instance == null)
                return true;

            if (__instance.statuses.Contains(Protected.protect))
            {
                MelonLogger.Msg("Blocked protected kill");
                __instance.KillProtected();
                return false;
            }

            return true;
        }
    }
    [HarmonyPatch(typeof(Character), nameof(Character.KillByDemon))]
    public static class ProtectionPatch4
    {
        static bool Prefix(Character __instance)
        {
            MelonLogger.Msg("Blocked protected kill");
            if (__instance == null)
                return true;

            if (__instance.statuses.Contains(Protected.protect))
            {
                MelonLogger.Msg("Blocked protected kill");
                __instance.KillProtected();
                return false;
            }

            return true;
        }
    }
}