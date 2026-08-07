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

namespace Demon_Bluff_Mods;
[RegisterTypeInIl2Cpp]
public class Industrialist : Role
{

    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Start)
        {
            Gameplay gameplay = Gameplay.Instance;
            Characters instance = Characters.Instance;
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            list1 = Characters.Instance.FilterAlignmentCharacters(list1, EAlignment.Good);
            list1.Remove(charRef);
            int randomIndex = UnityEngine.Random.Range(0, list1.Count);
            list1[randomIndex].statuses.AddStatus(Mad.mad2, list1[randomIndex]);
        }
        if (trigger == ETriggerPhase.Day)
        {
            Il2CppSystem.Collections.Generic.List<Character> allChars = Gameplay.CurrentCharacters;
            Il2CppSystem.Collections.Generic.List<Character> allChars2 = Characters.Instance.FilterCharacterContainsStatus(allChars, Mad.mad2);
            allChars = Characters.Instance.FilterCharacterContainsStatus(allChars, Mad.mad);
            foreach (Character character in allChars2)
            {
                allChars.Add(character);
            }
            if(allChars.Count == 0)
            {
                onActed?.Invoke(new ActedInfo($"Nobody is Mad!", null));
            }
            else
                onActed?.Invoke(new ActedInfo($"#{allChars[UnityEngine.Random.Range(0, allChars.Count)].id} is mad!", null));
        }
    }
    public override void BluffAct(ETriggerPhase trigger, Character charRef)
    { 
        if (trigger == ETriggerPhase.Day)
        {
            Il2CppSystem.Collections.Generic.List<Character> allChars = Gameplay.CurrentCharacters;
            allChars = Characters.Instance.FilterAlignmentCharacters(allChars, EAlignment.Good);
            onActed?.Invoke(new ActedInfo($"#{allChars[UnityEngine.Random.Range(0, allChars.Count)].id} is mad!", null));
        }
    }
    public Industrialist() : base(ClassInjector.DerivedConstructorPointer<Industrialist>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Industrialist(System.IntPtr ptr) : base(ptr)
    {
    }
}
