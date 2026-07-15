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
}