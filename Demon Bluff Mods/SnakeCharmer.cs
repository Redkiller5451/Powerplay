using Il2Cpp;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Demon_Bluff_Mods;
[RegisterTypeInIl2Cpp]
public class SnakeCharmer : Role
{

    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.AfterRoundStart && !charRef.statuses.Contains(ECharacterStatus.Corrupted))
        {
            //if (charRef.statuses.Contains(ECharacterStatus.Corrupted)) return;

            Character random = PrioritizeCertainEvils(charRef);
            CharacterData pickedEvil = random.dataRef;
            MelonLogger.Msg($"{random.id} is the Evil");
            random.Init(charRef.dataRef);
            charRef.Init(pickedEvil);
            random.DisableStartAbility();
            charRef.DisableStartAbility();
            charRef.statuses.statuses.Add(Rbed.silentRB);
            random.statuses.statuses.Add(ECharacterStatus.Corrupted);
            MelonLogger.Msg($"{random.id} is the Evil");
            MelonLogger.Msg($"The Snake Charmer has swapped #{charRef.id} and #{random.id}");
        }
        if(trigger == ETriggerPhase.Day)
        {
            MelonLogger.Msg($"Flutist said their piece");
            onActed?.Invoke(new ActedInfo($"I have been charmed by the Flutist!", null));
        }
    }
    private Character PrioritizeCertainEvils(Character charRef) {
        Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
        list1 = Characters.Instance.FilterAlignmentCharacters(list1, EAlignment.Evil);
        list1.Remove(charRef);
        Il2CppSystem.Collections.Generic.List<Character> prioritizedEvils = new();
        foreach (Character character in list1)
        {
            if (prioedEvils(character,charRef))
                prioritizedEvils.Add(character);
        }
        if (prioritizedEvils.Count > 0)
        {
            return prioritizedEvils[UnityEngine.Random.Range(0, prioritizedEvils.Count)];
        }
        else
        {
            return list1[UnityEngine.Random.Range(0, list1.Count)];
        }
    }
    private bool prioedEvils(Character character, Character charRef)
    {
        return (character.dataRef.characterId == "Baron_04539999" && IsntBaronSpawned(charRef)) || character.dataRef.characterId == "Mezepheles_09511163"
            || character.dataRef.characterId == "Puppet_15989619" || character.dataRef.characterId == "Traveler_POW"
            || character.dataRef.characterId == "Pooka_13445289";
    }
    private bool IsntBaronSpawned(Character charRef)
    {
        Il2CppSystem.Collections.Generic.List<Character> list = GetNeighbors(charRef);
        foreach (Character c in list)
        {
            if (c.dataRef.characterId == "Baron_04539999")
                return false;
        }
        return true;
    }
    private Il2CppSystem.Collections.Generic.List<Character> GetNeighbors(Character charRef)
    {
        Il2CppSystem.Collections.Generic.List<Character> myList = CharactersHelper.GetSortedListWithCharacterFirst(Gameplay.CurrentCharacters, charRef);
        myList.RemoveAt(0);
        Il2CppSystem.Collections.Generic.List<Character> neighbors = new Il2CppSystem.Collections.Generic.List<Character>();
        neighbors.Add(myList[0]);
        neighbors.Add(myList[myList.Count - 1]);
        return neighbors;
    }
    public override void BluffAct(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Day)
        {
            MelonLogger.Msg($"Flutist said their piece incorrectly...");
            onActed?.Invoke(new ActedInfo($"I have been charmed by the Flutist!", null));
        }
    }
    public override CharacterData GetRegisterAsRole(Character charRef)
    {
        //Taken from the Wretches code. Used to make the current Flutist still register as evil!
        Il2CppSystem.Collections.Generic.List<CharacterData> allChars = Gameplay.Instance.GetScriptCharacters();
        allChars = Characters.Instance.FilterCharacterAlignment(allChars, EAlignment.Evil);
        CharacterData randomMinion = allChars[UnityEngine.Random.Range(0, allChars.Count)];

        return randomMinion;
    }
    public SnakeCharmer() : base(ClassInjector.DerivedConstructorPointer<SnakeCharmer>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public SnakeCharmer(System.IntPtr ptr) : base(ptr)
    {
    }
}