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
public class Godfather : Neutrals
{

    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Start)
        { 
                changeAlignement(charRef);
                if (charRef.alignment == EAlignment.Evil)
                {
                MelonLogger.Msg("The Godfather is Evil");
                    Gameplay gameplay = Gameplay.Instance;
                    Characters instance = Characters.Instance;
                    Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                    list1 = Characters.Instance.FilterAlignmentCharacters(list1, EAlignment.Good);
                    Character random = list1[UnityEngine.Random.Range(0, list1.Count)];
                    random.ChangeAlignment(EAlignment.Evil);
                random.statuses.AddStatus(Swapped.swapped, charRef);
            }
                else
                {
                MelonLogger.Msg("The Godfather is Good");
                Gameplay gameplay = Gameplay.Instance;
                    Characters instance = Characters.Instance;
                    Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                    list1 = Characters.Instance.FilterCharacterType(list1, ECharacterType.Minion);
                    Character random = list1[UnityEngine.Random.Range(0, list1.Count)];
                    random.ChangeAlignment(EAlignment.Good);
                random.statuses.AddStatus(Swapped.swapped,charRef);
                }
            }
        }
    public Godfather() : base(ClassInjector.DerivedConstructorPointer<Godfather>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Godfather(System.IntPtr ptr) : base(ptr)
    {
    }
}
public static class Swapped
{
    public static ECharacterStatus swapped = (ECharacterStatus)235;
    
    //Taken from Snake Charmer, Wingidon
    [HarmonyPatch(typeof(Character), nameof(Character.RevealAllReal))]
    public static class swapStat
    {
        public static void Postfix(Character __instance)
        {
            if (__instance.statuses.Contains(Swapped.swapped))
            {
                if (__instance.alignment == EAlignment.Good)
                {
                    __instance.chName.text = __instance.dataRef.name.ToUpper() + "<color=#41BF69><size=18>\n<Swapped(Good)></color></size>";
                }
                else
                {
                    __instance.chName.text = __instance.dataRef.name.ToUpper() + "<color=#D62222><size=18>\n<Swapped(Evil)></color></size>";
                }
            }
        }
    }
}