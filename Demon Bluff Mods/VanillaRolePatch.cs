using Demon_Bluff_Mods;
using HarmonyLib;
using Il2Cpp;
using Il2CppSystem;
using MelonLoader;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using System.Reflection.Metadata.Ecma335;

[HarmonyPatch]
public static class VanillaPatch
{

   /* [HarmonyPatch(typeof(Bishop), nameof(Bishop.Act))]
    public static class BishopPatchInfo
    {
        static void Prefix(Bishop __instance,ETriggerPhase trigger, Character charRef)
        {
            if (trigger != ETriggerPhase.Day) return;
            List<Character> pickedCharacters = new List<Character>();

            Il2CppSystem.Collections.Generic.List<Character> allCharacters = Gameplay.CurrentCharacters;
            allCharacters = Characters.Instance.FilterCharacterType(allCharacters, ECharacterType.Outcast);
            if (allCharacters.Count > 0)
                pickedCharacters.Add(allCharacters[UnityEngine.Random.Range(0, allCharacters.Count)]);

            allCharacters = Gameplay.CurrentCharacters;
            allCharacters = Characters.Instance.FilterCharacterType(allCharacters, ECharacterType.Villager);
            if (allCharacters.Count > 0)
                pickedCharacters.Add(allCharacters[UnityEngine.Random.Range(0, allCharacters.Count)]);

            allCharacters = Gameplay.CurrentCharacters;
            allCharacters = WhichMinions(allCharacters);
            if (allCharacters.Count > 0)
                pickedCharacters.Add(allCharacters[UnityEngine.Random.Range(0, allCharacters.Count)]);

            if (allCharacters.Count == 0)
            {
                allCharacters = Gameplay.CurrentCharacters;
                allCharacters = Characters.Instance.FilterCharacterType(allCharacters, ECharacterType.Demon);
                pickedCharacters.Add(allCharacters[UnityEngine.Random.Range(0, allCharacters.Count)]);
            }

            System.Random random = new System.Random();

            pickedCharacters = pickedCharacters
                .OrderBy(c => c.id)
                .ThenBy(_ => UnityEngine.Random.value)
                .ToList();

            List<int> ids = new List<int>();
            foreach (Character c in pickedCharacters)
                ids.Add(c.id);

            pickedCharacters = pickedCharacters.OrderBy(x => random.Next()).ToList();

            Il2CppSystem.Collections.Generic.List<Character> translatingPickedCharacters = new();
            foreach (Character c in pickedCharacters)
            {
                translatingPickedCharacters.Add(c);
            }
            translatingPickedCharacters = ListHelper.ShuffleList(translatingPickedCharacters);

            List<ECharacterType> types = new List<ECharacterType>();
            foreach (Character c in pickedCharacters)
                types.Add(c.GetCharacterData().type);

            string info = ConjourInfo(ids, types, charRef);
            List<Character> chars = new List<Character>(pickedCharacters);
            Il2CppSystem.Collections.Generic.List<Character> translatingChars = new();
            foreach (Character c in chars)
            {
                translatingChars.Add(c);
            }
            ActedInfo newInfo = new ActedInfo(info, translatingChars);
            __instance.onActed?.Invoke(newInfo);
            return;
        }
    }
    public static string ConjourInfo(List<int> ids, List<ECharacterType> characters, Character charRef)
    {
        List<string> keywords = new List<string>();
        foreach (ECharacterType ct in characters)
            keywords.Add(ct.ToString());

        string info = "Between\n";

        if (ids.Count == 2)
            info += $"#{ids[0]}, #{ids[1]}";
        if (ids.Count == 3)
            info += $"#{ids[0]}, #{ids[1]}, #{ids[2]}";
        if (ids.Count == 1)
        {
            info = $"#{ids[0]} is a {InCaseCustom(characters[0])}";
            return info;
        }

        info += "\nthere is:\n";

        if (characters.Count == 2)
            info += $"{InCaseCustom(characters[0])} and {InCaseCustom(characters[1])}";
        if (characters.Count == 3)
            info += $"{InCaseCustom(characters[0])}, {InCaseCustom(characters[1])} and {InCaseCustom(characters[2])}";

        return info;
    }
    public static string InCaseCustom(ECharacterType type)
    {
     
            if (type == MafiaType.Member)
            {
                return "Mafia Member";
            }
            else if(type == CovType.Follower)
            {
                return "Coven Follower";
            }
        else
        {
            return type.ToString();
        }
       
    }
    public static Il2CppSystem.Collections.Generic.List<Character> WhichMinions(Il2CppSystem.Collections.Generic.List<Character> allCharacters)
    {
        Il2CppSystem.Collections.Generic.List<Character> amountOfMinions = Characters.Instance.FilterCharacterType(allCharacters, ECharacterType.Minion);
        Il2CppSystem.Collections.Generic.List<Character> amountOfMafia = Characters.Instance.FilterCharacterType(allCharacters, MafiaType.Member);
        Il2CppSystem.Collections.Generic.List<Character> amountOfCovenant = Characters.Instance.FilterCharacterType(allCharacters, CovType.Follower);
        if (amountOfMinions.Count > 0)
        {
            return amountOfMinions;
        }
        else if (amountOfMafia.Count > 0) { return amountOfMafia; }
        else { return amountOfCovenant; }
    }*/
    //TODO: Ask Skill Cycler why we need a PATCH FOR THIS!
   
}
