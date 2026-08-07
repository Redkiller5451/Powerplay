using Demon_Bluff_Mods;
using HarmonyLib;
using Il2Cpp;
using Il2CppTMPro;
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

namespace Demon_Bluff_Mods;
    public class ToolTipPatchClass
    {
        // new tooltips
        [HarmonyPatch(typeof(TMP_Text), "set_text")]
        public static class TMPTextPatch
        {
            static void Prefix(ref string value)
            {
                if (value != null)
                {
                    if (value.Contains("Roleblock"))
                    {
                        value = value.Replace(
                            "Roleblock",
                            "<link=\"Roleblock\"><color=#56A3FC>Roleblock</color></link>"
                        );
                    }
                    if (value.Contains("Roleblocked"))
                    {
                        value = value.Replace(
                            "Roleblocked",
                            "<link=\"Roleblocked\"><color=#56A3FC>Roleblocked</color></link>"
                        );
                    }
                    if (value.Contains("Roleblocking"))
                    {
                        value = value.Replace(
                            "Roleblocking",
                            "<link=\"Roleblocking\"><color=#56A3FC>Roleblocking</color></link>"
                        );
                    }
                    if (value.Contains("Jail"))
                    {
                        value = value.Replace(
                            "Jail",
                            "<link=\"Jail\"><color=#696969>Jail</color></link>"
                        );
                    }
                    if (value.Contains("Jailed"))
                    {
                        value = value.Replace(
                            "Jailed",
                            "<link=\"Jailed\"><color=#696969>Jailed</color></link>"
                        );
                    }
                    if (value.Contains("Jinx"))
                    {
                        value = value.Replace(
                            "Jinx",
                            "<link=\"Jinx\"><color=#AA41BF>Jinx</color></link>"
                        );
                    }
                    if (value.Contains("Jinxed"))
                    {
                        value = value.Replace(
                            "Jinxed",
                            "<link=\"Jinxed\"><color=#AA41BF>Jinxed</color></link>"
                        );
                    }
                    if (value.Contains("Mad"))
                    {
                        value = value.Replace(
                            "Mad",
                            "<link=\"Mad\"><color=#FF8000>Mad</color></link>"
                        );
                    }
                    if (value.Contains("Protect"))
                    {
                        value = value.Replace(
                            "Protect",
                            "<link=\"Protect\"><color=#69D172>Protect</color></link>"
                        );

                    }
                    if (value.Contains("Protected"))
                    {
                        value = value.Replace(
                            "Protected",
                            "<link=\"Protected\"><color=#69D172>Protected</color></link>"
                        );
                    }
                    if (value.Contains("Hex"))
                    {
                        value = value.Replace(
                            "Hex",
                            "<link=\"Hex\"><color=#7E3A94>Hex</color></link>"
                        );
                    }
                    if (value.Contains("Hexed"))
                    {
                        value = value.Replace(
                            "Hexed",
                            "<link=\"Hexed\"><color=#7E3A94>Hexed</color></link>"
                        );
                    }
                    if (value.Contains("Starve"))
                    {
                        value = value.Replace(
                            "Starve",
                            "<link=\"Starve\"><color=#C20A0A>Starve</color></link>"
                        );
                    }
                    if (value.Contains("Starved"))
                    {
                        value = value.Replace(
                            "Starved",
                            "<link=\"Starved\"><color=#C20A0A>Starved</color></link>"
                        );
                    }
                    if (value.Contains("UO"))
                    {
                        value = value.Replace(
                            "UO",
                            "<link=\"UO\"><color=#33327A>UO</color></link>"
                        );
                    }
                    if (value.Contains("Unknown Obstacle"))
                    {
                        value = value.Replace(
                            "Unknown Obstacle",
                            "<link=\"Unknown Obstacle\"><color=#33327A>Unknown Obstacle</color></link>"
                        );
                    }
                    if (value.Contains("Badly Poison"))
                    {
                        value = value.Replace(
                            "Badly Poison",
                            "<link=\"Badly Poison\"><color=#AA41BF>Badly Poison</color></link>"
                        );
                    }
                    if (value.Contains("Badly Poisoned"))
                    {
                        value = value.Replace(
                            "Badly Poisoned",
                            "<link=\"Badly Poisoned\"><color=#AA41BF>Badly Poisoned</color></link>"
                        );
                    }
                    if (value.Contains("Necronomicon"))
                    {
                        value = value.Replace(
                            "Necronomicon",
                            "<link=\"Necronomicon\"><color=#DD02E0>Necronomicon</color></link>"
                        );
                    }
                    if (value.Contains("Weather"))
                    {
                        value = value.Replace(
                            "Weather",
                            "<link=\"Weather\"><color=#FF7AE0>Weather</color></link>"
                        );
                    }
                    if (value.Contains("Neutral"))
                    {
                        value = value.Replace(
                            "Neutral",
                            "<link=\"Neutral\"><color=#8FA7B3>Neutral</color></link>"
                        );
                    }
                    if (value.Contains("Mafia"))
                    {
                        value = value.Replace(
                            "Mafia",
                            "<link=\"Mafia\"><color=#C20051>Mafia</color></link>"
                        );
                    }
                    if (value.Contains("Covenant"))
                    {
                        value = value.Replace(
                            "Covenant",
                            "<link=\"Covenant\"><color=#6B275D>Covenant</color></link>"
                        );
                    }
                }
            }
        }
        [HarmonyPatch(typeof(TextTooltipRecognizer), "GetTooltipInfo")]
        public static class TooltipPatch
        {
            static void Postfix(string linkID, ref TooltipInfo __result)
            {
                if (linkID == "Roleblock" || linkID == "Roleblocked" || linkID == "Roleblocking")
                {
                    __result = new TooltipInfo(
                        "Roleblocked characters cannot use their On-Pick abilities.\n Characters without on-pick abilities are unaffected.",
                        "Roleblocked",
                        new Color32(187, 102, 102, 255)
                    );
                }
                if (linkID == "Jail" || linkID == "Jailed")
                {
                    __result = new TooltipInfo(
                        "Jailed characters cannot use their On-Start, After Round Start or nightime abilities.",
                        "Jailed",
                        new Color32(187, 102, 102, 255)
                    );
                }
                if (linkID == "Jinx" || linkID == "Jinxed")
                {
                    __result = new TooltipInfo(
                        "Jinxed characters die when revealed.",
                        "Jinxed",
                        new Color32(187, 102, 102, 255)
                    );
                }
                if (linkID == "Mad")
                {
                    __result = new TooltipInfo(
                        "Mad characters register as an in-play card of a different type. \n For example, a mad Oracle may register as the Minion or the Industrialist, but not as the Mayor.",
                        "Mad",
                        new Color32(187, 102, 102, 255)
                    );
                }
                if (linkID == "Protect" || linkID == "Protected")
                {
                    __result = new TooltipInfo(
                        "Protected characters are unable to be executed. They are also unable to be killed by the Demon.",
                        "Protected",
                        new Color32(187, 102, 102, 255)
                    );
                }
                if (linkID == "Hex" || linkID == "Hexed")
                {
                    __result = new TooltipInfo(
                        "When all alive good cards are hexed, you lose.",
                        "Hexed",
                        new Color32(187, 102, 102, 255)
                    );
                }
                if (linkID == "Starve" || linkID == "Starved")
                {
                    __result = new TooltipInfo(
                        "Starved cards die upon the death of Famine. They are always Good.",
                        "Starved",
                        new Color32(187, 102, 102, 255)
                    );
                }
                if (linkID == "UO" || linkID == "Unknown Obstacle")
                {
                    __result = new TooltipInfo(
                        "Unknown Obstacle prevents interacting with a card.",
                        "Unknown Obstacle",
                        new Color32(187, 102, 102, 255)
                    );
                }
                if (linkID == "Badly Poison" || linkID == "Badly Poisoned")
                {
                    __result = new TooltipInfo(
                        "Badly Poisoned cards, when they are killed, will kill another Good card.",
                        "Badly Poisoned",
                        new Color32(187, 102, 102, 255)
                    );
                }
                if (linkID == "Necronomicon")
                {
                    __result = new TooltipInfo(
                        "The Necronomicon is wielded by a Covenant Follower.\n That Follower can kill every night.",
                        "Necronomicon",
                        new Color32(187, 102, 102, 255)
                    );
                }
                if (linkID == "Weather")
                {
                    __result = new TooltipInfo(
                        "Weather have global effects. They turn into a Minion afterwards.",
                        "Weather",
                        new Color32(187, 102, 102, 255)
                    );
                }
                if (linkID == "Neutral")
                {
                    __result = new TooltipInfo(
                        "Neutral characters have a 50% chance of becoming Good on Start and a 50% chance of becoming Evil on Start.",
                        "Neutral",
                        new Color32(187, 102, 102, 255)
                    );
                }
                if (linkID == "Mafia")
                {
                    __result = new TooltipInfo(
                        "Mafia Members don't register as Minions to the Oracle. They are also hidden from deckview. There can never be a Minion and Mafia together.",
                        "Mafia",
                        new Color32(187, 102, 102, 255)
                    );
                }
                if (linkID == "Covenant")
                {
                    __result = new TooltipInfo(
                        "Covenant Followers can wield the Necronomicon. They don't register as Minions. There can never be a Minion and Covenant together.",
                        "Covenant",
                        new Color32(187, 102, 102, 255)
                    );
                }
            }
        }
    }
