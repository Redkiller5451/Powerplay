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
    public class Prosecutor : Role
    {
        public Prosecutor() : base(ClassInjector.DerivedConstructorPointer<Prosecutor>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public Prosecutor(System.IntPtr ptr) : base(ptr)
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
                if (trigger == ETriggerPhase.Day)
            {
                
            Gameplay gameplay = Gameplay.Instance;
            Characters instance = Characters.Instance;
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                list1 = Characters.Instance.FilterRealCharacterType(list1, ECharacterType.Minion);
          
                string line;
            if (list1.Count > 0)
            {
                    int randomIndex = UnityEngine.Random.Range(0, list1.Count);
                    Character random = list1[randomIndex];
                    random.Kill();
                   
                    line = $"I killed #{random.id}, the {random.name}";
                }
            else
            {
                 line = $"I killed no minions";
            }
              
                onActed?.Invoke(new ActedInfo(line,list1));
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
