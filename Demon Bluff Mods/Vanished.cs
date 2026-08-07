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
public class Vanished : Role
{
    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if(trigger == ETriggerPhase.AfterRoundStart)
        {
            charRef.statuses.AddStatus(ECharacterStatus.Silenced, charRef);
            charRef.statuses.AddStatus(UO.UnknownObstacle, charRef);
            GetClosestAlignment(charRef).statuses.statuses.Add(ECharacterStatus.Silenced);
        }
    }
    public Character GetClosestAlignment(Character charRef)
    {
        Il2CppSystem.Collections.Generic.List<Character> allChars = Gameplay.CurrentCharacters;
        System.Collections.Generic.List<Character> translatingCurrentCharacters = new();
        foreach (Character c in allChars)
        {
            translatingCurrentCharacters.Add(c);
        }
        System.Collections.Generic.List <Character> clockwise = new(translatingCurrentCharacters);
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
            if (c.GetRegisterAlignment() == EAlignment.Evil)
                break;
        }
        foreach (Character c in clockwise)
        {
            clockwiseNumber++;
            if (c.GetRegisterAlignment() == EAlignment.Evil)
                break;
        }
        Character silenced = null;
        if(clockwiseNumber >= counterClockwiseNumber) { 
            foreach (Character character in clockwise)
            {
                if (character.alignment == EAlignment.Evil)
                {
                 silenced = character;
                    break;
                }
            }
        }
        else
        {
            foreach (Character character in counterclockwise)
            {
                if (character.alignment == EAlignment.Evil)
                {
                    silenced = character;
                    break;
                }
            }
        }
        return silenced;
    }
    public override void BluffAct(ETriggerPhase trigger, Character charRef)
    {       if (trigger == ETriggerPhase.AfterRoundStart)
        {
            charRef.statuses.AddStatus(ECharacterStatus.Silenced, charRef);
            charRef.statuses.AddStatus(UO.UnknownObstacle, charRef);
            GetClosestAlignmentBluff(charRef).statuses.statuses.Add(ECharacterStatus.Silenced);
        }

    }
    public Character GetClosestAlignmentBluff(Character charRef)
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
            if (c.GetRegisterAlignment() == EAlignment.Good)
                break;
        }
        foreach (Character c in clockwise)
        {
            clockwiseNumber++;
            if (c.GetRegisterAlignment() == EAlignment.Good)
                break;
        }
        Character silenced = null;
        if (clockwiseNumber >= counterClockwiseNumber)
        {
            foreach (Character character in clockwise)
            {
                if (character.alignment == EAlignment.Good)
                {
                    silenced = character;
                    break;
                }
            }
        }
        else
        {
            foreach (Character character in counterclockwise)
            {
                if (character.alignment == EAlignment.Good)
                {
                    silenced = character;
                    break;
                }
            }
        }
        return silenced;
    }

    public Vanished() : base(ClassInjector.DerivedConstructorPointer<Vanished>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);

    }
    public Vanished(System.IntPtr ptr) : base(ptr)
    {
    }
}