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
public class Crazed : Demon
{
    public Crazed() : base(ClassInjector.DerivedConstructorPointer<Crazed>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Crazed(System.IntPtr ptr) : base(ptr)
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


    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if(trigger == ETriggerPhase.Start)
        {
            Il2CppSystem.Collections.Generic.List<Character> allChars = Gameplay.CurrentCharacters;
            allChars = Characters.Instance.FilterCharacterMissingStatus(allChars,Mad.mad2);
            allChars = Characters.Instance.FilterAlignmentCharacters(allChars, EAlignment.Good);
            foreach (Character c in allChars)
            {
                MelonLogger.Msg($"#{c.id} is now mad");
                c.statuses.statuses.Add(Mad.mad2);
                c.statuses.AddStatus(ECharacterStatus.MessedUpByEvil, charRef);
            }
        }
    }
}
