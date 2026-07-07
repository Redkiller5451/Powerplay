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
public class Famine : Demon
{
    public Famine() : base(ClassInjector.DerivedConstructorPointer<Famine>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Famine(System.IntPtr ptr) : base(ptr)
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
    public override void Act(ETriggerPhase trigger, Character charRef)
    {

        //CODE STEALING: credit to TheCaldo
        if (trigger == ETriggerPhase.AfterRoundStart)
        {
            Gameplay gameplay = Gameplay.Instance;
            Characters instance = Characters.Instance;
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            list1 = Characters.Instance.FilterAlignmentCharacters(list1, EAlignment.Good);
            Il2CppSystem.Collections.Generic.List<Character> list2 = new Il2CppSystem.Collections.Generic.List<Character>();
            if (list1.Count > 0)
            {
                Character random = list1[UnityEngine.Random.Range(0, list1.Count)];
                list2.Add(random);
                list1.Remove(random);
                if (list1.Count > 0)
                {
                    random = list1[UnityEngine.Random.Range(0, list1.Count)];
                    list2.Add(random);
                    list1.Remove(random);
                    if (list1.Count > 0)
                    {
                        random = list1[UnityEngine.Random.Range(0, list1.Count)];
                        list2.Add(random);
                        list1.Remove(random);
                        if (list1.Count > 0)
                        {
                            random = list1[UnityEngine.Random.Range(0, list1.Count)];
                            list2.Add(random);
                            list1.Remove(random);
                            if (list1.Count > 0)
                            {
                                random = list1[UnityEngine.Random.Range(0, list1.Count)];
                                list2.Add(random);
                                list1.Remove(random);
                            }
                        }
                    }
                }
            }
            foreach (Character character in list2)
            {
                character.statuses.AddStatus(Starved.starved, character);
            }
        }
        if (trigger == ETriggerPhase.OnExecuted)
        {
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            list1 = Characters.Instance.FilterAlignmentCharacters(list1, EAlignment.Good);
            list1 = Characters.Instance.FilterCharacterContainsStatus(list1, Starved.starved);
            list1 = Characters.Instance.FilterRevealedCharacters(list1);
            foreach (Character character in list1)
            {
                character.statuses.AddStatus(ECharacterStatus.KilledByEvil, character);
                character.KillByDemon(charRef);
                Health health = PlayerController.PlayerInfo.health;
                health.Damage(2);
            }
        }
       
    }
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
 