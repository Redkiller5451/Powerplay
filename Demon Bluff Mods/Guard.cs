using Il2Cpp;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Demon_Bluff_Mods
{
    [RegisterTypeInIl2Cpp]
    public class Guard : Role
    {
        public Guard() : base(ClassInjector.DerivedConstructorPointer<Guard>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public Guard(System.IntPtr ptr) : base(ptr)
        {

        }
        public override ActedInfo GetInfo(Character charRef)
        {
            return new ActedInfo("");
        }
        public override ActedInfo GetBluffInfo(Character charRef)
        {
            return new ActedInfo("");
        }
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            Character random = null;
            if (trigger == ETriggerPhase.Start)
            {
                Gameplay gameplay = Gameplay.Instance;
                Characters instance = Characters.Instance;
                Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                if (charRef.statuses.Contains(ECharacterStatus.Corrupted))
                {
                    int randomIndex = UnityEngine.Random.Range(0, list1.Count);
                    random = list1[randomIndex];
                   
                }
                else
                {
                    list1 = Characters.Instance.FilterRealCharacterType(list1, ECharacterType.Villager);
                    int randomIndex = UnityEngine.Random.Range(0, list1.Count);
                    random = list1[randomIndex];
                    random.statuses.AddStatus(Protected.protect, random);
                    
                }
                    
                
            }
            if(trigger == ETriggerPhase.Day)
            {
                if (charRef.statuses.Contains(ECharacterStatus.Corrupted))
                {
                    Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                    list1 = Characters.Instance.FilterOutStatus(list1,Protected.protect);
                    int randomIndex = UnityEngine.Random.Range(0, list1.Count);
                    random = list1[randomIndex];
                    string line = $"#{random.id} is being protected";
                    onActed?.Invoke(new ActedInfo(line, null));
                }
                else
                {
                    Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                    list1 = Characters.Instance.FilterRealCharacterType(list1, ECharacterType.Villager);
                    list1 = Characters.Instance.FilterCharacterContainsStatus(list1, Protected.protect);
                    
                    string line = "";
                    if(list1.Count == 0)
                    {
                        line = "Noone is protected";
                    }
                    else
                    {
                        int randomIndex = UnityEngine.Random.Range(0, list1.Count);
                         random = list1[randomIndex];
                        line = $"#{random.id} is being protected";
                    }
                        
                onActed?.Invoke(new ActedInfo(line, null));

                }
                    
            }

        }
        public override void BluffAct(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Day)
            {
                Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                list1 = Characters.Instance.FilterOutStatus(list1, Protected.protect);
                int randomIndex = UnityEngine.Random.Range(0, list1.Count);
                Character random = list1[randomIndex];
                string line = $"#{random.id} is being protected";
                onActed?.Invoke(new ActedInfo(line, null));
            }

        }
    }
}
