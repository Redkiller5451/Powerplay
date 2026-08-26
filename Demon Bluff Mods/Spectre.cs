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
using static Il2CppSystem.Runtime.Remoting.RemotingServices;
using static InfoViewPatch;
using static MelonLoader.MelonLogger;

namespace Demon_Bluff_Mods
{
    [RegisterTypeInIl2Cpp]
    public class Spectre : Minion
    {
        Character alteredChar;
        bool lagPrevention = false;
        public Spectre() : base(ClassInjector.DerivedConstructorPointer<Spectre>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public Spectre(System.IntPtr ptr) : base(ptr)
        {

        }
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Start)
            {

                Gameplay gameplay = Gameplay.Instance;
                Characters instance = Characters.Instance;
                Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                list1 = Characters.Instance.FilterOutCharacterType(list1, ECharacterType.Outcast);
                list1 = Characters.Instance.FilterOutCharacterType(list1, NeutralType.Neutral);
                list1 = Characters.Instance.FilterOutCharacterType(list1, WeatherType.Weather);
                list1 = Characters.Instance.FilterOutRole(list1, "Flutist_POW");
                int randomIndex = UnityEngine.Random.Range(0, list1.Count); 
                Character changed = list1[randomIndex];
                MelonLogger.Msg($"Specter targetted #{list1[randomIndex].id}, the {list1[randomIndex].dataRef.name}");
                changed.statuses.AddStatus(Obscured.Obscure, charRef);
                alteredChar = changed;
                
            }
            if(trigger == ETriggerPhase.AfterRoundStart)
            {
                testMethod();
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
            return nums;
        }
        public void testMethod()
        {
  
                CharacterData resetData;
                SharedMethods shared = new SharedMethods();
                if (alteredChar.alignment == EAlignment.Evil)
                {
                    if (alteredChar.bluff != null)
                    {
                         resetData = alteredChar.bluff;
                    }
                    else
                    {
                        resetData = alteredChar.dataRef;
                    }

                }
                else
                {
                    resetData = alteredChar.dataRef;
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
                // Re-initialize the active entity with your safe runtime clone data
                if (alteredChar.alignment == EAlignment.Evil)
                {
                    alteredChar.GiveBluff(cd);
                    alteredChar.RevealBluff();
                     alteredChar.RefreshCharacter();
            }
                else
                {
                    alteredChar.Init(cd);
                }
           
        }
        public static List<string> FilteredRoles()
        {
            List<string> roles = new List<string>();
            roles.Add("0");
            return roles;
        }
    }
}

