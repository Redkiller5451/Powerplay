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
public class Death : Demon
{
    public Death() : base(ClassInjector.DerivedConstructorPointer<Death>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Death(System.IntPtr ptr) : base(ptr)
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
    public override ActedInfo GetBluffInfo(Character charRef)
    {
        ActedInfo actedInfo = new ActedInfo("I am corrupted", null);
        return actedInfo;
    }
    //Code from Wingidon
    public override Il2CppSystem.Collections.Generic.List<SpecialRule> GetRules()
    {
        Il2CppSystem.Collections.Generic.List<SpecialRule> sr = new Il2CppSystem.Collections.Generic.List<SpecialRule>();
        sr.Add(new NightModeRule(4));
        return sr;
    }
  
    public override void Act(ETriggerPhase trigger, Character charRef)
    {
            if (trigger == ETriggerPhase.Night)
        {
            if (charRef.state == ECharacterState.Dead) return;
            Gameplay gameplay = Gameplay.Instance;
            Characters instance = Characters.Instance;
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            list1 = Characters.Instance.FilterAlignmentCharacters(list1, EAlignment.Good);
            Health health = PlayerController.PlayerInfo.health;
            health.Damage(10);
            foreach (Character character in list1)
            {
                character.statuses.AddStatus(ECharacterStatus.KilledByEvil, charRef);
                character.KillByDemon(charRef);
            }

        }
    }
}
