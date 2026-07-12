/**using HarmonyLib;
using Il2Cpp;
using Il2CppInterop.Runtime;
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
    public class God : Demon
    {
        public God() : base(ClassInjector.DerivedConstructorPointer<God>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public God(System.IntPtr ptr) : base(ptr)
        {

        }
        public override string Description
        {
            get
            {
                return "This is a cool role!";
            }
        }
        public override ActedInfo GetInfo(Character charRef)
        {
            ActedInfo actedInfo = new ActedInfo("I have declared a Tribunal!", null);
            return actedInfo;
        }
        public override ActedInfo GetBluffInfo(Character charRef)
        {
            ActedInfo actedInfo = new ActedInfo("I am corrupted", null);
            return actedInfo;
        }
        //Code from Wingidon
        public override Il2CppSystem.Collections.Generic.List<SpecialRule> GetRules()
        {
            Il2CppSystem.Collections.Generic.List<SpecialRule> sr = new Il2CppSystem.Collections.Generic.List<SpecialRule>();
            sr.Add(new NightModeRule(4));
            return sr;
        }

        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger != ETriggerPhase.Start) return;
                int nOfCharacters = 11;
            int nOfMinions = UnityEngine.Random.Range(0, 6);
            int nOfOutcasts = UnityEngine.Random.Range(0, 6);
            int nOfVillagers = nOfCharacters-nOfMinions-nOfOutcasts;
            CharacterData[] allDatas = Il2CppSystem.Array.Empty<CharacterData>();
            Il2CppSystem.Collections.Generic.List<CharacterData> possibleMinions = new Il2CppSystem.Collections.Generic.List<CharacterData>();
            if (allDatas.Length == 0)
            {
                var loadedCharList = Resources.FindObjectsOfTypeAll(Il2CppType.Of<CharacterData>());
                if (loadedCharList != null)
                {
                    allDatas = new CharacterData[loadedCharList.Length];
                    for (int j = 0; j < loadedCharList.Length; j++)
                    {
                        allDatas[j] = loadedCharList[j]!.Cast<CharacterData>();
                    }
                }
            }
            for (int j = 0; j < allDatas.Length; j++)
            {
                CharacterData d = allDatas[j];
                if (d.type == ECharacterType.Minion)
                {
                    possibleMinions.Add(d);
                }
            }
            CharacterData[] allDatas2 = Il2CppSystem.Array.Empty<CharacterData>();
            Il2CppSystem.Collections.Generic.List<CharacterData> possibleOutcasts = new Il2CppSystem.Collections.Generic.List<CharacterData>();
            if (allDatas.Length == 0)
            {
                var loadedCharList = Resources.FindObjectsOfTypeAll(Il2CppType.Of<CharacterData>());
                if (loadedCharList != null)
                {
                    allDatas2 = new CharacterData[loadedCharList.Length];
                    for (int j = 0; j < loadedCharList.Length; j++)
                    {
                        allDatas2[j] = loadedCharList[j]!.Cast<CharacterData>();
                    }
                }
            }
            for (int j = 0; j < allDatas.Length; j++)
            {
                CharacterData d = allDatas[j];
                if (d.type == ECharacterType.Outcast)
                {
                    possibleOutcasts.Add(d);
                }
            }
            CharacterData chosenOutcast = possibleOutcasts[UnityEngine.Random.Range(0, possibleMinions.Count)];;
            CharacterData[] allDatas3 = Il2CppSystem.Array.Empty<CharacterData>();
            Il2CppSystem.Collections.Generic.List<CharacterData> possibleVillagers = new Il2CppSystem.Collections.Generic.List<CharacterData>();
            if (allDatas.Length == 0)
            {
                var loadedCharList = Resources.FindObjectsOfTypeAll(Il2CppType.Of<CharacterData>());
                if (loadedCharList != null)
                {
                    allDatas3 = new CharacterData[loadedCharList.Length];
                    for (int j = 0; j < loadedCharList.Length; j++)
                    {
                        allDatas3[j] = loadedCharList[j]!.Cast<CharacterData>();
                    }
                }
            }
            for (int j = 0; j < allDatas.Length; j++)
            {
                CharacterData d = allDatas[j];
                if (d.type == ECharacterType.Villager)
                {
                    possibleVillagers.Add(d);
                }
            }
            int count = 0;
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            do
            {
                
                int randomIndex = UnityEngine.Random.Range(0, list1.Count);
                Character random = list1[randomIndex];
                CharacterData minion = possibleMinions[UnityEngine.Random.Range(0, possibleMinions.Count)];
                random.Init(minion);
                possibleMinions.Remove(minion);
                list1.Remove(random);

            } while (count < nOfMinions);
            count = 0;
            do
            {
                int randomIndex = UnityEngine.Random.Range(0, list1.Count);
                Character random = list1[randomIndex];
                CharacterData minion = possibleOutcasts[UnityEngine.Random.Range(0, possibleOutcasts.Count)];
                random.Init(minion);
                possibleOutcasts.Remove(minion);
                list1.Remove(random);

            } while (count < nOfOutcasts);
            count = 0;
            do
            {
                int randomIndex = UnityEngine.Random.Range(0, list1.Count);
                Character random = list1[randomIndex];
                CharacterData minion = possibleVillagers[UnityEngine.Random.Range(0, possibleVillagers.Count)];
                random.Init(minion);
                possibleVillagers.Remove(minion);
                list1.Remove(random);

            } while (count < nOfVillagers);

        }


    }
   }*/

