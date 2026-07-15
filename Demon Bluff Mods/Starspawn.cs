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
public class Starspawn : Demon
{
    public Starspawn() : base(ClassInjector.DerivedConstructorPointer<Starspawn>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Starspawn(System.IntPtr ptr) : base(ptr)
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
        Gameplay gameplay = Gameplay.Instance;
        Characters instance = Characters.Instance;
        Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
        foreach (Character c in list1)
        {
            if (c.dataRef.picking)
            {
                c.OnDisable();
            }
        }
    }
    //Taken from Wingidons Undying 
}
