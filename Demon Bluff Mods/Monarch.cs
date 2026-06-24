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
public class Monarch : Role
{
    public Monarch() : base(ClassInjector.DerivedConstructorPointer<Monarch>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Monarch(System.IntPtr ptr) : base(ptr)
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
        ActedInfo actedInfo = new ActedInfo("I have knighted a player", null);
        return actedInfo;
    }
    public override ActedInfo GetBluffInfo(Character charRef)
    {
        ActedInfo actedInfo = new ActedInfo("I am corrupted", null);
        return actedInfo;
    }
    public override void Act(ETriggerPhase trigger, Character charRef)
    {
      
        int randomIndex = 0;
        if (trigger == ETriggerPhase.Day)
        {
            Gameplay gameplay = Gameplay.Instance;
            Characters instance = Characters.Instance;
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            list1 = Characters.Instance.FilterRealCharacterType(list1, ECharacterType.Villager);
            string line;

            if (list1.Count > 0)
            {
                randomIndex = UnityEngine.Random.Range(0, list1.Count);
                Character random = list1[randomIndex];
                line = $"#{random.id} is a Villager!";
            }
            else
            {
                line = $"there are no Villagers alive";
            }
            onActed?.Invoke(new ActedInfo(line,null));
        }
       
      }
    public override bool CheckIfCanBeKilled(Character charRef)
    {
        //if (charRef.statuses.statuses.Contains(ECharacterStatus.BrokenAbility))
        //return true;
        if (charRef.statuses.statuses.Contains(ECharacterStatus.HealthyBluff))
            return false;
        if (charRef.statuses.statuses.Contains(ECharacterStatus.Corrupted))
            return true;
        else
            return false;
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

