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
    public class Psychic : Role
    {
        public List<string> info = new List<string>();
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

        public string makeInfoGoodVision(Character goodChar, Character randoChar)
        {
            if (goodChar == null || randoChar == null) return "I-I can't seem to get a vision!";

            return $"Between #{goodChar.id} and #{randoChar.id} there is at least ONE Good.\n";
        }
        public string makeInfoEvilVision(Character evilChar, Character randoChar, Character randoChar2)
        {
            if (evilChar == null || randoChar == null || randoChar2 == null) return "I-I can't seem to get a vision!";

            return $"Between #{evilChar.id}, #{randoChar.id} and #{randoChar2.id} there is at least ONE Evil.\n";
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
            ActedInfo actedInfo = new ActedInfo(MakeInfo());
            return actedInfo;
        }

        public override ActedInfo GetBluffInfo(Character charRef)
        {
            ActedInfo actedInfo = new ActedInfo(MakeInfo());
            return actedInfo;
        }

        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Night)
            {
                nightCount++;
                if (charRef.state == ECharacterState.Dead) return;
                Il2CppSystem.Collections.Generic.List<Character> currentChars = (Gameplay.CurrentCharacters);
                Il2CppSystem.Collections.Generic.List<Character> list1 = new();
                foreach (Character c in currentChars)
                {
                    list1.Add(c);
                }
                Il2CppSystem.Collections.Generic.List<Character> good = Characters.Instance.FilterAlignmentCharacters(list1, EAlignment.Good);
                Il2CppSystem.Collections.Generic.List<Character> evil = Characters.Instance.FilterAlignmentCharacters(list1, EAlignment.Evil);
                string newInfo = "";
                if (nightCount % 2 == 1)
                {
                    Character goodChar = good[UnityEngine.Random.Range(0, good.Count)];
                    list1.Remove(goodChar);
                    Character randoChar = list1[UnityEngine.Random.Range(0, list1.Count)];
                    newInfo = makeInfoGoodVision(goodChar, randoChar);
                    info.Add(newInfo);
                }
                if (nightCount % 2 == 0)
                {
                    Character evilChar = evil[UnityEngine.Random.Range(0, evil.Count)];
                    list1.Remove(evilChar);
                    Character randoChar = list1[UnityEngine.Random.Range(0, list1.Count)];
                    list1.Remove(randoChar);
                    Character randoChar2 = list1[UnityEngine.Random.Range(0, list1.Count)];
                    newInfo = makeInfoEvilVision(evilChar,randoChar,randoChar2);
                    info.Add(newInfo);
                }
                if (charRef.revealed)
                {

                    onActed.Invoke(GetInfo(charRef));
                }
            }
            if (trigger == ETriggerPhase.Day)
            {
                charRef.revealed = true;
                onActed.Invoke(GetInfo(charRef));
            }
        }
        public override void BluffAct(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == BluffsActivationAtNight.NightAct)
            {
                nightCount++;
                if (charRef.state == ECharacterState.Dead) return;
                Il2CppSystem.Collections.Generic.List<Character> currentChars = (Gameplay.CurrentCharacters);
                Il2CppSystem.Collections.Generic.List<Character> list1 = new();
                foreach (Character c in currentChars)
                {
                    list1.Add(c);
                }
                Il2CppSystem.Collections.Generic.List<Character> good = Characters.Instance.FilterAlignmentCharacters(list1, EAlignment.Good);
                Il2CppSystem.Collections.Generic.List<Character> evil = Characters.Instance.FilterAlignmentCharacters(list1, EAlignment.Evil);
                string newInfo = "";
                if (nightCount % 2 == 1)
                {
                    Character goodChar = evil[UnityEngine.Random.Range(0, evil.Count)];
                    evil.Remove(goodChar);
                    Character randoChar = evil[UnityEngine.Random.Range(0, evil.Count)];
                    newInfo = makeInfoGoodVision(goodChar, randoChar);
                    info.Add(newInfo);
                }
                if (nightCount % 2 == 0)
                {
                    Character evilChar = good[UnityEngine.Random.Range(0, good.Count)];
                    good.Remove(evilChar);
                    Character randoChar = good[UnityEngine.Random.Range(0, good.Count)];
                    good.Remove(randoChar);
                    Character randoChar2 = good[UnityEngine.Random.Range(0, good.Count)];
                    newInfo = makeInfoEvilVision(evilChar, randoChar, randoChar2);
                    info.Add(newInfo);
                }
                if (charRef.revealed)
                {

                    onActed.Invoke(GetBluffInfo(charRef));
                }
            }
            if (trigger == ETriggerPhase.Day)
            {
                charRef.revealed = true;
                onActed.Invoke(GetBluffInfo(charRef));
            }
        }
        public Psychic() : base(ClassInjector.DerivedConstructorPointer<Psychic>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }

        public Psychic(System.IntPtr ptr) : base(ptr)
        {

        }
    }
}
