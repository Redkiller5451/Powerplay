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
        }
        public override void BluffAct(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Day)
            {
                this.onActed.Invoke(new ActedInfo("I am Corrupted", null));
            }
        }
        // These methods are a fork of the Alchemists method, except with Disguises instead of Corruption
        private void revealDisguises(Character charRef)
        {

            Il2CppSystem.Collections.Generic.List<Character> disguisedCharacters = GetDisguisedCharactersAroundMe(charRef);
            foreach (Character ch in disguisedCharacters)
            {
                ch.RevealAllReal();

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
