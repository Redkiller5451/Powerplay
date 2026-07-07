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
    public class Coroner : Role
    {
        public Coroner() : base(ClassInjector.DerivedConstructorPointer<Coroner>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public Coroner(System.IntPtr ptr) : base(ptr)
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
            list1 = Characters.Instance.FilterCharacterContainsStatus(list1, ECharacterStatus.KilledByEvil);
            if (list1.Count == 0)
            {
                return new ActedInfo("There are no dead players", null);
            }
            else
            {
                string line = "I have examined the corpses and found that: ";
                Il2CppSystem.Collections.Generic.List<Character> list3 = Characters.Instance.FilterAlignmentCharacters(list2, EAlignment.Evil);
                Il2CppSystem.Collections.Generic.List<Character> list4 = new Il2CppSystem.Collections.Generic.List<Character>();
                foreach (Character character in list1)
                {
                    if (character.statuses.statuses.Contains(ECharacterStatus.KilledByEvil))
                    {
                        int randomIndex = UnityEngine.Random.Range(0, list3.Count);
                        Character random = list3[randomIndex];
                        line += $"\n#{random.id} is a killer";
                        list4.Add(random);
                        list3.Remove(random);
                        if(list3.Count == 0)
                        {
                            line += "\nAnd that is every single killer!";
                            break;
                        }
                    }
                }
                return new ActedInfo(line, list4);
            }


        }
        public override ActedInfo GetBluffInfo(Character charRef)
        {
            Gameplay gameplay = Gameplay.Instance;
            Characters instance = Characters.Instance;
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            Il2CppSystem.Collections.Generic.List<Character> list2 = Characters.Instance.FilterAliveCharacters(list1);
            list1 = Characters.Instance.FilterCharacterContainsStatus(list1, ECharacterStatus.KilledByEvil);
            if (list1.Count == 0)
            {
                return new ActedInfo("There are no dead players", null);
            }
            else
            {
                string line = "I have examined the corpses and found that: ";
                Il2CppSystem.Collections.Generic.List<Character> list3 = Characters.Instance.FilterAlignmentCharacters(list2, EAlignment.Good);
                Il2CppSystem.Collections.Generic.List<Character> list4 = new Il2CppSystem.Collections.Generic.List<Character>();
                foreach (Character character in list1)
                {
                    if (character.statuses.statuses.Contains(ECharacterStatus.KilledByEvil))
                    {
                        int randomIndex = UnityEngine.Random.Range(0, list3.Count);
                        Character random = list3[randomIndex];
                        line += $"\n#{random.id} is a killer";
                        list4.Add(random);
                        list3.Remove(random);
                        if (list3.Count == 0)
                        {
                            line += "\nAnd that is every single killer!";
                            break;
                        }
                    }
                }
                return new ActedInfo(line, list4);
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