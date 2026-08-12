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

namespace Demon_Bluff_Mods;
[RegisterTypeInIl2Cpp]
public class TavernKeeper : Role
{

    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.AfterRoundStart)
        {
            Gameplay gameplay = Gameplay.Instance;
            Characters instance = Characters.Instance;
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            list1 = Characters.Instance.FilterAlignmentCharacters(list1, EAlignment.Good);
            list1.Remove(charRef);
            int randomIndex = UnityEngine.Random.Range(0, list1.Count);
            list1[randomIndex].statuses.AddStatus(Rbed.roleblocked, list1[randomIndex]);
        }
        if (trigger == ETriggerPhase.Day)
        {
            Il2CppSystem.Collections.Generic.List<Character> allChars = Gameplay.CurrentCharacters;
            Il2CppSystem.Collections.Generic.List<Character> allChars2 = Characters.Instance.FilterCharacterContainsStatus(allChars, Rbed.roleblocked);
            if (allChars2.Count == 0)
            {
                onActed?.Invoke(new ActedInfo($"I intoxicated noone!", null));
            }
            else
                onActed?.Invoke(new ActedInfo($"#{allChars2[UnityEngine.Random.Range(0, allChars2.Count)].id} is intoxicated!", null));
        }
    }
    public override void BluffAct(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Day)
        {
            Il2CppSystem.Collections.Generic.List<Character> allChars = Gameplay.CurrentCharacters;
            allChars = Characters.Instance.FilterAlignmentCharacters(allChars, EAlignment.Good);
            onActed?.Invoke(new ActedInfo($"#{allChars[UnityEngine.Random.Range(0, allChars.Count)].id} is intoxicated!", null));
        }
    }
    public TavernKeeper() : base(ClassInjector.DerivedConstructorPointer<TavernKeeper>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public TavernKeeper(System.IntPtr ptr) : base(ptr)
    {
    }
}
