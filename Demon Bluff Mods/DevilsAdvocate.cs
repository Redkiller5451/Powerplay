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
    public class DevilsAdvocate : Minion
    {
        public DevilsAdvocate() : base(ClassInjector.DerivedConstructorPointer<DevilsAdvocate>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public DevilsAdvocate(System.IntPtr ptr) : base(ptr)
        {

        }
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Start)
            {
                Gameplay gameplay = Gameplay.Instance;
                Characters instance = Characters.Instance;
                Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                list1 = Characters.Instance.FilterRealCharacterType(list1, ECharacterType.Demon);
                list1[0].statuses.AddStatus(ECharacterStatus.AppearTruthfull, list1[0]);
                list1[0].statuses.AddStatus(ECharacterStatus.HealthyBluff, list1[0]);
                list1[0].statuses.AddStatus(Protected.protect, list1[0]);
            }
            if(trigger == ETriggerPhase.OnExecuted)
            {
                Gameplay gameplay = Gameplay.Instance;
                Characters instance = Characters.Instance;
                Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                list1 = Characters.Instance.FilterRealCharacterType(list1, ECharacterType.Demon);
                foreach (Character character in list1)
                {
                    character.statuses.statuses.Remove(Protected.protect);
                }
            }

        }
    }
}