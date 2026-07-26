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
public class Repossessed : Role
{

    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Day)
        {
            onActed?.Invoke(GetInfo(charRef));
        }
    }
    public override ActedInfo GetInfo(Character charRef)
    {
        Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
        Il2CppSystem.Collections.Generic.List<Character> list2 = Characters.Instance.FilterCharacterContainsStatus(list1, Audited.audited);
        Il2CppSystem.Collections.Generic.List<Character> list3 = Characters.Instance.FilterByRole(list1, "Auditor_POW");
        System.Collections.Generic.List<Character> infoList = new();
        foreach (Character character in list2)
        {
            infoList.Add(character);
        }
        foreach (Character character in list3)
        {
            infoList.Add(character);
        }
        infoList = infoList
            .OrderBy(c => c.id)
            .ThenBy(_ => UnityEngine.Random.value)
            .ToList();

        Il2CppSystem.Collections.Generic.List<Character> infoTranslation = new();
        foreach (Character character in infoList)
            infoTranslation.Add(character);
        string info = ConjourInfo(infoList[0].id, infoList[1].id, infoList[2].id, charRef);
        return new ActedInfo(info, infoTranslation);
    }
    public string ConjourInfo(int id, int id2, int id3, Character charRef)
    {
        //string localization = TryLocalize<AlchemistLoc>(new List<object>() { howManyCures });
        //if (!string.IsNullOrEmpty(localization))
        //return localization;

        string info = $"One is the Auditor:\n#{id}, #{id2} or #{id3}";

        return info;
    }
    public Repossessed() : base(ClassInjector.DerivedConstructorPointer<Repossessed>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Repossessed(System.IntPtr ptr) : base(ptr)
    {
    }
}