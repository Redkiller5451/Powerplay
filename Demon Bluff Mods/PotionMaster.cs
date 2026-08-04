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
    public class PotionMaster : CovenFollower
    {
        public override Il2CppSystem.Collections.Generic.List<SpecialRule> GetRules()
        {
            Il2CppSystem.Collections.Generic.List<SpecialRule> sr = new Il2CppSystem.Collections.Generic.List<SpecialRule>();
            sr.Add(new NightModeRule(4));
            return sr;
        }

        public PotionMaster() : base(ClassInjector.DerivedConstructorPointer<PotionMaster>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public PotionMaster(System.IntPtr ptr) : base(ptr)
        {

        }
        public override ActedInfo GetInfo(Character charRef)
        {
            return new ActedInfo("");
        }
        //Code taken from Circus, as Slinger is very similar to Vizier
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            MelonLogger.Msg("PM Triggered Act");
            if (trigger == ETriggerPhase.Start)
            {
                MelonLogger.Msg("PM Triggered");
                Il2CppSystem.Collections.Generic.List<Character> unrevealedCharacters = Gameplay.CurrentCharacters;
                unrevealedCharacters = Characters.Instance.FilterAlignmentCharacters(unrevealedCharacters, EAlignment.Good);
                Character targetChar = unrevealedCharacters[UnityEngine.Random.RandomRangeInt(0, unrevealedCharacters.Count)];
                int randomIndex = UnityEngine.Random.RandomRangeInt(0, 3);
                targetChar.statuses.AddStatus(ECharacterStatus.MessedUpByEvil, charRef);
                if(randomIndex == 0)
                    targetChar.statuses.AddStatus(ECharacterStatus.Corrupted, charRef);
                else if (randomIndex == 1)
                    targetChar.statuses.AddStatus(Mad.mad2, charRef);
                else
                    targetChar.statuses.AddStatus(UO.UnknownObstacle, charRef);

                MelonLogger.Msg($"PM Triggered on #{targetChar.id}");
            }
            if (trigger == ETriggerPhase.Night && IsBookHolder(charRef))
            {
                KillHidden(charRef);
            }
        }
    }
}