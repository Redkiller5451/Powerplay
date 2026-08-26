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
    }
}
