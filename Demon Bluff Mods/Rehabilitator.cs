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
    public class Rehabilitator : Role
    {
        public List<string> info = new List<string>();
        public List<int> previousInts = new List<int>();
        public List<ActedInfo> backupInfo = new List<ActedInfo>();
        int nightCount = 0;
        public override string Description
        {
            get
            {
                return "";
            }
        }
        public override Il2CppSystem.Collections.Generic.List<SpecialRule> GetRules()
        {
            Il2CppSystem.Collections.Generic.List<SpecialRule> sr = new Il2CppSystem.Collections.Generic.List<SpecialRule>();
            sr.Add(new NightModeRule(4));
            return sr;
        }
        public string MakeInfo()
        {
            string infor = "";
            foreach (string i in info)
            {
                infor += i;
            }
            return infor;
        }
        public override ActedInfo GetInfo(Character charRef)
        {
            Il2CppSystem.Collections.Generic.List<Character> currentChars = (Gameplay.CurrentCharacters);
            Il2CppSystem.Collections.Generic.List<Character> list1 = new();
            foreach (Character c in currentChars)
            {
                list1.Add(c);
            }
            list1 = Characters.Instance.FilterRevealedCharacters(list1);
            list1 = Characters.Instance.FilterCharacterContainsStatus(list1,ECharacterStatus.Corrupted);
            string newInfo = "";
            if(list1.Count == 0)
            {
                newInfo += "Everyone is sober tonight!\n";
            }
            else if(list1.Count == 1)
            {
                newInfo += "Only 1 revealed card is corrupted\n";
            }
            else
            {
                newInfo += $"{list1.Count} revealed cards are corrupted\n";
            }
                info.Add(newInfo);
            ActedInfo actedInfo = new ActedInfo(newInfo);
            return actedInfo;
        }

        public override ActedInfo GetBluffInfo(Character charRef)
        {
            Il2CppSystem.Collections.Generic.List<Character> currentChars = (Gameplay.CurrentCharacters);
            Il2CppSystem.Collections.Generic.List<Character> list1 = new();
            foreach (Character c in currentChars)
            {
                list1.Add(c);
            }
            list1 = Characters.Instance.FilterRevealedCharacters(list1);
            list1 = Characters.Instance.FilterCharacterContainsStatus(list1, ECharacterStatus.Corrupted);
            int randomize = 0;
            if (previousInts.Count == 0)
            {
                 randomize = Calculator.RemoveNumberAndGetRandomNumberFromList(list1.Count, 1, 4);
            }
            else
            {
                randomize = Calculator.RemoveNumberAndGetRandomNumberFromList(list1.Count, previousInts[previousInts.Count-1], 6);
            }
            previousInts.Add(randomize);
            string newInfo = "";
            if (randomize == 1)
            {
                newInfo += "Only 1 revealed card is corrupted\n";
            }
            else
            {
                newInfo += $"{list1.Count} revealed cards are corrupted\n";
            }
            info.Add(newInfo);
            ActedInfo actedInfo = new ActedInfo(newInfo);
            return actedInfo;
        }

        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (charRef.GetState() == ECharacterState.Dead) return;
            if (trigger == BluffsActivationAtNight.NightAct)
            {
                nightCount++;

                if (charRef.revealed)
                {

                    onActed.Invoke(GetInfo(charRef));
                    onActed.Invoke(new ActedInfo(MakeInfo()));
                }
                else
                {
                    backupInfo.Add(GetInfo(charRef));
                }
            }
            if (trigger == ETriggerPhase.Day)
            {
                charRef.revealed = true;
                foreach (ActedInfo actedInfo in backupInfo)
                {
                    onActed.Invoke(actedInfo);
                }
                onActed.Invoke(new ActedInfo(MakeInfo()));
            }
        }
        public override void BluffAct(ETriggerPhase trigger, Character charRef)
        {
            if (charRef.state == ECharacterState.Dead) return;
            if (trigger == BluffsActivationAtNight.NightAct)
            {
                nightCount++;

                if (charRef.revealed)
                {

                    onActed.Invoke(GetBluffInfo(charRef));
                    onActed.Invoke(new ActedInfo(MakeInfo()));
                }
                else
                {
                    backupInfo.Add(GetBluffInfo(charRef));
                }
            }
            if (trigger == ETriggerPhase.Day)
            {
                charRef.revealed = true;
                onActed.Invoke(GetBluffInfo(charRef));
                onActed.Invoke(new ActedInfo(MakeInfo()));
            }
        }
        public Rehabilitator() : base(ClassInjector.DerivedConstructorPointer<Rehabilitator>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }

        public Rehabilitator(System.IntPtr ptr) : base(ptr)
        {

        }
    }
}

