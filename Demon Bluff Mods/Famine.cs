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
public class Famine : Demon
{
    public Famine() : base(ClassInjector.DerivedConstructorPointer<Famine>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Famine(System.IntPtr ptr) : base(ptr)
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
    public override void Act(ETriggerPhase trigger, Character charRef)
    {
   
        //CODE STEALING: credit to TheCaldo
        if (trigger == ETriggerPhase.Day)
        {
            if (charRef.state == ECharacterState.Dead) return;
            Gameplay gameplay = Gameplay.Instance;
            Characters instance = Characters.Instance;
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            list1 = Characters.Instance.FilterAlignmentCharacters(list1, EAlignment.Good);
            list1 = Characters.Instance.FilterRevealedCharacters(list1);
            foreach (Character character in list1)
            {
                character.statuses.AddStatus(ECharacterStatus.KilledByEvil, charRef);
                character.KillByDemon(charRef);
                if (character.dataRef.picking)
                {
                    character.pickable.SetActive(false);
                }
                PlayerController.PlayerInfo.health.Damage(2);
            }
            charRef.RevealReal();
        }
    }
}