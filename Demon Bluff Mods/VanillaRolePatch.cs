using Demon_Bluff_Mods;
using HarmonyLib;
using Il2Cpp;
using Il2CppInterop.Runtime;
using Il2CppSystem;
using Il2CppTMPro;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[HarmonyPatch]
public static class VanillaPatch
{

    [HarmonyPatch(typeof(ObjectivesUI), nameof(ObjectivesUI.UpdateObjectives))]
    [HarmonyPriority(Priority.Last)]
    public static class ChangeCounter
    {
        public static void Postfix(ObjectivesUI __instance)
        {
            bool Medusa = false;
            bool Mafia = false;
            foreach (Character c in Gameplay.CurrentCharacters)
            {
                if (c.dataRef.characterId == "Medusa_POW")
                {
                    Medusa = true;
                }
                if (c.dataRef.characterId == "Godfather2_POW" || c.dataRef.characterId == "Mafioso_POW")
                {
                    Mafia = true;
                }
            }
            if (!Medusa && !Mafia) return;
            int minions = Gameplay.CurrentScript.minion;
            int demons = Gameplay.CurrentScript.demon;
            var deadCharacters = Gameplay.DeadCharacters;
            int EvilsKilled = 0;

            foreach (var deadCharacter in deadCharacters)
            {
                if (deadCharacter.alignment == EAlignment.Evil)
                {
                    EvilsKilled++;
                }
            }
            if (Medusa || Mafia)
            {
                __instance.evilsKilled.text = string.Format("<color=grey>Evils killed:</color> <color=red>?");
            }
            else
            {
                __instance.evilsKilled.text = string.Format("<color=grey>Evils killed:</color> <color=red>{0}", EvilsKilled);
            }


            string minionCountText = "Minions";
            if (minions == 1)
            {
                minionCountText = "Minion";
            }
            string demonCountText = "Demons";
            if (demons == 1)
            {
                demonCountText = "Demon";
            }
            __instance.objective.text = string.Format("Find and Execute all Evil Characters<br><color=grey><size=18>(<color=orange>{0}+ {2}</color> and <color=red>{1}+ {3} </color>)", minions, demons, minionCountText, demonCountText);
            if (Medusa)
            {
                __instance.objective.text = "Find and Execute all Evil Characters.";
                var texts = __instance.GetComponentsInChildren<TMP_Text>(true);

                foreach (var text in texts)
                {
                    if (text == null)
                        continue;

                    if (text.text != null && text.text.Contains("Score:"))
                    {
                        text.text = "<size=20><color=grey>Score: <color=green><size=24>?";
                    }
                }
            }
        }
    }
    public static void DisableRedText()
    {
        GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject obj in objects)
        {
            if (obj != null && obj.name == "FloatingScore")
            {
                obj.SetActive(false);
            }
        }

    }
    public static void DisableHealthView()
    {
        GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();
        if (CheckForMedusa() || CheckForMafia())
        {
            foreach (GameObject obj in objects)
            {
                if (obj != null && obj.name == "FloatingScore")
                {
                    obj.SetActive(false);
                }
            }
        }
    }
    [HarmonyPatch(typeof(DisguiseIcon), nameof(DisguiseIcon.OnEnable))]
    public static class HideDisguiseIconPatch
    {
        public static void Postfix(DisguiseIcon __instance)
        {
            if (__instance != null && (CheckForMedusa() || CheckForMafia()))
            {
                __instance.gameObject.SetActive(false);
            }
        }
    }
    [HarmonyPatch(typeof(HealthView), "RefreshView")]
    public static class HealthViewPatch
    {
        [HarmonyPostfix]
        public static void Postfix(HealthView __instance)
        {
            if (__instance.text != null && (CheckForMedusa() || CheckForMafia()))
            {
                __instance.text.text = "?";

            }
        }
    }
    public static bool CheckForMedusa()
    {
        if (Gameplay.CurrentCharacters != null)
            foreach (Character c in Gameplay.CurrentCharacters)
            {
                if (c.dataRef.characterId == "Medusa_POW")
                {
                    return true;
                }
            }
        return false;
    }
    public static bool CheckForMafia()
    {
        if (Gameplay.CurrentCharacters != null)
            foreach (Character c in Gameplay.CurrentCharacters)
            {
                if (c.dataRef.characterId == "Godfather2_POW" || c.dataRef.characterId == "Mafioso_POW")
                {
                    return true;
                }
            }
        return false;
    }
    public static bool CheckForPirate()
    {
        if (Gameplay.CurrentCharacters != null)
            foreach (Character c in Gameplay.CurrentCharacters)
            {
                if (c.dataRef.characterId == "Pirate_POW")
                {
                    return true;
                }
            }
        return false;
    }
}
    [HarmonyPatch(typeof(Character), nameof(Character.Act))]
public static class InfoViewPatch
{
    [HarmonyPostfix]
    public static void Postfix(Character __instance, ETriggerPhase trigger)
    {
        //This used ChatGPT unfortunately. I didnt know how to access ActedInfo from here.
        if (__instance.statuses.statuses.Contains(Obscured.Obscure))
              {

                var original = __instance.onAboutToAct;

                System.Action<ActedInfo, ETriggerPhase> callback = (info, phase) =>
                {
                    ActedInfo aboutToActInfo = info;
                    if (aboutToActInfo != null)
                    {
                        info.desc = obscureWords(info.desc);
                    }
                    original?.Invoke(info, phase);
                };

                __instance.onAboutToAct =
                    DelegateSupport.ConvertDelegate<Il2CppSystem.Action<ActedInfo, ETriggerPhase>>(
                        callback
                    );

            }    

    }
    public static string obscureWords(string desc)
    {
        char[] allChars = desc.ToCharArray();
        List<string> words = new List<string>();
        foreach (char c in allChars)
        {
            words.Add(c.ToString());
        }
        List<string> nums = numbers();
        for (int i = 0; i < words.Count; i++)
        {
            if (!nums.Contains(words[i]))
            {
                words[i] = "-";
            }
        }
        string newString = "";
        foreach (string word in words)
        {
            newString += word;
        }
        return newString;
    }
    public static List<string> numbers()
    {
        List<string> nums = new List<string>();
        nums.Add("0");
        nums.Add("1");
        nums.Add("2");
        nums.Add("3");
        nums.Add("4");
        nums.Add("5");
        nums.Add("6");
        nums.Add("7");
        nums.Add("8");
        nums.Add("9");
        nums.Add(":");
        nums.Add(" ");
        nums.Add(",");
        nums.Add(".");
        nums.Add("!");
        nums.Add("?");
        nums.Add("#");
        nums.Add("\n");
        nums.Add("\t");
        return nums;
    }
}
[HarmonyPatch(typeof(Gameplay), "OnCharacterReveal")]
public static class w_AnyRevealPatch
{
    public static ETriggerPhase AnyReveal = (ETriggerPhase)1121218523;
    public static ETriggerPhase SelfReveal = (ETriggerPhase)1951261853; // Used for Pick characters
    [HarmonyPrefix]
    public static bool CharacterRevealPrefix(Character obj)
    {
        // MelonLogger.Msg("Revealing character...");
        obj.Act(SelfReveal);
        foreach (Character character in Gameplay.CurrentCharacters)
        {
            //MelonLogger.Msg("Calling on the Ritualist");
            character.Act(AnyReveal);
        }
        return true;
    }
}


