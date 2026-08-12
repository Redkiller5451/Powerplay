using Il2Cpp;
using Il2CppInterop.Runtime;
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
        if (trigger == ETriggerPhase.Start && !charRef.statuses.Contains(ECharacterStatus.Corrupted))
        {
            //if (charRef.statuses.Contains(ECharacterStatus.Corrupted)) return;

            Character random = PrioritizeCertainEvils(charRef);
            if (random == null)
            {
                onActed.Invoke(new ActedInfo($"I couldn't charm anyone..."));
                return;
            }
            CharacterData pickedEvil = random.dataRef;
            MelonLogger.Msg($"{random.id} is the Evil");
            Il2CppSystem.Collections.Generic.List<ECharacterStatus> statuses = random.statuses.statuses;
            random.Init(GetFlutistData());
            charRef.Init(pickedEvil);
            random.DisableStartAbility();
            charRef.DisableStartAbility();
            random.statuses.statuses.Add(Rbed.silentRB);
            charRef.statuses.statuses.Add(ECharacterStatus.AlteredCharacter);
            random.statuses.statuses.Add(ECharacterStatus.AlteredCharacter);
            if (pickedEvil.characterName == "Puppet")
            {
                charRef.statuses.statuses.Add(ECharacterStatus.HealthyBluff);
                charRef.statuses.statuses.Add(ECharacterStatus.WorkingAbility);
            }
            foreach (ECharacterStatus status in statuses)
            {
                charRef.statuses.statuses.Add((ECharacterStatus)status);
            }
            MelonLogger.Msg($"{random.id} is the Evil");
            MelonLogger.Msg($"The Snake Charmer has swapped #{charRef.id} and #{random.id}");
        }
        if(trigger == ETriggerPhase.Day)
        {
            MelonLogger.Msg($"Flutist is saying their piece");
            if (this.onActed == null)
            {
                this.onActed?.Invoke(new ActedInfo($"I have been charmed by the Flutist!"));
            }
            else
            {
                charRef.role.onActed.Invoke(new ActedInfo($"I have been charmed by the Flutist!"));
            }
            MelonLogger.Msg($"Flutist said their piece");
            return;
        }
    }
    private CharacterData GetFlutistData()
    {
        CharacterData[] allDatas = Il2CppSystem.Array.Empty<CharacterData>();
        var loadedCharList = Resources.FindObjectsOfTypeAll(Il2CppType.Of<CharacterData>());
        if (loadedCharList != null)
        {
            allDatas = new CharacterData[loadedCharList.Length];
            for (int j = 0; j < loadedCharList.Length; j++)
            {
                allDatas[j] = loadedCharList[j]!.Cast<CharacterData>();
            }
        }
        for (int j = 0; j < allDatas.Length; j++)
        {
            if (allDatas[j].characterId =="Flutist_POW")
            {
                    return (allDatas[j]);
            }
        }
        return null;
    }
    private Character PrioritizeCertainEvils(Character charRef) {
        Il2CppSystem.Collections.Generic.List<Character> currentChars = (Gameplay.CurrentCharacters);
        Il2CppSystem.Collections.Generic.List<Character> list1 = new();
        foreach (Character c in currentChars)
        {
            list1.Add(c);
        }
        list1 = Characters.Instance.FilterRealAlignmentCharacters(list1, EAlignment.Evil);
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
            list1 = Characters.Instance.FilterOutStatus(list1, NecroWielder.Necronomicon);
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
        if (trigger == ETriggerPhase.Day || trigger == ETriggerPhase.OnReveal)
        {
            MelonLogger.Msg($"Flutist said their piece incorrectly...");
            charRef.role.onActed.Invoke(new ActedInfo($"I have been charmed by the Flutist!"));
        }
    }
    public override CharacterData GetBluffIfAble(Character charRef)
    {
        return null;
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