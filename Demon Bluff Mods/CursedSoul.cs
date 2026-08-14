using Il2Cpp;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem;
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
public class CursedSoul : Neutrals
{
    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Start)
        {
            changeAlignement(charRef);

            Character random = GetEligibleChars(charRef);
            if (random == null)
            {
                onActed?.Invoke(new ActedInfo($"I couldn't pretend to be anyone..."));
                return;
            }
            if (charRef.alignment == EAlignment.Good)
            {
                charRef.GiveBluff(random.dataRef);
                charRef.statuses.AddStatus(ECharacterStatus.HealthyBluff, charRef);
                charRef.statuses.AddStatus(ECharacterStatus.WorkingAbility, charRef);
                random.statuses.AddStatus(ECharacterStatus.Corrupted,charRef);

            }
            if (charRef.alignment == EAlignment.Evil)
            {
                charRef.GiveBluff(random.dataRef);
            }

        }
    }
    private Character GetEligibleChars(Character charRef)
    {
        Il2CppSystem.Collections.Generic.List<Character> InPlay = Gameplay.CurrentCharacters;
        InPlay = Characters.Instance.FilterRealCharacterType(InPlay, ECharacterType.Villager);
        return InPlay[UnityEngine.Random.Range(0, InPlay.Count)];

    }
    public override void BluffAct(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Day || trigger == ETriggerPhase.OnReveal)
        {
            MelonLogger.Msg($"Flutist said their piece incorrectly...");
            charRef.role.onActed.Invoke(new ActedInfo($"I have been charmed by the Flutist!"));
        }
    }
    public CursedSoul() : base(ClassInjector.DerivedConstructorPointer<CursedSoul>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public CursedSoul(System.IntPtr ptr) : base(ptr)
    {
    }
}
