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
    public class Sailor : Role
    {
        public Sailor() : base(ClassInjector.DerivedConstructorPointer<Sailor>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public Sailor(System.IntPtr ptr) : base(ptr)
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
            if (trigger == ETriggerPhase.Day)
            {
                Gameplay gameplay = Gameplay.Instance;
                Characters instance = Characters.Instance;
                Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                if (charRef.statuses.Contains(ECharacterStatus.Corrupted))
                {
                    list1 = Characters.Instance.FilterOutStatus(list1, Protected.protect);
                    int randomIndex = UnityEngine.Random.Range(0, list1.Count);
                    random = list1[randomIndex];
                    string line = $"I trusted #{random.id} with my armor";
                    onActed?.Invoke(new ActedInfo(line, null));

                }
                else
                {
                    list1 = Characters.Instance.FilterOutRole(list1, "Knight_47970624");
                    list1.Remove(charRef);
                    int randomIndex = UnityEngine.Random.Range(0, list1.Count);
                    random = list1[randomIndex];
                    if (random.alignment == EAlignment.Good)
                    {
                        random.statuses.AddStatus(Protected.protect, charRef);
                    }
                    else
                    {
                        charRef.statuses.AddStatus(Protected.protect, charRef);
                    }
                    string line = "";
                    if (list1.Count == 0)
                    {
                        line = "I couldnt protect nobody.";
                    }
                    else
                    {
                        if (random.alignment == EAlignment.Good)
                        {
                            line = $"I trusted #{random.id} with my armor";
                        }
                        else
                        {
                        line = $"I did not trust #{random.id} with my armor";
                        }
                            
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
                list1 = Characters.Instance.FilterAlignmentCharacters(list1, EAlignment.Evil);
                int randomIndex = UnityEngine.Random.Range(0, list1.Count);
                Character random = list1[randomIndex];
                string line = $"I trusted #{random.id} with my armor";
                onActed?.Invoke(new ActedInfo(line, null));
            }

        }
    }
}
