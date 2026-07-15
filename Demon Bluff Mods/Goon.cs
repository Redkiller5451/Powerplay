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
public class Goon : Role
{
    private static Character lastPicker = null;
    public Goon() : base(ClassInjector.DerivedConstructorPointer<Goon>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Goon(System.IntPtr ptr) : base(ptr)
    {

    }
    public override string Description
    {
        get
        {
            return "This is a cool role!";
        }
    }


    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.OnPicked)
        {
            if (charRef.state == ECharacterState.Dead) return;
            if (lastPicker != null)
            {
                charRef.ChangeAlignment(lastPicker.alignment);
            }
        }
    }
    public static void SetLastPicker(Character picker)
    {
        lastPicker = picker;
    }
    //Taken from Wingidons Undying 
}
