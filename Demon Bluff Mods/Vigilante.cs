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
    public class Vigilante : Role
    {
        private bool GotRevealed = false;
        Character victim = null;
        public Vigilante() : base(ClassInjector.DerivedConstructorPointer<Vigilante>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public Vigilante(System.IntPtr ptr) : base(ptr)
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
            ActedInfo actedInfo = new ActedInfo($"I am shooting #{victim.id}... I don't trust them!", null);
            return actedInfo;
        }
        public override ActedInfo GetBluffInfo(Character charRef)
        {
            ActedInfo actedInfo = new ActedInfo("My bullet is defective!", null);
            return actedInfo;
        }
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Day)
            {
                Il2CppSystem.Collections.Generic.List<Character> possibleCharacters = new();
                possibleCharacters = Characters.Instance.FilterAliveCharacters(Gameplay.CurrentCharacters);
                possibleCharacters.Remove(charRef);
                int randomIndex = UnityEngine.Random.Range(0, possibleCharacters.Count);
                Character random = possibleCharacters[randomIndex];
                victim = random;
                GotRevealed = true;
                onActed?.Invoke(GetInfo(charRef));

            }
            if (trigger == ETriggerPhase.Night && GotRevealed )
            {
                if (victim != null)
                {
                    if (victim.state == ECharacterState.Dead && charRef.state != ECharacterState.Dead)
                    {
                        charRef.ShowActed(new ActedInfo("My target's house is already vacant!"), ETriggerPhase.Day);
                    }
                    else
                    {
                        if (charRef.statuses.Contains(ECharacterStatus.Corrupted))
                        {
                            charRef.ShowActed(GetBluffInfo(charRef), ETriggerPhase.Day);
                        }
                        else
                        {
                            victim.Kill();
                            if (victim.GetRealAlignment() == EAlignment.Good)
                            {
                                charRef.KillByDemon(charRef);
                                charRef.ShowActed(new ActedInfo("I deserve punishment for my crimes!"), ETriggerPhase.Day);
                            }
                            else
                            {
                                charRef.ShowActed(new ActedInfo("BEGONE YOU WRETCHED THING!"), ETriggerPhase.Day);
                            }
                        }
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
                possibleCharacters.Remove(charRef);
                int randomIndex = UnityEngine.Random.Range(0, possibleCharacters.Count);
                Character random = possibleCharacters[randomIndex];
                victim = random;
                GotRevealed = true;
                onActed?.Invoke(new ActedInfo($"I am shooting #{victim.id}... I don't trust them!", null));

            }
            if (trigger == BluffsActivationAtNight.NightAct && GotRevealed)
            {
                if (victim != null)
                {
                    if (victim.state == ECharacterState.Dead)
                    {
                        charRef.ShowActed(new ActedInfo("My target's house is already vacant!"), ETriggerPhase.Day);
                    }
                    else
                    {
                        charRef.ShowActed(GetBluffInfo(charRef), ETriggerPhase.Day);
                    }
                }
            }
        }
    }
}
