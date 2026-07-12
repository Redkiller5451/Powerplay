using Il2Cpp;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Demon_Bluff_Mods;
[RegisterTypeInIl2Cpp]
public class Vortox : Demon
{
    public Vortox() : base(ClassInjector.DerivedConstructorPointer<Vortox>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Vortox(System.IntPtr ptr) : base(ptr)
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
        if (trigger != ETriggerPhase.Start) return;

        Il2CppSystem.Collections.Generic.List<Character> sortedCharacters = Gameplay.CurrentCharacters;
        sortedCharacters = CharactersHelper.GetSortedListWithCharacterFirst(sortedCharacters, charRef);

        sortedCharacters.RemoveAt(0);
        List<Character> adjacentGoodCharacters = new List<Character>();
        if (sortedCharacters[0].dataRef.type == ECharacterType.Villager)
            adjacentGoodCharacters.Add(sortedCharacters[0]);
        if (sortedCharacters[sortedCharacters.Count - 1].dataRef.type == ECharacterType.Villager)
            adjacentGoodCharacters.Add(sortedCharacters[sortedCharacters.Count - 1]);

        foreach (Character c in adjacentGoodCharacters)
            if (c.dataRef.role is SaintVillager)
            {
                adjacentGoodCharacters.Remove(c);
                break;
            }

        if (adjacentGoodCharacters.Count <= 0) return;

        Character randomCharacter = adjacentGoodCharacters[UnityEngine.Random.Range(0, adjacentGoodCharacters.Count)];
        CharacterData minionData = GetID();
        MelonLogger.Msg($"[LOG] Vortox added {minionData.name}");
        randomCharacter.Init(minionData);
        randomCharacter.statuses.AddStatus(ECharacterStatus.AlteredCharacter, charRef);
        randomCharacter.statuses.AddStatus(ECharacterStatus.MessedUpByEvil, charRef);

    } 
    private static CharacterData GetID()
    {
        CharacterData[] allDatas = Il2CppSystem.Array.Empty<CharacterData>();
            CharacterData[] weatherData = Il2CppSystem.Array.Empty<CharacterData>();
        var loadedCharList = Resources.FindObjectsOfTypeAll(Il2CppType.Of<CharacterData>());
        if (loadedCharList != null)
        {
            allDatas = new CharacterData[loadedCharList.Length];
            for (int j = 0; j < loadedCharList.Length; j++)
            {
                allDatas[j] = loadedCharList[j]!.Cast<CharacterData>();
               
            }
        }
        weatherData = new CharacterData[4];
        int i = 0;
        for (int j = 0; j < allDatas.Length; j++)
        {
            if (allDatas[j].type == WeatherType.Weather)
            {
                weatherData[i] = allDatas[j];
                i++;
            }
        }
        int randomIndex = UnityEngine.Random.Range(0, 4);
        if (randomIndex == 0) return weatherData[0];
        else if (randomIndex == 1) return weatherData[1];
        else if (randomIndex == 3) return weatherData[3];
        else return weatherData[2];
    }
}
