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
        Character chRef;

        public override string Description
            => "Pick a character. If its Evil I die.";
        public Vigilante() : base(ClassInjector.DerivedConstructorPointer<Vigilante>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
            action1 = new System.Action(CharacterPicked);
            action2 = new System.Action(StopPick);
            action3 = new System.Action(CharacterPickedDrunk);
        }
        public Vigilante(System.IntPtr ptr) : base(ptr)
        {
            action1 = new System.Action(CharacterPicked);
            action2 = new System.Action(StopPick);
            action3 = new System.Action(CharacterPickedDrunk);
        }
        public override ActedInfo GetInfo(Character charRef)
        {
            return new ActedInfo("");
        }
        public override ActedInfo GetBluffInfo(Character charRef)
        {
            return new ActedInfo("");
        }
        private Il2CppSystem.Action action1;
        private Il2CppSystem.Action action2;
        private Il2CppSystem.Action action3;
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger != ETriggerPhase.Day) return;
            chRef = charRef;
            CharacterPicker.Instance.StartPickCharacters(1, charRef);
            CharacterPicker.OnCharactersPicked += action1;
            CharacterPicker.OnStopPick += action2;
        }
        private void CharacterPicked()
        {
            CharacterPicker.OnCharactersPicked -= action1;
            CharacterPicker.OnStopPick -= action2;

            Il2CppSystem.Collections.Generic.List<Character> chars = new Il2CppSystem.Collections.Generic.List<Character>();
            chars.Add(CharacterPicker.PickedCharacters[0]);

            string info = $"I shot #{chars[0].id}";
            if (chars[0].GetRegisterAlignment() == EAlignment.Good)
            {
                info += "\nAnd they were Good...";
            }
            else
            {
                info += "\nAnd they were Evil!";
            }
                bool shouldExecute = true;

            if (chars[0].state == ECharacterState.Dead)
            {
                shouldExecute = false;
                return;
            }

            onActed?.Invoke(new ActedInfo(info, chars));

            if (shouldExecute)
                chars[0].KillAndReveal();
        }

        public override void BluffAct(ETriggerPhase trigger, Character charRef)
        {
            if (trigger != ETriggerPhase.Day) return;
            chRef = charRef;
            CharacterPicker.Instance.StartPickCharacters(1, charRef);
            if (charRef.statuses.Contains(ECharacterStatus.WorkingAbility))
                CharacterPicker.OnCharactersPicked += action1;
            else
                CharacterPicker.OnCharactersPicked += action3;
            CharacterPicker.OnStopPick += action2;
        }
        private void StopPick()
        {
            CharacterPicker.OnCharactersPicked -= action3;
            CharacterPicker.OnCharactersPicked -= action1;
            CharacterPicker.OnStopPick -= action2;
        }

        private void CharacterPickedDrunk()
        {
            CharacterPicker.OnCharactersPicked -= action3;
            CharacterPicker.OnStopPick -= action2;

            Il2CppSystem.Collections.Generic.List<Character> chars = new Il2CppSystem.Collections.Generic.List<Character>();
            chars.Add(CharacterPicker.PickedCharacters[0]);

            string info = $"My bullet is defective! \n I couldn't shoot #{chars[0].id}";
            onActed?.Invoke(new ActedInfo(info, chars));
        }
    }
}
