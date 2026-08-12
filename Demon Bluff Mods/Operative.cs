using Il2Cpp;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demon_Bluff_Mods
{
    [RegisterTypeInIl2Cpp]
    public class Operative : Role
    {
        public Operative() : base(ClassInjector.DerivedConstructorPointer<Operative>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
            action1 = new System.Action(CharacterPicked);
            action2 = new System.Action(StopPick);
            action3 = new System.Action(CharacterPickedDrunk);
        }
        public Operative(System.IntPtr ptr) : base(ptr)
        {
            action1 = new System.Action(CharacterPicked);
            action2 = new System.Action(StopPick);
            action3 = new System.Action(CharacterPickedDrunk);
        }
        public override string Description
        {
            get
            {
                return "This is a cool role!";
            }
        }
        private Il2CppSystem.Action action1;
        private Il2CppSystem.Action action2;
        private Il2CppSystem.Action action3;
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger != ETriggerPhase.Day) return;
            CharacterPicker.Instance.StartPickCharacters(1, charRef);
            CharacterPicker.OnCharactersPicked += action1;
            CharacterPicker.OnStopPick += action2;
        }
        private void StopPick()
        {
            CharacterPicker.OnCharactersPicked -= action1;
            CharacterPicker.OnCharactersPicked -= action3;
            CharacterPicker.OnStopPick -= action2;

        }

        private void CharacterPicked()
        {
            CharacterPicker.OnCharactersPicked -= action1;
            CharacterPicker.OnStopPick -= action2;
            List<Character> outsiders = new List<Character>();
            List<int> ids = new List<int>();
            foreach (Character c in CharacterPicker.PickedCharacters)
            {
                ids.Add(c.id);
                outsiders.Add(c);
            }
            onActed?.Invoke(new ActedInfo(ConjureInfo(outsiders[0], IsTrespassing(outsiders[0]), IsMurder(outsiders[0]), IsFakingIdentity(outsiders[0]), IsLying(outsiders[0]))));
        }

        public override void BluffAct(ETriggerPhase trigger, Character charRef)
        {
            if (trigger != ETriggerPhase.Day) return;
            CharacterPicker.Instance.StartPickCharacters(1, charRef);
            CharacterPicker.OnCharactersPicked += action3;
            CharacterPicker.OnStopPick += action2;
        }
        private void CharacterPickedDrunk()
        {
            CharacterPicker.OnCharactersPicked -= action3;
            CharacterPicker.OnStopPick -= action2;
            List<Character> outsiders = new List<Character>();
            List<int> ids = new List<int>();
            foreach (Character c in CharacterPicker.PickedCharacters)
            {
                ids.Add(c.id);
                outsiders.Add(c);
            }

           int falseCrime = UnityEngine.Random.Range(0, 4);
            if(falseCrime ==0 )
            {
                onActed?.Invoke(new ActedInfo(ConjureInfo(outsiders[0], IsTrespassing(outsiders[0]), IsMurder(outsiders[0]), IsFakingIdentity(outsiders[0]), !IsLying(outsiders[0]))));
            }
            if (falseCrime == 1)
            {
                onActed?.Invoke(new ActedInfo(ConjureInfo(outsiders[0], IsTrespassing(outsiders[0]), IsMurder(outsiders[0]), !IsFakingIdentity(outsiders[0]), !IsLying(outsiders[0]))));
            }
            if (falseCrime == 2)
            {
                onActed?.Invoke(new ActedInfo(ConjureInfo(outsiders[0], !IsTrespassing(outsiders[0]), IsMurder(outsiders[0]), IsFakingIdentity(outsiders[0]), !IsLying(outsiders[0]))));
            }
            if (falseCrime == 3)
            {
                onActed?.Invoke(new ActedInfo(ConjureInfo(outsiders[0], IsTrespassing(outsiders[0]), !IsMurder(outsiders[0]), IsFakingIdentity(outsiders[0]), !IsLying(outsiders[0]))));
            }

        }

        private bool IsFakingIdentity(Character character)
        {
            if (character.bluff == null) return false;
            else return true;
        }
        private bool IsTrespassing(Character character)
        {
            if (character.bluff == null) return false;
            if (character.GetRegisterAs().type == ECharacterType.Villager) return false;
            if (character.bluff.picking) return true;
            else return false;
        }
        private bool IsLying(Character character)

        {
            ESubType sub = SubTypes.GetESubType(character.dataRef);
            if (sub == ESubType.Outcast_Deception || sub == ESubType.Minion_Deception || sub == ESubType.Demon_Deception || character.statuses.Contains(ECharacterStatus.Corrupted)
                || character.statuses.Contains(ECharacterStatus.AppearLying)) return true;
            else return false;
        }
        private bool IsMurder(Character character)

        {

            ESubType sub = SubTypes.GetESubType(character.dataRef);
            if (sub == ESubType.Town_Killing || sub == ESubType.Outcast_Killing || sub == ESubType.Minion_Killing || sub == ESubType.Demon_Killing) return true;
            else return false;
        }
        public string ConjureInfo(Character charRef, bool tress, bool murder, bool falseIdentity, bool perjury)
        {
            string info = $"I investigated #{charRef.id} and found ";
            if (!tress && !murder && !falseIdentity && !perjury)
            {
                info += "no evidence of any criminal activity.";
                return info;
            }
            else
            {

                List<string> infoList = new List<string>();

                info += "found evidence of ";
                if (perjury)
                    infoList.Add("Perjury");
                if (falseIdentity)
                    infoList.Add("Fraud");
                if (tress)
                    infoList.Add("Tresspassing");
                if (murder)
                    infoList.Add("Murder");
                for (int i = 0; i < infoList.Count; i++)
                {
                    info += infoList[i];
                    if (i + 2 == infoList.Count)
                    {
                        info += " and ";
                    }
                    else if(i+1 == infoList.Count)
                    {
                        info += "!";
                    }
                    else
                    {
                        info += ", ";
                    }

                }
            }
            return info;
        }
    }
}
