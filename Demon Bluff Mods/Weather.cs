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
using static MelonLoader.MelonLogger;

namespace Demon_Bluff_Mods

{

    public enum EWeatherPhase
    {
        Clear = 0,
        HarshSun = 10,
        HeavyRain = 20,
        Fog = 30,
    }
    [RegisterTypeInIl2Cpp]
    public class Weather : Minion
    {
        public Weather(IntPtr pointer)
        : base(pointer)
        {
        }
        public Weather() : base(ClassInjector.DerivedConstructorPointer<Weather>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public override string Description
    => "";

        public override ActedInfo GetInfo(Character charRef)
        {
            return new ActedInfo("");
        }
        public override ActedInfo GetBluffInfo(Character charRef)
        {
            return new ActedInfo("");
        }
        public override void Act(ETriggerPhase trigger, Character charRef)
        {

            return;
        }

        public static void becomeOtherMinion(Character charRef)
        {
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
            //Copied from riddles
            Il2CppSystem.Collections.Generic.List<string> blacklistMinionIDs = new();
            blacklistMinionIDs.Add("Puppet_15989619"); // Puppet is never in the Deck to begin with.
            blacklistMinionIDs.Add("Swarm_Good_WING"); // Swarm adding its counterpart to the Deck makes it far too obvious
            blacklistMinionIDs.Add("Swarm_Evil_WING"); // Swarm adding its counterpart to the Deck makes it far too obvious.
            blacklistMinionIDs.Add("Trickster_m_scm"); // Just in case.
            blacklistMinionIDs.Add("Trickster_m_register_scm"); // Just in case.
            blacklistMinionIDs.Add("Undying_WING"); // Undying is face-up. Don't add him as a fake Minion.
            blacklistMinionIDs.Add("EvilTwin_POW"); // Not copying Evil Twin its dumb
            blacklistMinionIDs.Add("GoodTwin_POW"); // Not copying Good Twin its dumb
            blacklistMinionIDs.Add("Marionette_11628408"); // That's the wrong Marionette.
            blacklistMinionIDs.Add("Werewolf_78350415"); // Werewolf is never in the Deck to begin with.
            blacklistMinionIDs.Add("Wretch_Evil_91222191"); // That's the wrong Wretch.
            for (int j = 0; j < allDatas.Length; j++)
            {
                CharacterData d = allDatas[j];
                if (d.type == ECharacterType.Minion && !blacklistMinionIDs.Contains(d.characterId))
                {
                    possibleMinions.Add(d);
                }
            }
            CharacterData chosenMinion = possibleMinions[UnityEngine.Random.Range(0, possibleMinions.Count)];
            Role temp = charRef.dataRef.role;
            charRef.Init(chosenMinion);
            Gameplay.Instance.AddScriptCharacter(ECharacterType.Minion, chosenMinion);
            if (temp is Foggy)
            {
                DeckView.AddToObscuredDeckView(chosenMinion);
            }
        }
    }
    public static class WeatherType
    {
        public static ECharacterType Weather = (ECharacterType)50;

    }
    public static class WeatherAlignement
    {
        public static EAlignment Weather = (EAlignment)40;

    }
    [RegisterTypeInIl2Cpp]
    public class Clear : Weather
    {
        public Clear(IntPtr pointer)
        : base(pointer)
        {
        }
        public Clear() : base(ClassInjector.DerivedConstructorPointer<Clear>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public override string Description
    => "";

        public override ActedInfo GetInfo(Character charRef)
        {
            return new ActedInfo("");
        }
        public override ActedInfo GetBluffInfo(Character charRef)
        {
            return new ActedInfo("");
        }
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Start)
            {
                becomeOtherMinion(charRef);
            }
        }
    }
    [RegisterTypeInIl2Cpp]
    public class Sunny : Weather
    {
        public Sunny(IntPtr pointer)
        : base(pointer)
        {
        }
        public Sunny() : base(ClassInjector.DerivedConstructorPointer<Sunny>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public override string Description
    => "";

        public override ActedInfo GetInfo(Character charRef)
        {
            return new ActedInfo("");
        }
        public override ActedInfo GetBluffInfo(Character charRef)
        {
            return new ActedInfo("");
        }
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Start)
            {
                Gameplay gameplay = Gameplay.Instance;
                Characters instance = Characters.Instance;
                Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                Il2CppSystem.Collections.Generic.List<Character> list2 = Characters.Instance.FilterRealCharacterType(list1, ECharacterType.Villager);
                int chanceOfCorruption = 0;
                foreach (Character character in list2)
                {
                    if (UnityEngine.Random.Range(0, 4) <= chanceOfCorruption)
                    {
                        character.statuses.statuses.Add(ECharacterStatus.Corrupted);
                        chanceOfCorruption = 0;
                    }
                    else
                    {
                        chanceOfCorruption++;
                    }
                }
                becomeOtherMinion(charRef);
            }
        }
    }

    [RegisterTypeInIl2Cpp]
    public class Stormy : Weather
    {
        public Stormy(IntPtr pointer)
        : base(pointer)
        {
        }
        public Stormy() : base(ClassInjector.DerivedConstructorPointer<Stormy>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public override string Description
    => "";

        public override ActedInfo GetInfo(Character charRef)
        {
            return new ActedInfo("");
        }
        public override ActedInfo GetBluffInfo(Character charRef)
        {
            return new ActedInfo("");
        }
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Start)

            {
                Gameplay gameplay = Gameplay.Instance;
                Characters instance = Characters.Instance;
                Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                Il2CppSystem.Collections.Generic.List<Character> list2 = Characters.Instance.FilterRealCharacterType(list1, ECharacterType.Villager);
                Il2CppSystem.Collections.Generic.List<Character> list3 = Characters.Instance.FilterRealCharacterType(list1, ECharacterType.Outcast);
                do
                {
                    BecomeOtherOutcast(list2[UnityEngine.Random.Range(0, list2.Count)]);
                    list2 = Characters.Instance.FilterRealCharacterType(list1, ECharacterType.Villager);
                    list3 = Characters.Instance.FilterRealCharacterType(list1, ECharacterType.Outcast);
                } while (list2.Count > list3.Count);
                becomeOtherMinion(charRef);
            }
        }
        public static void BecomeOtherOutcast(Character charRef)
        {
            CharacterData[] allDatas = Il2CppSystem.Array.Empty<CharacterData>();
            Il2CppSystem.Collections.Generic.List<CharacterData> possibleOucast = new Il2CppSystem.Collections.Generic.List<CharacterData>();
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
            Il2CppSystem.Collections.Generic.List<Character> list3 = Characters.Instance.FilterRealCharacterType((Gameplay.CurrentCharacters), ECharacterType.Outcast);
            for (int j = 0; j < allDatas.Length; j++)
            {
                CharacterData d = allDatas[j];
                if (d.type == ECharacterType.Outcast && !IfContains(list3, d))
                {
                    possibleOucast.Add(d);
                }
            }
            charRef.Init(possibleOucast[UnityEngine.Random.Range(0, possibleOucast.Count)]);
        }
        private static bool IfContains(Il2CppSystem.Collections.Generic.List<Character> list3, CharacterData d)
        {
            foreach (Character c in list3)
            {
                if (c.dataRef.role == d.role)
                    return true;
            }
            return false;
        }

    }

    [RegisterTypeInIl2Cpp]
    public class Foggy : Weather
    {
        public Foggy(IntPtr pointer)
        : base(pointer)
        {
        }
        public Foggy() : base(ClassInjector.DerivedConstructorPointer<Foggy>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public override string Description
    => "";

        public override ActedInfo GetInfo(Character charRef)
        {
            return new ActedInfo("");
        }
        public override ActedInfo GetBluffInfo(Character charRef)
        {
            return new ActedInfo("");
        }
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.AfterRoundStart)
            {
                Il2CppSystem.Collections.Generic.List<CharacterData> deckview = new Il2CppSystem.Collections.Generic.List<CharacterData>();
                deckview = Gameplay.Instance.GetScriptCharacters();
                Il2CppSystem.Collections.Generic.List<CharacterData> deckview2 = new Il2CppSystem.Collections.Generic.List<CharacterData>();
                deckview2 = Gameplay.Instance.GetNotInPlayCharacters();
                foreach (CharacterData cd in deckview2)
                {
                    if (!deckview.Contains(cd))
                    {
                        deckview.Add(cd);
                    }
                }
                foreach (CharacterData cd in deckview)
                {
                    DeckView.AddToObscuredDeckView(cd);
                }
                becomeOtherMinion(charRef);
            }
        }
    }
    [RegisterTypeInIl2Cpp]
    public class Windy : Weather
    {
        public Windy(IntPtr pointer)
        : base(pointer)
        {
        }
        public Windy() : base(ClassInjector.DerivedConstructorPointer<Windy>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public override string Description
    => "";

        public override ActedInfo GetInfo(Character charRef)
        {
            return new ActedInfo("");
        }
        public override ActedInfo GetBluffInfo(Character charRef)
        {
            return new ActedInfo("");
        }
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Start)
            {

            }
        }
    }
    [RegisterTypeInIl2Cpp]
    public class Snowy : Weather
    {
        public Snowy(IntPtr pointer)
        : base(pointer)
        {
        }
        public Snowy() : base(ClassInjector.DerivedConstructorPointer<Snowy>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public override string Description
    => "";

        public override ActedInfo GetInfo(Character charRef)
        {
            return new ActedInfo("");
        }
        public override ActedInfo GetBluffInfo(Character charRef)
        {
            return new ActedInfo("");
        }
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Start)
            {

                Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                int nOfSnowedIn = 0;
                do
                {
                    TurnIntoSnowedIn(list1[UnityEngine.Random.Range(0, list1.Count)]);
                    list1 = Characters.Instance.FilterRealCharacterType(list1, ECharacterType.Villager);
                    nOfSnowedIn++;
                } while (4 > nOfSnowedIn);
                
            }
            becomeOtherMinion(charRef);
        }
        
    
        public void TurnIntoSnowedIn(Character charRef)
        {
            CharacterData[] allDatas = Il2CppSystem.Array.Empty<CharacterData>();
            Il2CppSystem.Collections.Generic.List<CharacterData> possibleOucast = new Il2CppSystem.Collections.Generic.List<CharacterData>();
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
            Il2CppSystem.Collections.Generic.List<Character> list3 = Characters.Instance.FilterRealCharacterType((Gameplay.CurrentCharacters), ECharacterType.Outcast);
            for (int j = 0; j < allDatas.Length; j++)
            {
                CharacterData d = allDatas[j];
                if (d.characterId == "SnowedIn_POW")
                {
                    possibleOucast.Add(d);
                }
            }
            charRef.Init(possibleOucast[UnityEngine.Random.Range(0, possibleOucast.Count)]);
        }
    }
    public static class SnowedIn
    {
        public static ECharacterStatus snowedIn = (ECharacterStatus)250;
        [HarmonyPatch(typeof(SnowedInChar), nameof(SnowedInChar.Act))]
        public static class isSnowedIn
        {
            public static bool Prefix(SnowedInChar snowed,ETriggerPhase trigger, Character charRef)
            {
                if (trigger == ETriggerPhase.Day)
                {
                    snowed.onActed.Invoke(snowed.GetInfo(charRef));
                }
                return false;
            }
        }
    }
}
