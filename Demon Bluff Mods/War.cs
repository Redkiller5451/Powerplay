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
public class War : Demon
{
    public War() : base(ClassInjector.DerivedConstructorPointer<War>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public War(System.IntPtr ptr) : base(ptr)
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
        ActedInfo actedInfo = new ActedInfo("I have declared a Tribunal!", null);
        return actedInfo;
    }
    public override ActedInfo GetBluffInfo(Character charRef)
    {
        ActedInfo actedInfo = new ActedInfo("I am corrupted", null);
        return actedInfo;
    }
    //Code from Wingidon
    public override Il2CppSystem.Collections.Generic.List<SpecialRule> GetRules()
    {
        Il2CppSystem.Collections.Generic.List<SpecialRule> sr = new Il2CppSystem.Collections.Generic.List<SpecialRule>();
        sr.Add(new NightModeRule(4));
        return sr;
    }

    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        //CODE STEALING: credit to TheCaldo
        if (trigger == ETriggerPhase.Night)
        {
            if (charRef.state == ECharacterState.Dead) return;
            Gameplay gameplay = Gameplay.Instance;
            Characters instance = Characters.Instance;
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            list1 = Characters.Instance.FilterAlignmentCharacters(list1, EAlignment.Good);
            list1 = Characters.Instance.FilterAliveCharacters(list1);
            Health health = PlayerController.PlayerInfo.health;
            health.Damage(2);
            Character myTarget = list1[UnityEngine.Random.Range(0, list1.Count)];
            list1.Remove(myTarget);
            Character myTarget2 = list1[UnityEngine.Random.Range(0, list1.Count)];
            list1.Remove(myTarget2);
            myTarget.statuses.AddStatus(ECharacterStatus.KilledByEvil, charRef);
            myTarget.KillByDemon(charRef);
            myTarget2.statuses.AddStatus(ECharacterStatus.KilledByEvil, charRef);
            myTarget2.KillByDemon(charRef);
            if (myTarget.dataRef.picking)
            {
                myTarget.pickable.SetActive(false);
            }
            if (myTarget2.dataRef.picking)
            {
                myTarget2.pickable.SetActive(false);
            }
        }
    }
}
