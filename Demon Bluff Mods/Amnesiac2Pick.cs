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
public class Amnesiac2Pick : Role
{
    public Amnesiac2Pick() : base(ClassInjector.DerivedConstructorPointer<Amnesiac2Pick>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        action1 = new System.Action(CharacterPicked);
        action2 = new System.Action(StopPick);
        action3 = new System.Action(CharacterPickedDrunk);
    }
    public Amnesiac2Pick(System.IntPtr ptr) : base(ptr)
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
        CharacterPicker.Instance.StartPickCharacters(1, charRef);
        CharacterPicker.OnCharactersPicked += action1;
        CharacterPicker.OnStopPick += action2;
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
        int nPicks = GetClosestAlignement(outsiders[0]);
        onActed?.Invoke(new ActedInfo(ConjourInfo(nPicks, outsiders[0])));

    }

    public override void BluffAct(ETriggerPhase trigger, Character charRef)
    {
        if (trigger != ETriggerPhase.Day) return;
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
        int nPicks = GetClosestAlignement(outsiders[0]);
        nPicks = Calculator.RemoveNumberAndGetRandomNumberFromList(nPicks, 0, 5);
        onActed?.Invoke(new ActedInfo(ConjourInfo(nPicks, outsiders[0])));

    }
    public int GetClosestAlignement(Character pickedGood)
    {
        int count = 0;
        int savedCount = 100;

        Il2CppSystem.Collections.Generic.List<Character> myList = (Gameplay.CurrentCharacters);
        myList = CharactersHelper.GetSortedListWithCharacterFirst(myList, pickedGood);

        myList.RemoveAt(0);
        for (int i = 0; i < myList.Count; i++)
        {
            if (myList[i].GetCharacterType() == pickedGood.GetCharacterType())
            {
                savedCount = count;
                count = 0;
                break;
            }
            count++;
        }
        count = 0;
        for (int i = myList.Count - 1; i > 0; i--)
        {
            if (myList[i].GetCharacterType() == pickedGood.GetCharacterType())
            {
                if (count < savedCount)
                {
                    savedCount = count;
                    count = 0;
                }
                break;
            }
            count++;
        }

        return savedCount;
    }
    public string ConjourInfo(int nOfEvils, Character picked)
    {

        return $"I picked #{picked.id}, and I have received a {nOfEvils}";
    }
}