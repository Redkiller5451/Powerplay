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
    public class Medusa : CovenFollower
    {
        public override Il2CppSystem.Collections.Generic.List<SpecialRule> GetRules()
        {
            Il2CppSystem.Collections.Generic.List<SpecialRule> sr = new Il2CppSystem.Collections.Generic.List<SpecialRule>();
            sr.Add(new NightModeRule(4));
            return sr;
        }

        public Medusa() : base(ClassInjector.DerivedConstructorPointer<Medusa>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public Medusa(System.IntPtr ptr) : base(ptr)
        {

        }
        public override ActedInfo GetInfo(Character charRef)
        {
            return new ActedInfo("");
        }
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Start)
            {
                Il2CppSystem.Collections.Generic.List<Character> allCharacters = Gameplay.CurrentCharacters;
                Il2CppSystem.Collections.Generic.List<Character> list2 = new();
                allCharacters = Characters.Instance.FilterAliveCharacters(allCharacters);

                if (allCharacters.Count > 0)
                {
                    int randomIndex = UnityEngine.Random.Range(0, allCharacters.Count);
                    Character random = allCharacters[randomIndex];
                    list2.Add(random);
                    allCharacters.Remove(random);
                    if (allCharacters.Count > 0)
                    {
                        randomIndex = UnityEngine.Random.Range(0, allCharacters.Count);
                        random = allCharacters[randomIndex];
                        list2.Add(random);
                        allCharacters.Remove(random);
                        if (allCharacters.Count > 0)
                        {
                            randomIndex = UnityEngine.Random.Range(0, allCharacters.Count);
                            random = allCharacters[randomIndex];
                            list2.Add(random);
                        }
                    }
                }
                foreach(Character character in list2)
                {
                    character.statuses.AddStatus(Muddling.hiddenStatus, charRef);
                }
            
                
            }
            if (trigger == ETriggerPhase.Night && IsBookHolder(charRef))
            {
                KillHidden(charRef);
            }
        }
    }
}