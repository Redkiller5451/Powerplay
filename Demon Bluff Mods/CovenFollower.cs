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
    public class CovenFollower : Minion
    {
        public CovenFollower(IntPtr pointer)
        : base(pointer)
        {
        }
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
        }
        public CovenFollower() : base(ClassInjector.DerivedConstructorPointer<CovenFollower>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public void KillHidden(Character demonRef)
        {
            Il2CppSystem.Collections.Generic.List<Character> possibleCharacters = new Il2CppSystem.Collections.Generic.List<Character>();
            possibleCharacters = Characters.Instance.FilterAliveCharacters(Gameplay.CurrentCharacters);
            possibleCharacters = Characters.Instance.FilterAlignmentCharacters(possibleCharacters, EAlignment.Good);
            possibleCharacters = Characters.Instance.FilterHiddenCharacters(possibleCharacters);
            possibleCharacters = Characters.Instance.FilterCharacterMissingStatus(possibleCharacters, ECharacterStatus.UnkillableByDemon);
            possibleCharacters = Characters.Instance.FilterCharacterMissingStatus(possibleCharacters, Hexed.Hex);
            if (possibleCharacters.Count <= 0) { return; }
            Characters.Instance.GetRandomAliveCharacter(possibleCharacters).KillByDemon(demonRef);
        }
        public void KillRandom(Character demonRef)
        {
            Il2CppSystem.Collections.Generic.List<Character> possibleCharacters = new Il2CppSystem.Collections.Generic.List<Character>();
            possibleCharacters = Characters.Instance.FilterAliveCharacters(Gameplay.CurrentCharacters);
            //possibleCharacters = Characters.Instance.FilterAlignmentCharacters(possibleCharacters, EAlignment.Good);
            possibleCharacters = Characters.Instance.FilterHiddenCharacters(possibleCharacters);
            possibleCharacters = Characters.Instance.FilterCharacterMissingStatus(possibleCharacters, ECharacterStatus.UnkillableByDemon);
            if (possibleCharacters.Count == 0) { return; }
            Characters.Instance.GetRandomAliveCharacter(possibleCharacters).KillByDemon(demonRef);
        }
        public bool IsBookHolder(Character charRef)
        {
            return charRef.statuses.statuses.Contains(NecroWielder.Necronomicon);
        }
        public void hadBook(Character charRef)
        {
                Il2CppSystem.Collections.Generic.List<Character> viableCharacters = Gameplay.CurrentCharacters;
                viableCharacters = Characters.Instance.FilterRealCharacterType(viableCharacters, CovType.Follower);
                foreach (Character character in viableCharacters)
                {
                    character.KillByDemon(charRef);
                }
        }
    }
    public static class CovType
    {
        public static ECharacterType Preacher = (ECharacterType)165;

        public static ECharacterType Follower = (ECharacterType)170;
    }
    public static class CovAlignement
    {
        public static EAlignment Covenant = (EAlignment)160;

    }
    //Neutral Coloring
    //boomdandy.artBgColor = new Color(0.3679f, 0.2014f, 0.1541f);
    // boomdandy.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
    // boomdandy.cardBorderColor = new Color(0.7843f, 0.6471f, 0f);
    // boomdandy.color = new Color(0.8510f, 0.4549f, 0.0f);

}