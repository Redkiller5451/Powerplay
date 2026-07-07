using Demon_Bluff_Mods;
using HarmonyLib;
using Il2Cpp;
using Il2CppSystem;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public static class TargetClassExtensions
{
    // The 'this' keyword "adds" this method to TargetClass at compile-time
    public static void GetFamine(this Role instance, Character charRef)
    {
        // You can now access public members of the instance
        if(charRef.statuses.statuses.Contains(Starved.starved) && charRef.revealed)
        {
            charRef.statuses.AddStatus(ECharacterStatus.KilledByEvil, charRef);
            charRef.KillByDemon(charRef);
        }
    }
}