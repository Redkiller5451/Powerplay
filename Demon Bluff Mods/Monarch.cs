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
    public override void OnSpawn(Character charRef)
    {
        charRef.statuses.AddResistance(ECharacterStatus.Corrupted, charRef);
    }
    public void CurePoisons(Character charRef, Il2CppSystem.Collections.Generic.List<Character> list2)
    {
        foreach (Character c in list2)
        {
            if (c.statuses.statuses.Contains(ECharacterStatus.Corrupted)){
                c.statuses.RemoveStatusIfAble(ECharacterStatus.Corrupted);
            }
        }
    }
    public override void Act(ETriggerPhase trigger, Character charRef)
    {
      
        int randomIndex = 0;

        if (trigger == ETriggerPhase.Day)
        {
            Gameplay gameplay = Gameplay.Instance;
            Characters instance = Characters.Instance;
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            Il2CppSystem.Collections.Generic.List<Character> list2 = new Il2CppSystem.Collections.Generic.List<Character>();
            list1 = Characters.Instance.FilterRealCharacterType(list1, ECharacterType.Villager);
            string line;

            if (list1.Count > 0)
            {
                randomIndex = UnityEngine.Random.Range(0, list1.Count);
                Character random = list1[randomIndex];
                line = $"#{random.id} is a Villager!";
                list2.Add(random);
                list1.Remove(random);
                if (list1.Count > 0)
                {
                randomIndex = UnityEngine.Random.Range(0, list1.Count);
                random = list1[randomIndex];
                line += $"\n#{random.id} is a Villager!";
                    list2.Add(random);
                    list1.Remove(random);
                    if (list1.Count > 0)
                    {
                        randomIndex = UnityEngine.Random.Range(0, list1.Count);
                        random = list1[randomIndex];
                        list2.Add(random);
                        line += $"\n#{random.id} is a Villager!";
                    }
                    else
                    {
                        line += $"\nAnd there are no more Villagers alive";
                    }
                }
                 else
                 {
                line += $"\nAnd there are no more Villagers alive";
                }
            }
            else
            {
                line = $"There are no Villagers alive";
            }
            
            onActed?.Invoke(new ActedInfo(line,null));
        }
        if (CheckTriggerPhases().Contains(trigger))
        {
            SaintCureStatuses(charRef);
            charRef.statuses.AddStatus(ECharacterStatus.AppearTruthfull, charRef);
            if (charRef.alignment == EAlignment.Evil)
            {
                charRef.ChangeAlignment(EAlignment.Good);
                if (charRef.dataRef.characterId != "Monarch_POW")
                {
                    SharedMethods sharedScripts = new SharedMethods();
                    CharacterData saintRef = sharedScripts.GetCharDataViaID("Monarch_POW");
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
    public override CharacterData? GetBluffIfAble(Character charRef)
    {
        return null;
    }
}

