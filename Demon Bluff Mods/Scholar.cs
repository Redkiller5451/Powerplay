using Il2Cpp;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSoftMasking.Samples;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using Il2CppSystem.Runtime.Serialization.Formatters.Binary;
using MelonLoader;
using System;
using UnityEngine;
using static Il2Cpp.Interop;
using static Il2CppRewired.Demos.CustomPlatform.MyPlatformControllerExtension;
using static MelonLoader.MelonLaunchOptions;
using static MelonLoader.Modules.MelonModule;

namespace Demon_Bluff_Mods;
[RegisterTypeInIl2Cpp]
public class Scholar : Role
{
    public Scholar() : base(ClassInjector.DerivedConstructorPointer<Scholar>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Scholar(System.IntPtr ptr) : base(ptr)
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
        ActedInfo actedInfo = new ActedInfo(RandoAdvice(charRef), null);
        return actedInfo;
    }
    public override ActedInfo GetBluffInfo(Character charRef)
    {
        ActedInfo actedInfo = new ActedInfo(RandoAdviceBluff(charRef), null);
        return actedInfo;
    }
    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Day)
        {
            if (charRef.statuses.Contains(ECharacterStatus.Corrupted))
            {
                this.onActed.Invoke(this.GetBluffInfo(charRef));
            }
            else { 
                this.onActed?.Invoke(this.GetInfo(charRef));
            }
                
        }
    }
    public override void BluffAct(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Day)
        {
            this.onActed.Invoke(this.GetBluffInfo(charRef));

        }
    }
    public override CharacterData? GetBluffIfAble(Character charRef)
    {
        return null;
    }

    // These are the checks for scholar

    private string RandoAdvice(Character charRef)
    {
        Il2CppSystem.Collections.Generic.List<string> allLines = GatherTheInfo();
        Il2CppSystem.Collections.Generic.List<string> goodinfo = new();
        if (VillagersOrOutcasts())
        {
            goodinfo.Add(allLines[1]);
        }
        else
        {
            goodinfo.Add(allLines[2]);
        }
        if (IsPunishingEvil())
        {
            goodinfo.Add(allLines[3]);
        }
        if (AreEvilsNeighbors())
        {
            goodinfo.Add(allLines[4]);
        }
        if (RealOnPickVsFakeOnPick())
        {
            goodinfo.Add(allLines[5]);
        }
        if (TrustworthyNeighbors(charRef))
        {
            goodinfo.Add(allLines[6]);
        }
        if (RegisteringTruthful())
        {
            goodinfo.Add(allLines[7]);
        }
        if (IsDistortingEvil())
        {
            goodinfo.Add(allLines[8]);
        }
        if (IsMendaverte())
        {
            goodinfo.Add(allLines[9]);
        }
        if (IsGoodDoubleClaim())
        {
            goodinfo.Add(allLines[10]);
        }
        if (TooMuchCorruptionWithoutMendaverte() && !IsMendaverte())
        {
            goodinfo.Add(allLines[11]);
        }
        if (goodinfo.Count == 0)
        {
            return allLines[0];
        }
       
        return goodinfo[UnityEngine.Random.Range(0, goodinfo.Count)];
    }
    private Il2CppSystem.Collections.Generic.List<string> GatherTheInfo()
    {
        Il2CppSystem.Collections.Generic.List<string> info = new();
        info.Add("You should believe the Scholar!");
        info.Add("Your inner blues will guide you!");
        info.Add("A yellow happiness should proffer you!");
        info.Add("Patience is the greatest virtue!");
        info.Add("They are gathering in packs!");
        info.Add("The best job is the one done by yourself!");
        info.Add("Friends of mine are tight to me!");
        info.Add("Do not trust trust!");
        info.Add("The wicked's numbers are not as they seem!");
        info.Add("The Demon has distorted the town!");
        info.Add("The pairs should be trustworthy!");
        info.Add("Villagers who mean good are harmful today!");
        return info;
    }
    private string RandoAdviceBluff(Character charRef)
    {
        Il2CppSystem.Collections.Generic.List<string> allLines = GatherTheInfo();
        Il2CppSystem.Collections.Generic.List<string> goodinfo = new();
        if (!VillagersOrOutcasts())
        {
            goodinfo.Add(allLines[1]);
        }
        else
        {
            goodinfo.Add(allLines[2]);
        }
        if (!IsPunishingEvil())
        {
            goodinfo.Add(allLines[3]);
        }
        if (!AreEvilsNeighbors())
        {
            goodinfo.Add(allLines[4]);
        }
        if (!RealOnPickVsFakeOnPick())
        {
            goodinfo.Add(allLines[5]);
        }
        if (!TrustworthyNeighbors(charRef))
        {
            goodinfo.Add(allLines[6]);
        }
        if (!RegisteringTruthful())
        {
            goodinfo.Add(allLines[7]);
        }
        if (!IsDistortingEvil())
        {
            goodinfo.Add(allLines[8]);
        }
        if (!IsMendaverte())
        {
            goodinfo.Add(allLines[9]);
        }
        if (!IsGoodDoubleClaim())
        {
            goodinfo.Add(allLines[10]);
        }
        if (!TooMuchCorruptionWithoutMendaverte() && !IsMendaverte())
        {
            goodinfo.Add(allLines[11]);
        }
        if (goodinfo.Count == 0)
        {
            return allLines[0];
        }

        return goodinfo[UnityEngine.Random.Range(0, goodinfo.Count)];
    }
    private bool VillagersOrOutcasts()
    {
        Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
        list1 = Characters.Instance.FilterRealAlignmentCharacters(list1, EAlignment.Evil);
        int fakeOutcasts = 0;
        int fakeVillagers = 0;
        foreach (Character character in list1)
        {
            if(character.bluff != null)
            {
            if(character.bluff.type == ECharacterType.Outcast)
            {
                fakeOutcasts++;
            }
            else if (character.bluff.type == ECharacterType.Villager)
            {
                fakeVillagers++;
            }
            }
            
        }
        return fakeOutcasts+3 > fakeVillagers;
    }
    private bool IsGoodDoubleClaim()
    {
        Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
        Il2CppSystem.Collections.Generic.List<Character> list2 = Characters.Instance.FilterRealAlignmentCharacters(list1, EAlignment.Evil);
        Il2CppSystem.Collections.Generic.List<Character> list3 = Characters.Instance.FilterRealAlignmentCharacters(list1, EAlignment.Good);
        int evilDoubleClaim = 0;
        int goodDoubleClaim = 0;
        foreach (Character character in list2)
        {
            if (character.bluff != null)
            {
                if (SkippingLagObviousNotDouble(character))
                {
                    if (SkippingLagObviousDouble(character))
                    {
                        evilDoubleClaim++;
                    }
                    else
                    {
                        foreach (Character character2 in list3)
                        {
                            if (character.bluff.characterId == character2.dataRef.characterId)
                            {
                                evilDoubleClaim++;
                            }
                        }
                    }

                }

            }
        }
        foreach (Character character in list3)
        {
            foreach (Character character2 in list3)
            {
                if (character.bluff != null)
                {
                    if (SkippingLagObviousNotDouble(character))
                    {
                         if (SkippingLagObviousDouble(character))
                         {
                            goodDoubleClaim++;
                         }
                         else
                         {
                            if (character.bluff.characterId == character2.dataRef.characterId)
                            {
                                goodDoubleClaim++;
                            }
                         }
                    }

                }
                else
                {
                    if (character.dataRef.characterId == character2.dataRef.characterId)
                    {
                        goodDoubleClaim++;
                    }
                }

            }
        }
        return goodDoubleClaim > evilDoubleClaim && goodDoubleClaim!= 0;
    }
    private bool SkippingLagObviousNotDouble(Character character)
    {
        return character.dataRef.characterId != "Drunk_15369527" && character.GetCharacterType() != ECharacterType.Demon;
    }
    private bool SkippingLagObviousDouble(Character character)
    {
        return character.dataRef.characterId =="Doppleganger_52694042" || character.dataRef.characterId =="EvilTwin_POW";
    }
    private bool IsPunishingEvil()
    {
        Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
        list1 = Characters.Instance.FilterRealAlignmentCharacters(list1, EAlignment.Evil);
        foreach(Character character in list1)
        {
            if(MatchesPunishingEvil(character))
                return true;
        }
        return false;
    }
    private bool MatchesPunishingEvil(Character chara)
    {
        return chara.dataRef.characterId =="Grenadier_POW" || chara.dataRef.characterId =="Balancer_POW" || chara.dataRef.characterId =="EvilTwin_POW"
             || chara.dataRef.characterId =="Undying_WING" || chara.dataRef.characterId =="Agmeres_WING" || chara.dataRef.characterId =="Praesect_WING"
             || chara.dataRef.characterId =="Leviathan_WING";
    }
    private bool IsDistortingEvil()
    {
        Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
        list1 = Characters.Instance.FilterRealAlignmentCharacters(list1, EAlignment.Evil);
        foreach (Character character in list1)
        {
            if (MatchesDistortingEvil(character))
                return true;
        }
        return false;
    }
    private bool MatchesDistortingEvil(Character chara)
    {
        return chara.dataRef.characterId =="Imp_58992273" || chara.dataRef.characterId =="Mezepheles_09511163"
            || chara.dataRef.characterId =="Heretic_WING" || chara.dataRef.characterId =="Magnere_WING" || chara.dataRef.characterId =="Kingmaker_scm"; 
    }
    private bool IsMendaverte()
    {
        Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
        list1 = Characters.Instance.FilterRealAlignmentCharacters(list1, EAlignment.Evil);
        foreach (Character character in list1)
        {
            if (character.dataRef.characterId =="Mendaverte_WING")
                return true;
        }
        return false;
    }
    private bool AreEvilsNeighbors()
    {
        return GetPairCount() > 0;
    }
    private bool TooMuchCorruptionWithoutMendaverte()
    {
        Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
        int amountOfCorruption = 0;
        int halfOfTown = list1.Count / 2;
        foreach (Character character in list1)
        {
            if (character.statuses.statuses.Contains(ECharacterStatus.Corrupted))
            {
                amountOfCorruption++;
            }
        }
        return amountOfCorruption > halfOfTown;
    }
    private int GetPairCount()
    {
        Il2CppSystem.Collections.Generic.List<Character> myList = Gameplay.CurrentCharacters;
        myList.Add(Gameplay.CurrentCharacters[0]);

        int pairCount = 0;
        bool evilPrev = false;
        foreach (Character ch in myList)
        {
            if (ch.GetRegisterAlignment() == EAlignment.Evil)
            {
                if (evilPrev)
                    pairCount++;
                evilPrev = true;
            }
            else
                evilPrev = false;
        }

        return pairCount;
    }
    private bool RealOnPickVsFakeOnPick()
    {
        Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
        Il2CppSystem.Collections.Generic.List<Character> list2 = Characters.Instance.FilterRealAlignmentCharacters(list1, EAlignment.Evil);
        Il2CppSystem.Collections.Generic.List<Character> list3 = Characters.Instance.FilterRealAlignmentCharacters(list1, EAlignment.Good);
        int fakeOnPick = 0;
        int realOnPick = 0;
        foreach (Character character in list2)
        {
                if (character.bluff != null)
                {
                if (character.bluff.picking)
                {
                    fakeOnPick++;
                }
            }
        }
        foreach (Character character in list3)
            if (character.bluff != null)
            {
                {
                    if (character.bluff.picking)
                    {
                        realOnPick++;
                    }
                }
        }
        return realOnPick > fakeOnPick;
    }
    private bool TrustworthyNeighbors(Character charRef)
    {
        Il2CppSystem.Collections.Generic.List<Character> myList = GetNeighbors(charRef);
        foreach (Character character in myList)
        {
            if (CharacterHelper.CheckLyingAppearance(character))
            {
                return false;
            }
        }
        return true;
    }
    private Il2CppSystem.Collections.Generic.List<Character> GetNeighbors(Character charRef)
    {
        Il2CppSystem.Collections.Generic.List<Character> myList = CharactersHelper.GetSortedListWithCharacterFirst(Gameplay.CurrentCharacters, charRef);
        myList.RemoveAt(0);
        Il2CppSystem.Collections.Generic.List<Character> neighbors = new Il2CppSystem.Collections.Generic.List<Character>();
        neighbors.Add(myList[0]);
        neighbors.Add(myList[myList.Count - 1]);
        return neighbors;
    }
    private bool RegisteringTruthful()
    {
        Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
        foreach (Character character in list1)
        {
            if((!CharacterHelper.CheckLyingAppearance(character) && character.alignment == EAlignment.Evil) || character.dataRef.characterId == "Turncoat_WING")
            {
                return true;
            }
        }
        return false;
    }
}
