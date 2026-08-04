using HarmonyLib;
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
public class CovenPreacher : Demon
{
    public CovenPreacher(System.IntPtr pointer)
        : base(pointer)
    {
    }
    public CovenPreacher() : base(ClassInjector.DerivedConstructorPointer<CovenPreacher>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public override string Description
    => "";

    public override ActedInfo GetInfo(Character charRef)
    {
        return new ActedInfo("");
    }
    public override ActedInfo GetBluffInfo(Character charRef)
    {
        return new ActedInfo("");
    }
    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger != ETriggerPhase.Night) return;
        //Kill();
    }
    public override CharacterData GetBluffIfAble(Character charRef)
    {
        CharacterData bluff = Characters.Instance.GetRandomUniqueVillagerBluff();
        Gameplay.Instance.AddScriptCharacterIfAble(bluff.type, bluff);

        return bluff;
    }
    public void KillHidden(Character demonRef)
    {
        Il2CppSystem.Collections.Generic.List<Character> possibleCharacters = new Il2CppSystem.Collections.Generic.List<Character>();
        possibleCharacters = Characters.Instance.FilterAliveCharacters(Gameplay.CurrentCharacters);
        possibleCharacters = Characters.Instance.FilterAlignmentCharacters(possibleCharacters, EAlignment.Good);
        possibleCharacters = Characters.Instance.FilterHiddenCharacters(possibleCharacters);
        possibleCharacters = Characters.Instance.FilterCharacterMissingStatus(possibleCharacters, ECharacterStatus.UnkillableByDemon);
        if (possibleCharacters.Count <= 0) { KillRandom(demonRef); return; }
        Characters.Instance.GetRandomAliveCharacter(possibleCharacters).KillByDemon(demonRef);
    }
    public void KillRandom(Character demonRef)
    {
        Il2CppSystem.Collections.Generic.List<Character> possibleCharacters = new Il2CppSystem.Collections.Generic.List<Character>();
        possibleCharacters = Characters.Instance.FilterAliveCharacters(Gameplay.CurrentCharacters);
        //possibleCharacters = Characters.Instance.FilterAlignmentCharacters(possibleCharacters, EAlignment.Good);
        possibleCharacters = Characters.Instance.FilterHiddenCharacters(possibleCharacters);
        possibleCharacters = Characters.Instance.FilterCharacterMissingStatus(possibleCharacters, ECharacterStatus.UnkillableByDemon);
        if (possibleCharacters.Count == 0) { return; }
        Characters.Instance.GetRandomAliveCharacter(possibleCharacters).KillByDemon(demonRef);
    }
    public void SwapToCult()
    {
        Il2CppSystem.Collections.Generic.List<Character> viableCharacters = Gameplay.CurrentCharacters;
        viableCharacters = Characters.Instance.FilterAliveCharacters(viableCharacters);
        Il2CppSystem.Collections.Generic.List<Character> viableCharacters2 = Characters.Instance.FilterRealCharacterType(viableCharacters, WeatherType.Weather);
        viableCharacters = Characters.Instance.FilterRealCharacterType(viableCharacters, ECharacterType.Minion);
        foreach (Character chara in viableCharacters2)
        {
            viableCharacters.Add(chara);
        }
        Il2CppSystem.Collections.Generic.List<CharacterData> MafiaData = new();

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
            if (allDatas[j].characterId == "Slinger_POW")
            {
                MafiaData.Add(allDatas[j]);
                break;
            }
        }
        for (int j = 0; j < allDatas.Length; j++)
        {
            if (allDatas[j].characterId == "Wildling_POW")
            {
                MafiaData.Add(allDatas[j]);
                break;
            }
        }
        for (int j = 0; j < allDatas.Length; j++)
        {
            if (allDatas[j].characterId == "VoodooMaster_POW")
            {
                MafiaData.Add(allDatas[j]);
                break;
            }
        }
        for (int j = 0; j < allDatas.Length; j++)
        {
            if (allDatas[j].characterId == "PowderMaker_POW")
            {
                MafiaData.Add(allDatas[j]);
                break;
            }
        }
        for (int j = 0; j < allDatas.Length; j++)
        {
            if (allDatas[j].characterId == "Brewer_POW")
            {
                MafiaData.Add(allDatas[j]);
                break;
            }
        }


        Il2CppSystem.Collections.Generic.List<Character> allCharacters = Gameplay.CurrentCharacters;
        foreach (Character character1 in allCharacters)
        {
            if (character1.dataRef.characterId == "Slinger_POW")
            {
                MafiaData.Remove(character1.dataRef);
            }
            if (character1.dataRef.characterId == "Wildling_POW")
            {
                MafiaData.Remove(character1.dataRef);
            }
            if (character1.dataRef.characterId == "VoodooMaster_POW")
            {
                MafiaData.Remove(character1.dataRef);
            }
            if (character1.dataRef.characterId == "PowderMaker_POW")
            {
                MafiaData.Remove(character1.dataRef);
            }
            if (character1.dataRef.characterId == "Brewer_POW")
            {
                MafiaData.Remove(character1.dataRef);
            }
        }
        if (MafiaData.Count == 0)
        {
            for (int j = 0; j < allDatas.Length; j++)
            {
                if (allDatas[j].characterId == "CultMember_POW")
                {
                    MafiaData.Add(allDatas[j]);
                    break;
                }
            }
        }
        foreach (Character character in viableCharacters)
        {
            int randomIndex = UnityEngine.Random.Range(0, MafiaData.Count);
            Gameplay.Instance.AddScriptCharacter(ECharacterType.Minion, MafiaData[randomIndex]);
            character.Init(MafiaData[randomIndex]);
            if (MafiaData[randomIndex].characterId != "CultMember_POW")
                MafiaData.RemoveAt(randomIndex);
        }
    }
    public void GiveTheBook(Character charRef)
    {
        Il2CppSystem.Collections.Generic.List<Character> viableCharacters = Gameplay.CurrentCharacters;
        viableCharacters = Characters.Instance.FilterAliveCharacters(viableCharacters);
        viableCharacters = Characters.Instance.FilterRealCharacterType(viableCharacters, CovType.Follower);
        viableCharacters[UnityEngine.Random.Range(0, viableCharacters.Count)].statuses.AddStatus(NecroWielder.Necronomicon, charRef);
    }
}
