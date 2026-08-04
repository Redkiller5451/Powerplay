using Il2Cpp;
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
using HarmonyLib;


namespace Demon_Bluff_Mods
{
    public static class Dueled
    {
        public static ECharacterStatus dueled = (ECharacterStatus)195;
    }
    public static class UO
    {
        public static ECharacterStatus UnknownObstacle = (ECharacterStatus)196;
        [HarmonyPatch(typeof(Character), nameof(Character.ShowDescription))]
        public static class UOed
        {
            public static void Postfix(Character __instance)
            {
                if (__instance.statuses.Contains(UnknownObstacle))
                {
                    HintInfo info = new HintInfo();
                    info.text = "An Unknown Obstacle is preventing me from being revealed.";
                    UIEvents.OnShowHint.Invoke(info, __instance.hintPivot);
                }

            }
        }
    }
    public static class StarspawnCheck
    {
        public static ECharacterStatus starspawnCheck = (ECharacterStatus)197;

    }
    public static class Starved
    {
        public static ECharacterStatus starved = (ECharacterStatus)200;
        [HarmonyPatch(typeof(Character), nameof(Character.ShowDescription))]
        public static class becomeStarved
        {
            public static void Postfix(Character __instance)
            {
                if (__instance.statuses.Contains(starved))
                {
                    HintInfo info = new HintInfo();
                    info.text = "I am starved.\nRevealing me would kill me when Famine is killed, dealing 2 damage";
                    UIEvents.OnShowHint.Invoke(info, __instance.hintPivot);
                }

            }
        }
    }
    public static class NecroWielder
    {
        public static ECharacterStatus Necronomicon = (ECharacterStatus)198;
        [HarmonyPatch(typeof(Character), nameof(Character.RevealAllReal))]
        public static class NecroStat
        {
            public static void Postfix(Character __instance)
            {
                if (__instance.statuses.Contains(NecroWielder.Necronomicon))
                {
                    __instance.chName.text = __instance.dataRef.name.ToUpper() + "<color=#DD02E0><size=18>\n<Book Holder></color></size>";
                }
            }
        }
    }
    public static class Hexed
    {
        public static ECharacterStatus Hex = (ECharacterStatus)199;
    }
    public static class Immune
    {
        public static ECharacterStatus immune = (ECharacterStatus)205;
        [HarmonyPatch(typeof(Character), nameof(Character.ShowDescription))]
        public static class becomeImmune
        {
            public static void Postfix(Character __instance)
            {
                if (__instance.statuses.Contains(immune))
                {
                    HintInfo info = new HintInfo();
                    info.text = "I am Good and Uncorrupted. I cannot be Corrupted";
                    UIEvents.OnShowHint.Invoke(info, __instance.hintPivot);
                    __instance.statuses.AddResistance(ECharacterStatus.Corrupted, __instance);
                }
            }
        }
    }
    public static class Protected
    {
        public static ECharacterStatus protect = (ECharacterStatus)210;

    }
    public static class Jinxed
    {
        public static ECharacterStatus jinxed = (ECharacterStatus)230;
        [HarmonyLib.HarmonyPatch(typeof(Character), nameof(Character.OnReveal))]
        public class CharacterReveal
        {
            static void Postfix(Character __instance)
            {
                if (__instance != null)
                {
                    if (__instance.statuses.statuses.Contains(Jinxed.jinxed))
                    {
                        __instance.KillByDemon(__instance);
                        __instance.statuses.AddStatus(ECharacterStatus.KilledByEvil, __instance);
                    }
                }

            }
        }
        //Taken from Snake Charmer, Wingidon
        [HarmonyPatch(typeof(Character), nameof(Character.RevealAllReal))]
        public static class jinxedStat
        {
            public static void Postfix(Character __instance)
            {
                if (__instance.statuses.Contains(Jinxed.jinxed))
                {
                    __instance.chName.text = __instance.dataRef.name.ToUpper() + "<color=#AA41BF><size=18>\n<Jinxed></color></size>";
                }
            }
        }
    }
    public static class Poisoned
    {
        public static ECharacterStatus poisoned = (ECharacterStatus)231;
        [HarmonyLib.HarmonyPatch(typeof(Character), nameof(Character.Kill))]
        public class PoisonedAction
        {
            static void Postfix(Character __instance)
            {
                if (__instance != null)
                {
                    if (__instance.statuses.statuses.Contains(Poisoned.poisoned))
                    {
                        Il2CppSystem.Collections.Generic.List<Character> unrevealedCharacters = Gameplay.CurrentCharacters;
                        unrevealedCharacters = Characters.Instance.FilterAlignmentCharacters(unrevealedCharacters, EAlignment.Good);
                        Character targetChar = unrevealedCharacters[UnityEngine.Random.RandomRangeInt(0, unrevealedCharacters.Count)];
                        targetChar.statuses.AddStatus(ECharacterStatus.MessedUpByEvil, __instance);
                        targetChar.statuses.AddStatus(ECharacterStatus.KilledByEvil, __instance);
                        targetChar.KillByDemon(__instance);
                    }
                }

            }
        }
        [HarmonyLib.HarmonyPatch(typeof(Character), nameof(Character.KillByDemon))]
        public class PoisonedAction2
        {
            static void Postfix(Character __instance)
            {
                if (__instance != null)
                {
                    if (__instance.statuses.statuses.Contains(Poisoned.poisoned))
                    {
                        Il2CppSystem.Collections.Generic.List<Character> unrevealedCharacters = Gameplay.CurrentCharacters;
                        unrevealedCharacters = Characters.Instance.FilterAlignmentCharacters(unrevealedCharacters, EAlignment.Good);
                        Character targetChar = unrevealedCharacters[UnityEngine.Random.RandomRangeInt(0, unrevealedCharacters.Count)];
                        targetChar.statuses.AddStatus(ECharacterStatus.MessedUpByEvil, __instance);
                        targetChar.statuses.AddStatus(ECharacterStatus.KilledByEvil, __instance);
                        targetChar.KillByDemon(__instance);
                    }
                }

            }
        }
        //Taken from Snake Charmer, Wingidon
        [HarmonyPatch(typeof(Character), nameof(Character.RevealAllReal))]
        public static class poisonedStat
        {
            public static void Postfix(Character __instance)
            {
                if (__instance.statuses.Contains(Poisoned.poisoned))
                {
                    __instance.chName.text = __instance.dataRef.name.ToUpper() + "<color=#AA41BF><size=18>\n<Poisoned></color></size>";
                }
            }
        }
    }
    public static class Swapped
    {
        public static ECharacterStatus swapped = (ECharacterStatus)235;

