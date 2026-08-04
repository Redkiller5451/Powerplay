using HarmonyLib;
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

namespace Demon_Bluff_Mods
{
    [RegisterTypeInIl2Cpp]
    public class MafiaMember : Minion
    {
        public MafiaMember(IntPtr pointer)
        : base(pointer)
        {
        }
        public override string Description
    => "";

        public override ActedInfo GetInfo(Character charRef)
        {
            return new ActedInfo("");
        }
        public override ActedInfo GetBluffInfo(Character charRef)
        {
            return new ActedInfo("");
        }
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            return;
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
    }
    public static class MafiaType
    {
        public static ECharacterType Leader = (ECharacterType)155;
        public static ECharacterType Member = (ECharacterType)160;
    }
    public static class MafiaAlignement
    {
        public static EAlignment Mafia = (EAlignment)155;

    }

    //Neutral Coloring
    //boomdandy.artBgColor = new Color(0.3679f, 0.2014f, 0.1541f);
    // boomdandy.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
    // boomdandy.cardBorderColor = new Color(0.7843f, 0.6471f, 0f);
    // boomdandy.color = new Color(0.8510f, 0.4549f, 0.0f);

}
