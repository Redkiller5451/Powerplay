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
    public class Marksman : Role
    {
        public Marksman() : base(ClassInjector.DerivedConstructorPointer<Marksman>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public Marksman(System.IntPtr ptr) : base(ptr)
        {
            ClassInjector.DerivedConstructorBody(this);
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
                list1 = Characters.Instance.FilterRealCharacterType(list1, ECharacterType.Minion);
                list1 = Characters.Instance.FilterRevealedCharacters(list1);
                string line;
                if (list1.Count > 0)
                {
                if (list1.Count == 1)
                {

                    line = $"There is 1 Minion revealed";
                }
                else
                {
                    line = $"There are {list1.Count} Minions revealed";
                }
                    return new ActedInfo(line, null);
            }
                else
                {
                    line = $"There are no revealed Minions";
                return new ActedInfo(line,  null);
            }

               
        }
        public override ActedInfo GetBluffInfo(Character charRef)
        {
            Gameplay gameplay = Gameplay.Instance;
            Characters instance = Characters.Instance;
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            list1 = Characters.Instance.FilterRealCharacterType(list1, ECharacterType.Minion);
            int nOfMinions = list1.Count;
            list1 = Characters.Instance.FilterRevealedCharacters(list1);
            string line;
                if(nOfMinions > 0)
                {
                    int randomMinionAmount = UnityEngine.Random.Range(1, nOfMinions);
                    if (randomMinionAmount == list1.Count)
                    {
                        int chance = UnityEngine.Random.Range(0, 1);
                        if(chance == 0)
                        {
                            randomMinionAmount--;
                        }
                        else
                        {
                            randomMinionAmount++;
                        }
                    }
                    if (randomMinionAmount == 0)
                    {
                        line = $"There are no revealed Minions";
                    }
                    else if (randomMinionAmount == 1)
                    {
                        line = $"There is 1 Minion revealed";
                    }
                    else
                    {
                        line = $"There are {randomMinionAmount} Minions revealed";
                    }
                    return new ActedInfo(line, null);
                }
                else
                {
                        line = $"There is 1 Minion revealed";
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