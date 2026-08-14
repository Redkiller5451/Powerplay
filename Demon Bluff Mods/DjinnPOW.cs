using Demon_Bluff_Mods;
using Il2Cpp;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
namespace Demon_Bluff_Mods
{
    //Taken From riddler
    public class DjinnPOW
    {
        public static void Jinx(string demon)
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
            CharacterData covenite = new();
            foreach (CharacterData d in allDatas)
            {
                if (d.characterId == "Covenite_POW")
                {
                    covenite = d; break;
                }
            }
            CharacterData pilgrim = new();
            foreach (CharacterData d in allDatas)
            {
                if (d.characterId == "Pilgrim_POW")
                {
                    pilgrim = d; break;
                }
            }
            CharacterData outlier = new();
            foreach (CharacterData d in allDatas)
            {
                if (d.characterId == "Outlier_POW")
                {
                    outlier = d; break;
                }
            }
            List<string> invalid = GetInvalidCharacterIDs(demon);
            foreach (Character c in Gameplay.CurrentCharacters)
            {
                if (invalid.Contains(c.dataRef.characterId))
                {
                    if(c.GetCharacterType()== ECharacterType.Villager)
                         c.Init(pilgrim);
                    if (c.GetCharacterType() == ECharacterType.Outcast)
                        c.Init(outlier);
                    if (c.GetCharacterType() == ECharacterType.Minion)
                        c.Init(covenite);
                }
            }
        }
        public static void JinxVillagers(string demon)
        {
            List<string> invalid = GetInvalidCharacterIDs(demon);
            foreach (Character c in Gameplay.CurrentCharacters)
            {
                if (invalid.Contains(c.dataRef.characterId))
                {
                    // this only works because GetRandomUniqueVillagerBluff is no longer limited to 4 random characters
                    CharacterData newRole = Characters.Instance.GetRandomUniqueVillagerBluff();
                    while (invalid.Contains(newRole.characterId)) { newRole = Characters.Instance.GetRandomUniqueVillagerBluff(); }
                    c.Init(newRole);
                }
            }
        }
        public static List<string> GetInvalidCharacterIDs(string demon)
        {
            List<string> invalidMinions = new List<string>();
            switch (demon)
            {
                case "War":
                    invalidMinions.Add("Doppleganger_52694042");
                    invalidMinions.Add("WING_Dupery_Copycat");
                    break;
                case "Archmage":
                    invalidMinions.Add("Swarm_Good_WING");
                    break;
                case "Hex Master":
                    invalidMinions.Add("Swarm_Good_WING");
                    break;
                case "Godfather":
                    invalidMinions.Add("Swarm_Good_WING");
                    break;
                case "Mafioso":
                    invalidMinions.Add("Swarm_Good_WING");
                    break;
            }
            return invalidMinions;
        }
        public static List<string> GetCharactersThatCannotDie()
        {
            List<string> chars = new();
            chars.Add("Squire_scm");
            chars.Add("Undying_WING");
            chars.Add("Vizier_LRZH");
            chars.Add("WING_Dupery_Scoundrel");

            return chars;
        }
    }
}
