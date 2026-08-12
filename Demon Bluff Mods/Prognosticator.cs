using Il2Cpp;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSoftMasking.Samples;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using System;
using UnityEngine;
using static MelonLoader.MelonLaunchOptions;
using static MelonLoader.Modules.MelonModule;

namespace Demon_Bluff_Mods;
[RegisterTypeInIl2Cpp]
public class Prognosticator : Role
{
    public Prognosticator() : base(ClassInjector.DerivedConstructorPointer<Prognosticator>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        action1 = new System.Action(CharacterPicked);
        action2 = new System.Action(StopPick);
        action3 = new System.Action(CharacterPickedDrunk);
    }
    public Prognosticator(System.IntPtr ptr) : base(ptr)
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
        Il2CppSystem.Collections.Generic.List<Character> outsiders = new Il2CppSystem.Collections.Generic.List<Character>();
        Il2CppSystem.Collections.Generic.List<int> ids = new Il2CppSystem.Collections.Generic.List<int>();
        foreach (Character c in CharacterPicker.PickedCharacters)
        {
            ids.Add(c.id);
            outsiders.Add(c);
        }
        int nOfAllies = GetRowOfAllies(outsiders[0]);
        onActed?.Invoke(new ActedInfo(ConjourInfo(nOfAllies, outsiders[0]), outsiders));
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
        Il2CppSystem.Collections.Generic.List<Character> outsiders = new Il2CppSystem.Collections.Generic.List<Character>();
        Il2CppSystem.Collections.Generic.List<int> ids = new Il2CppSystem.Collections.Generic.List<int>();
        foreach (Character c in CharacterPicker.PickedCharacters)
        {
            ids.Add(c.id);
            outsiders.Add(c);
        }
        int nOfAllies = GetRowOfAllies(outsiders[0]);
        int randomizer = Calculator.RemoveNumberAndGetRandomNumberFromList(nOfAllies, 0, 4);
        onActed?.Invoke(new ActedInfo(ConjourInfo(randomizer, outsiders[0]),outsiders));

    }
    public string ConjourInfo(int nOfEvils, Character picked)
    { 
        if(nOfEvils == 0)
        {
            return $"#{picked.id} is isolated from their allies.";
        }
        else if(nOfEvils == 1)
        {
            return $"#{picked.id} has 1 allied neighbor in their chain.";
        }
        else
        {
            return $"#{picked.id} has {nOfEvils} allied neighbors in their chain.";
        }
    }
    public int GetRowOfAllies(Character charRef)
    {
        Il2CppSystem.Collections.Generic.List<Character> allChars = Gameplay.CurrentCharacters;
        System.Collections.Generic.List<Character> translatingCurrentCharacters = new();
        foreach (Character c in allChars)
        {
            translatingCurrentCharacters.Add(c);
        }
        System.Collections.Generic.List<Character> clockwise = new(translatingCurrentCharacters);
        System.Collections.Generic.List<Character> counterclockwise = new(translatingCurrentCharacters);

        foreach (Character ch in Gameplay.CurrentCharacters)
        {
            counterclockwise.Remove(ch);
            if (charRef == ch)
            {
                counterclockwise.Remove(ch);
                break;
            }
        }
        foreach (Character ch in Gameplay.CurrentCharacters)
        {
            if (charRef == ch)
                break;

            counterclockwise.Add(ch);
        }
        clockwise = new(counterclockwise);
        clockwise.Reverse();

        int clockwiseNumber = 0;
        int counterClockwiseNumber = 0;

        foreach (Character c in counterclockwise)
        {
            counterClockwiseNumber++;
            if (c.GetRegisterAlignment() != charRef.alignment)
                break;
        }
        foreach (Character c in clockwise)
        {
            clockwiseNumber++;
            if (c.GetRegisterAlignment() != charRef.alignment)
                break;
        }
        
        return (counterClockwiseNumber+clockwiseNumber)-2;
    }
}
