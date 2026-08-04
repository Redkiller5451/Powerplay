using Demon_Bluff_Mods;
using Il2Cpp;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem;
using MelonLoader;
using System;
using System.ComponentModel.Design;
using UnityEngine;

namespace Demon_Bluff_Mods
{
    [RegisterTypeInIl2Cpp]
    public class Wildling : CovenFollower
    {
        public Wildling() : base(ClassInjector.DerivedConstructorPointer<Wildling>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public Wildling(System.IntPtr ptr) : base(ptr)
        {

        }
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.AfterRoundStart)
            {
                Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                list1 = Characters.Instance.FilterAlignmentCharacters(list1, EAlignment.Evil);
                list1 = Characters.Instance.FilterOutRole(list1, "Professional_WING");
                list1 = Characters.Instance.FilterOutRole(list1, "Iris_WING");
                int randomIndex = UnityEngine.Random.Range(0, list1.Count);

                Character random = list1[randomIndex];
                
                random.statuses.AddStatus(ECharacterStatus.MessedUpByEvil, charRef);
                random.statuses.AddStatus(ECharacterStatus.AppearTruthfull, charRef);
                random.statuses.AddStatus(ECharacterStatus.HealthyBluff, charRef);
            }
            if (trigger == ETriggerPhase.Night && IsBookHolder(charRef))
            {
                KillHidden(charRef);
            }
        }
        public override CharacterData GetBluffIfAble(Character charRef)
        {
            // Become a new character
            CharacterData bluff = Characters.Instance.GetRandomUniqueBluff();
            Gameplay.Instance.AddScriptCharacterIfAble(bluff.type, bluff);

            return bluff;
        }
    }
}
