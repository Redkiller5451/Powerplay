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
            if (CheckTriggerPhases().Contains(trigger))
            {
                SaintCureStatuses(charRef);
                charRef.statuses.AddStatus(ECharacterStatus.AppearTruthfull, charRef);
                if (charRef.alignment == EAlignment.Evil)
                {
                    charRef.ChangeAlignment(EAlignment.Good);
                    if (charRef.dataRef.characterId != "Saint_WING")
                    {
                        SharedMethods sharedScripts = new SharedMethods();
                        CharacterData saintRef = sharedScripts.GetCharDataViaID("Jailor_POW");
                        charRef.Init(saintRef);
                    }
                }
            }
        }

        public override void BluffAct(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Day)
            {
                this.onActed.Invoke(this.GetBluffInfo(charRef));

            }
        }

        public Il2CppSystem.Collections.Generic.List<ETriggerPhase> CheckTriggerPhases()
        {
            Il2CppSystem.Collections.Generic.List<ETriggerPhase> returnList = new Il2CppSystem.Collections.Generic.List<ETriggerPhase>();
            returnList.Add(ETriggerPhase.Start);
            returnList.Add(ETriggerPhase.AfterRoundStart);
            returnList.Add(ETriggerPhase.Day);
            returnList.Add(ETriggerPhase.Night);
            returnList.Add(ETriggerPhase.OnReveal);
            returnList.Add(ETriggerPhase.OnExecuted);
            returnList.Add(ETriggerPhase.OnPicked);
            returnList.Add(ETriggerPhase.OnDied);
            return returnList;
        }
        public void SaintCureStatuses(Character charRef)
        {
            if (charRef.statuses.Contains((ECharacterStatus)968))
            {
                charRef.statuses.statuses.Remove((ECharacterStatus)968);
            }
            if (charRef.statuses.Contains((ECharacterStatus)1615919000))
            {
                charRef.statuses.statuses.Remove((ECharacterStatus)1615919000);
            }
            if (charRef.statuses.Contains((ECharacterStatus)907))
            {
                charRef.statuses.statuses.Remove((ECharacterStatus)907);
            }
            if (charRef.statuses.Contains((ECharacterStatus)918919))
            {
                charRef.statuses.statuses.Remove((ECharacterStatus)918919);
            }
            if (charRef.statuses.Contains((ECharacterStatus)880)) // Evil-turned (Skill Cycler's Riddles)
            {
                charRef.statuses.statuses.Remove((ECharacterStatus)880);
            }
            if (charRef.statuses.Contains(ECharacterStatus.AppearLying))
            {
                charRef.statuses.statuses.Remove(ECharacterStatus.AppearLying);
            }
            if (charRef.statuses.Contains(Swapped.swapped))
            {
                charRef.statuses.statuses.Remove(Swapped.swapped);
            }
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
                if (protestOccured)
                {
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
        public override CharacterData? GetBluffIfAble(Character charRef)
        {
            return null;
        }
    }
}
