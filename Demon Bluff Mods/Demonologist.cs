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
public class Demonologist : Role
{
    public Demonologist() : base(ClassInjector.DerivedConstructorPointer<Demonologist>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Demonologist(System.IntPtr ptr) : base(ptr)
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
        Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
        list1 = Characters.Instance.FilterCharacterType(list1, ECharacterType.Minion);
        string line = "";
        Il2CppSystem.Collections.Generic.List<string> subtypes = new();
        foreach (Character character in list1)
        {
            subtypes.Add(SubTypes.GetString(SubTypes.GetESubType(character.dataRef)));

        }
        if (0 == subtypes.Count)
        {
            line = $"There are no minions in-play";
        }
        else if (1 == subtypes.Count)
        {
            line += $"The Minions are composed of:\nOnly a {subtypes[0]}.";
        }
        else
        {
            line = "The Minions are composed of: ";
            foreach (string info in subtypes)
             {

                if (subtypes.IndexOf(info) == subtypes.Count - 1)
                {
                     line += $"\nand a {info}.";
                 }
                 else
                {
                    line += $"\na {info},";
                 }


             }
        }
            
        ActedInfo actedInfo = new ActedInfo(line, null);
        return actedInfo;
    }
    public override ActedInfo GetBluffInfo(Character charRef)
    {
        Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
        list1 = Characters.Instance.FilterCharacterType(list1, ECharacterType.Minion);
        string line = "";
        Il2CppSystem.Collections.Generic.List<string> subtypes = new();
        Il2CppSystem.Collections.Generic.List<string> possibleSubtypes = new();
        foreach (Character character in list1)
        {
            subtypes.Add(SubTypes.GetString(SubTypes.GetESubType(character.dataRef)));
        }
        possibleSubtypes.Add("Minion Deception");
        possibleSubtypes.Add("Minion Killing");
        possibleSubtypes.Add("Minion Utility");
        if (subtypes.Count == 0)
        {
            subtypes.Add(possibleSubtypes[UnityEngine.Random.Range(0, possibleSubtypes.Count)]);
        }
        else
        {
            string randomWrongSubtype = subtypes[UnityEngine.Random.Range(0, subtypes.Count)];
            if (randomWrongSubtype != null)
            {
                if(randomWrongSubtype == possibleSubtypes[0])
                {
                    int randomizer = Calculator.RemoveNumberAndGetRandomNumberFromList(0, 0, 3);
                    subtypes.Remove(randomWrongSubtype);
                    subtypes.Add(possibleSubtypes[randomizer]);
                }
                else if (randomWrongSubtype == possibleSubtypes[1])
                {
                    int randomizer = Calculator.RemoveNumberAndGetRandomNumberFromList(1, 0, 3);
                    subtypes.Remove(randomWrongSubtype);
                    subtypes.Add(possibleSubtypes[randomizer]);
                }
                else
                {
                    int randomizer = Calculator.RemoveNumberAndGetRandomNumberFromList(2, 0, 3);
                    subtypes.Remove(randomWrongSubtype);
                    subtypes.Add(possibleSubtypes[randomizer]);
                }
            }
        }
        if (1 == subtypes.Count)
        {
            line += $"The Minions are composed of:\nOnly a {subtypes[0]}.";
        }
        else
        {
            line = "The Minions are composed of: ";
            foreach (string info in subtypes)
            {

                if (subtypes.IndexOf(info) == subtypes.Count - 1)
                {
                    line += $"\nand a {info}.";
                }
                else
                {
                    line += $"\na {info},";
                }


            }
        }

        ActedInfo actedInfo = new ActedInfo(line, null);
        return actedInfo;
    }
    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.AfterRoundStart)
        {
            Il2CppSystem.Collections.Generic.List<CharacterData> deckview = new Il2CppSystem.Collections.Generic.List<CharacterData>();
            deckview = Gameplay.Instance.GetScriptCharactersOfType(ECharacterType.Minion);
            if (deckview.Count > 0)
            {
                CharacterData randomCD = deckview[UnityEngine.Random.RandomRange(0, deckview.Count)];
                DeckView.AddToObscuredDeckView(randomCD);
            }
            
            
        }
            if (trigger == ETriggerPhase.Day)
        {
            if (charRef.statuses.Contains(ECharacterStatus.Corrupted))
            {
                onActed?.Invoke(GetBluffInfo(charRef));
            }
            else
            {
                onActed?.Invoke(GetInfo(charRef));
            }

        }
    }
    public override void BluffAct(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.AfterRoundStart)
        {
            Il2CppSystem.Collections.Generic.List<CharacterData> deckview = new Il2CppSystem.Collections.Generic.List<CharacterData>();
            deckview = Gameplay.Instance.GetScriptCharactersOfType(ECharacterType.Minion);
            if (deckview.Count > 0)
            {
                CharacterData randomCD = deckview[UnityEngine.Random.RandomRange(0, deckview.Count)];
                DeckView.AddToObscuredDeckView(randomCD);
            }


        }
        if (trigger == ETriggerPhase.Day)
        {
            this.onActed.Invoke(this.GetBluffInfo(charRef));

        }
    }
    public override CharacterData? GetBluffIfAble(Character charRef)
    {
        return null;
    }
}