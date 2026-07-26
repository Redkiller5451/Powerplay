using Il2Cpp;
using HarmonyLib;
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
public class Auditor : Demon
{
    public Auditor() : base(ClassInjector.DerivedConstructorPointer<Auditor>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Auditor(System.IntPtr ptr) : base(ptr)
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
        if (ETriggerPhase.Start == trigger)
        {
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            Il2CppSystem.Collections.Generic.List<Character> list2 = Characters.Instance.FilterRealCharacterType(list1, ECharacterType.Villager);
            Il2CppSystem.Collections.Generic.List<Character> affected = new();
            int count = 0;
            do
            {
                int randomIndex = UnityEngine.Random.Range(0, list2.Count);
                Character random = list2[randomIndex];
                affected.Add(random);
                list2.Remove(random);
                count++;
            } while (list1.Count > 0 && count < 3);
            affected[0].statuses.AddStatus(ECharacterStatus.Corrupted, charRef);
            affected[1].statuses.AddStatus(ECharacterStatus.Corrupted, charRef);
            affected[0].statuses.AddStatus(Audited.audited, charRef);
            affected[1].statuses.AddStatus(Audited.audited, charRef);
            affected[0].statuses.AddStatus(ECharacterStatus.MessedUpByEvil, charRef);
            affected[1].statuses.AddStatus(ECharacterStatus.MessedUpByEvil, charRef);
            TurnIntoRepossessed(affected[2]);

        }
        //Taken from Wingidons Undying 
    }
    private void TurnIntoRepossessed(Character affected)
    {
        //Code taken from Wingidon
        CharacterData[] allDatas = Il2CppSystem.Array.Empty<CharacterData>();
        var loadedCharList = Resources.FindObjectsOfTypeAll(Il2CppType.Of<CharacterData>());
        if (loadedCharList != null)
        {
            allDatas = new CharacterData[loadedCharList.Length];
            for (int j = 0; j < loadedCharList.Length; j++)
            {
                allDatas[j] = loadedCharList[j]!.Cast<CharacterData>();
                affected.statuses.AddStatus(ECharacterStatus.AlteredCharacter, charRef);
                affected.statuses.AddStatus(ECharacterStatus.MessedUpByEvil, charRef);
            }
        }
        for (int j = 0; j < allDatas.Length; j++)
        {
            if (allDatas[j].characterId == "Repossessed_POW")
            {
                if (affected.GetRegisterAs().characterId != allDatas[j].characterId)
                {
                    affected.Init(allDatas[j]);
                }
            }
        }
    }
}
public static class Audited
{
    public static ECharacterStatus audited = (ECharacterStatus)300;
}
