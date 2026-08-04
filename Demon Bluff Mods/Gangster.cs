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
public class Gangster : MafiaMember
{
    public override Il2CppSystem.Collections.Generic.List<SpecialRule> GetRules()
    {
        Il2CppSystem.Collections.Generic.List<SpecialRule> sr = new Il2CppSystem.Collections.Generic.List<SpecialRule>();
        sr.Add(new NightModeRule(4));
        return sr;
    }
    public Gangster() : base(ClassInjector.DerivedConstructorPointer<Gangster>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }

    public Gangster(System.IntPtr ptr) : base(ptr)
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
        if (charRef.state == ECharacterState.Dead) return;
        if (trigger == ETriggerPhase.Night)
        {
            if (GetNeighborsAreMaf(charRef))
            {
                Character charToKill = GetNonMaf(charRef);
                if(charToKill.state != ECharacterState.Dead)
                {
                    charToKill.KillByDemon(charRef);
                    charToKill.statuses.AddStatus(ECharacterStatus.KilledByEvil, charRef);
                    PlayerController.PlayerInfo.health.Damage(3);
                }
            }
        }

    }
    public bool GetNeighborsAreMaf(Character charRef)
    {
        Il2CppSystem.Collections.Generic.List<Character> myList = CharactersHelper.GetSortedListWithCharacterFirst(Gameplay.CurrentCharacters, charRef);
        myList.RemoveAt(0);
        Il2CppSystem.Collections.Generic.List<Character> neighbors = new Il2CppSystem.Collections.Generic.List<Character>();
        neighbors.Add(myList[0]);
        neighbors.Add(myList[myList.Count - 1]);
        return ((neighbors[0].GetCharacterType() == MafiaType.Member || neighbors[0].GetCharacterType() == MafiaType.Leader) ||
             (neighbors[1].GetCharacterType() == MafiaType.Member || neighbors[1].GetCharacterType() == MafiaType.Leader)) &&
             !((neighbors[0].GetCharacterType() == MafiaType.Member || neighbors[0].GetCharacterType() == MafiaType.Leader) &&
             (neighbors[1].GetCharacterType() == MafiaType.Member || neighbors[1].GetCharacterType() == MafiaType.Leader));
    }
    public Character GetNonMaf(Character charRef)
    {
        Il2CppSystem.Collections.Generic.List<Character> neighbors = GetNeighbors(charRef);
        if (neighbors[0].GetCharacterType() != MafiaType.Leader && neighbors[0].GetCharacterType() != MafiaType.Member)
            return neighbors[0];
        else return neighbors[1];
    }
    public Il2CppSystem.Collections.Generic.List<Character> GetNeighbors(Character charRef)
    {
        Il2CppSystem.Collections.Generic.List<Character> myList = CharactersHelper.GetSortedListWithCharacterFirst(Gameplay.CurrentCharacters, charRef);
        myList.RemoveAt(0);
        Il2CppSystem.Collections.Generic.List<Character> neighbors = new Il2CppSystem.Collections.Generic.List<Character>();
        neighbors.Add(myList[0]);
        neighbors.Add(myList[myList.Count - 1]);
        return neighbors;
    }

}