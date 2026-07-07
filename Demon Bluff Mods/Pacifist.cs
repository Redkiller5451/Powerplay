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
        Character chRef;
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
            ActedInfo actedInfo = new ActedInfo("One of the protestors sabotaged the unity!", null);
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
            chRef = charRef;
            CharacterPicker.Instance.StartPickCharacters(4, charRef);
            CharacterPicker.OnCharactersPicked = action1;
            CharacterPicker.OnStopPick += action2;
            }
        private void CharacterPicked()
        {
            CharacterPicker.OnCharactersPicked -= action1;
            CharacterPicker.OnStopPick -= action2;
            if (chRef.statuses.Contains(ECharacterStatus.Corrupted))
            {
                this.onActed.Invoke(this.GetBluffInfo(chRef));
                return;
            }
            else
            {
                //We love stealing code from Wingidon... Again, MASSIVE credits to them.
                 Il2CppSystem.Collections.Generic.List<Character> chars = new Il2CppSystem.Collections.Generic.List<Character>();
                chars.Add(CharacterPicker.PickedCharacters[0]);
                chars.Add(CharacterPicker.PickedCharacters[1]);
                chars.Add(CharacterPicker.PickedCharacters[2]);
                chars.Add(CharacterPicker.PickedCharacters[3]);
                MelonLogger.Msg($"Paci picked characters: {chars[0].id} is the first");
                bool protestOccured = true;
                foreach (Character c in chars)
                {
                    MelonLogger.Msg($"Protest Loop");
                    if (c.alignment == EAlignment.Evil)
                    {
                        onActed?.Invoke(GetInfo(charRef));
                        protestOccured = false;
                    }
                }
                MelonLogger.Msg($"Checked Protest");
                if (protestOccured) {
                    Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                    list1 = Characters.Instance.FilterAlignmentCharacters(list1, EAlignment.Evil);
                    Health health = PlayerController.PlayerInfo.health;
                    health.Heal(10);
                    foreach (Character character in list1)
                    { 
                        character.Kill();
                    }
                }

            }
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
