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
    public class Boomdandy : Minion
    {
        public Boomdandy() : base(ClassInjector.DerivedConstructorPointer<Boomdandy>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public Boomdandy(System.IntPtr ptr) : base(ptr)
        {

        }
        public override ActedInfo GetInfo(Character charRef)
        {
            return new ActedInfo("");
        }
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.OnExecuted)
            {
                Gameplay gameplay = Gameplay.Instance;
                Characters instance = Characters.Instance;
                Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                list1 = Characters.Instance.FilterRealCharacterType(list1, ECharacterType.Villager);
                Character victim = null;
                Health health = PlayerController.PlayerInfo.health;
                int randomIndex1 = UnityEngine.Random.Range(0, list1.Count);
                victim = list1[randomIndex1];

                victim.KillByDemon(charRef);
                victim.statuses.statuses.Add(ECharacterStatus.KilledByEvil);
                victim.statuses.AddStatus(ECharacterStatus.MessedUpByEvil, victim);
                list1.Remove(victim);
                int randomIndex2 = UnityEngine.Random.Range(0, list1.Count);
                victim = list1[randomIndex2];
                victim.statuses.statuses.Add(ECharacterStatus.KilledByEvil);
                victim.KillByDemon(charRef);
                victim.statuses.AddStatus(ECharacterStatus.MessedUpByEvil, victim);
                if (!isRoundOver())
                {
                    health.Damage(3);
                }
            }
        }
        private bool isRoundOver()
        {
            Gameplay gameplay = Gameplay.Instance;
            Characters instance = Characters.Instance;
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            list1 = Characters.Instance.FilterAlignmentCharacters(list1, EAlignment.Evil);
            list1 = Characters.Instance.FilterAliveCharacters(list1);
            return list1.Count <= 0;
        }
    }
}

