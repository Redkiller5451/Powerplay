using Il2Cpp;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
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
    public class Traveler : Minion
    {
        public Traveler() : base(ClassInjector.DerivedConstructorPointer<Traveler>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public Traveler(System.IntPtr ptr) : base(ptr)
        {

        }
        CharacterData pickedCharacterPrevData;
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger != ETriggerPhase.Start) return;

            Il2CppSystem.Collections.Generic.List<Character> viableCharacters = Gameplay.CurrentCharacters;

            Il2CppSystem.Collections.Generic.List<CharacterData> notInPlayOutsiders = Gameplay.Instance.GetAscensionAllStartingCharacters();
            notInPlayOutsiders = Characters.Instance.FilterNotInDeckCharactersUnique(notInPlayOutsiders);
            notInPlayOutsiders = Characters.Instance.FilterRealCharacterType(notInPlayOutsiders, NeutralType.Neutral);
            if (notInPlayOutsiders.Count == 0)
            {
                notInPlayOutsiders = Gameplay.Instance.GetAllAscensionCharacters();
                notInPlayOutsiders = Characters.Instance.FilterRealCharacterType(notInPlayOutsiders, NeutralType.Neutral);
            }
            CharacterData pickedOutsider = notInPlayOutsiders[UnityEngine.Random.Range(0, notInPlayOutsiders.Count)];

            if (notInPlayOutsiders.Count != 0)
            {
                Gameplay.Instance.AddScriptCharacter(NeutralType.Neutral, pickedOutsider);

                viableCharacters = Characters.Instance.FilterAliveCharacters(viableCharacters);
                viableCharacters = Characters.Instance.FilterRealCharacterType(viableCharacters, ECharacterType.Villager);

                Character pickedCharacter = viableCharacters[UnityEngine.Random.Range(0, viableCharacters.Count)];
                pickedCharacterPrevData = pickedCharacter.dataRef;
                pickedCharacter.Init(pickedOutsider);
                Gameplay.Instance.AddScriptCharacter(ECharacterType.Outcast, pickedOutsider);
                
                viableCharacters.Remove(pickedCharacter);
                notInPlayOutsiders.Remove(pickedOutsider);
                pickedCharacter.statuses.AddStatus(ECharacterStatus.AlteredCharacter, charRef);
                pickedCharacter.statuses.AddStatus(ECharacterStatus.MessedUpByEvil, charRef);
                pickedCharacter.Act(ETriggerPhase.Start);
            }

            SitNextToOutsider(charRef);
        }

        private void SitNextToOutsider(Character charRef)
        {
            Il2CppSystem.Collections.Generic.List<Character> outsiders = Gameplay.CurrentCharacters;
            outsiders = Characters.Instance.FilterCharacterType(outsiders, NeutralType.Neutral);

            Character pickedOutsider = outsiders[UnityEngine.Random.Range(0, outsiders.Count)];
            pickedOutsider.statuses.AddStatus(ECharacterStatus.MessedUpByEvil, charRef);

            Il2CppSystem.Collections.Generic.List<Character> adjacentCharacters = Characters.Instance.GetAdjacentAliveCharacters(pickedOutsider);
            Character pickedSwapCharacter = adjacentCharacters[UnityEngine.Random.Range(0, adjacentCharacters.Count)];
            CharacterData pickedData = pickedSwapCharacter.dataRef;
            pickedSwapCharacter.Init(charRef.dataRef);
            charRef.Init(pickedData);
            pickedSwapCharacter.DisableStartAbility();

        }
        private static CharacterData GetID()
        {
            CharacterData[] allDatas = Il2CppSystem.Array.Empty<CharacterData>();
            Il2CppSystem.Collections.Generic.List<CharacterData> weatherData = new Il2CppSystem.Collections.Generic.List<CharacterData>();
            var loadedCharList = Resources.FindObjectsOfTypeAll(Il2CppType.Of<CharacterData>());
            if (loadedCharList != null)
            {
                allDatas = new CharacterData[loadedCharList.Length];
                for (int j = 0; j < loadedCharList.Length; j++)
                {
                    allDatas[j] = loadedCharList[j]!.Cast<CharacterData>();

                }
            }
            
            int i = 0;
            for (int j = 0; j < allDatas.Length; j++)
            {
                if (allDatas[j].type == NeutralType.Neutral)
                {
                    weatherData.Add(allDatas[j]);
                    i++;
                }
            }
            int randomIndex = UnityEngine.Random.Range(0, weatherData.Count);
            return weatherData[randomIndex];
        }
    }
}