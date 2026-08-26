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
    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Day)
        {
          
            Health health = PlayerController.PlayerInfo.health;
            health.AddMaxHp(10);
           
        }
        if (CheckTriggerPhases().Contains(trigger))
        {
            SaintCureStatuses(charRef);
            charRef.statuses.AddStatus(ECharacterStatus.AppearTruthfull, charRef);
            if (charRef.alignment == EAlignment.Evil)
            {
                charRef.ChangeAlignment(EAlignment.Good);
                if (charRef.dataRef.characterId != "Marshal_POW")
                {
                    SharedMethods sharedScripts = new SharedMethods();
                    CharacterData saintRef = sharedScripts.GetCharDataViaID("Marshal_POW");
                    charRef.Init(saintRef);
                }
            }
        }
    }

    public override void BluffAct(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Day)
        {
            this.onActed.Invoke(this.GetBluffInfo(charRef));

        }
    }

    public Il2CppSystem.Collections.Generic.List<ETriggerPhase> CheckTriggerPhases()
    {
        Il2CppSystem.Collections.Generic.List<ETriggerPhase> returnList = new Il2CppSystem.Collections.Generic.List<ETriggerPhase>();
        returnList.Add(ETriggerPhase.Start);
        returnList.Add(ETriggerPhase.AfterRoundStart);
        returnList.Add(ETriggerPhase.Day);
        returnList.Add(ETriggerPhase.Night);
        returnList.Add(ETriggerPhase.OnReveal);
        returnList.Add(ETriggerPhase.OnExecuted);
        returnList.Add(ETriggerPhase.OnPicked);
        returnList.Add(ETriggerPhase.OnDied);
        return returnList;
    }
    public void SaintCureStatuses(Character charRef)
    {
        if (charRef.statuses.Contains((ECharacterStatus)968))
        {
            charRef.statuses.statuses.Remove((ECharacterStatus)968);
        }
        if (charRef.statuses.Contains((ECharacterStatus)1615919000))
        {
            charRef.statuses.statuses.Remove((ECharacterStatus)1615919000);
        }
        if (charRef.statuses.Contains((ECharacterStatus)907))
        {
            charRef.statuses.statuses.Remove((ECharacterStatus)907);
        }
        if (charRef.statuses.Contains((ECharacterStatus)918919))
        {
            charRef.statuses.statuses.Remove((ECharacterStatus)918919);
        }
        if (charRef.statuses.Contains((ECharacterStatus)880)) // Evil-turned (Skill Cycler's Riddles)
        {
            charRef.statuses.statuses.Remove((ECharacterStatus)880);
        }
        if (charRef.statuses.Contains(ECharacterStatus.AppearLying))
        {
            charRef.statuses.statuses.Remove(ECharacterStatus.AppearLying);
        }
        if (charRef.statuses.Contains(Swapped.swapped))
        {
            charRef.statuses.statuses.Remove(Swapped.swapped);
        }
    }


}