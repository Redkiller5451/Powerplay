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
    public class Marshal: Role
    {
        public Marshal() : base(ClassInjector.DerivedConstructorPointer<Marshal>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public Marshal(System.IntPtr ptr) : base(ptr)
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
    public void checkForTpows()
    {
        Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
        for (int i = 0; i < list1.Count; i++)
        {
            Character c = list1[i];
            if (c.role is Monarch || c.role is Mayor || c.role is Prosecutor || c.role is Jailor)
            {
                for (int j = 0; j < list1.Count; j++)
                {
                    if (list1[j].role is Marshal)
                    {
                        list1[j].statuses.statuses.Add(ECharacterStatus.Corrupted);
                    }
                }

            }
            else if (c.role is Marshal)
            {
                break;
            }
        }
    }
    public override void Act(ETriggerPhase trigger, Character charRef)
    {
       

            if (trigger == ETriggerPhase.Day)
        {
            checkForTpows();
            Health health = PlayerController.PlayerInfo.health;
            health.AddMaxHp(10);
           
        }
    }
    public override void BluffAct(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Day)
        {
            this.onActed.Invoke(this.GetBluffInfo(charRef));

        }
    }
    public override CharacterData? GetBluffIfAble(Character charRef)
    {
        return null;
    }
}
   
