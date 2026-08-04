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
    public class Poisoner2 : CovenFollower
    {
        public override Il2CppSystem.Collections.Generic.List<SpecialRule> GetRules()
        {
            Il2CppSystem.Collections.Generic.List<SpecialRule> sr = new Il2CppSystem.Collections.Generic.List<SpecialRule>();
            sr.Add(new NightModeRule(4));
            return sr;
        }

        public Poisoner2() : base(ClassInjector.DerivedConstructorPointer<Poisoner2>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public Poisoner2(System.IntPtr ptr) : base(ptr)
        {

        }
        public override ActedInfo GetInfo(Character charRef)
        {
            return new ActedInfo("");
        }
        //Code taken from Circus, as Slinger is very similar to Vizier
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Start)
            {
                Il2CppSystem.Collections.Generic.List<Character> unrevealedCharacters = Gameplay.CurrentCharacters;
                unrevealedCharacters = Characters.Instance.FilterAlignmentCharacters(unrevealedCharacters, EAlignment.Good);
                Character targetChar = unrevealedCharacters[UnityEngine.Random.RandomRangeInt(0, unrevealedCharacters.Count)];
                targetChar.statuses.AddStatus(ECharacterStatus.MessedUpByEvil, charRef);
                targetChar.statuses.statuses.Add(Poisoned.poisoned);
                MelonLogger.Msg($"Poisoned #{targetChar.id}");
            }
                if (trigger == ETriggerPhase.Night && IsBookHolder(charRef))
            {
                KillHidden(charRef);
            }
        }
    }
}