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
            MelonLogger.Msg("Getting the Datas");
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
            MelonLogger.Msg("Transfering the Datas");
            bool checkForPowerplay = false;
            bool checkForWing = false;
            bool checkForRiddler = false;
            bool checkForTST = false;
            bool checkForCircus = false;
            for (int j = 0; j < allDatas.Length; j++)
            {
                if(allDatas[j] != null)
                    if (allDatas[j].characterId != null)
                        trueAllDatas.Add(allDatas[j]);
                
            }
            MelonLogger.Msg("Checking for other mods");
            foreach (CharacterData data in trueAllDatas)
            {
                if (data == null)
                {
                    MelonLogger.Warning("GetAllData: Found null CharacterData!");
                    continue;
                }

                if (data.characterId == null)
                {
                    MelonLogger.Warning("GetAllData: CharacterData has null characterId!");
                    continue;
                }
                if (data.characterId.EndsWith("_POW") && !checkForPowerplay)
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
                if (data.characterId.EndsWith("_LRZH") && !checkForCircus)
                {
                    checkForCircus = true;
                    MelonLogger.Msg("Circus is accounted for");
                }
                if (data.characterId.EndsWith("_TST") && !checkForTST)
                {
                    checkForTST = true;
                    MelonLogger.Msg("The Salem Trials is accounted for");
                }
            }
            
            return trueAllDatas;
        }
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Start)
            {
            int nOfCharacters = 15;
            int nOfDemons = UnityEngine.Random.Range(1, 4);
            int nOfMinions = UnityEngine.Random.Range(0, 6);
            int nOfOutcasts = UnityEngine.Random.Range(0, 6);
            int nOfVillagers = nOfCharacters-nOfMinions-nOfOutcasts-nOfDemons;
                Il2CppSystem.Collections.Generic.List<CharacterData> allDatas = GetAllData();
                Il2CppSystem.Collections.Generic.List<CharacterData> possibleMinions = new Il2CppSystem.Collections.Generic.List<CharacterData>();
                Il2CppSystem.Collections.Generic.List<CharacterData> possibleOutcasts = new Il2CppSystem.Collections.Generic.List<CharacterData>();
                Il2CppSystem.Collections.Generic.List<CharacterData> possibleVillagers = new Il2CppSystem.Collections.Generic.List<CharacterData>();
                Il2CppSystem.Collections.Generic.List<CharacterData> possibleDemons = new Il2CppSystem.Collections.Generic.List<CharacterData>();
                MelonLogger.Msg("Data Indexes");
                Il2CppSystem.Collections.Generic.List<string> blacklistMinionIDs = new();
                blacklistMinionIDs.Add("Werewolf_78350415"); // Werewolf is never in the Deck to begin with. 
                blacklistMinionIDs.Add("Bounty Hunter_39284184"); // Unused Content
                blacklistMinionIDs.Add("Delusion_10561407"); // Unused Content
                blacklistMinionIDs.Add("Mutant_84675843"); // Unused Content
                blacklistMinionIDs.Add("Saint_61372493"); // Unused Content
                blacklistMinionIDs.Add("Villager_80343266"); // Unused Content
                blacklistMinionIDs.Add("Villager_94437181"); // Unused Content
                blacklistMinionIDs.Add("Wretch_Evil_91222191"); // That's the wrong Wretch.
                blacklistMinionIDs.Add("WING_Dupery_Fall Guy MinionRegister"); // Should never appear ever
                blacklistMinionIDs.Add("Trickster_m_scm"); // Just in case.
                blacklistMinionIDs.Add("Trickster_m_register_scm"); // Just in case.
                blacklistMinionIDs.Add("Marionette_11628408"); // That's the wrong Marionette.
                blacklistMinionIDs.Add("Trickster_o_scm"); // Should never be added
                blacklistMinionIDs.Add("Repossessed_POW"); // Only Auditor adds this
                blacklistMinionIDs.Add("GoodTwin_POW"); // Only Evil Twin adds this
                blacklistMinionIDs.Add("Juror_POW"); // Only Court adds this
                blacklistMinionIDs.Add("Acolyte_WING"); // Only Praesect adds this
                blacklistMinionIDs.Add("Zealot_WING"); // Only Praesect adds this
                blacklistMinionIDs.Add("Fanatic_WING"); // Only Undying adds this
                blacklistMinionIDs.Add("Puppet_15989619"); //Only Puppeteer adds this
                foreach (CharacterData d in allDatas)
            {
                    if ((d.type == ECharacterType.Demon) && !(blacklistMinionIDs.Contains(d.characterId)))
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
                if (d.type == ECharacterType.Villager && !(blacklistMinionIDs.Contains(d.characterId)))
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
                count++;
                do
                {
                    MelonLogger.Msg("Demon Indexes");
                    int randomIndex = UnityEngine.Random.Range(0, list1.Count);
                    Character random = list1[randomIndex];
                    CharacterData minion = possibleDemons[UnityEngine.Random.Range(0, possibleDemons.Count)];
                    random.Init(minion);
                    possibleDemons.Remove(minion);
                    list1.Remove(random);
                    count++;

                } while (count < nOfDemons);
                count = 0;
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
                    MelonLogger.Msg($"{nOfVillagers-count} villager spots remaining");

                } while (count < list1.Count);
                 
            }
            }
                


    }
   }

