using Demon_Bluff_Mods;
using HarmonyLib;
using Il2Cpp;
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
    public class Butcher : Minion
    {
        public Butcher() : base(ClassInjector.DerivedConstructorPointer<Butcher>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public Butcher(System.IntPtr ptr) : base(ptr)
        {

        }
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
           
          
        }

    }
}
[HarmonyPatch]
public static class ButcherPatch
{
    [HarmonyPatch(typeof(Character), nameof(Character.Kill))]
    public static class IsButcherAlive
    {
        static bool Prefix(Character __instance)
        {
            if(__instance.role is Butcher)
            {
                return true;
            }
            MelonLogger.Msg("Butcher activated");
            Gameplay gameplay = Gameplay.Instance;
            Characters instance = Characters.Instance;
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            list1 = Characters.Instance.FilterAliveCharacters(list1);
            bool aliveButcher = false;
            foreach (Character character in list1)
            {
                if (character.role is Butcher)
                {
                    aliveButcher = true;

                }
            }
            if (aliveButcher)
            {

                list1 = Characters.Instance.FilterAlignmentCharacters(list1,EAlignment.Good);
                if (list1.Count > 0)
                {
                    int randomIndex = UnityEngine.Random.Range(0, list1.Count);
                    Character random = list1[randomIndex];
                    random.KillByDemon(__instance);
                    random.statuses.AddStatus(ECharacterStatus.KilledByEvil, __instance);
                    random.statuses.AddStatus(ECharacterStatus.MessedUpByEvil, __instance);
                    random.KillByDemon(__instance);
                    Health health = PlayerController.PlayerInfo.health;
                    if(!isRoundOver())
                        health.Damage(2);
                }
            }
            return true;
        }
        private static bool isRoundOver()
        {
            Gameplay gameplay = Gameplay.Instance;
            Characters instance = Characters.Instance;
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            list1 = Characters.Instance.FilterAlignmentCharacters(list1, EAlignment.Evil);
            list1 = Characters.Instance.FilterAliveCharacters(list1);
            return list1.Count <= 0;
        }
    }
}
