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
public class Amnesiac8Pick : Role
{
    Character chRef;
    public Amnesiac8Pick() : base(ClassInjector.DerivedConstructorPointer<Amnesiac8Pick>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        action1 = new System.Action(CharacterPicked);
        action2 = new System.Action(StopPick);
        action3 = new System.Action(CharacterPickedDrunk);
    }
    public Amnesiac8Pick(System.IntPtr ptr) : base(ptr)
    {
        action1 = new System.Action(CharacterPicked);
        action2 = new System.Action(StopPick);
        action3 = new System.Action(CharacterPickedDrunk);
    }
    public override ActedInfo GetInfo(Character charRef)
    {
        return new ActedInfo("");
    }
    public override ActedInfo GetBluffInfo(Character charRef)
    {
        return new ActedInfo("");
    }
    private Il2CppSystem.Action action1;
    private Il2CppSystem.Action action2;
    private Il2CppSystem.Action action3;
    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger != ETriggerPhase.Day) return;
        chRef = charRef;
        CharacterPicker.Instance.StartPickCharacters(1, charRef);
        if (charRef.statuses.Contains(ECharacterStatus.Corrupted))
        {
            CharacterPicker.OnCharactersPicked += action3;
            CharacterPicker.OnStopPick += action2;
        }
        else
        {
            CharacterPicker.OnCharactersPicked += action1;
            CharacterPicker.OnStopPick += action2;
        }

    }
    private void StopPick()
    {
        CharacterPicker.OnCharactersPicked -= action1;
        CharacterPicker.OnCharactersPicked -= action3;
        CharacterPicker.OnStopPick -= action2;

    }

    private void CharacterPicked()
    {
        CharacterPicker.OnCharactersPicked -= action1;
        CharacterPicker.OnStopPick -= action2;
        List<Character> outsiders = new List<Character>();
        List<int> ids = new List<int>();
        foreach (Character c in CharacterPicker.PickedCharacters)
        {
            ids.Add(c.id);
            outsiders.Add(c);
        }
        onActed?.Invoke(new ActedInfo(ConjourInfo(GoodInRange(outsiders[0]), outsiders[0])));
    }

    public override void BluffAct(ETriggerPhase trigger, Character charRef)
    {
        if (trigger != ETriggerPhase.Day) return;
        chRef = charRef;
        CharacterPicker.Instance.StartPickCharacters(1, charRef);
        CharacterPicker.OnCharactersPicked += action3;
        CharacterPicker.OnStopPick += action2;
    }
    private void CharacterPickedDrunk()
    {
        CharacterPicker.OnCharactersPicked -= action3;
        CharacterPicker.OnStopPick -= action2;
        List<Character> outsiders = new List<Character>();
        List<int> ids = new List<int>();
        foreach (Character c in CharacterPicker.PickedCharacters)
        {
            ids.Add(c.id);
            outsiders.Add(c);
        }
        onActed?.Invoke(new ActedInfo(ConjourInfo(GoodInRangeDrunk(outsiders[0]), outsiders[0])));

    }
    public string GoodInRange(Character picked)
    {
        Il2CppSystem.Collections.Generic.List<Character> outsiders = GetNeighbors(picked);
        Il2CppSystem.Collections.Generic.List<string> possibleGood = new();
        foreach (Character c in outsiders)
        {
            if (c.GetRegisterAlignment() == EAlignment.Good)
            {
                possibleGood.Add(c.dataRef.name);
            }
        }
        if (possibleGood.Count == 0) return "nothing";
        return possibleGood[UnityEngine.Random.Range(0, possibleGood.Count)];
    }
    public string GoodInRangeDrunk(Character picked)
    {
        Il2CppSystem.Collections.Generic.List<Character> outsiders = GetNeighbors(picked);
        Il2CppSystem.Collections.Generic.List<string> possibleGood = new();
        foreach (Character c in outsiders)
        {
            if (c.GetRegisterAlignment() == EAlignment.Evil && c.bluff != null)
            {
                possibleGood.Add(c.bluff.name);
            }
        }
        if (possibleGood.Count == 0) return "nothing";
        return possibleGood[UnityEngine.Random.Range(0, possibleGood.Count)];
    }
    public Il2CppSystem.Collections.Generic.List<Character> GetNeighbors(Character charRef)
    {
        Il2CppSystem.Collections.Generic.List<Character> myList = CharactersHelper.GetSortedListWithCharacterFirst(Gameplay.CurrentCharacters, charRef);
        myList.RemoveAt(0);
        Il2CppSystem.Collections.Generic.List<Character> neighbors = new Il2CppSystem.Collections.Generic.List<Character>();
        neighbors.Add(myList[0]);
        neighbors.Add(myList[1]);
        neighbors.Add(myList[myList.Count - 1]);
        neighbors.Add(myList[myList.Count - 2]);
        return neighbors;
    }

    public string ConjourInfo(string disguise, Character picked)
    {
        MelonLogger.Msg($"[LOG] Amne 8 triggered");
        return $"I picked #{picked.id} have received {disguise}!";
    }
}
