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
    public class Dreamweaver : CovenFollower
    {
        public override Il2CppSystem.Collections.Generic.List<SpecialRule> GetRules()
        {
            Il2CppSystem.Collections.Generic.List<SpecialRule> sr = new Il2CppSystem.Collections.Generic.List<SpecialRule>();
            sr.Add(new NightModeRule(4));
            return sr;
        }

        public Dreamweaver() : base(ClassInjector.DerivedConstructorPointer<Dreamweaver>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public Dreamweaver(System.IntPtr ptr) : base(ptr)
        {

        }
        public override ActedInfo GetInfo(Character charRef)
        {
            return new ActedInfo("");
        }
        //Code taken from Circus, as Slinger is very similar to Vizier
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if(trigger== ETriggerPhase.Start)
            {
                Il2CppSystem.Collections.Generic.List<Character> allChars = Gameplay.CurrentCharacters;
                allChars = Characters.Instance.FilterAlignmentCharacters(allChars, EAlignment.Good);
                Character c = allChars[UnityEngine.Random.Range(0, allChars.Count)];
                c.statuses.statuses.Add(Dreamweaved.Dreamweave);
                c.statuses.AddStatus(ECharacterStatus.MessedUpByEvil, charRef);
                MelonLogger.Msg($"Dreamweaved #{c.id}");
            }
            if (trigger == ETriggerPhase.Night && IsBookHolder(charRef))
            {
                KillHidden(charRef);
            }
        }
    }
}