        //Taken from Snake Charmer, Wingidon
        [HarmonyPatch(typeof(Character), nameof(Character.RevealAllReal))]
        public static class swapStat
        {
            public static void Postfix(Character __instance)
            {
                if (__instance.statuses.Contains(Swapped.swapped))
                {
                    if (__instance.alignment == EAlignment.Good)
                    {
                        __instance.chName.text = __instance.dataRef.name.ToUpper() + "<color=#41BF69><size=18>\n<Swapped(Good)></color></size>";
                    }
                    else
                    {
                        __instance.chName.text = __instance.dataRef.name.ToUpper() + "<color=#D62222><size=18>\n<Swapped(Evil)></color></size>";
                    }
                }
            }
        }
    }
    public static class HangTarget
    {
        public static ECharacterStatus hangtarget = (ECharacterStatus)255;
        [HarmonyPatch(typeof(Character), nameof(Character.Kill))]
        public static class isTheTarget
        {
            public static void Postfix(Character __instance)
            {
                if (__instance.statuses.Contains(hangtarget) && __instance.GetRealAlignment() == EAlignment.Good)
                {
                    PlayerController.PlayerInfo.health.Damage(3);
                }
            }
        }
        [HarmonyPatch(typeof(Character), nameof(Character.RevealAllReal))]
        public static class hangEffect
        {
            public static void Postfix(Character __instance)
            {
                if (__instance.statuses.Contains(HangTarget.hangtarget))
                {

                    __instance.chName.text = __instance.dataRef.name.ToUpper() + "<color=#616161><size=18>\n<Target></color></size>";

                }
            }
        }
    }
    public static class Mad
    {
        public static ECharacterStatus mad = (ECharacterStatus)260;
        public static ECharacterStatus mad2 = (ECharacterStatus)261;
        [HarmonyPatch(typeof(Character), nameof(Character.RevealAllReal))]
        public static class pvt
        {
            public static void Postfix(Character __instance)
            {
                if (__instance.statuses.Contains(mad) || __instance.statuses.Contains(mad2))
                {

                    __instance.chName.text = __instance.dataRef.name.ToUpper() + "<color=#FF8000><size=18>\n<Mad></color></size>";
                }
            }
        }
    }

    public static class MadVictim
    {
        public static ECharacterStatus madVictim = (ECharacterStatus)265;

