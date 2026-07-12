using Il2Cpp;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using MelonLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demon_Bluff_Mods
{
    [RegisterTypeInIl2Cpp]
    public class KnowItAll : Role
    {
        public KnowItAll() : base(ClassInjector.DerivedConstructorPointer<KnowItAll>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public KnowItAll(System.IntPtr ptr) : base(ptr)
        {
            ClassInjector.DerivedConstructorBody(this);
        }
        public override ActedInfo GetInfo(Character charRef)
        {
            ArrayList messages = new ArrayList();
            string info = "";
            if (WhatType())
            {
                messages = TrueMessages();
                info = $"To say \" {messages[UnityEngine.Random.Range(0, messages.Count)]} \" would be saying truths";
            }
            else
            {
                messages = FalseMessages();
                info = $"To say \" {messages[UnityEngine.Random.Range(0, messages.Count)]} \" would be saying falsehoods";
            }
            return new ActedInfo(info);
        }
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Day)
            {
                if (charRef.statuses.statuses.Contains(ECharacterStatus.Corrupted))
                {
                    onActed?.Invoke(GetBluffInfo(charRef));
                }
                else
                {
                    onActed?.Invoke(GetInfo(charRef));
                }

            }

        }
        public override void BluffAct(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Day)
            {
                onActed?.Invoke(GetBluffInfo(charRef));
            }
        }
        public override ActedInfo GetBluffInfo(Character charRef)
        {
            ArrayList messages = new ArrayList();
            string info = "";
            if (WhatType())
            {
                messages = TrueMessages();
                info = $"To say: \"{messages[UnityEngine.Random.Range(0, messages.Count)]}\",would be saying falsehoods";
            }
            else
            {
                messages = FalseMessages();
                info = $"To say: \"{messages[UnityEngine.Random.Range(0, messages.Count)]}\",would be saying truths";
            }
            return new ActedInfo(info);

        }
        private bool WhatType()
        {
            return UnityEngine.Random.Range(0, 1) == 1;
        }
        private ArrayList TrueMessages()
        {
            ArrayList messages = new ArrayList();
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            if (Characters.Instance.FilterCharacterContainsStatus(list1, ECharacterStatus.Corrupted).Count > 0)
            {
                messages.Add("There is Corruption in the Village");
            }
            Il2CppSystem.Collections.Generic.List<Character> list2 = Characters.Instance.FilterCharacterType(list1, ECharacterType.Minion);
            if (list2.Count == 0 )
            {
                messages.Add("There is no minions");
            }
            if (Characters.Instance.FilterCharacterContainsStatus(list1, ECharacterStatus.Silenced).Count > 0)
            {
                messages.Add("Someone is silenced in the Village");
            }
            if (isNextToMyFriend())
            {
                messages.Add("I am sitting next to my best friend!");
            }
            if (DidPuppeteerFail())
            {
                messages.Add("There is a Puppet in-play.");
            }
            if (isNextToOutcast())
            {
                messages.Add("I sit next to an Outcast");
            }
            if (DidLycanthropeTransform())
            {
                messages.Add("The Lycanthrope is now a Werewolf");
            }
            if (isNextToMinion())
            {
                messages.Add("I am next to a Minion.");
            }
            if (isInPlay("Jailor_POW") || isInPlay("Mayor_POW") || isInPlay("Monarch_POW") || isInPlay("Marshal_POW") || isInPlay("Prosecutor_POW") || isInPlay("Pacifist_POW") || isInPlay("Executive_POW"))
            {
                messages.Add("The Executive is here.");
            }
            if (isEvilVillager())
            {
                messages.Add("There is a Traitorous Villager.");
            }
            if (isDemonApoc())
            {
                messages.Add("The Apocalypse is upon us.");
            }
            if (messages.Count == 0)
            {
                messages.Add("You are playing Powerplay! Thanks!");
            }
            return messages;
        }
        private ArrayList FalseMessages()
        {
            ArrayList messages = new ArrayList();
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            if (Characters.Instance.FilterCharacterContainsStatus(list1, ECharacterStatus.Corrupted).Count == 0)
            {
                messages.Add("There is Corruption in the Village");
            }
            Il2CppSystem.Collections.Generic.List<Character> list2 = Characters.Instance.FilterCharacterType(list1, ECharacterType.Minion);
            if (list2.Count > 0)
            {
                messages.Add("There is no minions");
            }
            if (Characters.Instance.FilterCharacterContainsStatus(list1, ECharacterStatus.Silenced).Count == 0)
            {
                messages.Add("Someone is silenced in the Village");
            }
            if (!isNextToMyFriend())
            {
                messages.Add("I am sitting next to my best friend!");
            }
            if (!DidPuppeteerFail())
            {
                messages.Add("There is a Puppet in-play.");
            }
            if (!isNextToOutcast())
            {
                messages.Add("I sit next to an Outcast");
            }
            if (!DidLycanthropeTransform())
            {
                messages.Add("The Lycanthrope is now a Werewolf");
            }
            if (!isNextToMinion())
            {
                messages.Add("I am next to a Minion.");
            }
            if (!(isInPlay("Jailor_POW") || isInPlay("Mayor_POW") || isInPlay("Monarch_POW") || isInPlay("Marshal_POW") || isInPlay("Prosecutor_POW") || isInPlay("Pacifist_POW") || isInPlay("Executive_POW")))
            {
                messages.Add("The Executive is here.");
            }
            if (!isEvilVillager())
            {
                messages.Add("There is a Traitorous Villager.");
            }
            if (!isDemonApoc())
            {
                messages.Add("The Apocalypse is upon us.");
            }
            if (messages.Count == 0)
            {
                messages.Add("You should play Custom TT with Haiowi real.");
            }
            return messages;
        }
        public Il2CppSystem.Collections.Generic.List<Character> GetNeighbors()
        {
            Il2CppSystem.Collections.Generic.List<Character> myList = CharactersHelper.GetSortedListWithCharacterFirst(Gameplay.CurrentCharacters, charRef);
            myList.RemoveAt(0);
            Il2CppSystem.Collections.Generic.List<Character> neighbors = new Il2CppSystem.Collections.Generic.List<Character>();
            neighbors.Add(myList[0]);
            neighbors.Add(myList[myList.Count - 1]);
            return neighbors;
        }

        public bool isInPlay(string ID)
        {
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            foreach (Character character in list1)
            {
                if(character.dataRef.characterId == ID) return true;
            }
            return false;
        }
        public bool DidPuppeteerFail()
        {
            ArrayList messages = new ArrayList();
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            bool isPuppeteerThere = false;
            foreach (Character character in list1)
            {
                if (character.role is Mezepheles)
                {
                    isPuppeteerThere = true;
                }
            }
            bool isPuppetThere = false;
            foreach (Character character in list1)
            {
                if (character.role is Puppet)
                {
                    isPuppetThere = true;
                }
            }
            return isPuppeteerThere && isPuppetThere;
        }
        public bool isNextToMyFriend()
        {
            Il2CppSystem.Collections.Generic.List<Character> neighbors = GetNeighbors();
            return neighbors[0].role is Rambler || neighbors[1].role is Rambler;
        }
        public bool isNextToOutcast()
        {
            Il2CppSystem.Collections.Generic.List<Character> neighbors = GetNeighbors();
            return neighbors[0].GetCharacterType() is ECharacterType.Outcast || neighbors[1].GetCharacterType() is ECharacterType.Outcast;
        }
        public bool isNextToMinion()
        {
            Il2CppSystem.Collections.Generic.List<Character> neighbors = GetNeighbors();
            return neighbors[0].GetCharacterType() is ECharacterType.Minion || neighbors[1].GetCharacterType() is ECharacterType.Minion;
        }
        public bool DidLycanthropeTransform()
        {
            ArrayList messages = new ArrayList();
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            bool isWW = false;
            foreach (Character character in list1)
            {
                if (character.role is Werewolf)
                {
                    isWW = true;
                }
            }
            return isWW;
        }
        public bool isDemonApoc()
        {
            ArrayList messages = new ArrayList();
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            list1 = Characters.Instance.FilterCharacterType(list1, ECharacterType.Demon);
            bool thereIsApoc = false;
            foreach (Character character in list1)
            {
                if (character.role is Pestilence || character.role is Death || character.role is War || character.role is Famine)
                {
                    thereIsApoc = true;
                }
            }
            return thereIsApoc;
        }
        public bool isEvilVillager()
        {
            ArrayList messages = new ArrayList();
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            list1 = Characters.Instance.FilterCharacterType(list1, ECharacterType.Villager);
            bool thereIsEvil = false;
            foreach (Character character in list1)
            {
                if (character.alignment is EAlignment.Evil)
                {
                    thereIsEvil = true;
                }
            }
            return thereIsEvil;
        }
    }
}
