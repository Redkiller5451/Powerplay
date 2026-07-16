using HarmonyLib;
using Il2Cpp;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Demon_Bluff_Mods;
[RegisterTypeInIl2Cpp]
public class Apprentice : Neutrals
{

    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Start) {
            changeAlignement(charRef);
            if(charRef.alignment is EAlignment.Evil)
                becomeOtherMinion(charRef);
            else
                becomeOtherVillager(charRef);
            if(charRef.role is Apprentice)
            {
                onActed?.Invoke(new ActedInfo("I could not learn correctly..."));
            }
        }

    }
    public Apprentice() : base(ClassInjector.DerivedConstructorPointer<Apprentice>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Apprentice(System.IntPtr ptr) : base(ptr)
    {
    }
    public static void becomeOtherVillager(Character charRef)
    {
        CharacterData[] allDatas = Il2CppSystem.Array.Empty<CharacterData>();
        Il2CppSystem.Collections.Generic.List<CharacterData> possibleMinions = new Il2CppSystem.Collections.Generic.List<CharacterData>();
        if (allDatas.Length == 0)
        {
            var loadedCharList = Resources.FindObjectsOfTypeAll(Il2CppType.Of<CharacterData>());
            if (loadedCharList != null)
            {
                allDatas = new CharacterData[loadedCharList.Length];
                for (int j = 0; j < loadedCharList.Length; j++)
                {
                    allDatas[j] = loadedCharList[j]!.Cast<CharacterData>();
                }
            }
        }
        for (int j = 0; j < allDatas.Length; j++)
        {
            CharacterData d = allDatas[j];
            if (d.type == ECharacterType.Villager && inPlayVillager(d.characterId))
            {
                possibleMinions.Add(d);
            }
        }
        if (possibleMinions.Count == 0) return;
        CharacterData chosenMinion = possibleMinions[UnityEngine.Random.Range(0, possibleMinions.Count)];
        Role temp = charRef.dataRef.role;
        charRef.Init(chosenMinion);
        
    }
    private static bool inPlayVillager(string id)
    {
        Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
        list1 = Characters.Instance.FilterRealCharacterType(list1, ECharacterType.Villager);
        foreach (Character c in list1)
        {
            if (c.dataRef.characterId == id)
                return true;

        }
        return false;
    }
    public static void becomeOtherMinion(Character charRef)
    {
        CharacterData[] allDatas = Il2CppSystem.Array.Empty<CharacterData>();
        Il2CppSystem.Collections.Generic.List<CharacterData> possibleMinions = new Il2CppSystem.Collections.Generic.List<CharacterData>();
        Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
        list1 = Characters.Instance.FilterRealCharacterType(list1, ECharacterType.Minion);
        if (allDatas.Length == 0)
        {
            var loadedCharList = Resources.FindObjectsOfTypeAll(Il2CppType.Of<CharacterData>());
            if (loadedCharList != null)
            {
                allDatas = new CharacterData[loadedCharList.Length];
                for (int j = 0; j < loadedCharList.Length; j++)
                {
                    allDatas[j] = loadedCharList[j]!.Cast<CharacterData>();
                }
            }
        }
        //Copied from riddles
        Il2CppSystem.Collections.Generic.List<string> blacklistMinionIDs = new();
        blacklistMinionIDs.Add("Puppet_15989619"); // Puppet is never in the Deck to begin with.
        blacklistMinionIDs.Add("Swarm_Good_WING"); // Swarm adding its counterpart to the Deck makes it far too obvious
        blacklistMinionIDs.Add("Swarm_Evil_WING"); // Swarm adding its counterpart to the Deck makes it far too obvious.
        blacklistMinionIDs.Add("Trickster_m_scm"); // Just in case.
        blacklistMinionIDs.Add("Trickster_m_register_scm"); // Just in case.
        blacklistMinionIDs.Add("Undying_WING"); // Undying is face-up. Don't add him as a fake Minion.
        blacklistMinionIDs.Add("EvilTwin_POW"); // Not copying Evil Twin its dumb
        blacklistMinionIDs.Add("GoodTwin_POW"); // Not copying Good Twin its dumb
        blacklistMinionIDs.Add("Marionette_11628408"); // That's the wrong Marionette.
        blacklistMinionIDs.Add("Werewolf_78350415"); // Werewolf is never in the Deck to begin with.
        blacklistMinionIDs.Add("Wretch_Evil_91222191"); // That's the wrong Wretch.
        for (int j = 0; j < allDatas.Length; j++)
        {
            CharacterData d = allDatas[j];
            if (d.type == ECharacterType.Minion && !blacklistMinionIDs.Contains(d.characterId) && inPlayMinion(d.characterId))
            {
                possibleMinions.Add(d);
            }
        }
        if (possibleMinions.Count == 0) return;
        CharacterData chosenMinion = possibleMinions[UnityEngine.Random.Range(0, possibleMinions.Count)];
        Role temp = charRef.dataRef.role;
        charRef.Init(chosenMinion);
    }
    private static bool inPlayMinion(string id)
    {
        Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
        list1 = Characters.Instance.FilterRealCharacterType(list1, ECharacterType.Minion);
        foreach (Character c in list1)
        {
            if(c.dataRef.characterId == id)
                return true;

        }
        return false;
    }
}
