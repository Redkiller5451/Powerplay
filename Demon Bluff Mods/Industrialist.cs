using Il2Cpp;
using HarmonyLib;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem;
using MelonLoader;
using System;
using System.ComponentModel.Design;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Demon_Bluff_Mods;
[RegisterTypeInIl2Cpp]
public class Industrialist : Role
{

    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Start)
        {
            Il2CppSystem.Collections.Generic.List<Character> allChars = Gameplay.CurrentCharacters;
            allChars = Characters.Instance.FilterAlignmentCharacters(allChars, EAlignment.Good);
            int randomIndex = UnityEngine.Random.Range(0, allChars.Count);
            Character random = allChars[randomIndex];
            Il2CppSystem.Collections.Generic.List<Character> allChars2 = Gameplay.CurrentCharacters;
            if(random.GetCharacterType() == ECharacterType.Villager)
                Characters.Instance.FilterOutCharacterType(allChars2, ECharacterType.Villager);
            else
                Characters.Instance.FilterOutCharacterType(allChars2, ECharacterType.Outcast);
            randomIndex = UnityEngine.Random.Range(0, allChars2.Count);
            Character random2 = allChars2[randomIndex];
            random.statuses.AddStatus(MadVictim.madVictim, charRef);
            random2.statuses.AddStatus(Mad.mad, charRef);
        }
        if (trigger == ETriggerPhase.Day)
        {
            Il2CppSystem.Collections.Generic.List<Character> allChars = Gameplay.CurrentCharacters;
            Il2CppSystem.Collections.Generic.List<Character> allChars2 = Characters.Instance.FilterCharacterContainsStatus(allChars, Mad.mad2);
            allChars = Characters.Instance.FilterCharacterContainsStatus(allChars, Mad.mad);
            foreach (Character character in allChars2)
            {
                allChars.Add(character);
            }
            if(allChars.Count == 0)
            {
                onActed?.Invoke(new ActedInfo($"Nobody is Mad!", null));
            }
            else
                onActed?.Invoke(new ActedInfo($"#{allChars[UnityEngine.Random.Range(0, allChars.Count)].id} is Mad!", null));
        }
    }
    public override void BluffAct(ETriggerPhase trigger, Character charRef)
    { 
        if (trigger == ETriggerPhase.Day)
        {
            Il2CppSystem.Collections.Generic.List<Character> allChars = Gameplay.CurrentCharacters;
            allChars = Characters.Instance.FilterAlignmentCharacters(allChars, EAlignment.Good);
            onActed?.Invoke(new ActedInfo($"#{allChars[UnityEngine.Random.Range(0, allChars.Count)].id} is Mad!", null));
        }
    }
    public Industrialist() : base(ClassInjector.DerivedConstructorPointer<Industrialist>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Industrialist(System.IntPtr ptr) : base(ptr)
    {
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
            if(__instance.GetCharacterType() is ECharacterType.Villager)
            {
                allChars = Characters.Instance.FilterCharacterType(allChars, ECharacterType.Outcast);
                if (allChars.Count == 0)
                    allChars.Add(ProjectContext.Instance.gameData.GetCharacterDataOfId("Bombardier_79093372"));
            }
            else
            {
                allChars = Characters.Instance.FilterCharacterType(allChars, ECharacterType.Villager);
                if (allChars.Count == 0)
                     allChars.Add(ProjectContext.Instance.gameData.GetCharacterDataOfId("Confessor_18741708"));
            }
                
            CharacterData randomMinion = allChars[UnityEngine.Random.Range(0, allChars.Count)];
            __instance.UpdateRegisterAsRole(randomMinion);
        }
    }
}