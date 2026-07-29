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
public class Bootlegger : Minion
{

    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.AfterRoundStart)
        {
            Gameplay gameplay = Gameplay.Instance;
            Characters instance = Characters.Instance;
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            list1 = Characters.Instance.FilterAlignmentCharacters(list1, EAlignment.Good);
            Character char1 = PrioritizeOnPick(list1);
            char1.statuses.AddStatus(Rbed.roleblocked, charRef);
            list1.Remove(char1);
            char1 = PrioritizeOnPick(list1);
            char1.statuses.AddStatus(Rbed.roleblocked, charRef);
        }
    }
    private Character PrioritizeOnPick(Il2CppSystem.Collections.Generic.List<Character> list1)
    {
        Il2CppSystem.Collections.Generic.List<Character> list2 = new();
        foreach (Character c in list1)
        {
            if (c.dataRef.picking)
            {
                list2.Add(c);
            }
        }
        if (list2.Count > 0)
        {
            return list2[UnityEngine.Random.Range(0, list2.Count)];
        }
        else
            return list1[UnityEngine.Random.Range(0, list1.Count)];
    }

    public Bootlegger() : base(ClassInjector.DerivedConstructorPointer<Bootlegger>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Bootlegger(System.IntPtr ptr) : base(ptr)
    {
    }
}
