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


namespace Demon_Bluff_Mods
{
    [RegisterTypeInIl2Cpp]
    public class Ambusher : MafiaMember
    {
        public Ambusher() : base(ClassInjector.DerivedConstructorPointer<Ambusher>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public Ambusher(System.IntPtr ptr) : base(ptr)
        {

        }
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Start)
            {
                Gameplay gameplay = Gameplay.Instance;
                Characters instance = Characters.Instance;
                Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                list1 = Characters.Instance.FilterRealCharacterType(list1, ECharacterType.Villager);
                int randomIndex = UnityEngine.Random.Range(0, list1.Count);
                list1[randomIndex].statuses.AddStatus(Jinxed.jinxed, list1[randomIndex]);
                list1[randomIndex].statuses.AddStatus(ECharacterStatus.MessedUpByEvil, charRef);
            }

        }

    }
}


