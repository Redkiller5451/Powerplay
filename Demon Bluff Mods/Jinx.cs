using Il2Cpp;
using HarmonyLib;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem;
using MelonLoader;
using System;
using System.ComponentModel.Design;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


namespace Demon_Bluff_Mods
{
    [RegisterTypeInIl2Cpp]
    public class Jinx : Minion
    {
        public Jinx() : base(ClassInjector.DerivedConstructorPointer<Jinx>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public Jinx(System.IntPtr ptr) : base(ptr)
        {

        }
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.AfterRoundStart)
            {
                Gameplay gameplay = Gameplay.Instance;
                Characters instance = Characters.Instance;
                Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                list1 = Characters.Instance.FilterRealCharacterType(list1, ECharacterType.Villager);
                int randomIndex = UnityEngine.Random.Range(0, list1.Count);
                list1[randomIndex].statuses.AddStatus(Jinxed.jinxed, list1[randomIndex]);
            }

        }

    }
}public static class Jinxed
    {
        public static ECharacterStatus jinxed = (ECharacterStatus)230;
        [HarmonyLib.HarmonyPatch(typeof(Character), nameof(Character.OnReveal))]
        public class CharacterReveal
        {
            static void Postfix(Character __instance)
            {
                if (__instance != null)
                {
                    if (__instance.statuses.statuses.Contains(Jinxed.jinxed))
                    {
                        __instance.KillByDemon(__instance);
                        __instance.statuses.AddStatus(ECharacterStatus.MessedUpByEvil, __instance);
                    __instance.statuses.AddStatus(ECharacterStatus.KilledByEvil, __instance);
                }
                }

            }
        }
    //Taken from Snake Charmer, Wingidon
    [HarmonyPatch(typeof(Character), nameof(Character.RevealAllReal))]
    public static class jinxedStat
    {
        public static void Postfix(Character __instance)
        {
            if (__instance.statuses.Contains(Jinxed.jinxed))
            {
                __instance.chName.text = __instance.dataRef.name.ToUpper() + "<color=#AA41BF><size=18>\n<Jinxed></color></size>";
            }
        }
    }
}


