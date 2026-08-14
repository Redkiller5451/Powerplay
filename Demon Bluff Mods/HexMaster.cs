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
    public class HexMaster : CovenPreacher
    {
        public HexMaster() : base(ClassInjector.DerivedConstructorPointer<HexMaster>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public HexMaster(System.IntPtr ptr) : base(ptr)
        {

        }
        public override Il2CppSystem.Collections.Generic.List<SpecialRule> GetRules()
        {
            Il2CppSystem.Collections.Generic.List<SpecialRule> sr = new Il2CppSystem.Collections.Generic.List<SpecialRule>();
            sr.Add(new NightModeRule(2));
            return sr;
        }
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Init)
            {
                DjinnPOW.Jinx("Hex Master");
                
                
            }
            if (trigger == ETriggerPhase.Start)
            {
                SwapToCult();
                GiveTheBook(charRef);
            }
            if (charRef.state == ECharacterState.Dead) return;
            if (trigger == ETriggerPhase.Night)
            {
                Il2CppSystem.Collections.Generic.List<Character> viableCharacters = Gameplay.CurrentCharacters;
                viableCharacters = Characters.Instance.FilterAliveCharacters(viableCharacters);
                viableCharacters = Characters.Instance.FilterRealAlignmentCharacters(viableCharacters, EAlignment.Good);
                viableCharacters = Characters.Instance.FilterCharacterMissingStatus(viableCharacters, Hexed.Hex);

                if(viableCharacters.Count == 0)
                {
                    MelonLogger.Msg("No more non-hexed");
                    Health health = PlayerController.PlayerInfo.health;
                    health.ResetHp();
                    health.Damage(1000000000);
                    charRef.RevealAllReal();
                    charRef.ShowActed(new ActedInfo("Oh I have called upon thee! Blast away the knife wielding one.\n<color=#6B275D>HEX BOMB</color>!!!"),ETriggerPhase.Day);
                    Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                    list1 = Characters.Instance.FilterRealAlignmentCharacters(list1, EAlignment.Good);
                    list1 = Characters.Instance.FilterAliveCharacters(list1);
                    foreach (Character character in list1)
                    {
                        character.statuses.AddStatus(ECharacterStatus.KilledByEvil, charRef);
                        character.KillByDemon(charRef);
                    }
                }
                else
                {
                    int randomIndex = UnityEngine.Random.Range(0, viableCharacters.Count);
                    Character random = viableCharacters[randomIndex];
                    random.statuses.AddStatus(Hexed.Hex, charRef);
                    MelonLogger.Msg($"Hexed #{random.id}");
                }
            }
        }

        
    }
}
