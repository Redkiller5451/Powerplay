using Il2Cpp;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using HarmonyLib;

namespace Demon_Bluff_Mods;
[RegisterTypeInIl2Cpp]
public class Hangman : Neutrals
{

    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Start)
        {
            changeAlignement(charRef);
        }
        if (trigger == ETriggerPhase.Day)
        {
            if (charRef.alignment == EAlignment.Evil)
            {
                Gameplay gameplay = Gameplay.Instance;
                Characters instance = Characters.Instance;
                Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                list1 = Characters.Instance.FilterAlignmentCharacters(list1, EAlignment.Good);
                int randomIndex = UnityEngine.Random.Range(0, list1.Count);
                Character random = list1[randomIndex];
                random.statuses.AddStatus(HangTarget.hangtarget, random);
                onActed?.Invoke(new ActedInfo($"#{random.id} is Evil!", null));
            }
            else
            {
                Gameplay gameplay = Gameplay.Instance;
                Characters instance = Characters.Instance;
                Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                list1 = Characters.Instance.FilterAlignmentCharacters(list1, EAlignment.Evil);
                int randomIndex = UnityEngine.Random.Range(0, list1.Count);
                Character random = list1[randomIndex];
                random.statuses.AddStatus(HangTarget.hangtarget, random);
                onActed?.Invoke(new ActedInfo($"#{random.id} is Evil!", null));
            }
        }
    }
    public Hangman() : base(ClassInjector.DerivedConstructorPointer<Hangman>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Hangman(System.IntPtr ptr) : base(ptr)
    {
    }
}
public static class HangTarget
{
    public static ECharacterStatus hangtarget = (ECharacterStatus)255;
    [HarmonyPatch(typeof(Character), nameof(Character.Kill))]
    public static class isTheTarget
    {
        public static void Postfix(Character __instance)
        {
            if (__instance.statuses.Contains(hangtarget) && __instance.GetRealAlignment() == EAlignment.Good)
            {
                PlayerController.PlayerInfo.health.Damage(3);
            }
        }
    }
    [HarmonyPatch(typeof(Character), nameof(Character.RevealAllReal))]
    public static class hangEffect
    {
        public static void Postfix(Character __instance)
        {
            if (__instance.statuses.Contains(HangTarget.hangtarget))
            {
                
                    __instance.chName.text = __instance.dataRef.name.ToUpper() + "<color=#616161><size=18>\n<Target></color></size>";
               
            }
        }
    }
}
