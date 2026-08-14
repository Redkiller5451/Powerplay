using Demon_Bluff_Mods;
using Il2Cpp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Demon_Bluff_Mods.Pirate;
using static UnityEngine.GraphicsBuffer;

public static class TargetClassExtensions2
{
    // The 'this' keyword "adds" this method to TargetClass at compile-time

    public static Il2CppSystem.Collections.Generic.List<CharacterData> FilterCharacterType(this Gameplay instance, Il2CppSystem.Collections.Generic.List<CharacterData> allChars, ECharacterType charType)
    {
        Il2CppSystem.Collections.Generic.List<CharacterData> filteredList = new Il2CppSystem.Collections.Generic.List<CharacterData>();
        // You can now access public members of the instance
        foreach (CharacterData character in allChars)
        {
            if (character.type == charType)
                filteredList.Add(character);
        }

        return filteredList;
    }
    public static Il2CppSystem.Collections.Generic.List<CharacterData> FilterOutCharacterType(this Gameplay instance, Il2CppSystem.Collections.Generic.List<CharacterData> allChars, ECharacterType charType)
    {
        Il2CppSystem.Collections.Generic.List<CharacterData> filteredList = new Il2CppSystem.Collections.Generic.List<CharacterData>();
        // You can now access public members of the instance
        foreach (CharacterData character in allChars)
        {
            if (character.type != charType)
                filteredList.Add(character);
        }

        return filteredList;
    }
    public static Il2CppSystem.Collections.Generic.List<Character> FilterOutCharacterType(this Characters instance, Il2CppSystem.Collections.Generic.List<Character> allChars, ECharacterType charType)
    {
        Il2CppSystem.Collections.Generic.List < Character > filteredList = new Il2CppSystem.Collections.Generic.List<Character> ();
        // You can now access public members of the instance
        foreach (Character character in allChars)
        {
            if(character.GetCharacterType() != charType)
                filteredList.Add (character);
        }
        
        return filteredList;
    }
    public static Il2CppSystem.Collections.Generic.List<Character> FilterByRole(this Characters instance, Il2CppSystem.Collections.Generic.List<Character> allChars, string id)
    {
        Il2CppSystem.Collections.Generic.List<Character> filteredList = new Il2CppSystem.Collections.Generic.List<Character>();
        // You can now access public members of the instance
        foreach (Character character in allChars)
        {
            if (character.dataRef.characterId == id)
                filteredList.Add(character);
        }

        return filteredList;
    }
    public static Il2CppSystem.Collections.Generic.List<Character> FilterOutRole(this Characters instance, Il2CppSystem.Collections.Generic.List<Character> allChars, string id)
    {
        Il2CppSystem.Collections.Generic.List<Character> filteredList = new Il2CppSystem.Collections.Generic.List<Character>();
        // You can now access public members of the instance
        foreach (Character character in allChars)
        {
            if (character.dataRef.characterId != id)
                filteredList.Add(character);
        }

        return filteredList;
    }
    public static Il2CppSystem.Collections.Generic.List<CharacterData> FilterOutCharacterType(this Characters instance, Il2CppSystem.Collections.Generic.List<CharacterData> allChars, ECharacterType charType)
    {
        Il2CppSystem.Collections.Generic.List<CharacterData> filteredList = new Il2CppSystem.Collections.Generic.List<CharacterData>();
        // You can now access public members of the instance
        foreach (CharacterData character in allChars)
        {
            if (character.type != charType)
                filteredList.Add(character);
        }
        return filteredList;
    }
    public static Il2CppSystem.Collections.Generic.List<Character> FilterOutStatus(this Characters instance, Il2CppSystem.Collections.Generic.List<Character> allChars, ECharacterStatus status)
    {
        Il2CppSystem.Collections.Generic.List<Character> filteredList = new Il2CppSystem.Collections.Generic.List<Character>();
        // You can now access public members of the instance
        foreach (Character character in allChars)
        {
            if (!character.statuses.statuses.Contains(status))
                filteredList.Add(character);
        }
        return filteredList;
    }
    public static CharacterData GetDuplicateBluffWithoutType(this Characters instance, ECharacterType charType)
    {
        Il2CppSystem.Collections.Generic.List<CharacterData> filteredList = new Il2CppSystem.Collections.Generic.List<CharacterData>();
        // You can now access public members of the instance
        foreach (CharacterData character in instance.DuplicatesPool)
        {
            if (character.type != charType)
                filteredList.Add(character);
        }
        return filteredList[UnityEngine.Random.Range(0, filteredList.Count)];
    }
    public static Il2CppSystem.Collections.Generic.List<Character> FilterDeadCharacters(this Characters instance, Il2CppSystem.Collections.Generic.List<Character> allChars)
    {
        Il2CppSystem.Collections.Generic.List<Character> filteredList = new Il2CppSystem.Collections.Generic.List<Character>();
        // You can now access public members of the instance
        foreach (Character character in allChars)
        {
            if (character.state == ECharacterState.Dead)
                filteredList.Add(character);
        }

        return filteredList;
    }
    public static Il2CppSystem.Collections.Generic.List<Character> FilterBluffingCharacters(this Characters instance, Il2CppSystem.Collections.Generic.List<Character> allChars)
    {
        Il2CppSystem.Collections.Generic.List<Character> filteredList = new Il2CppSystem.Collections.Generic.List<Character>();
        // You can now access public members of the instance
        foreach (Character character in allChars)
        {
            if (character.bluff != null)
                filteredList.Add(character);
        }

        return filteredList;
    }
}