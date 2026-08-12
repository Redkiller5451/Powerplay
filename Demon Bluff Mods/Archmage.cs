using Il2Cpp;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem;
using MelonLoader;
using System;
using System.ComponentModel.Design;
using UnityEngine;
namespace Demon_Bluff_Mods
{
    [RegisterTypeInIl2Cpp]
    public class Archmage : CovenPreacher
    {
        public Archmage() : base(ClassInjector.DerivedConstructorPointer<Archmage>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public Archmage(System.IntPtr ptr) : base(ptr)
        {

        }
        CharacterData pickedCharacterPrevData;
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Start)
            {
                SwapToCult();
                CharacterData dataOfGrunt = null;
                Il2CppSystem.Collections.Generic.List<Character> viableCharacters = Gameplay.CurrentCharacters;
                CharacterData[] allDatas = Il2CppSystem.Array.Empty<CharacterData>();
                var loadedCharList = Resources.FindObjectsOfTypeAll(Il2CppType.Of<CharacterData>());
                if (loadedCharList != null)
                {
                    allDatas = new CharacterData[loadedCharList.Length];
                    for (int j = 0; j < loadedCharList.Length; j++)
                    {
                        allDatas[j] = loadedCharList[j]!.Cast<CharacterData>();
                    }
                }
                for (int j = 0; j < allDatas.Length; j++)
                {
                    if (allDatas[j].characterId == "CultMember_POW")
                    {

                        dataOfGrunt = allDatas[j];

                    }
                }

                if (dataOfGrunt != null)
                {


                    viableCharacters = Characters.Instance.FilterAliveCharacters(viableCharacters);
                    viableCharacters = Characters.Instance.FilterRealCharacterType(viableCharacters, ECharacterType.Villager);
                    MelonLogger.Msg("Second Archmage Check");
                    Character pickedCharacter = viableCharacters[UnityEngine.Random.Range(0, viableCharacters.Count)];
                    pickedCharacterPrevData = pickedCharacter.dataRef;
                    pickedCharacter.Init(dataOfGrunt);
                    viableCharacters.Remove(pickedCharacter);

                } 
                GiveTheBook(charRef);
                SitNextToOutsider(charRef);
            }
        }
        private void SitNextToOutsider(Character charRef)
        {
            Il2CppSystem.Collections.Generic.List<Character> outsiders = Gameplay.CurrentCharacters;
            outsiders = Characters.Instance.FilterCharacterType(outsiders, ECharacterType.Minion);

            Character pickedOutsider = outsiders[UnityEngine.Random.Range(0, outsiders.Count)];
            pickedOutsider.statuses.AddStatus(ECharacterStatus.MessedUpByEvil, charRef);

            Il2CppSystem.Collections.Generic.List<Character> adjacentCharacters = Characters.Instance.GetAdjacentAliveCharacters(pickedOutsider);
            Character pickedSwapCharacter = adjacentCharacters[UnityEngine.Random.Range(0, adjacentCharacters.Count)];
            CharacterData pickedData = pickedSwapCharacter.dataRef;
            pickedSwapCharacter.Init(charRef.dataRef);
            charRef.Init(pickedData);
            pickedSwapCharacter.DisableStartAbility();
        }
    }
}
