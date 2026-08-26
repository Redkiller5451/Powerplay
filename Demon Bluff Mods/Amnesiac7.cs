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
public class Amnesiac7Pick : Role
{
    Character chRef;
    public Amnesiac7Pick() : base(ClassInjector.DerivedConstructorPointer<Amnesiac7Pick>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        action1 = new System.Action(CharacterPicked);
        action2 = new System.Action(StopPick);
        action3 = new System.Action(CharacterPickedDrunk);
    }
    public Amnesiac7Pick(System.IntPtr ptr) : base(ptr)
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
        onActed?.Invoke(new ActedInfo(ConjourInfo(ClosestDisguisedAndWhichDisguise(outsiders[0]), outsiders[0])));
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
        onActed?.Invoke(new ActedInfo(ConjourInfo(ClosestDisguisedAndWhichDisguiseDrunk(outsiders[0]), outsiders[0])));

    }
    public string ClosestDisguisedAndWhichDisguise(Character picked)
    {
        int count = 0;
        int savedCount = 100;

        Il2CppSystem.Collections.Generic.List<Character> myList = (Gameplay.CurrentCharacters);
        myList = CharactersHelper.GetSortedListWithCharacterFirst(myList, picked);
        Character closestDisguised = null;
        myList.RemoveAt(0);
        for (int i = 0; i < myList.Count; i++)
        {
            if (myList[i].bluff != null)
            {
                closestDisguised = myList[i];
                savedCount = count;
                count = 0;
                break;
            }
            count++;
        }
        count = 0;
        for (int i = myList.Count - 1; i > 0; i--)
        {
            if (myList[i].bluff != null)
            {
                if (count < savedCount)
                {
                    closestDisguised = myList[i];
                    savedCount = count;
                    count = 0;
                }
                break;
            }
            count++;
        }
        if (closestDisguised == null) return "nothing";
        return closestDisguised.bluff.name;

    }
    public string ClosestDisguisedAndWhichDisguiseDrunk(Character picked)
    {
        int count = 0;
        int savedCount = 100;

        Il2CppSystem.Collections.Generic.List<Character> myList = (Gameplay.CurrentCharacters);
        myList = CharactersHelper.GetSortedListWithCharacterFirst(myList, picked);
        Character closestDisguised = null;
        myList.RemoveAt(0);
        for (int i = 0; i < myList.Count; i++)
        {
            if (myList[i].bluff != null)
            {
                count++;
            }
            else
            {
                {
                    closestDisguised = myList[i];
                    savedCount = count;
                    count = 0;
                    break;
                }

            }
        }
        count = 0;
        for (int i = myList.Count - 1; i > 0; i--)
        {
                if (myList[i].bluff != null)
                {
                    count++;
                }
                else
                {
                    if (count < savedCount)
                        {
                            closestDisguised = myList[i];
                            savedCount = count;
                            count = 0;
                        }
                     break;
                }
             
        }
        if (closestDisguised == null) return "nothing";
        return closestDisguised.dataRef.name;

    }

    public string ConjourInfo(string disguise, Character picked)
    {
        MelonLogger.Msg($"[LOG] Amne 7 triggered");
        return $"I picked #{picked.id} have received {disguise}!";
    }
}