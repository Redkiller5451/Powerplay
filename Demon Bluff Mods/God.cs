using HarmonyLib;
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
            int randoNight = UnityEngine.Random.Range(0, 4) + 2;
            sr.Add(new NightModeRule(randoNight));
            return sr;
        }
        public Il2CppSystem.Collections.Generic.List<CharacterData> GetAllData()
        {
            CharacterData[] allDatas = Il2CppSystem.Array.Empty<CharacterData>();
            Il2CppSystem.Collections.Generic.List<CharacterData> trueAllDatas = new();
            var loadedCharList = Resources.FindObjectsOfTypeAll(Il2CppType.Of<CharacterData>());
            if (loadedCharList != null)
            {
                allDatas = new CharacterData[loadedCharList.Length];
                for (int j = 0; j < loadedCharList.Length; j++)
                {
                    allDatas[j] = loadedCharList[j]!.Cast<CharacterData>();
                }
            }
            bool checkForPowerplay = false;
            bool checkForWing = false;
            bool checkForRiddler = false;
            for (int j = 0; j < allDatas.Length; j++)
            {
                trueAllDatas.Add(allDatas[j]);
                
            }
           foreach(CharacterData data in trueAllDatas)
            {
                if(data.characterId.EndsWith("_POW") && !checkForPowerplay)
                {
                    checkForPowerplay = true;
                    MelonLogger.Msg("Powerplay is accounted for");
                }
                if (data.characterId.EndsWith("_scm") && !checkForRiddler)
                {
                    checkForRiddler = true;
                    MelonLogger.Msg("Riddler is accounted for");
                }
                if (data.characterId.EndsWith("_WING") && !checkForWing)
                {
                    checkForWing = true;
                    MelonLogger.Msg("Wingidon is accounted for");
                }
            }
            
            return trueAllDatas;
        }
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Start)
            {
            int nOfCharacters = 15;
            int nOfMinions = UnityEngine.Random.Range(0, 6);
            int nOfOutcasts = UnityEngine.Random.Range(0, 6);
            int nOfVillagers = nOfCharacters-nOfMinions-nOfOutcasts-1;
                Il2CppSystem.Collections.Generic.List<CharacterData> allDatas = GetAllData();
                Il2CppSystem.Collections.Generic.List<CharacterData> possibleMinions = new Il2CppSystem.Collections.Generic.List<CharacterData>();
                Il2CppSystem.Collections.Generic.List<CharacterData> possibleOutcasts = new Il2CppSystem.Collections.Generic.List<CharacterData>();
                Il2CppSystem.Collections.Generic.List<CharacterData> possibleVillagers = new Il2CppSystem.Collections.Generic.List<CharacterData>();
                Il2CppSystem.Collections.Generic.List<CharacterData> possibleDemons = new Il2CppSystem.Collections.Generic.List<CharacterData>();
                MelonLogger.Msg("Data Indexes");
                Il2CppSystem.Collections.Generic.List<string> blacklistMinionIDs = new();
                blacklistMinionIDs.Add("Werewolf_78350415"); // Werewolf is never in the Deck to begin with. 
                blacklistMinionIDs.Add("Wretch_Evil_91222191"); // That's the wrong Wretch.
                blacklistMinionIDs.Add("WING_Dupery_Fall Guy MinionRegister"); // Should never appear ever
                blacklistMinionIDs.Add("Trickster_m_scm"); // Just in case.
                blacklistMinionIDs.Add("Trickster_m_register_scm"); // Just in case.
                blacklistMinionIDs.Add("Marionette_11628408"); // That's the wrong Marionette.
                blacklistMinionIDs.Add("Trickster_o_scm"); // Should never be added
                foreach (CharacterData d in allDatas)
            {
                    if ((d.type == ECharacterType.Demon) && (d.role is not Mutant || d.role is not Delusion || d.role is not God))
                    {
                        possibleDemons.Add(d);
                    }
                    if ((d.type == ECharacterType.Minion || d.type == WeatherType.Weather) && !(blacklistMinionIDs.Contains(d.characterId)))
                {
                    possibleMinions.Add(d);
                }
                if ((d.type == ECharacterType.Outcast || d.type == NeutralType.Neutral) && !(blacklistMinionIDs.Contains(d.characterId)))
                {
                    possibleOutcasts.Add(d);
                }
                if (d.type == ECharacterType.Villager && (d.role is not UselessVillager && d.role is not SaintVillager && d.role is not BountyHunter))
                {
                    possibleVillagers.Add(d);
                }
                   
            }
                MelonLogger.Msg($"size of villagers: {possibleVillagers.Count}");
                MelonLogger.Msg($"size of outcasts: {possibleOutcasts.Count}");
                MelonLogger.Msg($"size of minions: {possibleMinions.Count}");
                MelonLogger.Msg($"size of demons: {possibleDemons.Count}");

                int count = 0;
                Il2CppSystem.Collections.Generic.List<Character> currentChars = (Gameplay.CurrentCharacters);
                Il2CppSystem.Collections.Generic.List<Character> list1 = new();
                foreach (Character c in currentChars)
                {
                    list1.Add(c);
                }
                MelonLogger.Msg("Demon Indexes");
                charRef.Init(possibleDemons[UnityEngine.Random.Range(0, possibleDemons.Count)]);
                list1.Remove(charRef);
            do
            {
                    MelonLogger.Msg("Minions Indexes");
                int randomIndex = UnityEngine.Random.Range(0, list1.Count);
                Character random = list1[randomIndex];
                CharacterData minion = possibleMinions[UnityEngine.Random.Range(0, possibleMinions.Count)];
                random.Init(minion);
                possibleMinions.Remove(minion);
                list1.Remove(random);
                    count++;

            } while (count < nOfMinions);
            count = 0;
            do
            {
                    MelonLogger.Msg("Outcasts Indexes");
                    int randomIndex = UnityEngine.Random.Range(0, list1.Count);
                Character random = list1[randomIndex];
                CharacterData minion = possibleOutcasts[UnityEngine.Random.Range(0, possibleOutcasts.Count)];
                random.Init(minion);
                possibleOutcasts.Remove(minion);
                list1.Remove(random);
                    count++;

                } while (count < nOfOutcasts);
            count = 0;
            do
            {
                    MelonLogger.Msg($"{count < nOfVillagers}");
                    MelonLogger.Msg("Villager Indexes");
                    int randomIndex = UnityEngine.Random.Range(0, list1.Count);
                Character random = list1[randomIndex];
                    MelonLogger.Msg("Possible Villager Indexes");
                    CharacterData minion = possibleVillagers[UnityEngine.Random.Range(0, possibleVillagers.Count)];
                random.Init(minion);
                possibleVillagers.Remove(minion);
                    MelonLogger.Msg($"{possibleVillagers.Count} villagers remaining");
                    list1.Remove(random);
                    count++;

                } while (count < nOfVillagers);
                
                foreach (Character c in currentChars)
                {
                    list1.Add(c);
                }
                list1 = Characters.Instance.FilterAlignmentCharacters(list1, EAlignment.Good);
                MelonLogger.Msg("Effects Indexes");
                foreach (Character character in list1)
                {
                    int randomIndex = UnityEngine.Random.Range(0, 4);
                    if (randomIndex < 3)
                    {
                        int randomEffect = UnityEngine.Random.Range(0, 5);
                        if (randomEffect == 0)
                        {
                            character.statuses.statuses.Add(ECharacterStatus.Corrupted);
                        }
                        if (randomEffect == 1)
                        {
                            character.statuses.statuses.Add(Mad.mad2);
                        }
                        if (randomEffect == 2)
                        {
                            character.statuses.statuses.Add(ECharacterStatus.Silenced);
                        }
                        if (randomEffect == 3)
                        {
                            character.statuses.statuses.Add(UO.UnknownObstacle);
                        }
                        if (randomEffect == 4)
                        {
                            character.statuses.statuses.Add(Rbed.roleblocked);
                        }
                        character.statuses.AddStatus(ECharacterStatus.MessedUpByEvil, charRef);
                    }
                }
            }
            }
                


    }
   }

