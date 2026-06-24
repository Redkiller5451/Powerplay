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
public class Psychopath : Neutrals
{
    public override Il2CppSystem.Collections.Generic.List<SpecialRule> GetRules()
    {
        Il2CppSystem.Collections.Generic.List<SpecialRule> sr = new Il2CppSystem.Collections.Generic.List<SpecialRule>();
        sr.Add(new NightModeRule(4));
        return sr;
    }

    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Start)
        {
            changeAlignement(charRef);
        }
        if (trigger == ETriggerPhase.Night)
        {
            if (charRef.state == ECharacterState.Dead) return;
            if (charRef.alignment == EAlignment.Evil)
            {
                Gameplay gameplay = Gameplay.Instance;
                Characters instance = Characters.Instance;
                Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                list1 = Characters.Instance.FilterAlignmentCharacters(list1, EAlignment.Good);
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
                int randomIndex = UnityEngine.Random.Range(0, list1.Count);
                Character random = list1[randomIndex];
                random.KillByDemon(charRef);
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
    public Psychopath() : base(ClassInjector.DerivedConstructorPointer<Psychopath>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Psychopath(System.IntPtr ptr) : base(ptr)
    {
    }
}