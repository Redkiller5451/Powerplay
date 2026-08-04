using Il2Cpp;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem;
using MelonLoader;
using System;
using Il2CppSystem.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

namespace Demon_Bluff_Mods;
[RegisterTypeInIl2Cpp]
public class Spokesperson : MafiaMember
{
    public Spokesperson() : base(ClassInjector.DerivedConstructorPointer<Spokesperson>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Spokesperson(System.IntPtr ptr) : base(ptr)
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
    CharacterData pickedCharacterPrevData;
    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Start) {

            Il2CppSystem.Collections.Generic.List<Character> viableCharacters = Gameplay.CurrentCharacters;

            Il2CppSystem.Collections.Generic.List<CharacterData> notInPlayOutsiders = Gameplay.Instance.GetAscensionAllStartingCharacters();
            notInPlayOutsiders = Characters.Instance.FilterNotInDeckCharactersUnique(notInPlayOutsiders);
            notInPlayOutsiders = Characters.Instance.FilterRealCharacterType(notInPlayOutsiders, ECharacterType.Outcast);
            if (notInPlayOutsiders.Count == 0)
            {
                notInPlayOutsiders = Gameplay.Instance.GetAllAscensionCharacters();
                notInPlayOutsiders = Characters.Instance.FilterRealCharacterType(notInPlayOutsiders, ECharacterType.Outcast);
            }
            CharacterData pickedOutsider = notInPlayOutsiders[UnityEngine.Random.Range(0, notInPlayOutsiders.Count)];

            if (notInPlayOutsiders.Count != 0)
            {
                Gameplay.Instance.AddScriptCharacter(ECharacterType.Outcast, pickedOutsider);

                viableCharacters = Characters.Instance.FilterAliveCharacters((Il2CppSystem.Collections.Generic.List<Character>)Gameplay.CurrentCharacters);
                viableCharacters = Characters.Instance.FilterRealCharacterType((Il2CppSystem.Collections.Generic.List<Character>)Gameplay.CurrentCharacters, ECharacterType.Villager);

                Character pickedCharacter = ((Il2CppSystem.Collections.Generic.List<Character>)Gameplay.CurrentCharacters)[UnityEngine.Random.Range(0, ((Il2CppSystem.Collections.Generic.List<Character>)Gameplay.CurrentCharacters).Count)];
                pickedCharacterPrevData = pickedCharacter.dataRef;
                pickedCharacter.Init(pickedOutsider);
                ((Il2CppSystem.Collections.Generic.List<Character>)Gameplay.CurrentCharacters).Remove(pickedCharacter);
                notInPlayOutsiders.Remove(pickedOutsider);
            }
        }
        if(trigger == ETriggerPhase.Night)
        {
            Il2CppSystem.Collections.Generic.List<Character> viableCharacters = Gameplay.CurrentCharacters;
            viableCharacters = Characters.Instance.FilterRealCharacterType(viableCharacters, ECharacterType.Outcast);
            viableCharacters = Characters.Instance.FilterDeadCharacters(viableCharacters);
            if(viableCharacters.Count > 0)
            {
                KillHidden(charRef);
                PlayerController.PlayerInfo.health.Damage(2);
            }
        }

    }
    public void KillHidden(Character demonRef)
    {
        Il2CppSystem.Collections.Generic.List<Character> possibleCharacters = new();
        possibleCharacters = Characters.Instance.FilterAliveCharacters(Gameplay.CurrentCharacters);
        possibleCharacters = Characters.Instance.FilterAlignmentCharacters(possibleCharacters, EAlignment.Good);
        possibleCharacters = Characters.Instance.FilterHiddenCharacters(possibleCharacters);
        possibleCharacters = Characters.Instance.FilterCharacterMissingStatus(possibleCharacters, ECharacterStatus.UnkillableByDemon);
        if (possibleCharacters.Count <= 0) { return; }
        Characters.Instance.GetRandomAliveCharacter(possibleCharacters).KillByDemon(demonRef);
    }

    public override void BluffAct(ETriggerPhase trigger, Character charRef)
    {

    }
}