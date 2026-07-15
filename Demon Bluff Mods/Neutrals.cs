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
    public class Neutrals : Role
    {
        public Neutrals(IntPtr pointer)
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
        public static void changeAlignement(Character __instance)
        {
            MelonLogger.Msg($"#{__instance.id} is swapping alignements");
                int randoChance = UnityEngine.Random.Range(0, 99);
                if (randoChance > 49)
                {
                    __instance.ChangeAlignment(EAlignment.Evil);
                }
                else
                {
                    __instance.ChangeAlignment(EAlignment.Good);
                }
            }
    }
    public static class NeutralType
    {
        public static ECharacterType Neutral = (ECharacterType)40;
        [HarmonyPatch(typeof(Character), nameof(Character.ShowDescription))]
        public static void Postfix(Character __instance)
        {
            if (__instance.GetCharacterType() == Neutral)
            {
                HintInfo info = new HintInfo();
                info.text = "I am a <color=#64AAFA>Neutral</color>\nI can be good or bad";
            }
        }
    }
    public static class NeutralAlignement
    {
        public static EAlignment Neutral = (EAlignment)30;
        [HarmonyPatch(typeof(Character), nameof(Character.ShowDescription))]
        public static void Postfix(Character __instance)
        {
            if (__instance.alignment == Neutral)
            {
                HintInfo info = new HintInfo();
                info.text = "I am a <color=#64AAFA>Neutral</color>\nI can be good or bad";
            }
        }
       
    }

    //Neutral Coloring
    //boomdandy.artBgColor = new Color(0.3679f, 0.2014f, 0.1541f);
    // boomdandy.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
    // boomdandy.cardBorderColor = new Color(0.7843f, 0.6471f, 0f);
    // boomdandy.color = new Color(0.8510f, 0.4549f, 0.0f);

}
