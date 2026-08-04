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
public class Consort : MafiaMember
{
    public Consort() : base(ClassInjector.DerivedConstructorPointer<Consort>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }

    public Consort(System.IntPtr ptr) : base(ptr)
    {

    }
    public override string Description
    {
        get
        {
            return "This is a cool role!";
        }
    }
    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Start)
        {
            Il2CppSystem.Collections.Generic.List<Character> viableCharacters = Gameplay.CurrentCharacters;
            viableCharacters = Characters.Instance.FilterRealCharacterType(viableCharacters, ECharacterType.Villager);
            int randomIndex = UnityEngine.Random.Range(0, viableCharacters.Count);
            Character random = viableCharacters[randomIndex];
            random.statuses.AddStatus(ECharacterStatus.Corrupted, charRef);
            random.statuses.AddStatus(ECharacterStatus.AppearDisguised, charRef);
            MelonLogger.Msg($"Confused #{random.id}");
        }

    }

}