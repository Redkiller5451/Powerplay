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
using static Il2CppSystem.Globalization.HebrewNumber;

namespace Demon_Bluff_Mods
{
    [RegisterTypeInIl2Cpp]

    public class Pacifist : Role
    {
    
        public Pacifist() : base(ClassInjector.DerivedConstructorPointer<Pacifist>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
            action1 = new System.Action(CharacterPicked);
            action2 = new System.Action(StopPick);
        }
        public Pacifist(System.IntPtr ptr) : base(ptr)
        {
            ClassInjector.DerivedConstructorBody(this);
            action1 = new System.Action(CharacterPicked);
            action2 = new System.Action(StopPick);
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
        //CODE STEALING! Credit to Wingidon for the Forager code or else I wouldve been so clueless
        private Il2CppSystem.Action action1;
        private Il2CppSystem.Action action2;
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger != ETriggerPhase.Day) return;
            CharacterPicker.Instance.StartPickCharacters(1, charRef);
            CharacterPicker.OnCharactersPicked = action1;
            CharacterPicker.OnStopPick += action2;
            }
        private void CharacterPicked()
        {
            CharacterPicker.OnCharactersPicked -= action1;
            CharacterPicker.OnStopPick -= action2;

            Character demon = Characters.Instance.FilterCharacterType((Gameplay.CurrentCharacters), ECharacterType.Demon)[0];
            string info = "";
            Il2CppSystem.Collections.Generic.List<Character> chars = new Il2CppSystem.Collections.Generic.List<Character>();
            if (charRef.statuses.Contains(ECharacterStatus.Corrupted))
            {
                this.onActed.Invoke(this.GetBluffInfo(charRef));
                return;
            }
            else
            {
                //We love stealing code from Wingidon... Again, MASSIVE credits to them.
                
                chars.Add(CharacterPicker.PickedCharacters[0]);
                if (chars[0] == demon)
                {
                    info = $"#{chars[0].id} is a Demon!";
                }
                else
                {
                    info = $"#{chars[0].id} is not a Demon!";
                }
            }
            onActed?.Invoke(new ActedInfo(info, chars));
            Debug.Log($"{info}");
        }
        private void StopPick()
        { 
            CharacterPicker.OnCharactersPicked -= action1;
            CharacterPicker.OnStopPick -= action2;
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
