using Il2Cpp;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using UnityEngine;
using static Il2CppSystem.Runtime.Remoting.RemotingServices;
using static InfoViewPatch;
using static MelonLoader.MelonLogger;

namespace Demon_Bluff_Mods
{
    [RegisterTypeInIl2Cpp]
    public class Jinx : Role
    {
        Character alteredChar;
        bool lagPrevention = false;
        public Jinx() : base(ClassInjector.DerivedConstructorPointer<Jinx>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public Jinx(System.IntPtr ptr) : base(ptr)
        {

        }
        public override void BluffAct(ETriggerPhase trigger, Character charRef)
        {
            return;
        }
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Day && charRef.state != ECharacterState.Dead)
            {
                Gameplay gameplay = Gameplay.Instance;
                Characters instance = Characters.Instance;
                Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                list1 = Characters.Instance.FilterUnrevealedCharacters(list1);
                list1 = Characters.Instance.FilterAlignmentCharacters(list1, EAlignment.Evil);
                list1.Remove(charRef);
                int randomIndex = UnityEngine.Random.Range(0, list1.Count);
                Character changed = list1[randomIndex];
                MelonLogger.Msg($"Jinx targetted #{list1[randomIndex].id}, the {list1[randomIndex].dataRef.name}");
                changed.statuses.AddStatus(Obscured.Obscure, charRef);
                alteredChar = changed;
                testMethod(alteredChar);
                alteredChar.statuses.AddStatus(Obscured.Obscure, charRef);
                alteredChar.statuses.AddStatus(ECharacterStatus.MessedUpByEvil, charRef);
            }
        }
        public static void testMethod(Character __instance)
        {

            CharacterData resetData;
            SharedMethods shared = new SharedMethods();

            if (__instance.bluff != null)
            {
                resetData = __instance.bluff;
            }
            else
            {
                resetData = __instance.dataRef;
            }
            CharacterData masterCd = shared.GetCharDataViaID("WING_Dupery_VillagerSpectre");

            if (masterCd == null)
            {
                MelonLogger.Error("Failed to fetch VillagerSpectre_POW data reference!");
                return;
            }

            // CRITICAL FIX: Clone the object via Unity's Instantiate so you don't corrupt the global game data pool
            CharacterData cd = masterCd.MemberwiseClone().Cast<CharacterData>();

            // Copy over the roles and states cleanly to the runtime clone
            cd.role = resetData.role;
            if (resetData.picking)
            {
                cd.picking = true;
            }

            // Mutate the clone's text properties securely
            cd.name = obscureWords(resetData.name);
            cd.startingAlignment = resetData.startingAlignment;
            cd.type = resetData.type;
            cd.characterName = obscureWords(resetData.name);
            // Re-initialize the active entity with your safe runtime clone data
            if (__instance.bluff != null)
            {
                __instance.GiveBluff(cd);
                __instance.RevealBluff();
                __instance.RefreshCharacter();
            }
            else
            {
                __instance.Init(cd);
            }

        }
        public static string obscureWords(string desc)
        {
            char[] allChars = desc.ToCharArray();
            List<string> words = new List<string>();
            foreach (char c in allChars)
            {
                words.Add(c.ToString());
            }
            List<string> nums = numbers();
            for (int i = 0; i < words.Count; i++)
            {
                if (!nums.Contains(words[i]))
                {
                    words[i] = "-";
                }
            }
            string newString = "";
            foreach (string word in words)
            {
                newString += word;
            }
            return newString;
        }
        public static List<string> numbers()
        {
            List<string> nums = new List<string>();
            nums.Add("0");
            nums.Add("1");
            nums.Add("2");
            nums.Add("3");
            nums.Add("4");
            nums.Add("5");
            nums.Add("6");
            nums.Add("7");
            nums.Add("8");
            nums.Add("9");
            nums.Add(":");
            nums.Add(" ");
            nums.Add(",");
            nums.Add(".");
            nums.Add("!");
            nums.Add("?");
            nums.Add("#");
            nums.Add("\n");
            nums.Add("\t");
            return nums;
        }
        public override CharacterData GetBluffIfAble(Character charRef)
        {
            int diceRoll = Calculator.RollDice(10);

            if (diceRoll < 5)
            {
     
                charRef.statuses.statuses.Add(ECharacterStatus.HealthyBluff);
                
                // 100% Double Claim
                return Characters.Instance.GetRandomDuplicateBluff();
            }
            else
            {
                 charRef.statuses.statuses.Add(ECharacterStatus.HealthyBluff);
                
                // Become a new character
                CharacterData bluff = Characters.Instance.GetRandomUniqueBluff();
                Gameplay.Instance.AddScriptCharacterIfAble(bluff.type, bluff);

                return bluff;
            }
        }
    }

}