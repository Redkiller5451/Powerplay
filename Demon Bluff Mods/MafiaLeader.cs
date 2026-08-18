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
public class MafiaLeader : Demon
{
    public MafiaLeader(System.IntPtr pointer)
        : base(pointer)
    {
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
    public void KillRandom(Character demonRef)
    {
        Il2CppSystem.Collections.Generic.List<Character> possibleCharacters = new();
        possibleCharacters = Characters.Instance.FilterAliveCharacters(Gameplay.CurrentCharacters);
        //possibleCharacters = Characters.Instance.FilterAlignmentCharacters(possibleCharacters, EAlignment.Good);
        possibleCharacters = Characters.Instance.FilterHiddenCharacters(possibleCharacters);
        possibleCharacters = Characters.Instance.FilterCharacterMissingStatus(possibleCharacters, ECharacterStatus.UnkillableByDemon);
        if (possibleCharacters.Count == 0) { return; }
        Characters.Instance.GetRandomAliveCharacter(possibleCharacters).KillByDemon(demonRef);
    }
    public override CharacterData GetBluffIfAble(Character charRef)
    {
        CharacterData bluff = Characters.Instance.GetRandomUniqueVillagerBluff();
        Gameplay.Instance.AddScriptCharacterIfAble(bluff.type, bluff);

        return bluff;
    }

    CharacterData pickedCharacterPrevData;
    public void SwapToGrunt()
    {
        Il2CppSystem.Collections.Generic.List<Character> viableCharacters = Gameplay.CurrentCharacters;
        viableCharacters = Characters.Instance.FilterAliveCharacters(viableCharacters);
        Il2CppSystem.Collections.Generic.List<Character> viableCharacters2 = Characters.Instance.FilterRealCharacterType(viableCharacters, WeatherType.Weather);
        viableCharacters = Characters.Instance.FilterRealCharacterType(viableCharacters, ECharacterType.Minion);
        foreach (Character chara in viableCharacters2)
        {
            viableCharacters.Add(chara);
        }
        foreach (Character charb in viableCharacters2)
        {
            DeckView.AddToObscuredDeckView(charb.dataRef);
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
                if (allDatas[j].characterId =="Jinx_POW")
                {
                    MafiaData.Add(allDatas[j]);
                break;
                }
            }
        for (int j = 0; j < allDatas.Length; j++)
        {
            if (allDatas[j].characterId =="Enforcer_POW")
            {
                MafiaData.Add(allDatas[j]);
                break;
            }
        }
        for (int j = 0; j < allDatas.Length; j++)
        {
            if (allDatas[j].characterId =="Bootlegger_POW")
            {
                MafiaData.Add(allDatas[j]);
                break;
            }
        }
        for (int j = 0; j < allDatas.Length; j++)
        {
            if (allDatas[j].characterId =="Influencer_POW")
            {
                MafiaData.Add(allDatas[j]);
                break;
            }
        }
        for (int j = 0; j < allDatas.Length; j++)
        {
            if (allDatas[j].characterId =="Forger_POW")
            {
                MafiaData.Add(allDatas[j]);
                break;
            }
        }
        for (int j = 0; j < allDatas.Length; j++)
        {
            if (allDatas[j].characterId =="Gangster_POW")
            {
                MafiaData.Add(allDatas[j]);
                break;
            }
        }
        for (int j = 0; j < allDatas.Length; j++)
        {
            if (allDatas[j].characterId =="Spokesperson_POW")
            {
                MafiaData.Add(allDatas[j]);
                break;
            }
        }
        Il2CppSystem.Collections.Generic.List<Character> allCharacters = Gameplay.CurrentCharacters;
        foreach (Character character1 in allCharacters)
        {
            if(character1.dataRef.characterId == "Jinx_POW")
            {
                MafiaData.Remove(character1.dataRef);
            }
            if (character1.dataRef.characterId == "Enforcer_POW")
            {
                MafiaData.Remove(character1.dataRef);
            }
            if (character1.dataRef.characterId == "Bootlegger_POW")
            {
                MafiaData.Remove(character1.dataRef);
            }
            if (character1.dataRef.characterId == "Influencer_POW")
            {
                MafiaData.Remove(character1.dataRef);
            }
            if (character1.dataRef.characterId == "Forger_POW")
            {
                MafiaData.Remove(character1.dataRef);
            }
            if (character1.dataRef.characterId == "Gangster_POW")
            {
                MafiaData.Remove(character1.dataRef);
            }
            if (character1.dataRef.characterId == "Spokesperson_POW")
            {
                MafiaData.Remove(character1.dataRef);
            }
        }
        if(MafiaData.Count == 0)
        {
            for (int j = 0; j < allDatas.Length; j++)
            {
                if (allDatas[j].characterId =="Grunt_POW")
                {
                    MafiaData.Add(allDatas[j]);
                    break;
                }
            }
        }
        foreach (Character character in viableCharacters)
        {
            int randomIndex = UnityEngine.Random.Range(0, MafiaData.Count);
            MelonLogger.Msg($"{MafiaData[randomIndex].characterName} is in play");
            character.Init(MafiaData[randomIndex]);
            if (MafiaData[randomIndex].characterId != "Grunt_POW")
                 MafiaData.RemoveAt(randomIndex);
        }
    }
    public void MuddleTheInfo()
    {
        Il2CppSystem.Collections.Generic.List<Character> allCharacters = Gameplay.CurrentCharacters;
        foreach (Character character in allCharacters)
        {
            character.statuses.AddStatus(Muddling.hiddenStatus, charRef);
        }
    }
   
    private bool AlreadyInPlay(CharacterData cd)
    {
        Il2CppSystem.Collections.Generic.List<Character> list1 = Gameplay.CurrentCharacters;
        list1 = Characters.Instance.FilterCharacterType(list1, MafiaType.Member);
        foreach (Character character in list1)
        {
            if (character.dataRef.characterId == cd.characterId)
            {
                return false;
            }
        }
        return true;
    }
}

