using HarmonyLib;
using Il2Cpp;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem;
using MelonLoader;
using System;
using System.ComponentModel.Design;
using UnityEngine;
using static MelonLoader.MelonLaunchOptions;
using static UnityEngine.GraphicsBuffer;

namespace Demon_Bluff_Mods;
[RegisterTypeInIl2Cpp]
public class Amnesiac : Role
{
    public Amnesiac() : base(ClassInjector.DerivedConstructorPointer<Amnesiac>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Amnesiac(System.IntPtr ptr) : base(ptr)
    {

    }
    public CharacterData[] allDatas = Il2CppSystem.Array.Empty<CharacterData>();
    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Start)
        {
            //NOT MY OWN CODE
            Il2CppSystem.Collections.Generic.List<CharacterData> possibleTPOWs = new Il2CppSystem.Collections.Generic.List<CharacterData>();
            Il2CppSystem.Collections.Generic.List<string> possibleTPOWIDs = new Il2CppSystem.Collections.Generic.List<string>();
            // Possible TPOWs: 
            possibleTPOWIDs.Add("Amne1_POW"); // First Amne
            possibleTPOWIDs.Add("Amne2_POW"); // Second Amne
            possibleTPOWIDs.Add("Amne3_POW"); // Third Amne
            possibleTPOWIDs.Add("Amne4_POW"); // Fourth Amne
            possibleTPOWIDs.Add("Amne5_POW"); // Fifth Amne
            possibleTPOWIDs.Add("Amne6_POW"); // Sixth Amne
            if (allDatas.Length == 0)
            {
                var loadedCharList = Resources.FindObjectsOfTypeAll(Il2CppType.Of<CharacterData>());
                if (loadedCharList != null)
                {
                    allDatas = new CharacterData[loadedCharList.Length];
                    for (int j = 0; j < loadedCharList.Length; j++)
                    {
                        allDatas[j] = loadedCharList[j]!.Cast<CharacterData>();
                    }
                }
            }

            for (int j = 0; j < allDatas.Length; j++)
            {
                if (possibleTPOWIDs.Contains(allDatas[j].characterId))
                {
                    possibleTPOWs.Add(allDatas[j]);
                }
            }

            CharacterData chosenTPOW = possibleTPOWs[UnityEngine.Random.RandomRangeInt(0, possibleTPOWs.Count)];
            charRef.Init(chosenTPOW);
                   }
    }
     public override void BluffAct(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Start)
             allDatas = Il2CppSystem.Array.Empty<CharacterData>();
        {
            //NOT MY OWN CODE
            Il2CppSystem.Collections.Generic.List<CharacterData> possibleTPOWs = new Il2CppSystem.Collections.Generic.List<CharacterData>();
            Il2CppSystem.Collections.Generic.List<string> possibleTPOWIDs = new Il2CppSystem.Collections.Generic.List<string>();
            // Possible TPOWs: 
            possibleTPOWIDs.Add("Amne1_POW"); // First Amne
            possibleTPOWIDs.Add("Amne2_POW"); // Second Amne
            possibleTPOWIDs.Add("Amne3_POW"); // Third Amne
            possibleTPOWIDs.Add("Amne4_POW"); // Fourth Amne
            possibleTPOWIDs.Add("Amne5_POW"); // Fifth Amne
            possibleTPOWIDs.Add("Amne6_POW"); // Sixth Amne
            if (allDatas.Length == 0)
            {
                var loadedCharList = Resources.FindObjectsOfTypeAll(Il2CppType.Of<CharacterData>());
                if (loadedCharList != null)
                {
                    allDatas = new CharacterData[loadedCharList.Length];
                    for (int j = 0; j < loadedCharList.Length; j++)
                    {
                        allDatas[j] = loadedCharList[j]!.Cast<CharacterData>();
                    }
                }
            }

            for (int j = 0; j < allDatas.Length; j++)
            {
                if (possibleTPOWIDs.Contains(allDatas[j].characterId))
                {
                    possibleTPOWs.Add(allDatas[j]);
                }
            }

            CharacterData chosenTPOW = possibleTPOWs[UnityEngine.Random.RandomRangeInt(0, possibleTPOWs.Count)];
            charRef.GiveBluff(chosenTPOW);
        }
    }
}
//5 on-pick abilities
//5 non on-pick abilities
