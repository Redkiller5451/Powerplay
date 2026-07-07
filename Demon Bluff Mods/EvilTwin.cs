using Il2Cpp;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem;
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
    public class EvilTwin : Minion
    {
        public EvilTwin() : base(ClassInjector.DerivedConstructorPointer<EvilTwin>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public EvilTwin(System.IntPtr ptr) : base(ptr)
        {

        }
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Start)
            {
                
                Gameplay gameplay = Gameplay.Instance;
                Characters instance = Characters.Instance;
                Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                list1 = Characters.Instance.FilterCharacterType(list1, ECharacterType.Villager);
                Character random = list1[UnityEngine.Random.Range(0, list1.Count)];
                MelonLogger.Msg($"Turned #{random.id} into the Good Twin");
                //Code taken from Wingidon
                CharacterData[] allDatas = Il2CppSystem.Array.Empty<CharacterData>();
                var loadedCharList = Resources.FindObjectsOfTypeAll(Il2CppType.Of<CharacterData>());
                if (loadedCharList != null)
                {
                    allDatas = new CharacterData[loadedCharList.Length];
                    for (int j = 0; j < loadedCharList.Length; j++)
                    {
                        allDatas[j] = loadedCharList[j]!.Cast<CharacterData>();
                        random.statuses.AddStatus(ECharacterStatus.AlteredCharacter, charRef);
                        random.statuses.AddStatus(ECharacterStatus.MessedUpByEvil, charRef);
                    }
                }
                for (int j = 0; j < allDatas.Length; j++)
                {
                    if (allDatas[j].characterId == "GoodTwin_POW")
                    {
                        if (random.GetRegisterAs().characterId != allDatas[j].characterId)
                        {
                            random.Init(allDatas[j]);
                        }
                    }
                }
              
                random.statuses.AddStatus(ECharacterStatus.AppearTruthfull, random);
                random.statuses.AddStatus(ECharacterStatus.HealthyBluff, random);
            }
        }
        public override CharacterData GetBluffIfAble(Character charRef)
        {
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
            int charDataId = 0;
            for (int j = 0; j < allDatas.Length; j++)
            {
                if (allDatas[j].characterId == "GoodTwin_POW")
                {
                    charDataId = j;
                    break;
                }
            }
            return allDatas[charDataId];
        }
    }
}
