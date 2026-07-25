using Il2Cpp;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Demon_Bluff_Mods
{
    [RegisterTypeInIl2Cpp]
    public class Lookout2 : Role
    {
        public Lookout2() : base(ClassInjector.DerivedConstructorPointer<Lookout2>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public Lookout2(System.IntPtr ptr) : base(ptr)
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
            Gameplay gameplay = Gameplay.Instance;
            Characters instance = Characters.Instance;
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            Il2CppSystem.Collections.Generic.List<Character> list2 = Characters.Instance.FilterAliveCharacters(list1);
            list1 = Characters.Instance.FilterCharacterContainsStatus(list1, ECharacterStatus.MessedUpByEvil);
            if (list1.Count == 0)
            {
                string line = "I've seen no evils visiting.";
                return new ActedInfo(line, null);
            }
            else if (list1.Count == 1)
            {
                string line = "One person was visited by evils!";
                return new ActedInfo(line, null);
            }
            else
            {
                string line = $"{list1.Count} people were visited by evils!";
                return new ActedInfo(line, null);
            }


        }
        public override ActedInfo GetBluffInfo(Character charRef)
        {
            Gameplay gameplay = Gameplay.Instance;
            Characters instance = Characters.Instance;
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            Il2CppSystem.Collections.Generic.List<Character> list2 = Characters.Instance.FilterAlignmentCharacters(list1,EAlignment.Evil);
            list1 = Characters.Instance.FilterCharacterContainsStatus(list1, ECharacterStatus.MessedUpByEvil);
            int randomizer = Calculator.RemoveNumberAndGetRandomNumberFromList(list1.Count, 0, list2.Count);
            if (randomizer == 0)
            {
                string line = "I've seen no evils visiting.";
                return new ActedInfo(line, null);
            }
            else if (randomizer == 1)
            {
                string line = "One person was visited by evils!";
                return new ActedInfo(line, null);
            }
            else
            {
                string line = $"{randomizer} people were visited by evils!";
                return new ActedInfo(line, null);
            }

        }


        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Day)
            {
                if (charRef.statuses.statuses.Contains(ECharacterStatus.Corrupted))
                {
                    onActed?.Invoke(GetBluffInfo(charRef));
                }
                else
                {
                    onActed?.Invoke(GetInfo(charRef));
                }

            }

        }
        public override void BluffAct(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Day)
            {
                onActed?.Invoke(GetBluffInfo(charRef));
            }
        }
        public override CharacterData? GetBluffIfAble(Character charRef)
        {
            return null;
        }
    }
}