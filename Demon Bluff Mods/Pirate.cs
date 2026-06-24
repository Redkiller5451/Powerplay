using HarmonyLib;
using Il2Cpp;
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
using static UnityEngine.GraphicsBuffer;

namespace Demon_Bluff_Mods;
[RegisterTypeInIl2Cpp]
public class Pirate : Neutrals
{

    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Start)
        {
            if (trigger == ETriggerPhase.Start)
            {
                changeAlignement(charRef);
            }
            Gameplay gameplay = Gameplay.Instance;
            Characters instance = Characters.Instance;
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            list1 = Characters.Instance.FilterAlignmentCharacters(list1, EAlignment.Good);
            list1.Remove(charRef);
            if (list1.Count > 0)
            {
                int randomIndex = UnityEngine.Random.Range(0, list1.Count);
                Character random = list1[randomIndex];
                random.statuses.AddStatus(Dueled.dueled, random);
                random.statuses.AddStatus(ECharacterStatus.Silenced, random);
                if (random.dataRef.picking)
                {
                    random.pickable.SetActive(false);
                }
            }
        }
        if (trigger == ETriggerPhase.OnExecuted)
        {
            Gameplay gameplay = Gameplay.Instance;
            Characters instance = Characters.Instance;
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            list1 = Characters.Instance.FilterCharacterContainsStatus(list1, Dueled.dueled);
            if (list1.Count > 0)
            {
                list1[0].statuses.RemoveStatusIfAble(Dueled.dueled);
                list1[0].statuses.RemoveStatusIfAble(ECharacterStatus.Silenced);
                if (list1[0].dataRef.picking)
                {
                    list1[0].pickable.SetActive(true);
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
    public Pirate() : base(ClassInjector.DerivedConstructorPointer<Pirate>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Pirate(System.IntPtr ptr) : base(ptr)
    {
    }

    //Thank you to Caldo for the PoKill status
    public static class Dueled
    {
        public static ECharacterStatus dueled = (ECharacterStatus)195;
        [HarmonyPatch(typeof(Character), nameof(Character.ShowDescription))]
        public static class ChangeKillByDemonText
        {
            public static void Postfix(Character __instance)
            {
                if (__instance.statuses.Contains(dueled))
                {
                    HintInfo info = new HintInfo();
                    info.text = "I am being dueled by a <color=#F7ED88>Pirate</color>\nCannot use abilities.";
                    UIEvents.OnShowHint.Invoke(info, __instance.hintPivot);
                }
            }
        }
    }
}
