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
using static UnityEngine.GraphicsBuffer;
using System.Reflection.Metadata.Ecma335;

namespace Demon_Bluff_Mods
{
    [HarmonyPatch(typeof(NightCycle), nameof(NightCycle.ResetClock))]
    public static class BluffsActivationAtNight
    {
        public static ETriggerPhase NightAct = (ETriggerPhase)300;
        private static void Postfix()
        {
            foreach (Character c in Gameplay.CurrentCharacters)
            {
                c.Act(NightAct);
            }
        }
    }
}
