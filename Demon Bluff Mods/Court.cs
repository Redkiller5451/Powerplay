using Il2Cpp;
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
public class Court : Demon
{
    public Court() : base(ClassInjector.DerivedConstructorPointer<Court>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Court(System.IntPtr ptr) : base(ptr)
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


    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Start)
        {
        Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
        Il2CppSystem.Collections.Generic.List<Character> list2 = Characters.Instance.FilterAlignmentCharacters(list1, EAlignment.Good);
        Il2CppSystem.Collections.Generic.List<Character> list3 = Characters.Instance.FilterAlignmentCharacters(list1, EAlignment.Evil);
            Il2CppSystem.Collections.Generic.List<Character> list4 = Characters.Instance.FilterAlignmentCharacters(list1, WeatherAlignement.Weather);
            foreach (Character character in list4)
            {
                list3.Add(character);
            }
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
                if (allDatas[j].characterId == "Juror_POW")
                {
                        foreach (Character c in list2)
                        {
                            if (c.GetRegisterAs().characterId != allDatas[j].characterId)
                                {
                                    c.Init(allDatas[j]);
                                    c.statuses.statuses.RemoveRange(0, c.statuses.statuses.Count);
                                    c.statuses.AddStatus(ECharacterStatus.AppearTruthfull, c);
                                    c.statuses.AddStatus(ECharacterStatus.HealthyBluff, c);
                                }
                        }
                    break;
                }

            
             }
        
                for (int j = 0; j < allDatas.Length; j++)
                {
                    if (allDatas[j].characterId == "Court_POW")
                    {
                    foreach (Character c in list3)
                       {        
                           if (c.GetRegisterAs().characterId != allDatas[j].characterId)
                            {
                            c.Init(allDatas[j]);
                            c.statuses.statuses.RemoveRange(0, c.statuses.statuses.Count);
                            c.statuses.statuses.Remove(Protected.protect);
                            }
                    }
                    break;
                    }
                }
            }
        

    }
    public override CharacterData GetBluffIfAble(Character charRef)
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
        int charDataId = 0;
        for (int j = 0; j < allDatas.Length; j++)
        {
            if (allDatas[j].characterId == "Juror_POW")
            {
                charDataId = j;
                break;
            }
        }
        return allDatas[charDataId];
    }
    //Taken from Wingidons Undying 
}