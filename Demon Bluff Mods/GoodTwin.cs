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
    public class GoodTwin : Minion
    {
        public GoodTwin() : base(ClassInjector.DerivedConstructorPointer<GoodTwin>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public GoodTwin(System.IntPtr ptr) : base(ptr)
        {

        }
        public override ActedInfo GetInfo(Character charRef)
        {
            Gameplay gameplay = Gameplay.Instance;
            Characters instance = Characters.Instance;
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            Character target = new Character();
            foreach (Character character in list1)
            {
                if(character.role is EvilTwin)
                {
                    target = (Character)character;
                    break;
                }
            }

            return new ActedInfo($"#{target.id} is the Evil Twin!");
        }
        public override ActedInfo GetBluffInfo(Character charRef)
        {
            Gameplay gameplay = Gameplay.Instance;
            Characters instance = Characters.Instance;
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            Character target = new Character();
            foreach (Character character in list1)
            {
                if (character.role is GoodTwin)
                {
                    target = (Character)character;
                    break;
                }
            }

            return new ActedInfo($"#{target.id} is the Evil Twin!");
        }
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Day)
            {
                onActed?.Invoke(GetInfo(charRef));
            }
        }
        public override void BluffAct(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Day)
            {
                onActed?.Invoke(GetBluffInfo(charRef));
            }
        }
        public override CharacterData GetBluffIfAble(Character charRef)
        {
            charRef.statuses.AddStatus(ECharacterStatus.AppearTruthfull, charRef);
            charRef.statuses.AddStatus(ECharacterStatus.HealthyBluff, charRef);
            return null;
        }
    }
}
