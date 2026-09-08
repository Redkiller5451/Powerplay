using Il2Cpp;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSoftMasking.Samples;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using System;
using UnityEngine;
using static MelonLoader.MelonLaunchOptions;
using static MelonLoader.Modules.MelonModule;

namespace Demon_Bluff_Mods;
[RegisterTypeInIl2Cpp]
public class Crusader : Role
{
    Character fortifiedChar;
    public static Character lastPicker;
    public Crusader() : base(ClassInjector.DerivedConstructorPointer<Crusader>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Crusader(System.IntPtr ptr) : base(ptr)
    {

    }
    public override string Description
    {
        get
        {
            return "This is a cool role!";
        }
    }
    public override ActedInfo GetInfo(Character charRef)
    {
        ActedInfo actedInfo = new ActedInfo("I am a Pilgrim!", null);
        return actedInfo;
    }
    public override ActedInfo GetBluffInfo(Character charRef)
    {
        ActedInfo actedInfo = new ActedInfo("I am not a Pilgrim!", null);
        return actedInfo;
    }
    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Start)
        {
            if (!charRef.statuses.Contains(ECharacterStatus.Corrupted))
            {
                Gameplay gameplay = Gameplay.Instance;
                Characters instance = Characters.Instance;
                Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                list1 = Characters.Instance.FilterRealCharacterType(list1, ECharacterType.Villager);
                list1.Remove(charRef);
                Character fortified = list1[UnityEngine.Random.Range(0, list1.Count)];
                fortified.statuses.statuses.Add(Protected.protect);
                fortified.statuses.statuses.Add(Fortified.Fortify);
                fortifiedChar = fortified;
            }

        }
        if(trigger == ETriggerPhase.Day)
        {
            if (charRef.statuses.Contains(ECharacterStatus.Corrupted))
            {
                Gameplay gameplay = Gameplay.Instance;
                Characters instance = Characters.Instance;
                Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                list1 = Characters.Instance.FilterOutStatus(list1, Fortified.Fortify);
                list1.Remove(charRef);
                Character fortifiedClaim = list1[UnityEngine.Random.Range(0, list1.Count)];
                this.onActed.Invoke(new ActedInfo($"I have fortified #{fortifiedClaim.id}"));
            }
            else
            {
                this.onActed.Invoke(new ActedInfo($"I have fortified #{fortifiedChar.id}"));
            }

         }
    }
    public override void BluffAct(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Day)
        {
            Gameplay gameplay = Gameplay.Instance;
            Characters instance = Characters.Instance;
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            list1 = Characters.Instance.FilterOutStatus(list1, Fortified.Fortify);
            list1.Remove(charRef);
            Character fortifiedClaim = list1[UnityEngine.Random.Range(0, list1.Count)];
            this.onActed.Invoke(new ActedInfo($"I have fortified #{fortifiedClaim.id}"));

        }
    }
    public static void SetLastPicker(Character picker)
    {
        lastPicker = picker;
    }
    public override CharacterData? GetBluffIfAble(Character charRef)
    {
        return null;
    }
}
