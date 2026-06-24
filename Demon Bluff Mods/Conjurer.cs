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
    public class Conjurer: Minion
    {
        public Conjurer() : base(ClassInjector.DerivedConstructorPointer<Conjurer>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public Conjurer(System.IntPtr ptr) : base(ptr)
        {

        }
        public override ActedInfo GetInfo(Character charRef)
        {
            return new ActedInfo("");
        }
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.AfterRoundStart)
            {
                Gameplay gameplay = Gameplay.Instance;
                Characters instance = Characters.Instance;
                Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                list1 = Characters.Instance.FilterRealCharacterType(list1, ECharacterType.Villager);
                Character victim =null;
                foreach (Character character in list1)
                {
                    if(character.dataRef.role is Prosecutor || character.dataRef.role is Monarch ||
                        character.dataRef.role is Jailor || character.dataRef.role is Mayor ||
                        character.dataRef.role is Marshal || character.dataRef.role is Official)
                    {
                        victim = character;
                    }
                }
                if (victim == null)
                {
                    int randomIndex = UnityEngine.Random.Range(0, list1.Count);
                    victim = list1[randomIndex];
                }
                victim.statuses.statuses.Add(ECharacterStatus.KilledByEvil);
                victim.KillByDemon(charRef);

                
            }
        }
        }
}
