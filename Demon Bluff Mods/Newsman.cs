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
public class Newsman : Role
{
    public Newsman() : base(ClassInjector.DerivedConstructorPointer<Newsman>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Newsman(System.IntPtr ptr) : base(ptr)
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
        int howFar = GetClosestPoisonedCharacter(charRef);
        Il2CppSystem.Collections.Generic.List<Character> chars = Characters.Instance.GetCharactersAtRange(howFar, charRef);

        string info = ConjourInfo(howFar, charRef);
        ActedInfo newInfo = new ActedInfo(info, chars);
        return newInfo;
    }

    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger != ETriggerPhase.Day) return;
        onActed?.Invoke(GetInfo(charRef));
    }

    public override void BluffAct(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Day)
            onActed?.Invoke(GetBluffInfo(charRef));

    }

    public override ActedInfo GetBluffInfo(Character charRef)
    {
        int howFar = GetClosestPoisonedCharacter(charRef);

        int randomHowFar = Calculator.RemoveNumberAndGetRandomNumberFromList(howFar, 0, 4);
        Il2CppSystem.Collections.Generic.List<Character> chars = Characters.Instance.GetCharactersAtRange(randomHowFar, charRef);

        string info = ConjourInfo(randomHowFar, charRef);

        ActedInfo newInfo = new ActedInfo(info, chars);
        return newInfo;
    }
    public int GetClosestPoisonedCharacter(Character charRef)
    {
        Il2CppSystem.Collections.Generic.List<Character> myList = CharactersHelper.GetSortedListWithCharacterFirst(Gameplay.CurrentCharacters, charRef);

        myList.RemoveAt(0);
        int savedCount = 0;
        int count = 0;
        for (int i = 0; i < myList.Count; i++)
        {
            count++;
            if (myList[i].statuses.statuses.Contains(Mad.mad2) || myList[i].statuses.statuses.Contains(Mad.mad))
            {
                savedCount = count;
                count = 0;
                break;
            }
        }
        count = 0;
        for (int i = myList.Count - 1; i > 0; i--)
        {
            count++;
            if (myList[i].statuses.statuses.Contains(Mad.mad2) || myList[i].statuses.statuses.Contains(Mad.mad))
            {
                if (count < savedCount)
                {
                    savedCount = count;
                    count = 0;
                }
                break;
            }
        }

        return savedCount;
    }
    public string ConjourInfo(int howFar, Character charRef)
    {
        string info = "";
        if (howFar == 0)
            info = "There are no Mad characters";
        else if (howFar == 1)
            info = "I am 1 card away from a Mad character";
        else
            info = $"I am {howFar} cards away from a Mad character";

        return info;
    }
}
