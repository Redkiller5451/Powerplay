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
        action1 = new System.Action(CharacterPicked);
        action2 = new System.Action(StopPick);
    }
    public Jailor(System.IntPtr ptr) : base(ptr)
    {
        action1 = new System.Action(CharacterPicked);
        action2 = new System.Action(StopPick);
    }
    public override ActedInfo GetInfo(Character charRef)
    {
        return new ActedInfo("");
    }
    public override ActedInfo GetBluffInfo(Character charRef)
    {
        return new ActedInfo("");
    }
    private Il2CppSystem.Action action1;
    private Il2CppSystem.Action action2;
    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger != ETriggerPhase.Day) return;
        CharacterPicker.Instance.StartPickCharacters(1, charRef);
        CharacterPicker.OnCharactersPicked += action1;
        CharacterPicker.OnStopPick += action2;
    }
    private void StopPick()
    {
        CharacterPicker.OnCharactersPicked -= action1;
        CharacterPicker.OnStopPick -= action2;

    }

    private void CharacterPicked()
    {
        CharacterPicker.OnCharactersPicked -= action1;
        CharacterPicker.OnStopPick -= action2;
        Il2CppSystem.Collections.Generic.List<Character> outsiders = new Il2CppSystem.Collections.Generic.List<Character>();
        Il2CppSystem.Collections.Generic.List<int> ids = new Il2CppSystem.Collections.Generic.List<int>();
        foreach (Character c in CharacterPicker.PickedCharacters)
        {
            ids.Add(c.id);
            outsiders.Add(c);
        }
        Il2CppSystem.Collections.Generic.List<Character> neighborsOfPicked = GetNeighbors(outsiders[0]);
        Il2CppSystem.Collections.Generic.List<Character> evils = WhoIsEvil(outsiders[0], neighborsOfPicked);
        foreach (Character c in evils)
        {
            c.Kill();
        }
        onActed?.Invoke(new ActedInfo(info(outsiders[0], neighborsOfPicked, evils)));
    }

    public override void BluffAct(ETriggerPhase trigger, Character charRef)
    {
        if (trigger != ETriggerPhase.Day) return;
        this.onActed.Invoke(this.GetBluffInfo(charRef));
    }
    public Il2CppSystem.Collections.Generic.List<Character> GetNeighbors(Character charRef)
    {
        Il2CppSystem.Collections.Generic.List<Character> myList = CharactersHelper.GetSortedListWithCharacterFirst(Gameplay.CurrentCharacters, charRef);
        myList.RemoveAt(0);
        Il2CppSystem.Collections.Generic.List<Character> neighbors = new Il2CppSystem.Collections.Generic.List<Character>();
        neighbors.Add(myList[0]);
        neighbors.Add(myList[myList.Count - 1]);
        return neighbors;
    }
    public Il2CppSystem.Collections.Generic.List<Character> WhoIsEvil(Character charRef, Il2CppSystem.Collections.Generic.List<Character> neighborsOfPicked)
    {
        Il2CppSystem.Collections.Generic.List<Character> characters = new();
        Il2CppSystem.Collections.Generic.List<Character> evils = new();
        characters.Add(charRef);
        characters.Add(neighborsOfPicked[0]);
        characters.Add(neighborsOfPicked[1]);
        foreach (Character character in characters)
        {
            if(character.GetRealAlignment() == EAlignment.Evil)
            {
                evils.Add(character);
            }
        }
        return evils;
    }
    private string info(Character picked, Il2CppSystem.Collections.Generic.List<Character> characters, Il2CppSystem.Collections.Generic.List<Character> evils)
    {
        if (evils.Count == 0)
        {
            return $"Between {picked.id} and their neighbors, I couldn't find any Evils.";
        }
        if (evils.Count == 1)
        {
            return $"Between {picked.id} and their neighbors, I executed one Evil.";
        }
        if (evils.Count == 2)
        {
            return $"Between {picked.id} and their neighbors, I executed two Evils.";
        }
        if (evils.Count == 3)
        {
            return $"Between {picked.id} and their neighbors, I executed three Evils.";
        }
        else
        {
            return "ERROR";
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