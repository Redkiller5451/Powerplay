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
    public class Jester : Neutrals
    {
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Start)
            {
                changeAlignement(charRef);
            }
            if (trigger == ETriggerPhase.OnExecuted)
            {
                if (charRef.alignment == EAlignment.Evil)
                {
                    Gameplay gameplay = Gameplay.Instance;
                    Characters instance = Characters.Instance;
                    Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                    list1 = Characters.Instance.FilterAlignmentCharacters(list1, EAlignment.Good);
                    list1 = Characters.Instance.FilterAliveCharacters(list1);
                    int randomIndex = UnityEngine.Random.Range(0, list1.Count);
                    Character random = list1[randomIndex];
                    random.KillByDemon(charRef);
                }
                else
                {
                    Gameplay gameplay = Gameplay.Instance;
                    Characters instance = Characters.Instance;
                    Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                    list1 = Characters.Instance.FilterAlignmentCharacters(list1, EAlignment.Evil);
                    list1 = Characters.Instance.FilterAliveCharacters(list1);
                    if (list1.Count == 0) return;
                    int randomIndex = UnityEngine.Random.Range(0, list1.Count);
                    Character random = list1[randomIndex];
                    random.KillByDemon(charRef);
                    random.statuses.AddStatus(ECharacterStatus.MessedUpByEvil, charRef);
                }
            }
        }
        public override CharacterData GetBluffIfAble(Character charRef)
        {
            
                // 100% Double Claim
                return Characters.Instance.GetDuplicateBluffWithoutType(ECharacterType.Outcast);
            
        }
        public Jester() : base(ClassInjector.DerivedConstructorPointer<Jester>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public Jester(System.IntPtr ptr) : base(ptr)
        {
        }
        public override CharacterData GetRegisterAsRole(Character charRef)
        {
            //Taken from the Wretches code. Used to make the current Flutist still register as evil!
            Il2CppSystem.Collections.Generic.List<CharacterData> allChars = Gameplay.Instance.GetScriptCharacters();
            allChars = Characters.Instance.FilterCharacterAlignment(allChars, EAlignment.Evil);
            CharacterData randomMinion = allChars[UnityEngine.Random.Range(0, allChars.Count)];

            return randomMinion;
        }
    }
    }
