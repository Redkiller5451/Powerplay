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
public class SnowedInChar : Role
{
    public SnowedInChar() : base(ClassInjector.DerivedConstructorPointer<SnowedInChar>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public SnowedInChar(System.IntPtr ptr) : base(ptr)
    {

    }
    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if(trigger == ETriggerPhase.Day)
        {
            onActed?.Invoke(GetInfo(charRef));
        }
        


    }
     public override ActedInfo GetInfo(Character charRef)
    {
        Gameplay gameplay = Gameplay.Instance;
        Characters instance = Characters.Instance;
        return new ActedInfo("I am Snowed in!");

    }
}
