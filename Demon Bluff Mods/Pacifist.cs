using Il2Cpp;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Demon_Bluff_Mods
{
    [RegisterTypeInIl2Cpp]
    public class Pacifist : Role
    {
        public Pacifist() : base(ClassInjector.DerivedConstructorPointer<Pacifist>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public Pacifist(System.IntPtr ptr) : base(ptr)
        {
            ClassInjector.DerivedConstructorBody(this);
        }
        public override string Description
        {
            get
            {
                return "This is a cool role!";
            }
        }
        public override ActedInfo GetInfo(Character charRef)
        {
            ActedInfo actedInfo = new ActedInfo("I Killed a Minion", null);
            return actedInfo;
        }
        public override ActedInfo GetBluffInfo(Character charRef)
        {
            ActedInfo actedInfo = new ActedInfo("I am Corrupted", null);
            return actedInfo;
        }

        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Start)
            {
                int randoChance = UnityEngine.Random.Range(0, 5);
                if (randoChance > 2)
                {
                    charRef.statuses.AddStatus(ECharacterStatus.Corrupted,charRef);
                    this.onActed.Invoke(this.GetBluffInfo(charRef));
                }
                else
                {
                    Gameplay gameplay = Gameplay.Instance;
                    Characters instance = Characters.Instance;
                    Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                    list1 = Characters.Instance.FilterRealCharacterType(list1, ECharacterType.Villager);
                    string line;
                    if (list1.Count > 0)
                    {
                        foreach (Character character in list1)
                        {
                            character.statuses.AddStatus(ECharacterStatus.UnkillableByDemon, charRef);
                        }
                        line = $"I am protecting the Villagers";
                    }
                else
                {                    line = $"There are no Villagers";
                }
                    this.onActed.Invoke(new ActedInfo(line, null));                }
                    
            }

        }
        public override void BluffAct(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Day)
            {
                this.onActed.Invoke(this.GetBluffInfo(charRef));
            }
        }
        public override CharacterData? GetBluffIfAble(Character charRef)
        {
            return null;
        }
    }
}
