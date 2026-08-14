using Il2Cpp;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using MelonLoader;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Il2CppSystem.Net.NetworkInformation;

namespace Demon_Bluff_Mods;
[RegisterTypeInIl2Cpp]
public class Tapper : Role
{

    public Tapper() : base(ClassInjector.DerivedConstructorPointer<Tapper>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        action1 = new System.Action(CharacterPicked);
        action2 = new System.Action(StopPick);
        action3 = new System.Action(CharacterPickedDrunk);
    }
    public Tapper(System.IntPtr ptr) : base(ptr)
    {
        action1 = new System.Action(CharacterPicked);
        action2 = new System.Action(StopPick);
        action3 = new System.Action(CharacterPickedDrunk);
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
    private Il2CppSystem.Action action3;
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
        CharacterPicker.OnCharactersPicked -= action3;
        CharacterPicker.OnStopPick -= action2;

    }

    private void CharacterPicked()
    {
        CharacterPicker.OnCharactersPicked -= action1;
        CharacterPicker.OnStopPick -= action2;
        List<Character> outsiders = new List<Character>();
        List<int> ids = new List<int>();
        foreach (Character c in CharacterPicker.PickedCharacters)
        {
            ids.Add(c.id);
            outsiders.Add(c);
        }
        Il2CppSystem.Collections.Generic.List<Character> neighborsOfPicked = GetNeighbors(outsiders[0]);
        Il2CppSystem.Collections.Generic.List<ECharacterStatus> statuses = GetStatuses(outsiders[0], neighborsOfPicked);
        onActed?.Invoke(new ActedInfo(info(outsiders[0], neighborsOfPicked, statuses)));
    }

