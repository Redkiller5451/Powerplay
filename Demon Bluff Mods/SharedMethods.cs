using Il2Cpp;
using Il2CppInterop.Runtime;
using Il2CppSystem.Runtime.Remoting.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Demon_Bluff_Mods
{
    public class SharedMethods
    {
        public CharacterData GetCharDataViaID(string id)
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
            for (int j = 0; j < allDatas.Length; j++)
            {
                if (allDatas[j].characterId == id)
                {
                    return allDatas[j];
                }
            }
            return null;
        }
        public CharacterData GetBluffDemonIfAble(Character charRef)
        {
            CharacterData bluff = Characters.Instance.GetRandomUniqueVillagerBluff();
            Gameplay.Instance.AddScriptCharacterIfAble(bluff.type, bluff);

            return bluff;
        }
        public CharacterData GetBluffMinionIfAble(Character charRef)
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
        public Il2CppSystem.Collections.Generic.List<bool> IsAModInstalled()
        {
            //Code taken from Riddles. Developper code originally
            Il2CppSystem.Collections.Generic.List<bool> installedMods = new();
            // current list of mods: Riddles, Wingidon's Expansion Pack, Dupery Bluff
            // Requirements: Latest update after June 15th, 2026 & At least 1 modded character
            Il2CppSystem.Collections.Generic.List<CharacterData> characters = Gameplay.Instance.GetAllAscensionCharacters();
            bool riddles = false;
            bool wingidon = false;
            foreach (CharacterData character in characters)
            {
                {

                    if (character.characterId.EndsWith("_scm")) riddles = true;
                    else if (character.characterId.EndsWith("_WING")) wingidon = true;

                    if (riddles && wingidon)
                    {
                        break;
                    }
                }

            }
            installedMods.Add(wingidon);
            installedMods.Add(riddles);
            return installedMods;
        }
        public bool isNotStatus(ECharacterStatus status)
        {
            Il2CppSystem.Collections.Generic.List<ECharacterStatus> invalidStatuses = new Il2CppSystem.Collections.Generic.List<ECharacterStatus>();

                invalidStatuses.Add((ECharacterStatus)901) ; invalidStatuses.Add((ECharacterStatus)902) ;
                invalidStatuses.Add((ECharacterStatus)903) ; invalidStatuses.Add((ECharacterStatus)904) ;
                invalidStatuses.Add((ECharacterStatus)918918) ; invalidStatuses.Add((ECharacterStatus)82113114) ;
                invalidStatuses.Add((ECharacterStatus)1618119) ; invalidStatuses.Add((ECharacterStatus)2051879715) ;
                invalidStatuses.Add((ECharacterStatus)2051879522) ; invalidStatuses.Add((ECharacterStatus)2114495619) ;
                invalidStatuses.Add((ECharacterStatus)2114495161) ; invalidStatuses.Add((ECharacterStatus)2114495239) ;
                invalidStatuses.Add((ECharacterStatus)1201) ; invalidStatuses.Add((ECharacterStatus)1202) ;
                invalidStatuses.Add((ECharacterStatus)1203) ; invalidStatuses.Add((ECharacterStatus)1204) ;
                invalidStatuses.Add((ECharacterStatus)874) ; invalidStatuses.Add((ECharacterStatus)876) ;
                invalidStatuses.Add((ECharacterStatus)879) ; invalidStatuses.Add((ECharacterStatus)882) ;
                invalidStatuses.Add((ECharacterStatus)197) ; invalidStatuses.Add((ECharacterStatus)3001);
            invalidStatuses.Add((ECharacterStatus)318251620) ; invalidStatuses.Add(SailorPing.sailorPing) ;
                invalidStatuses.Add((ECharacterStatus.HealthyBluff)) ; invalidStatuses.Add((ECharacterStatus.AppearDisguised)) ;
                invalidStatuses.Add((ECharacterStatus.AppearHonest)) ; invalidStatuses.Add((ECharacterStatus.AppearLying)) ;
                invalidStatuses.Add((ECharacterStatus.AppearTruthfull)) ; invalidStatuses.Add((ECharacterStatus.BrokenAbility)) ;
                invalidStatuses.Add((ECharacterStatus.HealthyBluff)) ; invalidStatuses.Add((ECharacterStatus.UnkillableByDemon)) ;
                invalidStatuses.Add((ECharacterStatus.WorkingAbility)) ; invalidStatuses.Add((ECharacterStatus.NoDamage)) ;
                invalidStatuses.Add((ECharacterStatus.Lying)) ; invalidStatuses.Add((MadVictim.madVictim));
            invalidStatuses.Add(Audited.audited); invalidStatuses.Add(Sacrifice.sacrifice);
            invalidStatuses.Add(HangTarget.hangtarget); invalidStatuses.Add(StarspawnCheck.starspawnCheck);
            invalidStatuses.Add(Dueled.dueled); invalidStatuses.Add(NecroWielder.Necronomicon); 
            return invalidStatuses.Contains(status) ;
        }
    }
}
