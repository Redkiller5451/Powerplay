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
public class Pestilence : Demon
{
    public Pestilence() : base(ClassInjector.DerivedConstructorPointer<Pestilence>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Pestilence(System.IntPtr ptr) : base(ptr)
    {

    }
    public override string Description
    {
        get
        {
            return "This is a cool role!";
        }
    }
    public override ActedInfo GetInfo(Character charRef)
    {
        ActedInfo actedInfo = new ActedInfo("I have declared a Tribunal!", null);
        return actedInfo;
    }
    public override ActedInfo GetBluffInfo(Character charRef)
    {
        ActedInfo actedInfo = new ActedInfo("I am corrupted", null);
        return actedInfo;
    }
    public override Il2CppSystem.Collections.Generic.List<SpecialRule> GetRules()
    {
        Il2CppSystem.Collections.Generic.List<SpecialRule> sr = new Il2CppSystem.Collections.Generic.List<SpecialRule>();
        sr.Add(new NightModeRule(4));
        return sr;
    }
    public override void OnSpawn(Character charRef)
    {
        Gameplay gameplay = Gameplay.Instance;
        Characters instance = Characters.Instance;
        Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
        list1 = Characters.Instance.FilterCharacterType(list1, ECharacterType.Villager);
        int randomIndex = UnityEngine.Random.Range(0, list1.Count);
        Character random = list1[randomIndex];
        random.statuses.statuses.Add(Immune.immune);
        random.statuses.AddResistance(ECharacterStatus.Corrupted, random);
    }
    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if(trigger == ETriggerPhase.Start)
        {
            Gameplay gameplay = Gameplay.Instance;
            Characters instance = Characters.Instance;
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            list1 = Characters.Instance.FilterCharacterType(list1, ECharacterType.Villager);
            foreach (Character character in list1)
            {
                int randomIndex = UnityEngine.Random.Range(0,4);
                if(randomIndex < 3)
               {
                    character.statuses.statuses.Add(ECharacterStatus.Corrupted);
                }
            }
            }

        //CODE STEALING: credit to TheCaldo
        if (trigger == ETriggerPhase.Night)
        {
            if (charRef.state == ECharacterState.Dead) return;
            Gameplay gameplay = Gameplay.Instance;
            Characters instance = Characters.Instance;
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            list1 = Characters.Instance.FilterCharacterContainsStatus(list1, ECharacterStatus.Corrupted);
            list1 = Characters.Instance.FilterRevealedCharacters(list1);
            foreach (Character character in list1)
            {
                character.statuses.AddStatus(ECharacterStatus.KilledByEvil, charRef);
                character.KillByDemon(charRef);
                if (character.dataRef.picking)
                {
                    character.pickable.SetActive(false);
                }
                PlayerController.PlayerInfo.health.Damage(2);
            }
        }
    }
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