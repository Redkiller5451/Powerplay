using Il2Cpp;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem;
using MelonLoader;
using System;
using System.ComponentModel.Design;
using UnityEngine;

namespace Demon_Bluff_Mods;
[RegisterTypeInIl2Cpp]
public class Forger : MafiaMember
{
    public Forger() : base(ClassInjector.DerivedConstructorPointer<Forger>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }

    public Forger(System.IntPtr ptr) : base(ptr)
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
        if(trigger == ETriggerPhase.Start)
        {
            Il2CppSystem.Collections.Generic.List<Character> unrevealedCharacters = Gameplay.CurrentCharacters;
        Il2CppSystem.Collections.Generic.List<Character> Evils = Characters.Instance.FilterAlignmentCharacters(unrevealedCharacters, EAlignment.Evil);
        Il2CppSystem.Collections.Generic.List<Character> Good = Characters.Instance.FilterAlignmentCharacters(unrevealedCharacters, EAlignment.Good);
        int randomIndex = UnityEngine.Random.Range(0, Evils.Count);
        Character random = Evils[randomIndex];
        randomIndex = UnityEngine.Random.Range(0, Good.Count);
        Character random2 = Good[randomIndex];
        random.UpdateRegisterAsRole(random2.dataRef);
        random2.UpdateRegisterAsRole(random.dataRef);
        MelonLogger.Msg($"Swapped #{random.id} and #{random2.id}");
        }
        

    }

}