using Demon_Bluff_Mods;
using HarmonyLib;
using Il2Cpp;
using Il2CppSystem;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[HarmonyLib.HarmonyPatch(typeof(CharacterPicker), nameof(CharacterPicker.StartPickCharacters))]
public class CharacterPickerPatch
{
    static void Prefix(int howMany, Character picker)
    {
        if (picker != null)
        {
            Veteran.SetLastPicker(picker);
        }
    }
}
