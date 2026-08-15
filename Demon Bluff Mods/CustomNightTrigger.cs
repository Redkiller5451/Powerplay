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

    //from Skill Cycler thank god this exists
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
        private static int getRulesCall;

        [HarmonyPatch(typeof(Gameplay), "UpdateRules")]
        public static class UpdateRulesPatch
        {
            public static void Prefix()
            {
                getRulesCall = 0;
            }
        }

        [HarmonyPatch(typeof(Role), "GetRules")]
        public static class GetRulesPatch
        {
            public static void Postfix(Role __instance, ref Il2CppSystem.Collections.Generic.List<SpecialRule> __result)
            {
                getRulesCall++;
                if (__result == null)
                    __result = new Il2CppSystem.Collections.Generic.List<SpecialRule>();

                if (getRulesCall < 3)
                {
                    var rules = new Il2CppSystem.Collections.Generic.List<SpecialRule>();
                    rules.Add(new NightModeRule(4));
                    __result = rules;
                }
                else
                {
                    __result = new Il2CppSystem.Collections.Generic.List<SpecialRule>();
                }
            }
        }
    }

}