    public override void BluffAct(ETriggerPhase trigger, Character charRef)
    {
        if (trigger != ETriggerPhase.Day) return;
        CharacterPicker.Instance.StartPickCharacters(1, charRef);
        CharacterPicker.OnCharactersPicked += action3;
        CharacterPicker.OnStopPick += action2;
    }
    private void CharacterPickedDrunk()
    {
        CharacterPicker.OnCharactersPicked -= action3;
        CharacterPicker.OnStopPick -= action2;
        List<Character> outsiders = new List<Character>();
        List<int> ids = new List<int>();
        foreach (Character c in CharacterPicker.PickedCharacters)
        {
            ids.Add(c.id);
            outsiders.Add(c);
        }
        Il2CppSystem.Collections.Generic.List<Character> neighborsOfPicked = GetNeighbors(outsiders[0]);
        Il2CppSystem.Collections.Generic.List<ECharacterStatus>  statuses = GetStatusesDrunk(outsiders[0], neighborsOfPicked);
        onActed?.Invoke(new ActedInfo(info(outsiders[0], neighborsOfPicked, statuses)));

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
    public Il2CppSystem.Collections.Generic.List<ECharacterStatus> GetStatuses(Character charRef, Il2CppSystem.Collections.Generic.List<Character> neighborsOfPicked)
    {
        Il2CppSystem.Collections.Generic.List<Character> characters = new();
        characters.Add(charRef);
        characters.Add(neighborsOfPicked[0]);
        characters.Add(neighborsOfPicked[1]);

        Il2CppSystem.Collections.Generic.List<ECharacterStatus> statuses = new Il2CppSystem.Collections.Generic.List<ECharacterStatus>();
        foreach(Character character in neighborsOfPicked)
        {
            foreach(ECharacterStatus status in character.statuses.statuses)
            {
                if (isAPingableStatus(status))
                {
                    statuses.Add(status);
                }
            }
        }
        return statuses;


    }
    private string info(Character picked, Il2CppSystem.Collections.Generic.List<Character> characters, Il2CppSystem.Collections.Generic.List<ECharacterStatus> statuses)
    {
        if (statuses.Count == 0)
        {
            return $"Between {picked.id} and their neighbors, I couldn't find any evil visits.";
        }
        if (statuses.Count == 1)
        {
            return $"Between {picked.id} and their neighbors, a card that {statusToText(statuses[0])}.";
        }
        if (statuses.Count == 2)
        {
            statuses = randomizeStatus(statuses);
            return $"Between {picked.id} and their neighbors, a card that {statusToText(statuses[0])} and that {statusToText(statuses[1])}.";
        }
        if (statuses.Count == 3)
        {
            return $"Between {picked.id} and their neighbors, a card that {statusToText(statuses[0])}, that {statusToText(statuses[1])} and that {statusToText(statuses[2])}.";
        }
        else
        {
            return "ERROR";
        }
    }
    private Il2CppSystem.Collections.Generic.List<ECharacterStatus> randomizeStatus(Il2CppSystem.Collections.Generic.List<ECharacterStatus> statuses)
    {
        System.Collections.Generic.List<ECharacterStatus> translatedStatuses1 = new();
        foreach(ECharacterStatus status in statuses) { translatedStatuses1.Add(status); }
        translatedStatuses1 = translatedStatuses1
           .OrderBy(_ => UnityEngine.Random.value)
           .ToList();
        Il2CppSystem.Collections.Generic.List<ECharacterStatus> translatedStatuses2 = new();
        foreach (ECharacterStatus status in translatedStatuses1) { translatedStatuses2.Add(status); }
        return translatedStatuses2;
    }
    private string statusToText(ECharacterStatus status)
    {
        MelonLogger.Msg("Tapper info triggered 2");
        if (status == ECharacterStatus.Corrupted)
        {
            return "is Corrupted";
        }
        if (status == ECharacterStatus.Silenced)
        {
            return "is Silenced";
        }
        if (status == Mad.mad2 || status == Mad.mad)
        {
            return "is Mad";
        }
        if (status == UO.UnknownObstacle)
        {
            return "has an Unknown Obstacle";
        }
        if (status == Poisoned.poisoned)
        {
            return "is Badly Poisoned";
        }
        if (status == Rbed.roleblocked)
        {
            return "is Intoxicated";
        }
        if (status == (ECharacterStatus)1615919151)
        {
            return "is Poisoned";
        }
        if (status == (ECharacterStatus)918919)
        {
            return "is Hypnotised";
        }
        if (status == (ECharacterStatus)873)
        {
            return "is Accused";
        }
        if (status == (ECharacterStatus)881) 
        {
            return "is Confused";
        }
        if (status == (ECharacterStatus)878)
        {
            return "is Guarded";
        }
        if (status == (ECharacterStatus)911)
        {
            return "is Erased";
        }
        return "has an Unknown Status";
        
    }
    public Il2CppSystem.Collections.Generic.List<ECharacterStatus> GetStatusesDrunk(Character charRef, Il2CppSystem.Collections.Generic.List<Character> neighborsOfPicked)
    {
        Il2CppSystem.Collections.Generic.List<Character> characters = new();
        characters.Add(charRef);
        characters.Add(neighborsOfPicked[0]);
        characters.Add(neighborsOfPicked[1]);

        Il2CppSystem.Collections.Generic.List<ECharacterStatus> statuses = new Il2CppSystem.Collections.Generic.List<ECharacterStatus>();
        Il2CppSystem.Collections.Generic.List<ECharacterStatus> lyingStatuses = new();
        foreach (Character character in neighborsOfPicked)
        {
            foreach (ECharacterStatus status in character.statuses.statuses)
            {
                if (isAPingableStatus(status))
                {
                    statuses.Add(status);
                }
            }
        }
        lyingStatuses.Add(ECharacterStatus.Corrupted);
        lyingStatuses.Add(ECharacterStatus.Silenced);
        lyingStatuses.Add(Mad.mad2);
        lyingStatuses.Add(Poisoned.poisoned);
        lyingStatuses.Add(UO.UnknownObstacle);
        lyingStatuses.Add(Rbed.roleblocked);
        Il2CppSystem.Collections.Generic.List<bool> modsInstalled = IsAModInstalled();
        if (modsInstalled[0])
        {
            lyingStatuses.Add((ECharacterStatus)1615919151); // Poisoned by Snake Charmer
            lyingStatuses.Add((ECharacterStatus)918919); // Iris
        }
        else if (modsInstalled[1])
        {
            lyingStatuses.Add((ECharacterStatus)873); // Accused
            lyingStatuses.Add((ECharacterStatus)881); //Confused
            lyingStatuses.Add((ECharacterStatus)911); //Erased
            lyingStatuses.Add((ECharacterStatus)878); //Guarded
        }
        if(statuses.Count > 0)
            lyingStatuses.Remove(statuses[UnityEngine.Random.Range(0, statuses.Count)]);
        int nOfLiesStatus = UnityEngine.Random.Range(0, 4);
        if(statuses.Count == 0 && nOfLiesStatus == 0)
        {
            nOfLiesStatus++; 
        }
        Il2CppSystem.Collections.Generic.List<ECharacterStatus> drunkInfo = new();
        if (nOfLiesStatus == 0)
        {
            return drunkInfo;
        }
        else if (nOfLiesStatus == 1)
        {
            drunkInfo.Add(lyingStatuses[UnityEngine.Random.Range(0, lyingStatuses.Count)]);
            return drunkInfo;
        }
        else if (nOfLiesStatus == 2)
        {
            ECharacterStatus status1 = lyingStatuses[UnityEngine.Random.Range(0, lyingStatuses.Count)];
            lyingStatuses.Remove(status1 );
            ECharacterStatus status2 = lyingStatuses[UnityEngine.Random.Range(0, lyingStatuses.Count)];
            drunkInfo.Add(status1);
            drunkInfo.Add(status2);
            return drunkInfo;
        }
        else
        {
            ECharacterStatus status1 = lyingStatuses[UnityEngine.Random.Range(0, lyingStatuses.Count)];
            lyingStatuses.Remove(status1);
            ECharacterStatus status2 = lyingStatuses[UnityEngine.Random.Range(0, lyingStatuses.Count)];
            lyingStatuses.Remove(status2);
            ECharacterStatus status3 = lyingStatuses[UnityEngine.Random.Range(0, lyingStatuses.Count)];
            drunkInfo.Add(status1);
            drunkInfo.Add(status2);
            drunkInfo.Add(status3);
            return drunkInfo;
        }


    }
    private Il2CppSystem.Collections.Generic.List<bool> IsAModInstalled()
    {
        //Code taken from Riddles. Developper code originally
        Il2CppSystem.Collections.Generic.List<bool> installedMods = new();
        // current list of mods: Riddles, Wingidon's Expansion Pack, Dupery Bluff
        // Requirements: Latest update after June 15th, 2026 & At least 1 modded character
        Il2CppSystem.Collections.Generic.List<CharacterData> characters = Gameplay.Instance.GetAllAscensionCharacters();
        bool riddles = false;
        bool wingidon = false;
        foreach (CharacterData character in characters)
        {
            {

                if (character.characterId.EndsWith("_scm")) riddles = true;
                else if (character.characterId.EndsWith("_WING")) wingidon = true;

                if (riddles && wingidon)
                {
                    break;
                }
            }
            
        }
        installedMods.Add(wingidon);
            installedMods.Add(riddles);
            return installedMods;
    }
    private bool isAPingableStatus(ECharacterStatus status)
    {
        Il2CppSystem.Collections.Generic.List<ECharacterStatus> lyingStatuses = new();
        lyingStatuses.Add(ECharacterStatus.Corrupted);
        lyingStatuses.Add(ECharacterStatus.Silenced);
        lyingStatuses.Add(Mad.mad);
        lyingStatuses.Add(Poisoned.poisoned);
        lyingStatuses.Add(UO.UnknownObstacle);
        lyingStatuses.Add(Rbed.roleblocked);
        Il2CppSystem.Collections.Generic.List<bool> modsInstalled = IsAModInstalled();
        if (modsInstalled[0])
        {
            lyingStatuses.Add((ECharacterStatus)1615919151); // Poisoned by Snake Charmer
            lyingStatuses.Add((ECharacterStatus)918919); // Iris
        }
        else if (modsInstalled[1])
        {
            lyingStatuses.Add((ECharacterStatus)873); // Accused
            lyingStatuses.Add((ECharacterStatus)881); //Confused
            lyingStatuses.Add((ECharacterStatus)911); //Erased
            lyingStatuses.Add((ECharacterStatus)878); //Guarded
        }
        return lyingStatuses.Contains(status);
    }
}
