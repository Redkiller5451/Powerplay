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
public class Juror : Role
{
    public Juror() : base(ClassInjector.DerivedConstructorPointer<Juror>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Juror(System.IntPtr ptr) : base(ptr)
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
        Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
        int characterId = 0;
        do
        {
            characterId = UnityEngine.Random.Range(0, list1.Count);
        } while (list1[characterId] == charRef);
        Character random = list1[characterId];
        ActedInfo actedInfo;
        
        if (random.alignment == EAlignment.Good)
        {
            actedInfo = new ActedInfo($"I vote #{random.id} innocent!", null);
        }
        else
        {
            actedInfo = new ActedInfo($"I vote #{random.id} guilty!", null);
        }
        return actedInfo;
    }

    public override ActedInfo GetBluffInfo(Character charRef)
    {
        Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
        int characterId = 0;
        do
        {
            characterId = UnityEngine.Random.Range(0, list1.Count);
        } while (list1[characterId] == charRef);
        Character random = list1[characterId];
        ActedInfo actedInfo;

        if (random.alignment == EAlignment.Good)
        {
            actedInfo = new ActedInfo($"I vote #{random.id} guilty!", null);
        }
        else
        {
            actedInfo = new ActedInfo($"I vote #{random.id} innocent!", null);
        }
        return actedInfo;
    }
    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Day)
        {
            if (charRef.statuses.statuses.Contains(ECharacterStatus.Corrupted))
            {
                onActed?.Invoke(GetBluffInfo(charRef));
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
            onActed?.Invoke(GetBluffInfo(charRef));
        }
    }
}
