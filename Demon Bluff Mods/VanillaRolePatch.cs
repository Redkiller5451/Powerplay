using Demon_Bluff_Mods;
using HarmonyLib;
using Il2Cpp;
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
            if (CheckForPirate() || CheckForMedusa() || CheckForMafia())
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
                if (__instance != null && (CheckForMedusa()|| CheckForMafia()))
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
                if (__instance.text != null && (CheckForMedusa()|| CheckForMafia()))
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

