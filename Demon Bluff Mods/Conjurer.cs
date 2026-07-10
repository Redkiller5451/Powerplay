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
        //Code taken from Circus, as Slinger is very similar to Vizier
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.AfterRoundStart)
            {
                object delay = MelonCoroutines.Start(KillCharacter(charRef));
            }
        }
        public System.Collections.IEnumerator KillCharacter(Character charRef)
        {
            yield return new WaitForSeconds(1f);
            Il2CppSystem.Collections.Generic.List<Character> unrevealedCharacters = Characters.Instance.FilterHiddenCharacters(Gameplay.CurrentCharacters);
            unrevealedCharacters = Characters.Instance.FilterAlignmentCharacters(unrevealedCharacters, EAlignment.Good);
            if (unrevealedCharacters.Count > 0)
            {
                Character targetChar = unrevealedCharacters[UnityEngine.Random.RandomRangeInt(0, unrevealedCharacters.Count)];
                targetChar.statuses.AddStatus(ECharacterStatus.KilledByEvil, charRef);
                targetChar.statuses.AddStatus(ECharacterStatus.MessedUpByEvil, charRef);
                targetChar.KillByDemon(charRef);
            }
        }
    }
}
