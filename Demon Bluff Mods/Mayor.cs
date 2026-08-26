using Il2Cpp;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSoftMasking.Samples;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using System;
using UnityEngine;
using static MelonLoader.MelonLaunchOptions;
using static MelonLoader.Modules.MelonModule;

namespace Demon_Bluff_Mods
{
    [RegisterTypeInIl2Cpp]
    public class Mayor : Role
    {
        public Mayor() : base(ClassInjector.DerivedConstructorPointer<Mayor>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public Mayor(System.IntPtr ptr) : base(ptr)
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

            return new ActedInfo("");
           
        }

        public override ActedInfo GetBluffInfo(Character charRef)
        {
            return new ActedInfo("");
        }

        public override void Act(ETriggerPhase trigger, Character charRef)
        {
          
            if (trigger == ETriggerPhase.Day)
            {
             
                revealDisguises(charRef);
            }
            if (CheckTriggerPhases().Contains(trigger))
            {
                SaintCureStatuses(charRef);
                charRef.statuses.AddStatus(ECharacterStatus.AppearTruthfull, charRef);
                if (charRef.alignment == EAlignment.Evil)
                {
                    charRef.ChangeAlignment(EAlignment.Good);
                    if (charRef.dataRef.characterId != "Mayor_POW")
                    {
                        SharedMethods sharedScripts = new SharedMethods();
                        CharacterData saintRef = sharedScripts.GetCharDataViaID("Mayor_POW");
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
        // These methods are a fork of the Alchemists method, except with Disguises instead of Corruption
        private void revealDisguises(Character charRef)
        {

            Il2CppSystem.Collections.Generic.List<Character> disguisedCharacters = GetDisguisedCharactersAroundMe(charRef);
            foreach (Character ch in disguisedCharacters)
            {
                ch.RevealAllReal();
                if (ch.bluff.picking)
                {
                    ch.bluff.picking = false;
                }


            }
            string line = ConjourInfo(disguisedCharacters);
            Debug.Log(line);
            onActed?.Invoke(new ActedInfo(line,disguisedCharacters));
           

        }
        public Il2CppSystem.Collections.Generic.List<Character> GetDisguisedCharactersAroundMe(Character charRef)
        {
            Il2CppSystem.Collections.Generic.List<Character> myList = CharactersHelper.GetSortedListWithCharacterFirst(Gameplay.CurrentCharacters, charRef);
            Il2CppSystem.Collections.Generic.List<Character> disguisedCharacters = new Il2CppSystem.Collections.Generic.List<Character>();

            myList.RemoveAt(0);
            for (int i = 0; i < myList.Count; i++)
            {
                if (i > 1) break;
                if (myList[i].bluff)
                {
                    disguisedCharacters.Add(myList[i]);
                }
            }

            int j = 0;

            for (int i = myList.Count - 1; i > 0; i--)
            {
                if (j > 1) break;
                if (myList[i].bluff)
                {
                    disguisedCharacters.Add(myList[i]);
                }
                j++;
            }
            return disguisedCharacters;
        }
   
    public string ConjourInfo(Il2CppSystem.Collections.Generic.List<Character> disguisedCharacters)
        {
            string line;
            if (disguisedCharacters.Count > 1)
            {
                line = $"I have revealed {disguisedCharacters.Count} cards";
            }
            else if (disguisedCharacters.Count == 1)
            {
                line = $"I have revealed a singular card";
            }
            else
            {
                line = $"All cards around me are trustworthy";
            }
            return line;
        }
    }
}
