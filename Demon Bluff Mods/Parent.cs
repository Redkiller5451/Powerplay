using Il2Cpp;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem;
using MelonLoader;
using System;
using System.ComponentModel.Design;
using UnityEngine;

namespace Demon_Bluff_Mods;
[RegisterTypeInIl2Cpp]
public class Parent : Role
{
    /**
     * In case people are curious where I got the idea for this... I didn't make this! My father did! I literally just asked both my parents "What would you think a role called 'Parent'
     * would do" and he responded "They would do anything, including lie, to protect their child." And I stuck to that idea. Hence why Parent is unbluffable.
     */
    Character isTheChild = null;
    public Parent() : base(ClassInjector.DerivedConstructorPointer<Parent>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Parent(System.IntPtr ptr) : base(ptr)
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
        if(isTheChild.dataRef.gender == EGender.Male)
        {
            return new ActedInfo($"My son is a {isTheChild.dataRef.characterName}", null);
        }
        else if (isTheChild.dataRef.gender == EGender.Female)
        {
            return new ActedInfo($"My daughter is a {isTheChild.dataRef.characterName}", null);
        }
        else
        {
            return new ActedInfo($"My child is a {isTheChild.dataRef.characterName}", null);
        }

    }
    public override ActedInfo GetBluffInfo(Character charRef)
    {
        if (isTheChild.dataRef.gender == EGender.Male)
        {
            return new ActedInfo($"My son is a {isTheChild.bluff.characterName}", null);
        }
        else if (isTheChild.dataRef.gender == EGender.Female)
        {
            return new ActedInfo($"My daughter is a {isTheChild.bluff.characterName}", null);
        }
        else
        {
            return new ActedInfo($"My child is a {isTheChild.bluff.characterName}", null);
        } 
    }
    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Start)
        {
            MelonLogger.Msg("Parent Acted");
            Il2CppSystem.Collections.Generic.List<Character> currentChars = (Gameplay.CurrentCharacters);
            Il2CppSystem.Collections.Generic.List<Character> list1 = new();
            foreach (Character c in currentChars)
            {
                list1.Add(c);
            }
            list1.Remove(charRef);
            isTheChild = list1[UnityEngine.Random.Range(0, list1.Count)];
            if(isTheChild.alignment == EAlignment.Evil)
            {
                charRef.ChangeAlignment(EAlignment.Evil);
            }
        }
        if (trigger == ETriggerPhase.Day)
        {
            if (charRef.alignment == EAlignment.Evil)
            {
  
                    if (isTheChild.bluff != null)
                    {
                        onActed?.Invoke(GetBluffInfo(charRef));
                    }
                    else
                    {
                        onActed?.Invoke(GetInfo(charRef));
                    }
                
            }

           else
            {
            onActed?.Invoke(GetInfo(charRef));
            }
                
        }
    }
    public override void BluffAct(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Day)
        {
            if (isTheChild.bluff != null)
            {
                onActed?.Invoke(GetBluffInfo(charRef));
            }
            else
            {
                onActed?.Invoke(GetInfo(charRef));
            }
        }
    }
    public override CharacterData? GetBluffIfAble(Character charRef)
    {
        return null;
    }
}