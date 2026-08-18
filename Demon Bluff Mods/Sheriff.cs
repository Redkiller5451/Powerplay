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
    public class Sheriff : Role
    {
        public List<string> info = new List<string>();
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
        public Sheriff() : base(ClassInjector.DerivedConstructorPointer<Sheriff>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public Sheriff(System.IntPtr ptr) : base(ptr)
        {

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
            if (trigger == BluffsActivationAtNight.NightAct)
            {
                if (charRef.state == ECharacterState.Dead) return;
                Il2CppSystem.Collections.Generic.List<Character> currentChars = (Gameplay.CurrentCharacters);
                Il2CppSystem.Collections.Generic.List<Character> list1 = new();
                foreach (Character c in currentChars)
                {
                    list1.Add(c);
                }
                int randomIndex = UnityEngine.Random.Range(0, list1.Count);
                Character random = list1[randomIndex];
                if (SubTypes.GetESubType(random.dataRef) == ESubType.Minion_Killing || SubTypes.GetESubType(random.dataRef) == ESubType.Demon_Killing || SubTypes.GetESubType(random.dataRef) == ESubType.Outcast_Killing)
                {
                    info.Add("Wait no AAAAAAA");
                    charRef.statuses.AddStatus(ECharacterStatus.KilledByEvil, charRef);
                    charRef.KillByDemon(random);
                }
                else if (random.GetRegisterAlignment() == EAlignment.Evil)
                {
                    info.Add($"#{random.id} seems suspicious!\n");
                }
                else
                {
                    info.Add($"#{random.id} seems innocent!\n");
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
                if (charRef.state == ECharacterState.Dead) return;
                Il2CppSystem.Collections.Generic.List<Character> currentChars = (Gameplay.CurrentCharacters);
                Il2CppSystem.Collections.Generic.List<Character> list1 = new();
                foreach (Character c in currentChars)
                {
                    list1.Add(c);
                }
                int randomIndex = UnityEngine.Random.Range(0, list1.Count);
                Character random = list1[randomIndex];
                if (random.GetRegisterAlignment() == EAlignment.Good)
                {
                    info.Add($"#{random.id} seems suspicious!\n");
                }
                else
                {
                    info.Add($"#{random.id} seems innocent!\n");
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
        public override CharacterData? GetBluffIfAble(Character charRef)
        {
            return null;
        }
    }
}
