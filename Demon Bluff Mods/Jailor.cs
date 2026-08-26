using Il2Cpp;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HarmonyLib;

namespace Demon_Bluff_Mods;
[RegisterTypeInIl2Cpp]
public class Jailor : Role
{
    public Jailor() : base(ClassInjector.DerivedConstructorPointer<Jailor>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Jailor(IntPtr ptr) : base(ptr)
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
        if (trigger == ETriggerPhase.Start)
        {
            Gameplay gameplay = Gameplay.Instance;
            Characters instance = Characters.Instance;
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            list1 = Characters.Instance.FilterCharacterType(list1, ECharacterType.Demon);
            foreach (Character character in list1)
            {
                character.statuses.statuses.Add(Jailed.jailed);
            }
        }
        if(trigger == ETriggerPhase.Day)
        {
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            list1 = Characters.Instance.FilterCharacterType(list1, ECharacterType.Demon);
            string info = "they are the: ";
            foreach (Character character in list1)
            {
                info += character.dataRef.characterName + " ";
            }
            onActed?.Invoke(new ActedInfo($"I've jailed the Demon, {info}"));
        }
        if (CheckTriggerPhases().Contains(trigger))
        {
            SaintCureStatuses(charRef);
            charRef.statuses.AddStatus(ECharacterStatus.AppearTruthfull, charRef);
            if (charRef.alignment == EAlignment.Evil)
            {
                charRef.ChangeAlignment(EAlignment.Good);
                if (charRef.dataRef.characterId != "Jailor_POW")
                {
                    SharedMethods sharedScripts = new SharedMethods();
                    CharacterData saintRef = sharedScripts.GetCharDataViaID("Jailor_POW");
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