        [HarmonyPatch(typeof(Character), nameof(Character.RevealAllReal))]
        public static class pvt
        {
            public static void Postfix(Character __instance)
            {
                if (__instance.statuses.Contains(madVictim))
                {

                    __instance.chName.text = __instance.dataRef.name.ToUpper() + "<color=#FF8000><size=18>\n<Mad Victim></color></size>";
                }
            }
        }
    }
    [HarmonyPatch(typeof(Character), nameof(Character.Reveal))]
    public static class Madness
    {
        public static void Postfix(Character __instance)
        {
            if (__instance.statuses.Contains(Mad.mad))
            {
                Il2CppSystem.Collections.Generic.List<Character> allChars = Gameplay.CurrentCharacters;
                allChars = Characters.Instance.FilterCharacterContainsStatus(allChars, MadVictim.madVictim);
                CharacterData randomMinion = allChars[0].dataRef;
                __instance.UpdateRegisterAsRole(randomMinion);
            }
            if (__instance.statuses.Contains(Mad.mad2))
            {
                Il2CppSystem.Collections.Generic.List<CharacterData> allChars = new Il2CppSystem.Collections.Generic.List<CharacterData>();
                foreach (CharacterData charData in Gameplay.Instance.GetScriptCharacters())
                {
                    allChars.Add(charData);
                }
                if (__instance.GetCharacterType() is ECharacterType.Villager)
                {
                    allChars = Characters.Instance.FilterOutCharacterType(allChars, ECharacterType.Villager);
                    if (allChars.Count == 0)
                        allChars.Add(ProjectContext.Instance.gameData.GetCharacterDataOfId("Bombardier_79093372"));
                }
                else
                {
                    allChars = Characters.Instance.FilterOutCharacterType(allChars, ECharacterType.Outcast);
                    if (allChars.Count == 0)
                        allChars.Add(ProjectContext.Instance.gameData.GetCharacterDataOfId("Confessor_18741708"));
                }

                CharacterData randomMinion = allChars[UnityEngine.Random.Range(0, allChars.Count)];
                MelonLogger.Msg($"[LOG] #{__instance.id} is registering as the {randomMinion.characterName}");
                __instance.UpdateRegisterAsRole(randomMinion);
            }
        }
    }
    public static class Sacrifice
    {
        public static ECharacterStatus sacrifice = (ECharacterStatus)270;
        [HarmonyPatch(typeof(Character), nameof(Character.Kill))]
        public static class ChangeKillByDemonText
        {
            public static bool Prefix(Character __instance)
            {
                if (__instance.statuses.Contains(sacrifice))
                {
                    Gameplay gameplay = Gameplay.Instance;
                    Characters instance = Characters.Instance;
                    Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                    list1 = Characters.Instance.FilterAliveCharacters(list1);
                    foreach (Character c in list1)
                    {
                        if (c.role is Scapegoat)
                        {
                            c.Kill();
                            if (c.alignment is EAlignment.Evil)
                            {
                                PlayerController.PlayerInfo.health.Damage(5);
                            }
                            return false;
                        }
                    }
                    return true;

                }
                return true;
            }
        }
    }
    public static class Jailed
    {
        public static ECharacterStatus jailed = (ECharacterStatus)290;
        [HarmonyPatch(typeof(Character), nameof(Character.Act))]
        public static class BecomeJailed
        {
            public static bool Prefix(Character __instance, ETriggerPhase trigger)
            {
                if (__instance.statuses.Contains(jailed) && (trigger == ETriggerPhase.Night || trigger == ETriggerPhase.AfterRoundStart || trigger == ETriggerPhase.Start))
                {
                    return false;
                }
                return true;
            }
        }
    }

    public static class Rbed
    {
        public static ECharacterStatus roleblocked = (ECharacterStatus)291;
        public static ECharacterStatus silentRB = (ECharacterStatus)292;
        [HarmonyPatch(typeof(Character), nameof(Character.RoleAct))]
        public static class BecomeRbd
        {
            public static bool Prefix(Character __instance, ETriggerPhase trigger)
            {
                if (__instance.role == null)
                {
                    return true;
                }
                if (__instance.statuses.Contains(roleblocked) && __instance.dataRef.picking)
                {
                    if (trigger == ETriggerPhase.Day)
                    {
                        __instance.ShowActed(new ActedInfo("I have been Roleblocked"),trigger);
                    }
                    return false;
                }

                if (__instance.statuses.Contains(silentRB) && (trigger == ETriggerPhase.AfterRoundStart || trigger == ETriggerPhase.Start))
                {

                    return false;
                }
                return true;
            }
        }
        [HarmonyPatch(typeof(Character), nameof(Character.RevealAllReal))]
        public static class pvt
        {
            public static void Postfix(Character __instance)
            {
                if (__instance.statuses.Contains(roleblocked))
                {

                    __instance.chName.text = __instance.dataRef.name.ToUpper() + "<color=#56A3FC><size=15>\n<Roleblocked></color></size>";
                }
            }
        }
    }

    public static class SailorPing
    {
        public static ECharacterStatus sailorPing = (ECharacterStatus)299;
    }
    public static class Audited
    {
        public static ECharacterStatus audited = (ECharacterStatus)300;
    }
}