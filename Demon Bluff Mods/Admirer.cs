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
    public class Admirer : Role
    {
        public Admirer() : base(ClassInjector.DerivedConstructorPointer<Admirer>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public Admirer(System.IntPtr ptr) : base(ptr)
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
            ActedInfo actedInfo = new ActedInfo("I am a Pilgrim!", null);
            return actedInfo;
        }
        public override ActedInfo GetBluffInfo(Character charRef)
        {
            ActedInfo actedInfo = new ActedInfo("I am not a Pilgrim!", null);
            return actedInfo;
        }
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Day)
            {
                if (charRef.statuses.Contains(ECharacterStatus.Corrupted))
                {
                    Il2CppSystem.Collections.Generic.List<Character> possibleCharacters = new();
                    possibleCharacters = Characters.Instance.FilterAliveCharacters(Gameplay.CurrentCharacters);
                    possibleCharacters = Characters.Instance.FilterAlignmentCharacters(possibleCharacters, EAlignment.Evil);
                    
                    possibleCharacters = Characters.Instance.FilterHiddenCharacters(possibleCharacters);
                    possibleCharacters.Remove(charRef);
                    if (possibleCharacters.Count == 0)
                    {
                        onActed?.Invoke(new ActedInfo("I... I cannot feel love!"));
                    }
                    possibleCharacters = Characters.Instance.FilterBluffingCharacters(possibleCharacters);
                    if (possibleCharacters.Count == 0)
                    {
                        onActed?.Invoke(new ActedInfo("I do not have my Phaethon!"));
                    }
                    else
                    {
                        int randomIndex = UnityEngine.Random.Range(0, possibleCharacters.Count);
                        Character random = possibleCharacters[randomIndex];
                        string info = $"My love is of the {SubTypes.GetString(SubTypes.GetESubType(random.bluff))} type!";
                        onActed?.Invoke(new ActedInfo(info));
                    }
                }
                else
                {
                    Il2CppSystem.Collections.Generic.List<Character> possibleCharacters = new();
                    possibleCharacters = Characters.Instance.FilterAliveCharacters(Gameplay.CurrentCharacters);
                    possibleCharacters = Characters.Instance.FilterCharacterType(possibleCharacters, ECharacterType.Villager);
                    possibleCharacters = Characters.Instance.FilterHiddenCharacters(possibleCharacters);
                    possibleCharacters.Remove(charRef);
                    if (possibleCharacters.Count ==0)
                    {
                        onActed?.Invoke(new ActedInfo("I do not have my Phaethon!"));
                    }
                    else
                    {
                        int randomIndex = UnityEngine.Random.Range(0, possibleCharacters.Count);
                        Character random = possibleCharacters[randomIndex];
                        string info = $"My love is of the {SubTypes.GetString(SubTypes.GetESubType(random.dataRef))} type!";
                        onActed?.Invoke(new ActedInfo(info));
                    }
                }

            }
        }
        public override void BluffAct(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Day)
            {
                Il2CppSystem.Collections.Generic.List<Character> possibleCharacters = new();
                possibleCharacters = Characters.Instance.FilterAliveCharacters(Gameplay.CurrentCharacters);
                possibleCharacters = Characters.Instance.FilterAlignmentCharacters(possibleCharacters, EAlignment.Evil);
                possibleCharacters = Characters.Instance.FilterHiddenCharacters(possibleCharacters);
                possibleCharacters.Remove(charRef);
                if (possibleCharacters.Count == 0)
                {
                    onActed?.Invoke(new ActedInfo("I... I cannot feel love!"));
                }
                possibleCharacters = Characters.Instance.FilterBluffingCharacters(possibleCharacters);
                if (possibleCharacters.Count == 0)
                {
                    onActed?.Invoke(new ActedInfo("I do not have my Phaethon!"));
                }
                else
                {
                    int randomIndex = UnityEngine.Random.Range(0, possibleCharacters.Count);
                    Character random = possibleCharacters[randomIndex];
                    string info = $"My love is of the {SubTypes.GetString(SubTypes.GetESubType(random.bluff))} type!";
                    onActed?.Invoke(new ActedInfo(info));
                }

            }
        }
        public override CharacterData? GetBluffIfAble(Character charRef)
        {
            return null;
        }
    }
}
