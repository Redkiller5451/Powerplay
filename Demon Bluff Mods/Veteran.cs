using Il2Cpp;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Demon_Bluff_Mods;
[RegisterTypeInIl2Cpp]
public class Veteran : Role
{
    private static Character lastPicker = null;
    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Start)
        {
            charRef.statuses.AddStatus(ECharacterStatus.HealthyBluff, charRef);
        }
        if (trigger == ETriggerPhase.OnPicked)
        {
            if (charRef.state == ECharacterState.Dead) return;
            if (lastPicker != null)
            {
                if (lastPicker.GetRegisterAlignment() == EAlignment.Good)
                {
                    if (charRef.statuses.statuses.Contains(ECharacterStatus.Corrupted) || charRef.GetRegisterAlignment() == EAlignment.Evil)
                        return;
                    lastPicker.Kill();
                    charRef.RevealReal();
                    onActed?.Invoke(new ActedInfo($"I killed the {lastPicker.name}", null));
                }
            }
        }
    }
    public override CharacterData GetBluffIfAble(Character charRef)
    {
        int diceRoll = Calculator.RollDice(10);

        if (diceRoll < 5)
        {
            // 100% Double Claim
            return Characters.Instance.GetRandomDuplicateBluff();
        }
        else
        {
            // Become a new character
            CharacterData bluff = Characters.Instance.GetRandomUniqueBluff();
            Gameplay.Instance.AddScriptCharacterIfAble(bluff.type, bluff);

            return bluff;
        }
    }
    public static void SetLastPicker(Character picker)
    {
        lastPicker = picker;
    }
    public Veteran() : base(ClassInjector.DerivedConstructorPointer<Veteran>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Veteran(System.IntPtr ptr) : base(ptr)
    {
    }
}