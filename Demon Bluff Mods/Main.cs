// See https://aka.ms/new-console-template for more information
using Demon_Bluff_Mods;
using HarmonyLib;
using UnityEngine;
using UnityEngine.EventSystems;
using Il2Cpp;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppTMPro;
using MelonLoader;
using MelonLoader.Utils;
using Microsoft.Win32.SafeHandles;
[assembly: MelonInfo(typeof(Demon_Bluff_Mods.Main), "Demon Bluff Mods", "1.9.2", "Redkiller")]
[assembly: MelonGame("UmiArt", "Demon Bluff")]

namespace Demon_Bluff_Mods;

public class Main : MelonMod
{
    public override void OnInitializeMelon()
    {
        
        UniversalUtility.AddEnum<EAlignment>("Neutral", (EAlignment)(150));
        UniversalUtility.AddEnum<ECharacterType>("Neutral", (EAlignment)(150));
        UniversalUtility.AddEnum<EAlignment>("Weather", (EAlignment)(40));
        UniversalUtility.AddEnum<ECharacterType>("Weather", (EAlignment)(50));
        try
        {
            base.HarmonyInstance.PatchAll(typeof(SimpleEnumPatcher));
        }
        catch (HarmonyException ex)
        {
            base.LoggerInstance.BigError(ex.ToString());
        }

        ClassInjector.RegisterTypeInIl2Cpp<Coroner>();
        ClassInjector.RegisterTypeInIl2Cpp<Marksman>();
        ClassInjector.RegisterTypeInIl2Cpp<Prosecutor>();
        ClassInjector.RegisterTypeInIl2Cpp<Sailor>();
        ClassInjector.RegisterTypeInIl2Cpp<Lookout2>();
        ClassInjector.RegisterTypeInIl2Cpp<Mayor>();
        ClassInjector.RegisterTypeInIl2Cpp<Marshal>();
        ClassInjector.RegisterTypeInIl2Cpp<Monarch>();
        ClassInjector.RegisterTypeInIl2Cpp<Pacifist>();
        ClassInjector.RegisterTypeInIl2Cpp<Official>();
        ClassInjector.RegisterTypeInIl2Cpp<Fisherman>();
        ClassInjector.RegisterTypeInIl2Cpp<KnowItAll>();
        ClassInjector.RegisterTypeInIl2Cpp<TeaLady>();
        ClassInjector.RegisterTypeInIl2Cpp<Jailor>();
        ClassInjector.RegisterTypeInIl2Cpp<Guard>();
        ClassInjector.RegisterTypeInIl2Cpp<Juror>();
        ClassInjector.RegisterTypeInIl2Cpp<Washerwoman>();
        ClassInjector.RegisterTypeInIl2Cpp<Newsman>();
        ClassInjector.RegisterTypeInIl2Cpp<ChoirBoy>();
        ClassInjector.RegisterTypeInIl2Cpp<Scholar>();
        ClassInjector.RegisterTypeInIl2Cpp<Vigilante>();
        ClassInjector.RegisterTypeInIl2Cpp<Oracle2>();

        ClassInjector.RegisterTypeInIl2Cpp<Veteran>();
        ClassInjector.RegisterTypeInIl2Cpp<SnakeCharmer>();
        ClassInjector.RegisterTypeInIl2Cpp<SnowedInChar>();
        ClassInjector.RegisterTypeInIl2Cpp<Vanished>();
        ClassInjector.RegisterTypeInIl2Cpp<TavernKeeper>();
        ClassInjector.RegisterTypeInIl2Cpp<Amnesiac>();
        ClassInjector.RegisterTypeInIl2Cpp<Repossessed>();
        ClassInjector.RegisterTypeInIl2Cpp<Goon>();
        ClassInjector.RegisterTypeInIl2Cpp<Industrialist>();

        ClassInjector.RegisterTypeInIl2Cpp<Psychopath>();
        ClassInjector.RegisterTypeInIl2Cpp<Pirate>();
        ClassInjector.RegisterTypeInIl2Cpp<Godfather>();
        ClassInjector.RegisterTypeInIl2Cpp<Hangman>();
        ClassInjector.RegisterTypeInIl2Cpp<Jester>();
        ClassInjector.RegisterTypeInIl2Cpp<Scapegoat>();
        ClassInjector.RegisterTypeInIl2Cpp<Apprentice>();

        ClassInjector.RegisterTypeInIl2Cpp<Boomdandy>();
        ClassInjector.RegisterTypeInIl2Cpp<Ambusher>();
        ClassInjector.RegisterTypeInIl2Cpp<Traveler>();
        ClassInjector.RegisterTypeInIl2Cpp<EvilTwin>();
        ClassInjector.RegisterTypeInIl2Cpp<GoodTwin>();
        ClassInjector.RegisterTypeInIl2Cpp<DevilsAdvocate>();
        ClassInjector.RegisterTypeInIl2Cpp<Butcher>();
        ClassInjector.RegisterTypeInIl2Cpp<Cerenovus>();

        ClassInjector.RegisterTypeInIl2Cpp<Wildling>();
        ClassInjector.RegisterTypeInIl2Cpp<Conjurer>();
        ClassInjector.RegisterTypeInIl2Cpp<VoodooMaster>();
        ClassInjector.RegisterTypeInIl2Cpp<CultMember>();
        ClassInjector.RegisterTypeInIl2Cpp<Poisoner2>();
        ClassInjector.RegisterTypeInIl2Cpp<PotionMaster>();

        ClassInjector.RegisterTypeInIl2Cpp<Gangster>();
        ClassInjector.RegisterTypeInIl2Cpp<Enforcer>();

        ClassInjector.RegisterTypeInIl2Cpp<Death>();
        ClassInjector.RegisterTypeInIl2Cpp<Famine>();
        ClassInjector.RegisterTypeInIl2Cpp<Pestilence>();
        ClassInjector.RegisterTypeInIl2Cpp<War>();
        ClassInjector.RegisterTypeInIl2Cpp<Vortox>();
        ClassInjector.RegisterTypeInIl2Cpp<Court>();
        ClassInjector.RegisterTypeInIl2Cpp<Crazed>();
        ClassInjector.RegisterTypeInIl2Cpp<Starspawn>();
        ClassInjector.RegisterTypeInIl2Cpp<Auditor>();

        ClassInjector.RegisterTypeInIl2Cpp<Stormy>();
        ClassInjector.RegisterTypeInIl2Cpp<Sunny>();
        ClassInjector.RegisterTypeInIl2Cpp<Foggy>();
        ClassInjector.RegisterTypeInIl2Cpp<Snowy>();
    }
    
    public static void MakeTwelve()
    {
        GameObject circle12 = CreateCircle(12);
        GameObject circle13 = CreateCircle(13);
        GameObject circle14 = CreateCircle(14);
        GameObject circle15 = CreateCircle(15);
    }
    public MelonPreferences_Category configCategory = null!;
    public override void OnLateInitializeMelon()
    {
        GameObject content = GameObject.Find("Game/Gameplay/Content");
        NightPhase nightPhase = content.GetComponent<NightPhase>(); 
        configCategory = MelonPreferences.CreateCategory("PowerplaySettings");
        MakeTwelve();

        configCategory.CreateEntry("DebugMode", false, "Debug Mode", "Whether or not debug mode is enabled. Debug Mode outputs logs to the console about some roles and what they're doing.");
        configCategory.CreateEntry("AllowMafia", true, "Allow Mafia", "Whether or not Mafia can spawn");
        configCategory.CreateEntry("AllowCovenant", true, "Allow Covenant", "Whether or not Covenant can spawn");
        configCategory.CreateEntry("SeekMisery", true, "Allow A bad bad idea", "Whether or not you can get the All Any scripts. PLS DONT TURN THIS ON.");
        configCategory.CreateEntry("Godfather_Weight", 2, description: "How likely Godfather will be in-play. Only available if Mafia is turned on.");
        configCategory.CreateEntry("Mafioso_Weight", 2, description: "How likely Mafioso will be in-play. Only available if Mafia is turned on.");
        configCategory.CreateEntry("Archmage_Weight", 2, description: "How likely Archmage will be in-play. Only available if Covenant is turned on.");
        configCategory.CreateEntry("HexMaster_Weight", 2, description: "How likely Hex Master will be in-play. Only available if Covenant is turned on.");
        configCategory.CreateEntry("Death_Weight", 1, description: "How likely Death will be in-play. Any of these roles may be disabled by setting their weight to \"0\".");
        configCategory.CreateEntry("Famine_Weight", 1, description: "How likely Famine will be in-play. Any of these roles may be disabled by setting their weight to \"0\".");
        configCategory.CreateEntry("Pestilence_Weight", 1, description: "How likely Pestilence will be in-play. Any of these roles may be disabled by setting their weight to \"0\".");
        configCategory.CreateEntry("War_Weight", 1, description: "How likely War will be in-play. Any of these roles may be disabled by setting their weight to \"0\".");
        configCategory.CreateEntry("Vortox_Weight", 2, description: "How likely Vortox will be in-play. Any of these roles may be disabled by setting their weight to \"0\".");
        configCategory.CreateEntry("Crazed_Weight", 2, description: "How likely Crazed will be in-play. Any of these roles may be disabled by setting their weight to \"0\".");
        configCategory.CreateEntry("Court_Weight", 3, description: "How likely Court will be in-play. Any of these roles may be disabled by setting their weight to \"0\".");
        configCategory.CreateEntry("Auditor_Weight", 3, description: "How likely Auditor will be in-play. Any of these roles may be disabled by setting their weight to \"0\".");
        configCategory.CreateEntry("Starspawn_Weight", 3, description: "How likely Starspawn will be in-play. Any of these roles may be disabled by setting their weight to \"0\".");
        configCategory.CreateEntry("FallenProphet_Weight", 1, description: "How likely Fallen Prophet will be in-play.");
        configCategory.SetFilePath(Path.Combine(MelonEnvironment.UserDataDirectory, "PowerplayConfig.cfg"));
        configCategory.SaveToFile();

        Il2Cpp.CharacterData pil = new Il2Cpp.CharacterData();
        pil.role = new Pilgrim();
        pil.name = "Pilgrim";
        pil.characterName = "Pilgrim";
        pil.description = "I say \"I am the Pilgrim\".";
        pil.flavorText = "\"Shows up when things go awry. \nDoesn't contribute much though...\"";
        pil.hints = "I am the result of a bad Villager interaction between a POWERPLAY Demon and another mod's villager. \n I can appear naturally.";
        pil.ifLies = "I say \"I am not the Pilgrim\"";
        pil.notes = "";
        pil.picking = false;
        pil.startingAlignment = EAlignment.Good;
        pil.type = ECharacterType.Villager;
        pil.abilityUsage = EAbilityUsage.Once;
        pil.bluffable = true;
        pil.characterId = "Pilgrim_POW";
        pil.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        pil.cardBgColor = new Color(0.26f, 0.1519f, 0.3396f);
        pil.cardBorderColor = new Color(0.7133f, 0.339f, 0.8679f);
        pil.color = new Color(1f, 0.935f, 0.7302f);
        pil.additionalFlavorTexts = new Il2CppStringArray(1);
        pil.additionalFlavorTexts[0] = pil.flavorText;
        pil.gender = EGender.Male;

        Il2Cpp.CharacterData marksman = new Il2Cpp.CharacterData();
        marksman.role = new Marksman();
        marksman.name = "Marksman";
        marksman.characterName = "Marksman";
        marksman.description = "Learn how many Minions are revealed. \nIf there are none, learn it.";
        marksman.flavorText = "\"He has a sharp eye.\n Sees less than the Slayer though...\"";
        marksman.hints = "My sharp eye bypasses misregistration. I always see accurately.";
        marksman.ifLies = "Learn a false amount of revealed Minions";
        marksman.notes = "";
        marksman.picking = false;
        marksman.startingAlignment = EAlignment.Good;
        marksman.type = ECharacterType.Villager;
        marksman.abilityUsage = EAbilityUsage.Once;
        marksman.bluffable = true;
        marksman.characterId = "Marksman_POW";
        marksman.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        marksman.cardBgColor = new Color(0.26f, 0.1519f, 0.3396f);
        marksman.cardBorderColor = new Color(0.7133f, 0.339f, 0.8679f);
        marksman.color = new Color(1f, 0.935f, 0.7302f);
        marksman.additionalFlavorTexts = new Il2CppStringArray(1);
        marksman.additionalFlavorTexts[0] = marksman.flavorText;
        marksman.gender = EGender.Male;

        Il2Cpp.CharacterData vigilante = new Il2Cpp.CharacterData();
        vigilante.role = new Vigilante();
        vigilante.name = "Vigilante";
        vigilante.characterName = "Vigilante";
        vigilante.description = "On Pick:\n I execute. ";
        vigilante.flavorText = "\"This Slayer doesn't have restraint.\nIsn't always effective...\"";
        vigilante.hints = "";
        vigilante.ifLies = "My bullet is defective and I cannot shoot.";
        vigilante.notes = "";
        vigilante.picking = true;
        vigilante.startingAlignment = EAlignment.Good;
        vigilante.type = ECharacterType.Villager;
        vigilante.abilityUsage = EAbilityUsage.Once;
        vigilante.bluffable = true;
        vigilante.characterId = "Vigilante_POW";
        vigilante.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        vigilante.cardBgColor = new Color(0.26f, 0.1519f, 0.3396f);
        vigilante.cardBorderColor = new Color(0.7133f, 0.339f, 0.8679f);
        vigilante.color = new Color(1f, 0.935f, 0.7302f);
        vigilante.additionalFlavorTexts = new Il2CppStringArray(1);
        vigilante.additionalFlavorTexts[0] = vigilante.flavorText;
        vigilante.gender = EGender.Male;

        Il2Cpp.CharacterData coroner = new Il2Cpp.CharacterData();
        coroner.role = new Coroner();
        coroner.name = "Coroner";
        coroner.characterName = "Coroner";
        coroner.description = "If there is a card killed by an Evil, learn an Evil character.\nIf not, there is a 50% chance I point at Good, and a 50% chance I point at evil";
        coroner.flavorText = "\"Has valuable information!\nOnly in niche circumstances.\"";
        coroner.hints = "";
        coroner.ifLies = "Always points to a Good card instead.";
        coroner.notes = "";
        coroner.picking = false;
        coroner.startingAlignment = EAlignment.Good;
        coroner.type = ECharacterType.Villager;
        coroner.abilityUsage = EAbilityUsage.Once;
        coroner.bluffable = true;
        coroner.characterId = "Coroner_POW";
        coroner.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        coroner.cardBgColor = new Color(0.26f, 0.1519f, 0.3396f);
        coroner.cardBorderColor = new Color(0.7133f, 0.339f, 0.8679f);
        coroner.color = new Color(1f, 0.935f, 0.7302f);
        coroner.additionalFlavorTexts = new Il2CppStringArray(1);
        coroner.additionalFlavorTexts[0] = coroner.flavorText;
        coroner.gender = EGender.Male;

        Il2Cpp.CharacterData guard = new Il2Cpp.CharacterData();
        guard.role = new Guard();
        guard.name = "Guard";
        guard.characterName = "Guard";
        guard.description = $"A Villager is {formattedKeyText("Protected")}. \nLearn a {formattedKeyText("Protected")} card.";
        guard.flavorText = "\"A Knight who serves others\nMade his own armor weaker\"";
        guard.hints = "";
        guard.ifLies = $"I dont {formattedKeyText("Protect")} at all. Learn a random card.";
        guard.notes = "";
        guard.picking = false;
        guard.startingAlignment = EAlignment.Good;
        guard.type = ECharacterType.Villager;
        guard.abilityUsage = EAbilityUsage.Once;
        guard.bluffable = true;
        guard.characterId = "Guard_POW";
        guard.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        guard.cardBgColor = new Color(0.26f, 0.1519f, 0.3396f);
        guard.cardBorderColor = new Color(0.7133f, 0.339f, 0.8679f);
        guard.color = new Color(1f, 0.935f, 0.7302f);
        guard.additionalFlavorTexts = new Il2CppStringArray(1);
        guard.additionalFlavorTexts[0] = guard.flavorText;
        guard.gender = EGender.Male;

        Il2Cpp.CharacterData washerwoman = new Il2Cpp.CharacterData();
        washerwoman.role = new Washerwoman();
        washerwoman.name = "Demographer";
        washerwoman.characterName = "Demographer";
        washerwoman.description = "Pick 3 cards. I say an in-play Villager";
        washerwoman.flavorText = "\"Views the villager population. \n Has a bad memory.\"";
        washerwoman.hints = "";
        washerwoman.ifLies = "Says a Wrong Villager or No Villagers instead";
        washerwoman.notes = "";
        washerwoman.picking = true;
        washerwoman.startingAlignment = EAlignment.Good;
        washerwoman.type = ECharacterType.Villager;
        washerwoman.abilityUsage = EAbilityUsage.Once;
        washerwoman.bluffable = true;
        washerwoman.characterId = "Demographer_POW";
        washerwoman.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        washerwoman.cardBgColor = new Color(0.26f, 0.1519f, 0.3396f);
        washerwoman.cardBorderColor = new Color(0.7133f, 0.339f, 0.8679f);
        washerwoman.color = new Color(1f, 0.935f, 0.7302f);
        washerwoman.additionalFlavorTexts = new Il2CppStringArray(1);
        washerwoman.additionalFlavorTexts[0] = washerwoman.flavorText;
        washerwoman.gender = EGender.Male;

        Il2Cpp.CharacterData lookout = new Il2Cpp.CharacterData();
        lookout.role = new Lookout2();
        lookout.name = "Lookout";
        lookout.characterName = "Lookout";
        lookout.description = "Learn how many cards have been affected by evils.";
        lookout.flavorText = "\"Always on the watch. \nCannot seem to catch Evils though.\"";
        lookout.hints = "";
        lookout.ifLies = "Learn a random number instead.";
        lookout.notes = "";
        lookout.picking = false;
        lookout.startingAlignment = EAlignment.Good;
        lookout.type = ECharacterType.Villager;
        lookout.abilityUsage = EAbilityUsage.Once;
        lookout.bluffable = true;
        lookout.characterId = "Lookout_POW";
        lookout.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        lookout.cardBgColor = new Color(0.26f, 0.1519f, 0.3396f);
        lookout.cardBorderColor = new Color(0.7133f, 0.339f, 0.8679f);
        lookout.color = new Color(1f, 0.935f, 0.7302f);
        lookout.additionalFlavorTexts = new Il2CppStringArray(1);
        lookout.additionalFlavorTexts[0] = lookout.flavorText;
        lookout.gender = EGender.Male;

        Il2Cpp.CharacterData seer = new Il2Cpp.CharacterData();
        seer.role = new Prognosticator();
        seer.name = "Prognosticator";
        seer.characterName = "Prognosticator";
        seer.description = "<b>On Pick:</b>\n: Choose a card. Learn how long their chain of same Alignment is.";
        seer.flavorText = "\"Can easily discern friend from foe.\nJust look at who is partying with who!\"";
        seer.hints = "";
        seer.ifLies = "Learn a random number instead.";
        seer.notes = "";
        seer.picking = true;
        seer.startingAlignment = EAlignment.Good;
        seer.type = ECharacterType.Villager;
        seer.abilityUsage = EAbilityUsage.Once;
        seer.bluffable = true;
        seer.characterId = "Prognosticator_POW";
        seer.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        seer.cardBgColor = new Color(0.26f, 0.1519f, 0.3396f);
        seer.cardBorderColor = new Color(0.7133f, 0.339f, 0.8679f);
        seer.color = new Color(1f, 0.935f, 0.7302f);
        seer.additionalFlavorTexts = new Il2CppStringArray(1);
        seer.additionalFlavorTexts[0] = seer.flavorText;
        seer.gender = EGender.Male;

        Il2Cpp.CharacterData knowItAll = new Il2Cpp.CharacterData();
        knowItAll.role = new KnowItAll();
        knowItAll.name = "Know-it-All";
        knowItAll.characterName = "Know-it-All";
        knowItAll.description = "Learn a factually true or false statement, and learn if it is true or false";
        knowItAll.flavorText = "\"Has too much knowledge to share!\nThe Rambler is his best friend!\"";
        knowItAll.hints = "";
        knowItAll.ifLies = "Learn the opposite truthness of the statement";
        knowItAll.notes = "";
        knowItAll.picking = false;
        knowItAll.startingAlignment = EAlignment.Good;
        knowItAll.type = ECharacterType.Villager;
        knowItAll.abilityUsage = EAbilityUsage.Once;
        knowItAll.bluffable = true;
        knowItAll.characterId = "Know-it-All_POW";
        knowItAll.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        knowItAll.cardBgColor = new Color(0.26f, 0.1519f, 0.3396f);
        knowItAll.cardBorderColor = new Color(0.7133f, 0.339f, 0.8679f);
        knowItAll.color = new Color(1f, 0.935f, 0.7302f);
        knowItAll.additionalFlavorTexts = new Il2CppStringArray(1);
        knowItAll.additionalFlavorTexts[0] = knowItAll.flavorText;
        knowItAll.gender = EGender.Male;

        Il2Cpp.CharacterData scholar = new Il2Cpp.CharacterData();
        scholar.role = new Scholar();
        scholar.name = "Scholar";
        scholar.characterName = "Scholar";
        scholar.description = "Learn cryptic advice!";
        scholar.flavorText = "\"She learns from the blabbermouths. \nOne day, the Know-it-all will be proud.\"";
        scholar.hints = "";
        scholar.ifLies = "Learn bad advice.";
        scholar.notes = "";
        scholar.picking = false;
        scholar.startingAlignment = EAlignment.Good;
        scholar.type = ECharacterType.Villager;
        scholar.abilityUsage = EAbilityUsage.Once;
        scholar.bluffable = true;
        scholar.characterId = "Scholar_POW";
        scholar.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        scholar.cardBgColor = new Color(0.26f, 0.1519f, 0.3396f);
        scholar.cardBorderColor = new Color(0.7133f, 0.339f, 0.8679f);
        scholar.color = new Color(1f, 0.935f, 0.7302f);
        scholar.additionalFlavorTexts = new Il2CppStringArray(1);
        scholar.additionalFlavorTexts[0] = scholar.flavorText;
        scholar.gender = EGender.Female;

        Il2Cpp.CharacterData psy = new Il2Cpp.CharacterData();
        psy.role = new Psychic();
        psy.name = "Wise Elder";
        psy.characterName = "Wise Elder";
        psy.description = "<b>At Night:</b>\n On odd nights: Learn two characters. AT LEAST one is good. \n On even nights: Learn 3 characters. AT LEAST one is evil.";
        psy.flavorText = "\"It is said that she can see everyone's true intentions.\nShe simply snoops around when they aren't looking.\"";
        psy.hints = "";
        psy.ifLies = "On odd nights you learn two evils. \n On even nights you learn 3 good.";
        psy.notes = "";
        psy.picking = false;
        psy.startingAlignment = EAlignment.Good;
        psy.type = ECharacterType.Villager;
        psy.abilityUsage = EAbilityUsage.Once;
        psy.bluffable = true;
        psy.characterId = "WiseElder_POW";
        psy.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        psy.cardBgColor = new Color(0.26f, 0.1519f, 0.3396f);
        psy.cardBorderColor = new Color(0.7133f, 0.339f, 0.8679f);
        psy.color = new Color(1f, 0.935f, 0.7302f);
        nightPhase.nightCharactersOrder.Add(psy);
        psy.additionalFlavorTexts = new Il2CppStringArray(1);
        psy.additionalFlavorTexts[0] = psy.flavorText;
        psy.gender = EGender.Female;

        Il2Cpp.CharacterData tracker = new Il2Cpp.CharacterData();
        tracker.role = new Huntress();
        tracker.name = "Huntress";
        tracker.characterName = "Huntress";
        tracker.description = "Learn an Evil that affected a Good card.\nI can't track kills.";
        tracker.flavorText = "\"The Hunter and her have a secret thing. \nThe entire town knows.\"";
        tracker.hints = "";
        tracker.ifLies = "I point to a good card.";
        tracker.notes = "";
        tracker.picking = false;
        tracker.startingAlignment = EAlignment.Good;
        tracker.type = ECharacterType.Villager;
        tracker.abilityUsage = EAbilityUsage.Once;
        tracker.bluffable = true;
        tracker.characterId = "Huntress_POW";
        tracker.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        tracker.cardBgColor = new Color(0.26f, 0.1519f, 0.3396f);
        tracker.cardBorderColor = new Color(0.7133f, 0.339f, 0.8679f);
        tracker.color = new Color(1f, 0.935f, 0.7302f);
        tracker.additionalFlavorTexts = new Il2CppStringArray(1);
        tracker.additionalFlavorTexts[0] = tracker.flavorText;
        tracker.gender = EGender.Female;

        Il2Cpp.CharacterData spy = new Il2Cpp.CharacterData();
        spy.role = new Tapper();
        spy.name = "Tapper";
        spy.characterName = "Tapper";
        spy.description = "<b>On Pick:</b>\n Pick a character. Learn what statuses effect them and their neighbors.";
        spy.flavorText = "\"Has placed a tap on every home. \nOften just sees the Scout.\"";
        spy.hints = "";
        spy.ifLies = "At least one of my statuses are wrong, or I state no statuses when there are some.";
        spy.notes = "";
        spy.picking = true;
        spy.startingAlignment = EAlignment.Good;
        spy.type = ECharacterType.Villager;
        spy.abilityUsage = EAbilityUsage.Once;
        spy.bluffable = true;
        spy.characterId = "Tapper_POW";
        spy.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        spy.cardBgColor = new Color(0.26f, 0.1519f, 0.3396f);
        spy.cardBorderColor = new Color(0.7133f, 0.339f, 0.8679f);
        spy.color = new Color(1f, 0.935f, 0.7302f);
        spy.additionalFlavorTexts = new Il2CppStringArray(1);
        spy.additionalFlavorTexts[0] = spy.flavorText;
        spy.gender = EGender.Male;

        Il2Cpp.CharacterData sher = new Il2Cpp.CharacterData();
        sher.role = new Sheriff();
        sher.name = "Constable";
        sher.characterName = "Constable";
        sher.description = "<b>At Night:</b>\n I search a character's house. If they are evil, learn they seem suspicious. If they are good, learn they are innocent.";
        sher.flavorText = "\"Is given higher authority to search for demons. \nMostly searches for drama.\"";
        sher.hints = "If truthful: \nIf I visit an Outcast Killing, Minion Killing, or Demon Killing, I will die.";
        sher.ifLies = "Learn the opposite suspicion.";
        sher.notes = "";
        sher.picking = false;
        sher.startingAlignment = EAlignment.Good;
        sher.type = ECharacterType.Villager;
        sher.abilityUsage = EAbilityUsage.Once;
        sher.bluffable = true;
        sher.characterId = "Constable_POW";
        sher.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        sher.cardBgColor = new Color(0.26f, 0.1519f, 0.3396f);
        sher.cardBorderColor = new Color(0.7133f, 0.339f, 0.8679f);
        sher.color = new Color(1f, 0.935f, 0.7302f);
        nightPhase.nightCharactersOrder.Add(sher);
        sher.additionalFlavorTexts = new Il2CppStringArray(1);
        sher.additionalFlavorTexts[0] = sher.flavorText;
        sher.gender = EGender.Male;

        Il2Cpp.CharacterData newsman = new Il2Cpp.CharacterData();
        newsman.role = new Newsman();
        newsman.name = "Newsman";
        newsman.characterName = "Newsman";
        newsman.description = $"Learn the closest {formattedKeyText("Mad")} Character";
        newsman.flavorText = "\"HEAR IT HEAR IT, The Demographer mistook the Poet for the Drunk! \nMore at 5\"";
        newsman.hints = "";
        newsman.ifLies = "Learn a random number";
        newsman.notes = "";
        newsman.picking = false;
        newsman.startingAlignment = EAlignment.Good;
        newsman.type = ECharacterType.Villager;
        newsman.abilityUsage = EAbilityUsage.Once;
        newsman.bluffable = true;
        newsman.characterId = "Newsman_POW";
        newsman.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        newsman.cardBgColor = new Color(0.26f, 0.1519f, 0.3396f);
        newsman.cardBorderColor = new Color(0.7133f, 0.339f, 0.8679f);
        newsman.color = new Color(1f, 0.935f, 0.7302f);
        newsman.additionalFlavorTexts = new Il2CppStringArray(1);
        newsman.additionalFlavorTexts[0] = knowItAll.flavorText;
        newsman.gender = EGender.Male;

        Il2Cpp.CharacterData admi = new Il2Cpp.CharacterData();
        admi.role = new Admirer();
        admi.name = "Lovestruck";
        admi.characterName = "Lovestruck";
        admi.description = $"Learn an unrevealed {formattedKeyText("Subtype")}. \n If no more valid cards can be revealed, learn it. ";
        admi.flavorText = "\"She's waiting for her shooting star. \n \"Comme une étoile filante!\" she says!\"";
        admi.hints = "If I say that I cannot love, I am always lying.";
        admi.ifLies = "Learn a bluffing card.";
        admi.notes = "";
        admi.picking = false;
        admi.startingAlignment = EAlignment.Good;
        admi.type = ECharacterType.Villager;
        admi.abilityUsage = EAbilityUsage.Once;
        admi.bluffable = true;
        admi.characterId = "Lovestruck_POW";
        admi.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        admi.cardBgColor = new Color(0.26f, 0.1519f, 0.3396f);
        admi.cardBorderColor = new Color(0.7133f, 0.339f, 0.8679f);
        admi.color = new Color(1f, 0.935f, 0.7302f);
        admi.additionalFlavorTexts = new Il2CppStringArray(1);
        admi.additionalFlavorTexts[0] = admi.flavorText;
        admi.gender = EGender.Female;

        Il2Cpp.CharacterData fisherman = new Il2Cpp.CharacterData();
        fisherman.role = new Fisherman();
        fisherman.name = "Fisherman";
        fisherman.characterName = "Fisherman";
        fisherman.description = "Learn how far is a specific Villager to another Villager";
        fisherman.flavorText = "\"Likes to show off is awesome catches.\nOnly the Baker seems to care.\"";
        fisherman.hints = "";
        fisherman.ifLies = "Still points to a Villager, but the number is wrong";
        fisherman.notes = "";
        fisherman.picking = false;
        fisherman.startingAlignment = EAlignment.Good;
        fisherman.type = ECharacterType.Villager;
        fisherman.abilityUsage = EAbilityUsage.Once;
        fisherman.bluffable = true;
        fisherman.characterId = "Fisherman_POW";
        fisherman.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        fisherman.cardBgColor = new Color(0.26f, 0.1519f, 0.3396f);
        fisherman.cardBorderColor = new Color(0.7133f, 0.339f, 0.8679f);
        fisherman.color = new Color(1f, 0.935f, 0.7302f);
        fisherman.additionalFlavorTexts = new Il2CppStringArray(1);
        fisherman.additionalFlavorTexts[0] = fisherman.flavorText;
        fisherman.gender = EGender.Male;

        Il2Cpp.CharacterData sailor = new Il2Cpp.CharacterData();
        sailor.role = new Sailor();
        sailor.name = "Armorsmith";
        sailor.characterName = "Armorsmith";
        sailor.description = $"When revealed: \n I point at a card. \n If they are Good, they are {formattedKeyText("Protected")} and learn they are {formattedKeyText("Trustworthy")}. \nIf else, I am {formattedKeyText("Protected")}.";
        sailor.flavorText = "\"She makes great armor. \n The Knight got better elsewhere...\"";
        sailor.hints = "I see the Wretch as Good.";
        sailor.ifLies = $"I don't {formattedKeyText("Protect")} either card.\n I may point at Evils and call them {formattedKeyText("Trustworthy")}.";
        sailor.notes = "If truthful:\nI don't point at the Knight (She is jealous).";
        sailor.picking = false;
        sailor.startingAlignment = EAlignment.Good;
        sailor.type = ECharacterType.Villager;
        sailor.abilityUsage = EAbilityUsage.Once;
        sailor.bluffable = true;
        sailor.characterId = "Armorsmith_POW";
        sailor.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        sailor.cardBgColor = new Color(0.26f, 0.1519f, 0.3396f);
        sailor.cardBorderColor = new Color(0.7133f, 0.339f, 0.8679f);
        sailor.color = new Color(1f, 0.935f, 0.7302f);
        sailor.additionalFlavorTexts = new Il2CppStringArray(1);
        sailor.additionalFlavorTexts[0] = sailor.flavorText;
        sailor.gender = EGender.Female;

        Il2Cpp.CharacterData teaLady = new Il2Cpp.CharacterData();
        teaLady.role = new TeaLady();
        teaLady.name = "Soldier";
        teaLady.characterName = "Soldier";
        teaLady.description = $"Good characters sitting next to me are {formattedKeyText("Protected")}.\n If I sit next to Evil I am Corrupted.";
        teaLady.flavorText = "\"Defends all Good people\nIs the only friend of the Wretch.\"";
        teaLady.hints = "I see the Wretch as Good.";
        teaLady.ifLies = $"Good Characters sitting next to me are not {formattedKeyText("Protected")}.";
        teaLady.notes = "";
        teaLady.picking = false;
        teaLady.startingAlignment = EAlignment.Good;
        teaLady.type = ECharacterType.Villager;
        teaLady.abilityUsage = EAbilityUsage.Once;
        teaLady.bluffable = true;
        teaLady.characterId = "Soldier_POW";
        teaLady.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        teaLady.cardBgColor = new Color(0.26f, 0.1519f, 0.3396f);
        teaLady.cardBorderColor = new Color(0.7133f, 0.339f, 0.8679f);
        teaLady.color = new Color(1f, 0.935f, 0.7302f);
        teaLady.additionalFlavorTexts = new Il2CppStringArray(1);
        teaLady.additionalFlavorTexts[0] = teaLady.flavorText;
        teaLady.gender = EGender.Female;

        Il2Cpp.CharacterData oracle = new Il2Cpp.CharacterData();
        oracle.role = new Oracle2();
        oracle.name = "Herbalist";
        oracle.characterName = "Herbalist";
        oracle.description = $"An unrevealed Villager role is immune to Corruption.\nLearn an unrevealed Villager.";
        oracle.flavorText = "\"People call her treatments fake all the time.\nShe gets used to it.\"";
        oracle.hints = "";
        oracle.ifLies = $"Learn a bluff. I don't heal corruption.";
        oracle.notes = "";
        oracle.picking = false;
        oracle.startingAlignment = EAlignment.Good;
        oracle.type = ECharacterType.Villager;
        oracle.abilityUsage = EAbilityUsage.Once;
        oracle.bluffable = true;
        oracle.characterId = "Herbalist_POW";
        oracle.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        oracle.cardBgColor = new Color(0.26f, 0.1519f, 0.3396f);
        oracle.cardBorderColor = new Color(0.7133f, 0.339f, 0.8679f);
        oracle.color = new Color(1f, 0.935f, 0.7302f);
        oracle.additionalFlavorTexts = new Il2CppStringArray(1);
        oracle.additionalFlavorTexts[0] = oracle.flavorText;
        oracle.gender = EGender.Female;

        Il2Cpp.CharacterData dep = new Il2Cpp.CharacterData();
        dep.role = new Deputy();
        dep.name = "Deputy";
        dep.characterName = "Deputy";
        dep.description = $"I shoot a card. I miss if they are good and kill if they are evil.";
        dep.flavorText = "\"Is given way too much power. \n Somehow she never abuses it.\"";
        dep.hints = "";
        dep.ifLies = $"I claim I missed on an evil.";
        dep.notes = "";
        dep.picking = false;
        dep.startingAlignment = EAlignment.Good;
        dep.type = ECharacterType.Villager;
        dep.abilityUsage = EAbilityUsage.Once;
        dep.bluffable = true;
        dep.characterId = "Deputy_POW";
        dep.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        dep.cardBgColor = new Color(0.26f, 0.1519f, 0.3396f);
        dep.cardBorderColor = new Color(0.7133f, 0.339f, 0.8679f);
        dep.color = new Color(1f, 0.935f, 0.7302f);
        dep.additionalFlavorTexts = new Il2CppStringArray(1);
        dep.additionalFlavorTexts[0] = dep.flavorText;
        dep.gender = EGender.Female;

        Il2Cpp.CharacterData invest = new Il2Cpp.CharacterData();
        invest.role = new Operative();
        invest.name = "Operative";
        invest.characterName = "Operative";
        invest.description = $"<b>On Pick:</b>\n Choose a card. Learn if they have committed one of 4 crimes.";
        invest.flavorText = "\"Night one: The Mayor is Murder/Tress\"";
        invest.hints = $"Crimes:\nMurder: Is a killing {formattedKeyText("Subtype")}. \nTresspassing: Evil bluffing on-pick character. \nFraud: Disguised character. \nPerjury: Character is lying.";
        invest.ifLies = $"One and only one of my stated crimes are false.";
        invest.notes = "";
        invest.picking = true;
        invest.startingAlignment = EAlignment.Good;
        invest.type = ECharacterType.Villager;
        invest.abilityUsage = EAbilityUsage.Once;
        invest.bluffable = true;
        invest.characterId = "Operative_POW";
        invest.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        invest.cardBgColor = new Color(0.26f, 0.1519f, 0.3396f);
        invest.cardBorderColor = new Color(0.7133f, 0.339f, 0.8679f);
        invest.color = new Color(1f, 0.935f, 0.7302f);
        invest.additionalFlavorTexts = new Il2CppStringArray(1);
        invest.additionalFlavorTexts[0] = invest.flavorText;
        invest.gender = EGender.Female;

        Il2Cpp.CharacterData parent = new Il2Cpp.CharacterData();
        parent.role = new Parent();
        parent.name = "Parent";
        parent.characterName = "Parent";
        parent.description = $"Learn what role my child is. I am unbluffable. I turn Evil if my child is Evil.";
        parent.flavorText = "\"Will do anything to protect their kid. \n Even if it means destroying the world.\"";
        parent.hints = "";
        parent.ifLies = "If I can, learn what bluff my child is.";
        parent.notes = "";
        parent.picking = false;
        parent.startingAlignment = EAlignment.Good;
        parent.type = ECharacterType.Villager;
        parent.abilityUsage = EAbilityUsage.Once;
        parent.bluffable = false;
        parent.characterId = "Parent_POW";
        parent.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        parent.cardBgColor = new Color(0.26f, 0.1519f, 0.3396f);
        parent.cardBorderColor = new Color(0.7133f, 0.339f, 0.8679f);
        parent.color = new Color(1f, 0.935f, 0.7302f);
        parent.additionalFlavorTexts = new Il2CppStringArray(1);
        parent.additionalFlavorTexts[0] = parent.flavorText;
        parent.gender = EGender.They;

        Il2Cpp.CharacterData prosecutor = new Il2Cpp.CharacterData();
        prosecutor.role = new Prosecutor();
        prosecutor.name = "Prosecutor";
        prosecutor.characterName = "Prosecutor";
        prosecutor.description = $"Upon {formattedKeyText("Revealing")}, I kill a Minion!";
        prosecutor.flavorText = "\"He is a bit strict, but means well.\"";
        prosecutor.hints = "I cannot be Evil";
        prosecutor.ifLies = "Says 'I am corrupted' ";
        prosecutor.notes = "";
        prosecutor.picking = false;
        prosecutor.startingAlignment = EAlignment.Good;
        prosecutor.type = ECharacterType.Villager;
        prosecutor.abilityUsage = EAbilityUsage.Once;
        prosecutor.bluffable = false;
        prosecutor.characterId = "Prosecutor_POW";
        prosecutor.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        prosecutor.cardBgColor = new Color(0.26f, 0.1519f, 0.3396f);
        prosecutor.cardBorderColor = new Color(0.7133f, 0.339f, 0.8679f);
        prosecutor.color = new Color(1f, 0.935f, 0.7302f);
        prosecutor.additionalFlavorTexts = new Il2CppStringArray(1);
        prosecutor.additionalFlavorTexts[0] = prosecutor.flavorText;
        prosecutor.gender = EGender.Male;

        Il2Cpp.CharacterData mayor = new Il2Cpp.CharacterData();
        mayor.role = new Mayor();
        mayor.name = "Mayor";
        mayor.characterName = "Mayor";
        mayor.description = $"I {formattedKeyText("Reveal")} Disguised characters 2 cards away from me!";
        mayor.flavorText = "\"Everyone knows the Mayor! And the Mayor knows everything\"";
        mayor.hints = "I cannot be Evil";
        mayor.ifLies = "Says 'I am corrupted' ";
        mayor.notes = "";
        mayor.picking = false;
        mayor.startingAlignment = EAlignment.Good;
        mayor.type = ECharacterType.Villager;
        mayor.abilityUsage = EAbilityUsage.Once;
        mayor.bluffable = false;
        mayor.characterId = "Mayor_POW";
        mayor.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        mayor.cardBgColor = new Color(0.26f, 0.1519f, 0.3396f);
        mayor.cardBorderColor = new Color(0.7133f, 0.339f, 0.8679f);
        mayor.color = new Color(1f, 0.935f, 0.7302f);
        mayor.additionalFlavorTexts = new Il2CppStringArray(1);
        mayor.additionalFlavorTexts[0] = mayor.flavorText;
        mayor.gender = EGender.Male;

        Il2Cpp.CharacterData marshal = new Il2Cpp.CharacterData();
        marshal.role = new Marshal();
        marshal.name = "Marshal";
        marshal.characterName = "Marshal";
        marshal.description = $"Grants you 10 extra {formattedKeyText("Health")} points!";
        marshal.flavorText = "\"A military man with big ambitions\"";
        marshal.hints = "I cannot be Evil";
        marshal.ifLies = "Says 'I am corrupted' ";
        marshal.notes = "";
        marshal.picking = false;
        marshal.startingAlignment = EAlignment.Good;
        marshal.type = ECharacterType.Villager;
        marshal.abilityUsage = EAbilityUsage.Once;
        marshal.bluffable = false;
        marshal.characterId = "Marshal_POW";
        marshal.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        marshal.cardBgColor = new Color(0.26f, 0.1519f, 0.3396f);
        marshal.cardBorderColor = new Color(0.7133f, 0.339f, 0.8679f);
        marshal.color = new Color(1f, 0.935f, 0.7302f);
        marshal.additionalFlavorTexts = new Il2CppStringArray(1);
        marshal.additionalFlavorTexts[0] = marshal.flavorText;
        marshal.gender = EGender.Male;

        Il2Cpp.CharacterData monarch = new Il2Cpp.CharacterData();
        monarch.role = new Monarch();
        monarch.name = "Emperor";
        monarch.characterName = "Emperor";
        monarch.description = "I cannot die. Learn 3 Villagers.";
        monarch.flavorText = "\"The Emperor of the land,\nthe Empress is mostly in charge.\"";
        monarch.hints = "I cannot be Evil";
        monarch.ifLies = "Says 'I am corrupted' ";
        monarch.notes = "";
        monarch.picking = false;
        monarch.startingAlignment = EAlignment.Good;
        monarch.type = ECharacterType.Villager;
        monarch.abilityUsage = EAbilityUsage.Once;
        monarch.bluffable = false;
        monarch.characterId = "Monarch_POW";
        monarch.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        monarch.cardBgColor = new Color(0.26f, 0.1519f, 0.3396f);
        monarch.cardBorderColor = new Color(0.7133f, 0.339f, 0.8679f);
        monarch.color = new Color(1f, 0.935f, 0.7302f);
        monarch.additionalFlavorTexts = new Il2CppStringArray(1);
        monarch.additionalFlavorTexts[0] = monarch.flavorText;
        monarch.gender = EGender.Male;

        Il2Cpp.CharacterData official = new Il2Cpp.CharacterData();
        official.role = new Official();
        official.name = "Executive";
        official.characterName = "Executive";
        official.description = "I take on a Power role!";
        official.flavorText = "\"A good government executive that takes on any position\"";
        official.hints = "I cannot be Evil";
        official.ifLies = "Says 'I am corrupted' ";
        official.notes = "";
        official.picking = false;
        official.startingAlignment = EAlignment.Good;
        official.type = ECharacterType.Villager;
        official.abilityUsage = EAbilityUsage.Once;
        official.bluffable = false;
        official.characterId = "Executive_POW";
        official.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        official.cardBgColor = new Color(0.26f, 0.1519f, 0.3396f);
        official.cardBorderColor = new Color(0.7133f, 0.339f, 0.8679f);
        official.color = new Color(1f, 0.935f, 0.7302f);
        official.additionalFlavorTexts = new Il2CppStringArray(1);
        official.additionalFlavorTexts[0] = official.flavorText;

        Il2Cpp.CharacterData pacifist = new Il2Cpp.CharacterData();
        pacifist.role = new Pacifist();
        pacifist.name = "Pacifist";
        pacifist.characterName = "Pacifist";
        pacifist.description = "On pick: Choose 4 cards. \n If they are all Good, you win!";
        pacifist.flavorText = "\"Organizes peaceful protests against the Demons\nThey don't end well.\"";
        pacifist.hints = "I cannot be Evil";
        pacifist.ifLies = "Says 'I am corrupted' ";
        pacifist.notes = "";
        pacifist.picking = true;
        pacifist.startingAlignment = EAlignment.Good;
        pacifist.type = ECharacterType.Villager;
        pacifist.abilityUsage = EAbilityUsage.Once;
        pacifist.bluffable = false;
        pacifist.characterId = "Pacifist_POW";
        pacifist.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        pacifist.cardBgColor = new Color(0.26f, 0.1519f, 0.3396f);
        pacifist.cardBorderColor = new Color(0.7133f, 0.339f, 0.8679f);
        pacifist.color = new Color(1f, 0.935f, 0.7302f);
        pacifist.additionalFlavorTexts = new Il2CppStringArray(1);
        pacifist.additionalFlavorTexts[0] = pacifist.flavorText;
        pacifist.gender = EGender.Female;
        // This is taken from Wingidon's DBExpansion mod


        Il2Cpp.CharacterData jailor = new Il2Cpp.CharacterData();
        jailor.role = new Jailor();
        jailor.name = "Jailor";
        jailor.characterName = "Jailor";
        jailor.description = $"The Demon is {formattedKeyText("Jailed")} and cannot act.";
        jailor.flavorText = "\"The Demon shall not act whilst she's around.\"";
        jailor.hints = "I cannot be Evil";
        jailor.ifLies = "Says 'I am corrupted' ";
        jailor.notes = "";
        jailor.picking = false;
        jailor.startingAlignment = EAlignment.Good;
        jailor.type = ECharacterType.Villager;
        jailor.abilityUsage = EAbilityUsage.Once;
        jailor.bluffable = false;
        jailor.characterId = "Jailor_POW";
        jailor.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        jailor.cardBgColor = new Color(0.26f, 0.1519f, 0.3396f);
        jailor.cardBorderColor = new Color(0.7133f, 0.339f, 0.8679f);
        jailor.color = new Color(1f, 0.935f, 0.7302f);
        jailor.additionalFlavorTexts = new Il2CppStringArray(1);
        jailor.additionalFlavorTexts[0] = jailor.flavorText;
        jailor.gender = EGender.Female;

        Il2Cpp.CharacterData choirboy = new Il2Cpp.CharacterData();
        choirboy.role = new ChoirBoy();
        choirboy.name = "Royal Knight";
        choirboy.characterName = "Royal Knight";
        choirboy.description = "If the Power role is dead or has a status, learn all Demons.";
        choirboy.flavorText = "\"A good Royal Knight that protects the Executive!\"";
        choirboy.hints = "If Truthful: \n If the Executive is not in-play I say so.";
        choirboy.ifLies = "Learn no Demons or learn that the Executive is fine when they aren't.";
        choirboy.notes = "";
        choirboy.picking = false;
        choirboy.startingAlignment = EAlignment.Good;
        choirboy.type = ECharacterType.Villager;
        choirboy.abilityUsage = EAbilityUsage.Once;
        choirboy.bluffable = true;
        choirboy.characterId = "RoyalKnight_POW";
        choirboy.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        choirboy.cardBgColor = new Color(0.26f, 0.1519f, 0.3396f);
        choirboy.cardBorderColor = new Color(0.7133f, 0.339f, 0.8679f);
        choirboy.color = new Color(1f, 0.935f, 0.7302f);
        choirboy.additionalFlavorTexts = new Il2CppStringArray(1);
        choirboy.additionalFlavorTexts[0] = official.flavorText;

        Il2Cpp.CharacterData rej = new Il2Cpp.CharacterData();
        rej.role = new Rejected();
        rej.name = "Outlier";
        rej.characterName = "Outlier";
        rej.description = "I do nothing";
        rej.flavorText = "\"Is banished for unknown reason.\nPossibly their smell.\"";
        rej.hints = "I am the result of a bad Outcast interaction between a POWERPLAY demon and another mod. I can appear naturally. More than One card can be an Outlier.";
        rej.ifLies = "";
        rej.notes = "";
        rej.picking = false;
        rej.startingAlignment = EAlignment.Good;
        rej.type = ECharacterType.Outcast;
        rej.abilityUsage = EAbilityUsage.Once;
        rej.bluffable = true;
        rej.characterId = "Outlier_POW";
        rej.artBgColor = new Color(0.3679f, 0.2014f, 0.1541f);
        rej.cardBgColor = new Color(0.102f, 0.0667f, 0.0392f);
        rej.cardBorderColor = new Color(0.7843f, 0.6471f, 0f);
        rej.color = new Color(0.9659f, 1f, 0.4472f);
        rej.additionalFlavorTexts = new Il2CppStringArray(1);
        rej.additionalFlavorTexts[0] = rej.flavorText;
        rej.gender = EGender.Male;

        Il2Cpp.CharacterData snakeCharmer = new Il2Cpp.CharacterData();
        snakeCharmer.role = new SnakeCharmer();
        snakeCharmer.name = "Flutist";
        snakeCharmer.characterName = "Flutist";
        snakeCharmer.description = "I swap with an Evil.\nI register as Evil.\nI cannot be Evil";
        snakeCharmer.flavorText = "\"Tries to charm the Evils into revealing themselves. \n Become one instead.\"";
        snakeCharmer.hints = "I prioritize swapping with evils that summon stuff next to them.";
        snakeCharmer.ifLies = "";
        snakeCharmer.notes = "The Corruption is there to prevent disco.";
        snakeCharmer.picking = false;
        snakeCharmer.startingAlignment = EAlignment.Good;
        snakeCharmer.type = ECharacterType.Outcast;
        snakeCharmer.abilityUsage = EAbilityUsage.Once;
        snakeCharmer.bluffable = false;
        snakeCharmer.characterId = "Flutist_POW";
        snakeCharmer.artBgColor = new Color(0.3679f, 0.2014f, 0.1541f);
        snakeCharmer.cardBgColor = new Color(0.102f, 0.0667f, 0.0392f);
        snakeCharmer.cardBorderColor = new Color(0.7843f, 0.6471f, 0f);
        snakeCharmer.color = new Color(0.9659f, 1f, 0.4472f);
        snakeCharmer.additionalFlavorTexts = new Il2CppStringArray(1);
        snakeCharmer.additionalFlavorTexts[0] = snakeCharmer.flavorText;
        snakeCharmer.gender = EGender.Male;

        Il2Cpp.CharacterData amnesiac = new Il2Cpp.CharacterData();
        amnesiac.role = new Amnesiac();
        amnesiac.name = "Amnesiac";
        amnesiac.characterName = "Amnesiac";
        amnesiac.description = "I can get one of 6 abilities, you don't learn which:\nNumbers:\nHow many evil neighbors \nHow close another card of the same character type is to the picked one" +
            "\nThe amount of non-villagers between me and the picked card, clockwise from them to me\n\nYes or no:\nDo they have a status?\nAm I closer to the Demon?\nIf we share an alignement.";
        amnesiac.flavorText = "\"See I would come up with something.\nBut I forgot.\"";
        amnesiac.hints = "";
        amnesiac.ifLies = "Says a random number of the opposite of the statement";
        amnesiac.notes = "";
        amnesiac.picking = false;
        amnesiac.startingAlignment = EAlignment.Good;
        amnesiac.type = ECharacterType.Outcast;
        amnesiac.abilityUsage = EAbilityUsage.Once;
        amnesiac.bluffable = true;
        amnesiac.characterId = "Amnesiac_POW";
        amnesiac.artBgColor = new Color(0.3679f, 0.2014f, 0.1541f);
        amnesiac.cardBgColor = new Color(0.102f, 0.0667f, 0.0392f);
        amnesiac.cardBorderColor = new Color(0.7843f, 0.6471f, 0f);
        amnesiac.color = new Color(0.9659f, 1f, 0.4472f);
        amnesiac.additionalFlavorTexts = new Il2CppStringArray(1);
        amnesiac.additionalFlavorTexts[0] = amnesiac.flavorText;
        amnesiac.gender = EGender.Male;

        Il2Cpp.CharacterData indust = new Il2Cpp.CharacterData();
        indust.role = new Industrialist();
        indust.name = "Industrialist";
        indust.characterName = "Industrialist";
        indust.description = $"I make a Good Characater {formattedKeyText("Mad")}. Learn one {formattedKeyText("Mad")} character.";
        indust.flavorText = "\"If you'd be like that guy right there.\n Maybe you'd get hired here!\"";
        indust.hints = "";
        indust.ifLies = $"I say a Good character is {formattedKeyText("Mad")} when they aren't.";
        indust.notes = "";
        indust.picking = false;
        indust.startingAlignment = EAlignment.Good;
        indust.type = ECharacterType.Outcast;
        indust.abilityUsage = EAbilityUsage.Once;
        indust.bluffable = true;
        indust.characterId = "Industrialist_POW";
        indust.artBgColor = new Color(0.3679f, 0.2014f, 0.1541f);
        indust.cardBgColor = new Color(0.102f, 0.0667f, 0.0392f);
        indust.cardBorderColor = new Color(0.7843f, 0.6471f, 0f);
        indust.color = new Color(0.9659f, 1f, 0.4472f);
        indust.additionalFlavorTexts = new Il2CppStringArray(1);
        indust.additionalFlavorTexts[0] = indust.flavorText;
        indust.gender = EGender.Male;

        Il2Cpp.CharacterData veteran = new Il2Cpp.CharacterData();
        veteran.role = new Veteran();
        veteran.name = "Veteran";
        veteran.characterName = "Veteran";
        veteran.description = "I kill any Good players that pick me\nI deal 2 damage to you. \nI disguise.";
        veteran.flavorText = "\"Tries to bait the Demon\nOnly Villagers fall for the bait.\"";
        veteran.hints = "";
        veteran.ifLies = "";
        veteran.notes = "";
        veteran.picking = false;
        veteran.startingAlignment = EAlignment.Good;
        veteran.type = ECharacterType.Outcast;
        veteran.abilityUsage = EAbilityUsage.Once;
        veteran.bluffable = false;
        veteran.characterId = "Veteran_POW";
        veteran.artBgColor = new Color(0.3679f, 0.2014f, 0.1541f);
        veteran.cardBgColor = new Color(0.102f, 0.0667f, 0.0392f);
        veteran.cardBorderColor = new Color(0.7843f, 0.6471f, 0f);
        veteran.color = new Color(0.9659f, 1f, 0.4472f);
        veteran.additionalFlavorTexts = new Il2CppStringArray(1);
        veteran.additionalFlavorTexts[0] = veteran.flavorText;
        veteran.gender = EGender.Male;

        Il2Cpp.CharacterData vanished = new Il2Cpp.CharacterData();
        vanished.role = new Vanished();
        vanished.name = "Vanished";
        vanished.characterName = "Vanished";
        vanished.description = $"I cast {formattedKeyText("Unknown Obstacle")} on myself.\n I silence my closest Evil neighbor.";
        vanished.flavorText = "\"Out of sight, out of mind is his motto.\"";
        vanished.hints = $"";
        vanished.ifLies = $"I still cast {formattedKeyText("Unknown Obstacle")}.\n I instead silence my closest Good neighbor.";
        vanished.notes = "";
        vanished.picking = false;
        vanished.startingAlignment = EAlignment.Good;
        vanished.type = ECharacterType.Outcast;
        vanished.abilityUsage = EAbilityUsage.Once;
        vanished.bluffable = true;
        vanished.characterId = "Vanished_POW";
        vanished.artBgColor = new Color(0.3679f, 0.2014f, 0.1541f);
        vanished.cardBgColor = new Color(0.102f, 0.0667f, 0.0392f);
        vanished.cardBorderColor = new Color(0.7843f, 0.6471f, 0f);
        vanished.color = new Color(0.9659f, 1f, 0.4472f);
        vanished.additionalFlavorTexts = new Il2CppStringArray(1);
        vanished.additionalFlavorTexts[0] = vanished.flavorText;
        vanished.gender = EGender.Male;

        Il2Cpp.CharacterData tav = new Il2Cpp.CharacterData();
        tav.role = new TavernKeeper();
        tav.name = "Winemaker";
        tav.characterName = "Winemaker";
        tav.description = $"I {formattedKeyText("Intoxicate")} a random Good card. Learn a {formattedKeyText("Intoxicated")} card.";
        tav.flavorText = "\"Likes to celebrate.\nKnows the Drunk a bit too well.\"";
        tav.hints = "";
        tav.ifLies = $"Learn a random card. I don't {formattedKeyText("Intoxicate")}.";
        tav.notes = "";
        tav.picking = false;
        tav.startingAlignment = EAlignment.Good;
        tav.type = ECharacterType.Outcast;
        tav.abilityUsage = EAbilityUsage.Once;
        tav.bluffable = true;
        tav.characterId = "Winemaker_POW";
        tav.artBgColor = new Color(0.3679f, 0.2014f, 0.1541f);
        tav.cardBgColor = new Color(0.102f, 0.0667f, 0.0392f);
        tav.cardBorderColor = new Color(0.7843f, 0.6471f, 0f);
        tav.color = new Color(0.9659f, 1f, 0.4472f);
        tav.additionalFlavorTexts = new Il2CppStringArray(1);
        tav.additionalFlavorTexts[0] = tav.flavorText;
        tav.gender = EGender.Female;

        Il2Cpp.CharacterData goon = new Il2Cpp.CharacterData();
        goon.role = new Goon();
        goon.name = "Mobster";
        goon.characterName = "Mobster";
        goon.description = $"I change {formattedKeyText("Alignment")} based off who picked me.\nLearn when I swap alignments.";
        goon.flavorText = "\"I work for anyone, anything, anywhere\"";
        goon.hints = "";
        goon.ifLies = "";
        goon.notes = "";
        goon.picking = false;
        goon.startingAlignment = EAlignment.Good;
        goon.type = ECharacterType.Outcast;
        goon.abilityUsage = EAbilityUsage.Once;
        goon.bluffable = false;
        goon.characterId = "Mobster_POW";
        goon.artBgColor = new Color(0.3679f, 0.2014f, 0.1541f);
        goon.cardBgColor = new Color(0.102f, 0.0667f, 0.0392f);
        goon.cardBorderColor = new Color(0.7843f, 0.6471f, 0f);
        goon.color = new Color(0.9659f, 1f, 0.4472f);
        goon.additionalFlavorTexts = new Il2CppStringArray(1);
        goon.additionalFlavorTexts[0] = goon.flavorText;
        goon.gender = EGender.Male;

        

        Il2Cpp.CharacterData doom = new Il2Cpp.CharacterData();
        doom.role = new Doomsayer();
        doom.name = "Doomsayer";
        doom.characterName = "Doomsayer";
        doom.description = $"<b>On Pick:</b>\n I kill a villager and a card opposing my {formattedKeyText("Alignment")}." +
            $"\n I deal 3 {formattedKeyText("Damage")} per Good card killed.";
        doom.flavorText = "\"He's predicted too many catastrophes. \nProbably the cause of said catastrophes.\"";
        doom.hints = customHint("Alignment Hint", "Neutral");
        doom.ifLies = "";
        doom.notes = "";
        doom.picking = true;
        doom.startingAlignment = NeutralAlignement.Neutral;
        doom.type = NeutralType.Neutral;
        doom.abilityUsage = EAbilityUsage.Once;
        doom.bluffable = false;
        doom.characterId = "Doomsayer_POW";
        doom.artBgColor = new Color(0.3679f, 0.2014f, 0.1541f);
        doom.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        doom.cardBorderColor = new Color(0.7843f, 0.6471f, 0f);
        doom.color = new Color(0.8510f, 0.4549f, 0.0f);
        doom.additionalFlavorTexts = new Il2CppStringArray(1);
        doom.additionalFlavorTexts[0] = doom.flavorText;
        doom.gender = EGender.Male;

        Il2Cpp.CharacterData pirate = new Il2Cpp.CharacterData();
        pirate.role = new Pirate();
        pirate.name = "Pirate";
        pirate.characterName = "Pirate";
        pirate.description = $"I duel a card. I lose if they are of the same  {formattedKeyText("Alignment")}, they die if they are of a different  {formattedKeyText("Alignment")}";
        pirate.flavorText = "\"You've got a fine coin there!\n Mind if I take it?\"";
        pirate.hints = customHint("Alignment Hint","Neutral") + "\nI disable all Red text from appearing.";
        pirate.ifLies = "";
        pirate.notes = "";
        pirate.picking = false;
        pirate.startingAlignment = NeutralAlignement.Neutral;
        pirate.type = NeutralType.Neutral;
        pirate.abilityUsage = EAbilityUsage.Once;
        pirate.bluffable = false;
        pirate.characterId = "Pirate_POW";
        pirate.artBgColor = new Color(0.3679f, 0.2014f, 0.1541f);
        pirate.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        pirate.cardBorderColor = new Color(0.7843f, 0.6471f, 0f);
        pirate.color = new Color(0.8510f, 0.4549f, 0.0f);
        pirate.additionalFlavorTexts = new Il2CppStringArray(1);
        pirate.additionalFlavorTexts[0] = pirate.flavorText;
        pirate.gender = EGender.Male;

        Il2Cpp.CharacterData cs = new Il2Cpp.CharacterData();
        cs.role = new CursedSoul();
        cs.name = "Actress";
        cs.characterName = "Actress";
        cs.description = $"I bluff as in in-play card. If I am good, the other card lies. If I am evil, I lie.";
        cs.flavorText = "\"Your story is but a script, the world nothing other than a stage.\"";
        cs.hints = customHint("Alignment Hint", "Neutral");
        cs.ifLies = "";
        cs.notes = "";
        cs.picking = false;
        cs.startingAlignment = NeutralAlignement.Neutral;
        cs.type = NeutralType.Neutral;
        cs.abilityUsage = EAbilityUsage.Once;
        cs.bluffable = false;
        cs.characterId = "Actress_POW";
        cs.artBgColor = new Color(0.3679f, 0.2014f, 0.1541f);
        cs.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        cs.cardBorderColor = new Color(0.7843f, 0.6471f, 0f);
        cs.color = new Color(0.8510f, 0.4549f, 0.0f);
        cs.additionalFlavorTexts = new Il2CppStringArray(1);
        cs.additionalFlavorTexts[0] = cs.flavorText;
        cs.gender = EGender.Female;

        Il2Cpp.CharacterData apprentice = new Il2Cpp.CharacterData();
        apprentice.role = new Apprentice();
        apprentice.name = "Apprentice";
        apprentice.characterName = "Apprentice";
        apprentice.description = "I become a random in-play Villager or Minion";
        apprentice.flavorText = "\"Likes to learn from everything. \nIncluding Demons...\"";
        apprentice.hints = customHint("Alignment Hint", "Neutral");
        apprentice.ifLies = "";
        apprentice.notes = "";
        apprentice.picking = false;
        apprentice.startingAlignment = NeutralAlignement.Neutral;
        apprentice.type = NeutralType.Neutral;
        apprentice.abilityUsage = EAbilityUsage.Once;
        apprentice.bluffable = false;
        apprentice.characterId = "Apprentice_POW";
        apprentice.artBgColor = new Color(0.3679f, 0.2014f, 0.1541f);
        apprentice.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        apprentice.cardBorderColor = new Color(0.7843f, 0.6471f, 0f);
        apprentice.color = new Color(0.8510f, 0.4549f, 0.0f);
        apprentice.additionalFlavorTexts = new Il2CppStringArray(1);
        apprentice.additionalFlavorTexts[0] = apprentice.flavorText;
        apprentice.gender = EGender.Male;

        Il2Cpp.CharacterData godfather = new Il2Cpp.CharacterData();
        godfather.role = new Godfather();
        godfather.name = "Advisor";
        godfather.characterName = "Advisor";
        godfather.description = $"I swap someones {formattedKeyText("Alignment")} to my own.";
        godfather.flavorText = "\"Look man... you ain't gonna survive with em.\nMy group though? Assured success!\"";
        godfather.hints = customHint("Alignment Hint", "Neutral") + $"\n I can only change Minions or Villagers.\n Swapped Villagers lie and swapped Minions do not lie.";
        godfather.ifLies = "";
        godfather.notes = "";
        godfather.picking = false;
        godfather.startingAlignment = NeutralAlignement.Neutral;
        godfather.type = NeutralType.Neutral;
        godfather.abilityUsage = EAbilityUsage.Once;
        godfather.bluffable = false;
        godfather.characterId = "Godfather_POW";
        godfather.artBgColor = new Color(0.3679f, 0.2014f, 0.1541f);
        godfather.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        godfather.cardBorderColor = new Color(0.7843f, 0.6471f, 0f);
        godfather.color = new Color(0.8510f, 0.4549f, 0.0f);
        godfather.additionalFlavorTexts = new Il2CppStringArray(1);
        godfather.additionalFlavorTexts[0] = godfather.flavorText;
        godfather.gender = EGender.Male;

        Il2Cpp.CharacterData psycho = new Il2Cpp.CharacterData();
        psycho.role = new Psychopath();
        psycho.name = "Psychopath";
        psycho.characterName = "Psychopath";
        psycho.description = $"I kill at night, dealing 2 {formattedKeyText("Damage")} if I am Good and 0 if I am evil. I kill cards opposite of my {formattedKeyText("Alignment")}.\n I disguise.";
        psycho.flavorText = "\"Has a select few targets in mind\nFriendly or Adversary\"";
        psycho.hints = customHint("Alignment Hint", "Neutral") + "\nArt made by Wingidon, based off the Original Psychopath's art. Shoutout to him!";
        psycho.ifLies = "If I am evil, I lie.";
        psycho.notes = "";
        psycho.picking = false;
        psycho.startingAlignment = NeutralAlignement.Neutral;
        psycho.type = NeutralType.Neutral;
        psycho.abilityUsage = EAbilityUsage.Once;
        psycho.bluffable = false;
        psycho.characterId = "Psychopath_POW";
        psycho.artBgColor = new Color(0.3679f, 0.2014f, 0.1541f);
        psycho.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        psycho.cardBorderColor = new Color(0.7843f, 0.6471f, 0f);
        psycho.color = new Color(0.8510f, 0.4549f, 0.0f);
        nightPhase.nightCharactersOrder.Add(psycho);
        psycho.additionalFlavorTexts = new Il2CppStringArray(1);
        psycho.additionalFlavorTexts[0] = psycho.flavorText;
        psycho.gender = EGender.Male;

        Il2Cpp.CharacterData hangman = new Il2Cpp.CharacterData();
        hangman.role = new Hangman();
        hangman.name = "Hangman";
        hangman.characterName = "Hangman";
        hangman.description = $"I point to my Hang Target, and call them Evil\n If I am Good, I am saying truth. \n If I am Evil, I lie.\n Executing the person I point to when I lie deals extra {formattedKeyText("Damage")}.";
        hangman.flavorText = "\"Is always convinced someone is Evil. \n Is sometimes correct \"";
        hangman.hints = customHint("Alignment Hint", "Neutral");
        hangman.ifLies = "";
        hangman.notes = "";
        hangman.picking = false;
        hangman.startingAlignment = NeutralAlignement.Neutral;
        hangman.type = NeutralType.Neutral;
        hangman.abilityUsage = EAbilityUsage.Once;
        hangman.bluffable = false;
        hangman.characterId = "Hangman_POW";
        hangman.artBgColor = new Color(0.3679f, 0.2014f, 0.1541f);
        hangman.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        hangman.cardBorderColor = new Color(0.7843f, 0.6471f, 0f);
        hangman.color = new Color(0.8510f, 0.4549f, 0.0f);
        hangman.additionalFlavorTexts = new Il2CppStringArray(1);
        hangman.additionalFlavorTexts[0] = hangman.flavorText;
        hangman.gender = EGender.Male;

        Il2Cpp.CharacterData scapegoat = new Il2Cpp.CharacterData();
        scapegoat.role = new Scapegoat();
        scapegoat.name = "Scapegoat";
        scapegoat.characterName = "Scapegoat";
        scapegoat.description = $"One character is my Sacrifice, if you kill them I die instead, and you take 5 {formattedKeyText("Damage")} regardless of my {formattedKeyText("Alignment")}.";
        scapegoat.flavorText = "\"DO NOT KILL THEM!!!!\"";
        scapegoat.hints = customHint("Alignment Hint","Neutral");
        scapegoat.ifLies = "";
        scapegoat.notes = "";
        scapegoat.picking = false;
        scapegoat.startingAlignment = NeutralAlignement.Neutral;
        scapegoat.type = NeutralType.Neutral;
        scapegoat.abilityUsage = EAbilityUsage.Once;
        scapegoat.bluffable = false;
        scapegoat.characterId = "Scapegoat_POW";
        scapegoat.artBgColor = new Color(0.3679f, 0.2014f, 0.1541f);
        scapegoat.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        scapegoat.cardBorderColor = new Color(0.7843f, 0.6471f, 0f);
        scapegoat.color = new Color(0.8510f, 0.4549f, 0.0f);
        scapegoat.additionalFlavorTexts = new Il2CppStringArray(1);
        scapegoat.additionalFlavorTexts[0] = scapegoat.flavorText;
        scapegoat.gender = EGender.Male;

        Il2Cpp.CharacterData jester = new Il2Cpp.CharacterData();
        jester.role = new Jester();
        jester.name = "Court Fool";
        jester.characterName = "Court Fool";
        jester.description = $"If you kill me, I kill someone opposing my {formattedKeyText("Alignment")}. \nI lie and disguise. \n I ALWAYS register as Evil and as a Minion";
        jester.flavorText = "\"My job's to entertain and REIGN\"";
        jester.hints = customHint("Alignment Hint", "Neutral");
        jester.ifLies = "";
        jester.notes = "";
        jester.picking = false;
        jester.startingAlignment = NeutralAlignement.Neutral;
        jester.type = NeutralType.Neutral;
        jester.abilityUsage = EAbilityUsage.Once;
        jester.bluffable = false;
        jester.characterId = "Jester_POW";
        jester.artBgColor = new Color(0.3679f, 0.2014f, 0.1541f);
        jester.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        jester.cardBorderColor = new Color(0.7843f, 0.6471f, 0f);
        jester.color = new Color(0.8510f, 0.4549f, 0.0f);
        jester.additionalFlavorTexts = new Il2CppStringArray(1);
        jester.additionalFlavorTexts[0] = jester.flavorText;
        jester.gender = EGender.Male;

        Il2Cpp.CharacterData cov = new Il2Cpp.CharacterData();
        cov.role = new Covenite();
        cov.name = "Covenite";
        cov.characterName = "Covenite";
        cov.description = "I lie and disguise.";
        cov.flavorText = "\"They like the mischief as much as the Underling. \n Less quiet about it.\"";
        cov.hints = "I am the result of a bad Minion interaction between a POWERPLAY demon and another mod. I cannot appear otherwise.";
        cov.ifLies = "";
        cov.notes = "";
        cov.picking = false;
        cov.startingAlignment = EAlignment.Evil;
        cov.type = ECharacterType.Minion;
        cov.abilityUsage = EAbilityUsage.Once;
        cov.bluffable = false;
        cov.characterId = "Covenite_POW";
        cov.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        cov.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        cov.cardBorderColor = new Color(0.8196f, 0.0f, 0.0275f);
        cov.color = new Color(0.8510f, 0.4549f, 0.0f);
        cov.additionalFlavorTexts = new Il2CppStringArray(1);
        cov.additionalFlavorTexts[0] = cov.flavorText;
        cov.gender = EGender.Male;

        Il2Cpp.CharacterData devilsAdvocate = new Il2Cpp.CharacterData();
        devilsAdvocate.role = new DevilsAdvocate();
        devilsAdvocate.name = "Supporter";
        devilsAdvocate.characterName = "Supporter";
        devilsAdvocate.description = $"<b>Whilst Alive:</b>\n The Demon is {formattedKeyText("Protected")}. \n I lie and disguise.";
        devilsAdvocate.flavorText = "\"Has an excellent reason on why the Demon should stay alive. \n Never actually says it.\"";
        devilsAdvocate.hints = customHint("Keyword","Whilst Alive");
        devilsAdvocate.ifLies = "";
        devilsAdvocate.notes = "";
        devilsAdvocate.picking = false;
        devilsAdvocate.startingAlignment = EAlignment.Evil;
        devilsAdvocate.type = ECharacterType.Minion;
        devilsAdvocate.abilityUsage = EAbilityUsage.Once;
        devilsAdvocate.bluffable = false;
        devilsAdvocate.characterId = "Supporter_POW";
        devilsAdvocate.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        devilsAdvocate.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        devilsAdvocate.cardBorderColor = new Color(0.8196f, 0.0f, 0.0275f);
        devilsAdvocate.color = new Color(0.8510f, 0.4549f, 0.0f);
        devilsAdvocate.additionalFlavorTexts = new Il2CppStringArray(1);
        devilsAdvocate.additionalFlavorTexts[0] = devilsAdvocate.flavorText;
        devilsAdvocate.gender = EGender.Male;

        Il2Cpp.CharacterData traveler = new Il2Cpp.CharacterData();
        traveler.role = new Traveler();
        traveler.name = "Traveler";
        traveler.characterName = "Traveler";
        traveler.description = $"One character becomes a {formattedKeyText("Neutral")}. I sit next to a {formattedKeyText("Neutral")}. \n I lie and disguise.";
        traveler.flavorText = "\"He likes bringing his friends.\n His friends arent trustworthy\"";
        traveler.hints = "";
        traveler.ifLies = "";
        traveler.notes = "";
        traveler.picking = false;
        traveler.startingAlignment = EAlignment.Evil;
        traveler.type = ECharacterType.Minion;
        traveler.abilityUsage = EAbilityUsage.Once;
        traveler.bluffable = false;
        traveler.characterId = "Traveler_POW";
        traveler.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        traveler.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        traveler.cardBorderColor = new Color(0.8196f, 0.0f, 0.0275f);
        traveler.color = new Color(0.8510f, 0.4549f, 0.0f);
        traveler.additionalFlavorTexts = new Il2CppStringArray(1);
        traveler.additionalFlavorTexts[0] = traveler.flavorText;
        traveler.gender = EGender.Male;
        traveler.additionalPossibleCharacters = MakeAddedCharacters(0, 1, 0, 0);

        Il2Cpp.CharacterData boomdandy = new Il2Cpp.CharacterData();
        boomdandy.role = new Boomdandy();
        boomdandy.name = "Grenadier";
        boomdandy.characterName = "Grenadier";
        boomdandy.description = $"When Executed, I kill 2 Villagers. I deal 2 {formattedKeyText("Damage")} upon being executed.";
        boomdandy.flavorText = "\"Plays too much with bombs\nIs the Bombardier's brother\"";
        boomdandy.hints = $"If I am the last evil executed, I don't deal 2 {formattedKeyText("Damage")}.";
        boomdandy.ifLies = "";
        boomdandy.notes = "";
        boomdandy.picking = false;
        boomdandy.startingAlignment = EAlignment.Evil;
        boomdandy.type = ECharacterType.Minion;
        boomdandy.abilityUsage = EAbilityUsage.Once;
        boomdandy.bluffable = false;
        boomdandy.characterId = "Grenadier_POW";
        boomdandy.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        boomdandy.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        boomdandy.cardBorderColor = new Color(0.8196f, 0.0f, 0.0275f);
        boomdandy.color = new Color(0.8510f, 0.4549f, 0.0f);
        boomdandy.additionalFlavorTexts = new Il2CppStringArray(1);
        boomdandy.additionalFlavorTexts[0] = boomdandy.flavorText;
        boomdandy.gender = EGender.Male;

        Il2Cpp.CharacterData cerenovus = new Il2Cpp.CharacterData();
        cerenovus.role = new Cerenovus();
        cerenovus.name = "Manipulator";
        cerenovus.characterName = "Manipulator";
        cerenovus.description = $"One Good card is {formattedKeyText("Mad")}. \n I lie and disguise.";
        cerenovus.flavorText = "\"You aren't really accepted here. \nBelieve me, I have heard stuff.\"";
        cerenovus.hints = $"";
        cerenovus.ifLies = "";
        cerenovus.notes = "";
        cerenovus.picking = false;
        cerenovus.startingAlignment = EAlignment.Evil;
        cerenovus.type = ECharacterType.Minion;
        cerenovus.abilityUsage = EAbilityUsage.Once;
        cerenovus.bluffable = false;
        cerenovus.characterId = "Manipulator_POW";
        cerenovus.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        cerenovus.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        cerenovus.cardBorderColor = new Color(0.8196f, 0.0f, 0.0275f);
        cerenovus.color = new Color(0.8510f, 0.4549f, 0.0f);
        cerenovus.additionalFlavorTexts = new Il2CppStringArray(1);
        cerenovus.additionalFlavorTexts[0] = cerenovus.flavorText;
        cerenovus.gender = EGender.Male;

        Il2Cpp.CharacterData butcher = new Il2Cpp.CharacterData();
        butcher.role = new Butcher();
        butcher.name = "Balancer";
        butcher.characterName = "Balancer";
        butcher.description = $"<b>Whilst Alive:</b>\nEach time you execute, I kill a good character, dealing 1 {formattedKeyText("Damage")}.";
        butcher.flavorText = "\"Eye for an eye is his motto. \nHasn't gone blind yet\"";
        butcher.hints = customHint("Keyword", "Whilst Alive");
        butcher.ifLies = "";
        butcher.notes = "";
        butcher.picking = false;
        butcher.startingAlignment = EAlignment.Evil;
        butcher.type = ECharacterType.Minion;
        butcher.abilityUsage = EAbilityUsage.Once;
        butcher.bluffable = false;
        butcher.characterId = "Balancer_POW";
        butcher.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        butcher.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        butcher.cardBorderColor = new Color(0.8196f, 0.0f, 0.0275f);
        butcher.color = new Color(0.8510f, 0.4549f, 0.0f);
        butcher.additionalFlavorTexts = new Il2CppStringArray(1);
        butcher.additionalFlavorTexts[0] = butcher.flavorText;
        butcher.gender = EGender.Male;

        Il2Cpp.CharacterData gTwin = new Il2Cpp.CharacterData();
        gTwin.role = new GoodTwin();
        gTwin.name = "Good Twin";
        gTwin.characterName = "Good Twin";
        gTwin.description = $"I point at the {roleColour("Minion")}Evil Twin</color>";
        gTwin.flavorText = "\"It's the other one I swear!\"";
        gTwin.hints = customHint("Interactions", "Good Minion");
        gTwin.ifLies = "";
        gTwin.notes = "";
        gTwin.picking = false;
        gTwin.startingAlignment = EAlignment.Good;
        gTwin.type = ECharacterType.Minion;
        gTwin.abilityUsage = EAbilityUsage.Once;
        gTwin.bluffable = false;
        gTwin.characterId = "GoodTwin_POW";
        gTwin.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        gTwin.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        gTwin.cardBorderColor = new Color(0.8196f, 0.0f, 0.0275f);
        gTwin.color = new Color(0.8510f, 0.4549f, 0.0f);
        gTwin.additionalFlavorTexts = new Il2CppStringArray(1);
        gTwin.additionalFlavorTexts[0] = gTwin.flavorText;
        gTwin.doNotCountAsEvilForUi = true;
        gTwin.gender = EGender.Female;

        Il2Cpp.CharacterData eTwin = new Il2Cpp.CharacterData();
        eTwin.role = new EvilTwin();
        eTwin.name = "Evil Twin";
        eTwin.characterName = "Evil Twin";
        eTwin.description = $"<b>Setup</b>: \nI turn a random Villager into the {roleColour("GoodMinion")}Good Twin</color>. \nI disguise as the {roleColour("GoodMinion")}Good Twin</color> and point at her";
        eTwin.flavorText = "\"It's the other one I swear!\"";
        eTwin.hints = customHint("Keyword", "Setup");
        eTwin.ifLies = "";
        eTwin.notes = "";
        eTwin.picking = false;
        eTwin.startingAlignment = EAlignment.Evil;
        eTwin.type = ECharacterType.Minion;
        eTwin.abilityUsage = EAbilityUsage.Once;
        eTwin.bluffable = false;
        eTwin.characterId = "EvilTwin_POW";
        eTwin.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        eTwin.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        eTwin.cardBorderColor = new Color(0.8196f, 0.0f, 0.0275f);
        eTwin.color = new Color(0.8510f, 0.4549f, 0.0f);
        eTwin.additionalFlavorTexts = new Il2CppStringArray(1);
        eTwin.additionalFlavorTexts[0] = eTwin.flavorText;
        eTwin.gender = EGender.Female;
        eTwin.additionalPossibleCharacters = MakeAddedCharacters(0, 0, 1, 0);

        Il2Cpp.CharacterData crazed = new Il2Cpp.CharacterData();
        crazed.role = new Crazed();
        crazed.name = "Crazed";
        crazed.characterName = "Crazed";
        crazed.description = $"<b>Game Start</b>:\nAll Villagers and Outcasts are {formattedKeyText("Mad")}. \nI lie and disguise.";
        crazed.flavorText = "\"I'm you, you, you\"";
        crazed.hints = "";
        crazed.ifLies = "";
        crazed.notes = "";
        crazed.picking = false;
        crazed.startingAlignment = EAlignment.Evil;
            crazed.type = ECharacterType.Demon;
        crazed.abilityUsage = Il2Cpp.EAbilityUsage.Once;
        crazed.bluffable = false;
        crazed.characterId = "Crazed_POW";
        crazed.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        crazed.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        crazed.cardBorderColor = new Color(0.8196f, 0.0f, 0.0275f);
        crazed.color = new Color(1f, 0.3804f, 0.3804f);
        crazed.additionalFlavorTexts = new Il2CppStringArray(1);
        crazed.additionalFlavorTexts[0] = crazed.flavorText;
        crazed.gender = EGender.Male;

        Il2Cpp.CharacterData court = new Il2Cpp.CharacterData();
        court.role = new Court();
        court.name = "Court";
        court.characterName = "Court";
        court.description = $"<b>Setup:</b> \nAll Good cards turn into the {roleColour("Villager")}Juror</color>. \n All Evils turn into the {roleColour("Demon")}Court</color>. \nI lie and disguise as the {roleColour("Villager")}Juror</color>.";
        court.flavorText = "\"Empress, Emperor, Clown, Riddler, Plaguebearer. \nNothing but meaningless titles in his court.\"";
        court.hints = customHint("Keyword","Setup");
        court.ifLies = "";
        court.notes = "";
        court.picking = false;
        court.startingAlignment = EAlignment.Evil;
        court.type = ECharacterType.Demon;
        court.abilityUsage = Il2Cpp.EAbilityUsage.Once;
        court.bluffable = false;
        court.characterId = "Court_POW";
        court.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        court.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        court.cardBorderColor = new Color(0.8196f, 0.0f, 0.0275f);
        court.color = new Color(1f, 0.3804f, 0.3804f);
        court.additionalFlavorTexts = new Il2CppStringArray(1);
        court.additionalFlavorTexts[0] = court.flavorText;
        court.gender = EGender.Male;

        Il2Cpp.CharacterData juror = new Il2Cpp.CharacterData();
        juror.role = new Juror();
        juror.name = "Juror";
        juror.characterName = "Juror";
        juror.description = "Learn a card is either Innocent or Guilty. Innocent means Good and Guilty means Evil.\n I only spawn when Court is in session.";
        juror.flavorText = "\"We are but one of many\"";
        juror.hints = "";
        juror.ifLies = "Learn the opposite statement ";
        juror.notes = "";
        juror.picking = false;
        juror.startingAlignment = EAlignment.Good;
        juror.type = ECharacterType.Villager;
        juror.abilityUsage = EAbilityUsage.Once;
        juror.bluffable = true;
        juror.characterId = "Juror_POW";
        juror.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        juror.cardBgColor = new Color(0.26f, 0.1519f, 0.3396f);
        juror.cardBorderColor = new Color(0.7133f, 0.339f, 0.8679f);
        juror.color = new Color(1f, 0.935f, 0.7302f);
        juror.additionalFlavorTexts = new Il2CppStringArray(1);
        juror.additionalFlavorTexts[0] = jailor.flavorText;
        juror.gender = EGender.Male;

        Il2Cpp.CharacterData audi = new Il2Cpp.CharacterData();
        audi.role = new Auditor();
        audi.name = "Auditor";
        audi.characterName = "Auditor";
        audi.description = $"<b>Game Start</b>:\nI turn one good Villager into the {roleColour("Outcast")}Repossessed</color>. Two others are Corrupted. \nI lie and disguise.";
        audi.flavorText = "\"The Auditor has reported you for tax evasion.\"";
        audi.hints = "";
        audi.ifLies = "";
        audi.notes = "";
        audi.picking = false;
        audi.startingAlignment = EAlignment.Evil;
        audi.type = ECharacterType.Demon;
        audi.abilityUsage = Il2Cpp.EAbilityUsage.Once;
        audi.bluffable = false;
        audi.characterId = "Auditor_POW";
        audi.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        audi.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        audi.cardBorderColor = new Color(0.8196f, 0.0f, 0.0275f);
        audi.color = new Color(1f, 0.3804f, 0.3804f);
        audi.additionalFlavorTexts = new Il2CppStringArray(1);
        audi.additionalFlavorTexts[0] = audi.flavorText;
        audi.gender = EGender.Male;
        audi.additionalPossibleCharacters = MakeAddedCharacters(0, 1, 0, 0);

        Il2Cpp.CharacterData star = new Il2Cpp.CharacterData();
        star.role = new Starspawn();
        star.name = "Starspawn";
        star.characterName = "Starspawn";
        star.description = $"3 cards at random have {formattedKeyText("Unknown Obstacle")}. \nI lie and disguise. \n <b>When Executed</b>: \nAll cards with {formattedKeyText("Unknown Obstacle")} become revealable.";
        star.flavorText = "\"The being of above calls for endless night.\"";
        star.hints = "";
        star.ifLies = "";
        star.notes = "";
        star.picking = false;
        star.startingAlignment = EAlignment.Evil;
        star.type = ECharacterType.Demon;
        star.abilityUsage = Il2Cpp.EAbilityUsage.Once;
        star.bluffable = false;
        star.characterId = "Starspawn_POW";
        star.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        star.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        star.cardBorderColor = new Color(0.8196f, 0.0f, 0.0275f);
        star.color = new Color(1f, 0.3804f, 0.3804f);
        star.additionalFlavorTexts = new Il2CppStringArray(1);
        star.additionalFlavorTexts[0] = star.flavorText;
        star.gender = EGender.Female;

        Il2Cpp.CharacterData repo = new Il2Cpp.CharacterData();
        repo.role = new Repossessed();
        repo.name = "Repossessed";
        repo.characterName = "Repossessed";
        repo.description = $"I can only be created due to the {roleColour("Demon")}Auditor</color>. I point at the two corrupted and {roleColour("Demon")}Auditor</color>.";
        repo.flavorText = "\"Didnt pay the house in time.\nFeels less homely.\"";
        repo.hints = "";
        repo.ifLies = "";
        repo.notes = "";
        repo.picking = false;
        repo.startingAlignment = EAlignment.Good;
        repo.type = ECharacterType.Outcast;
        repo.abilityUsage = EAbilityUsage.Once;
        repo.bluffable = false;
        repo.characterId = "Repossessed_POW";
        repo.artBgColor = new Color(0.3679f, 0.2014f, 0.1541f);
        repo.cardBgColor = new Color(0.102f, 0.0667f, 0.0392f);
        repo.cardBorderColor = new Color(0.7843f, 0.6471f, 0f);
        repo.color = new Color(0.9659f, 1f, 0.4472f);
        repo.additionalFlavorTexts = new Il2CppStringArray(1);
        repo.additionalFlavorTexts[0] = repo.flavorText;
        repo.gender = EGender.Male;

        Il2Cpp.CharacterData vortox = new Il2Cpp.CharacterData();
        vortox.role = new Vortox();
        vortox.name = "Vortox";
        vortox.characterName = "Vortox";
        vortox.description = $"I cast a random {formattedKeyText("Weather")}.\nI lie and disguise.";
        vortox.flavorText = "\"WOOSH WOOSH WOOSH WOOSH\"";
        vortox.hints = "";
        vortox.ifLies = "";
        vortox.notes = "";
        vortox.picking = false;
        vortox.startingAlignment = EAlignment.Evil;
        vortox.type = ECharacterType.Demon;
        vortox.abilityUsage = Il2Cpp.EAbilityUsage.Once;
        vortox.bluffable = false;
        vortox.characterId = "Vortox_POW";
        vortox.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        vortox.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        vortox.cardBorderColor = new Color(0.8196f, 0.0f, 0.0275f);
        vortox.color = new Color(1f, 0.3804f, 0.3804f);
        vortox.additionalFlavorTexts = new Il2CppStringArray(1);
        vortox.additionalFlavorTexts[0] = vortox.flavorText;
        vortox.gender = EGender.Male;
        vortox.additionalPossibleCharacters = MakeAddedCharacters(0, 2, 0, 0);

        Il2Cpp.CharacterData pestilence = new Il2Cpp.CharacterData();
        pestilence.role = new Pestilence();
        pestilence.name = "Pestilence";
        pestilence.characterName = "Pestilence";
        pestilence.description = $"Every Villager has a 80% chance of being Corrupted.\n<b>At Night</b>: I kill all revealed {formattedKeyText("Damage")} cards, dealing 1 damage each.";
        pestilence.flavorText = "\"I came to look upon it with unutterable loathing,\n and to flee silently from its odious presence, as from the breath of a pestilence. \n - Edgar Allen Poe\"";
        pestilence.hints = "One card is Immune, meaning they cannot be corrupted";
        pestilence.ifLies = "";
        pestilence.notes = "";
        pestilence.picking = false;
        pestilence.startingAlignment = EAlignment.Evil;
        pestilence.type = ECharacterType.Demon;
        pestilence.abilityUsage = Il2Cpp.EAbilityUsage.Once;
        pestilence.bluffable = false;
        pestilence.characterId = "Pestilence_POW";
        pestilence.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        pestilence.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        pestilence.cardBorderColor = new Color(0.8196f, 0.0f, 0.0275f);
        pestilence.color = new Color(1f, 0.3804f, 0.3804f);
        nightPhase.nightCharactersOrder.Add(pestilence);
        pestilence.additionalFlavorTexts = new Il2CppStringArray(1);
        pestilence.additionalFlavorTexts[0] = pestilence.flavorText;
        pestilence.gender = EGender.Male;

        Il2Cpp.CharacterData famine = new Il2Cpp.CharacterData();
        famine.role = new Famine();
        famine.name = "Famine";
        famine.characterName = "Famine";
        famine.description = $"5 Good cards become {formattedKeyText("Starved")}.\n<b>When Executed</b>:\nI kill all revealed {formattedKeyText("Starved")} cards, dealing 2 {formattedKeyText("Damage")} each.";
        famine.flavorText = "\"They that die by famine die by inches.\n -Matthew Henry\"";
        famine.hints = "";
        famine.ifLies = "";
        famine.notes = "";
        famine.picking = false;
        famine.startingAlignment = EAlignment.Evil;
        famine.type = ECharacterType.Demon;
        famine.abilityUsage = Il2Cpp.EAbilityUsage.Once;
        famine.bluffable = false;
        famine.characterId = "Famine_POW";
        famine.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        famine.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        famine.cardBorderColor = new Color(0.8196f, 0.0f, 0.0275f);
        famine.color = new Color(1f, 0.3804f, 0.3804f);
        famine.additionalFlavorTexts = new Il2CppStringArray(1);
        famine.additionalFlavorTexts[0] = famine.flavorText;
        famine.gender = EGender.Male;

        Il2Cpp.CharacterData war = new Il2Cpp.CharacterData();
        war.role = new War();
        war.name = "War";
        war.characterName = "War";
        war.description = $"<b>At Night</b>:\n I kill 2 cards, dealing 2 {formattedKeyText("Damage")}. \n Outcasts and Minions are far more abundant.";
        war.flavorText = "\"I came.\nI saw.\nI conquered. \n - Julius Ceasar\"";
        war.hints = "";
        war.ifLies = "";
        war.notes = "";
        war.picking = false;
        war.startingAlignment = EAlignment.Evil;
        war.type = ECharacterType.Demon;
        war.abilityUsage = Il2Cpp.EAbilityUsage.Once;
        war.bluffable = false;
        war.characterId = "War_POW";
        war.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        war.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        war.cardBorderColor = new Color(0.8196f, 0.0f, 0.0275f);
        war.color = new Color(1f, 0.3804f, 0.3804f);
        nightPhase.nightCharactersOrder.Add(war);
        war.additionalFlavorTexts = new Il2CppStringArray(1);
        war.additionalFlavorTexts[0] = war.flavorText;
        war.gender = EGender.Male;

        Il2Cpp.CharacterData death = new Il2Cpp.CharacterData();
        death.role = new Death();
        death.name = "Death";
        death.characterName = "Death";
        death.description = "You have one day.\nBest of luck.";
        death.flavorText = "\"I have become Death, Destroyer of Worlds\n - J. Robert Oppenheimer\"";
        death.hints = "One thing: Death cannot hide.";
        death.ifLies = "";
        death.notes = "";
        death.picking = false;
        death.startingAlignment = EAlignment.Evil;
        death.type = ECharacterType.Demon;
        death.abilityUsage = Il2Cpp.EAbilityUsage.Once;
        death.bluffable = false;
        death.characterId = "Death_POW";
        death.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        death.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        death.cardBorderColor = new Color(0.8196f, 0.0f, 0.0275f);
        death.color = new Color(1f, 0.3804f, 0.3804f);
        nightPhase.nightCharactersOrder.Add(death);
        death.additionalFlavorTexts = new Il2CppStringArray(1);
        death.additionalFlavorTexts[0] = death.flavorText;
        death.gender = EGender.Male;

        Il2Cpp.CharacterData grunt = new Il2Cpp.CharacterData();
        grunt.role = new Grunt();
        grunt.name = "Grunt";
        grunt.characterName = "Grunt";
        grunt.description = $"I lie and disguise.";
        grunt.flavorText = "\"Just a standard Grunt\"";
        grunt.hints = customHint("Alignment Hint", "Mafia Member");
        grunt.ifLies = "";
        grunt.notes = "";
        grunt.picking = false;
        if (configCategory.GetEntry<bool>("AllowMafia").Value)
       
         grunt.startingAlignment = EAlignment.Evil;
        grunt.type = ECharacterType.Minion;
       
        grunt.abilityUsage = EAbilityUsage.Once;
        grunt.bluffable = false;
        grunt.characterId = "Grunt_POW";
        grunt.artBgColor = new Color(0.1098f, 0.0824f, 0.1412f);
        grunt.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        grunt.cardBorderColor = new Color(0.9216f, 0.149f, 0.5412f);
        grunt.color = new Color(0.8902f, 0.0902f, 0.451f);
        grunt.additionalFlavorTexts = new Il2CppStringArray(1);
        grunt.additionalFlavorTexts[0] = grunt.flavorText;
        grunt.gender = EGender.Female;

        Il2Cpp.CharacterData jinx = new Il2Cpp.CharacterData();
        jinx.role = new Ambusher();
        jinx.name = "Ambusher";
        jinx.characterName = "Ambusher";
        jinx.description = $"<b>Game Start</b>:\nOne character is {formattedKeyText("Jinxed")}. If they are revealed, they die.";
        jinx.flavorText = "\"Spends a long time preparing an ambush.\nKills one person per year.\"";
        jinx.hints = customHint("Alignment Hint", "Mafia Member"); ;
        jinx.ifLies = "";
        jinx.notes = "";
        jinx.picking = false;
        
            jinx.startingAlignment = EAlignment.Evil;
            jinx.type = ECharacterType.Minion;
       
            jinx.abilityUsage = EAbilityUsage.Once;
        jinx.bluffable = false;
        jinx.characterId = "Jinx_POW";
        jinx.artBgColor = new Color(0.1098f, 0.0824f, 0.1412f);
        jinx.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        jinx.cardBorderColor = new Color(0.9216f, 0.149f, 0.5412f);
        jinx.color = new Color(0.8902f, 0.0902f, 0.451f);
        jinx.additionalFlavorTexts = new Il2CppStringArray(1);
        jinx.additionalFlavorTexts[0] = jinx.flavorText;
        jinx.gender = EGender.Male;

        Il2Cpp.CharacterData enforcer = new Il2Cpp.CharacterData();
        enforcer.role = new Enforcer();
        enforcer.name = "Enforcer";
        enforcer.characterName = "Enforcer";
        enforcer.description = $"<b>Game Start</b>:\nI cast {formattedKeyText("Unknown Obstacle")} on a random card.";
        enforcer.flavorText = "\"The Bishop? Ah that guy? \n Don't try it. She won't talk.\"";
        enforcer.hints = customHint("Alignment Hint", "Mafia Member"); ;
        enforcer.ifLies = "";
        enforcer.notes = "";
        enforcer.picking = false;
       
            enforcer.startingAlignment = EAlignment.Evil;
            enforcer.type = ECharacterType.Minion;
       
        enforcer.abilityUsage = EAbilityUsage.Once;
        enforcer.bluffable = false;
        enforcer.characterId = "Enforcer_POW";
        enforcer.artBgColor = new Color(0.1098f, 0.0824f, 0.1412f);
        enforcer.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        enforcer.cardBorderColor = new Color(0.9216f, 0.149f, 0.5412f);
        enforcer.color = new Color(0.8902f, 0.0902f, 0.451f);
        enforcer.additionalFlavorTexts = new Il2CppStringArray(1);
        enforcer.additionalFlavorTexts[0] = enforcer.flavorText;
        enforcer.gender = EGender.Male;

        Il2Cpp.CharacterData forger = new Il2Cpp.CharacterData();
        forger.role = new Forger();
        forger.name = "Forger";
        forger.characterName = "Forger";
        forger.description = $"<b>Game Start</b>:\nI swap the registered roles of an Evil and a Good card. \n I lie and disguise.";
        forger.flavorText = "\"A Lawyer that mastered how to forge signatures. \n The Mafia loves the girl.\"";
        forger.hints = customHint("Alignment Hint", "Mafia Member"); ;
        forger.ifLies = "";
        forger.notes = "";
        forger.picking = false;
            forger.startingAlignment = EAlignment.Evil;
            forger.type = ECharacterType.Minion;
        
        forger.abilityUsage = EAbilityUsage.Once;
        forger.bluffable = false;
        forger.characterId = "Forger_POW";
        forger.artBgColor = new Color(0.1098f, 0.0824f, 0.1412f);
        forger.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        forger.cardBorderColor = new Color(0.9216f, 0.149f, 0.5412f);
        forger.color = new Color(0.8902f, 0.0902f, 0.451f);
        forger.additionalFlavorTexts = new Il2CppStringArray(1);
        forger.additionalFlavorTexts[0] = forger.flavorText;
        forger.gender = EGender.Female;

        Il2Cpp.CharacterData gangster = new Il2Cpp.CharacterData();
        gangster.role = new Gangster();
        gangster.name = "Gangster";
        gangster.characterName = "Gangster";
        gangster.description = $"<b>At Night</b>:\n if I am adjacent to only one {formattedKeyText("Mafia")}, I kill my non-{formattedKeyText("Mafia")} Neighbor, dealing 3 {formattedKeyText("Damage")}.";
        gangster.flavorText = "\"I'll take care of it. \n No problem!\"";
        gangster.hints = customHint("Alignment Hint", "Mafia Member"); ;
        gangster.ifLies = "";
        gangster.notes = "";
        gangster.picking = false;

            gangster.startingAlignment = EAlignment.Evil;
            gangster.type = ECharacterType.Minion;
        
        gangster.abilityUsage = EAbilityUsage.Once;
        gangster.bluffable = false;
        gangster.characterId = "Gangster_POW";
        gangster.artBgColor = new Color(0.1098f, 0.0824f, 0.1412f);
        gangster.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        gangster.cardBorderColor = new Color(0.9216f, 0.149f, 0.5412f);
        gangster.color = new Color(0.8902f, 0.0902f, 0.451f);
        nightPhase.nightCharactersOrder.Add(gangster);
        gangster.additionalFlavorTexts = new Il2CppStringArray(1);
        gangster.additionalFlavorTexts[0] = gangster.flavorText;
        gangster.gender = EGender.Male;

        Il2Cpp.CharacterData cons = new Il2Cpp.CharacterData();
        cons.role = new Consort();
        cons.name = "Influencer";
        cons.characterName = "Influencer";
        cons.description = "<b>Game Start</b>:\nA random villager is Corrupted and registers as Disguised. \n I lie and disguise";
        cons.flavorText = "\"She knows she's pretty. \n Uses it to manipulate the men around her.\"";
        cons.hints = customHint("Alignment Hint", "Mafia Member"); ;
        cons.ifLies = "";
        cons.notes = "";
        cons.picking = false;
     
            cons.startingAlignment = EAlignment.Evil;
            cons.type = ECharacterType.Minion;
        
        cons.abilityUsage = EAbilityUsage.Once;
        cons.bluffable = false;
        cons.characterId = "Influencer_POW";
        cons.artBgColor = new Color(0.1098f, 0.0824f, 0.1412f);
        cons.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        cons.cardBorderColor = new Color(0.9216f, 0.149f, 0.5412f);
        cons.color = new Color(0.8902f, 0.0902f, 0.451f);
        cons.additionalFlavorTexts = new Il2CppStringArray(1);
        cons.additionalFlavorTexts[0] = cons.flavorText;
        cons.gender = EGender.Female;

        Il2Cpp.CharacterData bootlegger = new Il2Cpp.CharacterData();
        bootlegger.role = new Bootlegger();
        bootlegger.name = "Bootlegger";
        bootlegger.characterName = "Bootlegger";
        bootlegger.description = $"<b>Game Start</b>:\nTwo cards are {formattedKeyText("Intoxicated")}. \nI lie and disguise.";
        bootlegger.flavorText = "\"Makes amazing drinks. \n The Winemaker is jealous of her.\"";
        bootlegger.hints = customHint("Alignment Hint", "Mafia Member") + $"\nI prioritize {formattedKeyText("Intoxicating")} on-pick cards.";
        bootlegger.ifLies = "";
        bootlegger.notes = "";
        bootlegger.picking = false;
 
            bootlegger.startingAlignment = EAlignment.Evil;
            bootlegger.type = ECharacterType.Minion;
        
        bootlegger.abilityUsage = EAbilityUsage.Once;
        bootlegger.bluffable = false;
        bootlegger.characterId = "Bootlegger_POW";
        bootlegger.artBgColor = new Color(0.1098f, 0.0824f, 0.1412f);
        bootlegger.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        bootlegger.cardBorderColor = new Color(0.9216f, 0.149f, 0.5412f);
        bootlegger.color = new Color(0.8902f, 0.0902f, 0.451f);
        bootlegger.additionalFlavorTexts = new Il2CppStringArray(1);
        bootlegger.additionalFlavorTexts[0] = bootlegger.flavorText;
        bootlegger.gender = EGender.Female;

        Il2Cpp.CharacterData spoke = new Il2Cpp.CharacterData();
        spoke.role = new Spokesperson();
        spoke.name = "Spokesperson";
        spoke.characterName = "Spokesperson";
        spoke.description = $"<b>Game Start</b>:\nOne villager turns into an Outcast. \n<b>At Night</b>:\nIf any Outcasts are dead, dealing 2 {formattedKeyText("Damage")}. \nI lie and disguise.";
        spoke.flavorText = "\"Look, they might be shunned...\n But they are still important assets yes?\"";
        spoke.hints = customHint("Alignment Hint", "Mafia Member");
        spoke.ifLies = "";
        spoke.notes = "";
        spoke.picking = false;

            spoke.startingAlignment = EAlignment.Evil;
            spoke.type = ECharacterType.Minion;
        
        spoke.abilityUsage = EAbilityUsage.Once;
        spoke.bluffable = false;
        spoke.characterId = "Spokesperson_POW";
        spoke.artBgColor = new Color(0.1098f, 0.0824f, 0.1412f);
        spoke.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        spoke.cardBorderColor = new Color(0.9216f, 0.149f, 0.5412f);
        spoke.color = new Color(0.8902f, 0.0902f, 0.451f);
        spoke.additionalFlavorTexts = new Il2CppStringArray(1);
        spoke.additionalFlavorTexts[0] = spoke.flavorText;
        spoke.additionalPossibleCharacters = MakeAddedCharacters(0, 1, 0, 0);
        spoke.gender = EGender.Male;

        Il2Cpp.CharacterData gf2 = new Il2Cpp.CharacterData();
        gf2.role = new Godfather2();
        gf2.name = "Godfather";
        gf2.characterName = "Godfather";
        gf2.description = $"<b>Game Start</b>:\nI turn a neighbor into a {formattedKeyText("Mafia")} Member.\nI lie and disguise.";
        gf2.flavorText = "\"Son... are the bad townies threatening you?\nWell... my family never judges each other.\"";
        gf2.hints = customHint("Alignment Hint", "Mafia Leader");
        gf2.ifLies = "";
        gf2.notes = "";
        gf2.picking = false;
        gf2.startingAlignment = EAlignment.Evil;
        gf2.type = ECharacterType.Demon;
        gf2.abilityUsage = Il2Cpp.EAbilityUsage.Once;
        gf2.bluffable = false;
        gf2.characterId = "Godfather2_POW";
        gf2.artBgColor = new Color(0.1098f, 0.0824f, 0.1412f);
        gf2.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        gf2.cardBorderColor = new Color(0.9216f, 0.149f, 0.5412f);
        gf2.color = new Color(0.8902f, 0.0902f, 0.451f);
        gf2.additionalFlavorTexts = new Il2CppStringArray(1);
        gf2.additionalFlavorTexts[0] = gf2.flavorText;
        gf2.gender = EGender.Male;
        
        Il2Cpp.CharacterData mafio = new Il2Cpp.CharacterData();
        mafio.role = new Mafioso();
        mafio.name = "Mafioso";
        mafio.characterName = "Mafioso";
        mafio.description = $"<b>At Night</b>:\n I kill a card dealing 1 {formattedKeyText("Damage")}. Night is 2 turns instead of 4 turns. \n I lie and disguise.";
        mafio.flavorText = "\"Loyal to a fault. \n Never ever betrayed the boss.\"";
        mafio.hints = customHint("Alignment Hint", "Mafia Leader");
        mafio.ifLies = "";
        mafio.notes = "";
        mafio.picking = false;
        mafio.startingAlignment = EAlignment.Evil;
        mafio.type = ECharacterType.Demon;
        mafio.abilityUsage = Il2Cpp.EAbilityUsage.Once;
        mafio.bluffable = false;
        mafio.characterId = "Mafioso_POW";
        mafio.artBgColor = new Color(0.1098f, 0.0824f, 0.1412f);
        mafio.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        mafio.cardBorderColor = new Color(0.9216f, 0.149f, 0.5412f);
        mafio.color = new Color(0.8902f, 0.0902f, 0.451f);
        nightPhase.nightCharactersOrder.Add(mafio);
        mafio.additionalFlavorTexts = new Il2CppStringArray(1);
        mafio.additionalFlavorTexts[0] = mafio.flavorText;
        mafio.gender = EGender.Male;

        Il2Cpp.CharacterData cultM = new Il2Cpp.CharacterData();
        cultM.role = new CultMember();
        cultM.name = "Cult Member";
        cultM.characterName = "Cult Member";
        cultM.description = $"I lie and disguise.";
        cultM.flavorText = "\"A basic Cult Member to keep the Covenant supplied\"";
        cultM.hints = customHint("Alignment Hint", "Covenant Follower");
        cultM.ifLies = "";
        cultM.notes = "";
        cultM.picking = false;
       
        cultM.startingAlignment = EAlignment.Evil;
        cultM.type = ECharacterType.Minion;
        
        cultM.abilityUsage = EAbilityUsage.Once;
        cultM.bluffable = false;
        cultM.characterId = "CultMember_POW";
        cultM.artBgColor = new Color(0.541f, 0.224f, 0.659f);
        cultM.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        cultM.cardBorderColor = new Color(0.51f, 0.173f, 0.612f);
        cultM.color = new Color(0.455f, 0.129f, 0.541f);
        cultM.additionalFlavorTexts = new Il2CppStringArray(1);
        nightPhase.nightCharactersOrder.Add(cultM);
        cultM.additionalFlavorTexts[0] = cultM.flavorText;
        cultM.gender = EGender.Male;

        Il2Cpp.CharacterData wildling = new Il2Cpp.CharacterData();
        wildling.role = new Wildling();
        wildling.name = "Wildling";
        wildling.characterName = "Wildling";
        wildling.description = "<b>Game Start</b>:\nOne Evil registers as truthful and tells the truth, they also register as being Messed By Evil.\nI lie and disguise. I follow the Demon disguise rules.";
        wildling.flavorText = "\"The wild has taught her how to tell the truth.\nShe has difficulty teaching this to others.\"";
        wildling.hints = customHint("Alignment Hint", "Covenant Follower") + $"\nI cannot turn the Iris or Professional truthful... I really don't like their attitude.";
        wildling.ifLies = "";
        wildling.notes = "";
        wildling.picking = false;

            wildling.startingAlignment = EAlignment.Evil;
            wildling.type = ECharacterType.Minion;
        
        wildling.abilityUsage = EAbilityUsage.Once;
        wildling.bluffable = false;
        wildling.characterId = "Wildling_POW";
        wildling.artBgColor = new Color(0.541f, 0.224f, 0.659f);
        wildling.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        wildling.cardBorderColor = new Color(0.51f, 0.173f, 0.612f);
        wildling.color = new Color(0.455f, 0.129f, 0.541f);
        nightPhase.nightCharactersOrder.Add(wildling);
        wildling.additionalFlavorTexts = new Il2CppStringArray(1);
        wildling.additionalFlavorTexts[0] = wildling.flavorText;
        wildling.gender = EGender.Female;

        Il2Cpp.CharacterData conjurer = new Il2Cpp.CharacterData();
        conjurer.role = new Conjurer();
        conjurer.name = "Slinger";
        conjurer.characterName = "Slinger";
        conjurer.description = $"<b>Game Start</b>:\nI kill a character before the round starts.\nI lie and disguise.";
        conjurer.flavorText = "\"Takes too much joy in throwing rocks\"";
        conjurer.hints = customHint("Alignment Hint", "Covenant Follower");
        conjurer.ifLies = "";
        conjurer.notes = "";
        conjurer.picking = false;

            conjurer.startingAlignment = EAlignment.Evil;
            conjurer.type = ECharacterType.Minion;
        
        conjurer.abilityUsage = EAbilityUsage.Once;
        conjurer.bluffable = false;
        conjurer.characterId = "Slinger_POW";
        conjurer.artBgColor = new Color(0.541f, 0.224f, 0.659f);
        conjurer.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        conjurer.cardBorderColor = new Color(0.51f, 0.173f, 0.612f);
        conjurer.color = new Color(0.455f, 0.129f, 0.541f);
        nightPhase.nightCharactersOrder.Add(conjurer);
        conjurer.additionalFlavorTexts = new Il2CppStringArray(1);
        conjurer.additionalFlavorTexts[0] = conjurer.flavorText;
        conjurer.gender = EGender.Female;

        Il2Cpp.CharacterData pois2 = new Il2Cpp.CharacterData();
        pois2.role = new Poisoner2();
        pois2.name = "Powder Maker";
        pois2.characterName = "Powder Maker";
        pois2.description = $"<b>Game Start</b>:\nI {formattedKeyText("Badly Poison")} a card.\nI lie and disguise.";
        pois2.flavorText = "\"Take it! It's medicine! \n I promise!\"";
        pois2.hints = customHint("Alignment Hint", "Covenant Follower");
        pois2.ifLies = "";
        pois2.notes = "";
        pois2.picking = false;

            pois2.startingAlignment = EAlignment.Evil;
            pois2.type = ECharacterType.Minion;
        
        pois2.abilityUsage = EAbilityUsage.Once;
        pois2.bluffable = false;
        pois2.characterId = "PowderMaker_POW";
        pois2.artBgColor = new Color(0.541f, 0.224f, 0.659f);
        pois2.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        pois2.cardBorderColor = new Color(0.51f, 0.173f, 0.612f);
        pois2.color = new Color(0.455f, 0.129f, 0.541f);
        nightPhase.nightCharactersOrder.Add(pois2);
        pois2.additionalFlavorTexts = new Il2CppStringArray(1);
        pois2.additionalFlavorTexts[0] = pois2.flavorText;
        pois2.gender = EGender.Female;

        Il2Cpp.CharacterData pm = new Il2Cpp.CharacterData();
        pm.role = new PotionMaster();
        pm.name = "Brewer";
        pm.characterName = "Brewer";
        pm.description = $"<b>Game Start</b>:\nOne card has a random status between Corrupted, {formattedKeyText("Unknown Obstacle")} and being {formattedKeyText("Mad")}.\nI lie and disguise.";
        pm.flavorText = "\"Like to mix and match ingredients. \n Results tend to favor the explosive kind.\"";
        pm.hints = customHint("Alignment Hint", "Covenant Follower");
        pm.ifLies = "";
        pm.notes = "";
        pm.picking = false;

            pm.startingAlignment = EAlignment.Evil;
            pm.type = ECharacterType.Minion;
        
        pm.abilityUsage = EAbilityUsage.Once;
        pm.bluffable = false;
        pm.characterId = "Brewer_POW";
        pm.artBgColor = new Color(0.541f, 0.224f, 0.659f);
        pm.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        pm.cardBorderColor = new Color(0.51f, 0.173f, 0.612f);
        pm.color = new Color(0.455f, 0.129f, 0.541f);
        nightPhase.nightCharactersOrder.Add(pm);
        pm.additionalFlavorTexts = new Il2CppStringArray(1);
        pm.additionalFlavorTexts[0] = pm.flavorText;
        pm.gender = EGender.Female;

        Il2Cpp.CharacterData voodooMaster = new Il2Cpp.CharacterData();
        voodooMaster.role = new VoodooMaster();
        voodooMaster.name = "Voodoo Master";
        voodooMaster.characterName = "Voodoo Master";
        voodooMaster.description = $"<b>Game Start</b>:\nI silence a Good card.\nI lie and disguise.";
        voodooMaster.flavorText = "\"Don't you love shaking a sinner's hand?\"";
        voodooMaster.hints = customHint("Alignment Hint", "Covenant Follower");
        voodooMaster.ifLies = "";
        voodooMaster.notes = "";
        voodooMaster.picking = false;

            voodooMaster.startingAlignment = EAlignment.Evil;
        voodooMaster.type = ECharacterType.Minion;
        
        
        voodooMaster.abilityUsage = EAbilityUsage.Once;
        voodooMaster.bluffable = false;
        voodooMaster.characterId = "VoodooMaster_POW";
        voodooMaster.artBgColor = new Color(0.541f, 0.224f, 0.659f);
        voodooMaster.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        voodooMaster.cardBorderColor = new Color(0.51f, 0.173f, 0.612f);
        voodooMaster.color = new Color(0.455f, 0.129f, 0.541f);
        nightPhase.nightCharactersOrder.Add(voodooMaster);
        voodooMaster.additionalFlavorTexts = new Il2CppStringArray(1);
        voodooMaster.additionalFlavorTexts[0] = voodooMaster.flavorText;
        voodooMaster.gender = EGender.Male;

       /* Il2Cpp.CharacterData medu = new Il2Cpp.CharacterData();
        medu.role = new Medusa();
        medu.name = "Medusa";
        medu.characterName = "Medusa";
        medu.description = $"Executed cards don't show their real identity.\nYou cannot see your health.\nI lie and disguise.";
        medu.flavorText = "\"Don't you love shaking a sinner's hand?\"";
        medu.hints = customHint("Alignment Hint", "Covenant Follower");
        medu.ifLies = "";
        medu.notes = "";
        medu.picking = false;

        medu.startingAlignment = EAlignment.Evil;
        medu.type = ECharacterType.Minion;


        medu.abilityUsage = EAbilityUsage.Once;
        medu.bluffable = false;
        medu.characterId = "Medusa_POW";
        medu.artBgColor = new Color(0.541f, 0.224f, 0.659f);
        medu.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        medu.cardBorderColor = new Color(0.51f, 0.173f, 0.612f);
        medu.color = new Color(0.455f, 0.129f, 0.541f);
        nightPhase.nightCharactersOrder.Add(medu);
        medu.additionalFlavorTexts = new Il2CppStringArray(1);
        medu.additionalFlavorTexts[0] = medu.flavorText;
        medu.gender = EGender.Female;*/

        Il2Cpp.CharacterData arch = new Il2Cpp.CharacterData();
        arch.role = new Archmage();
        arch.name = "Archmage";
        arch.characterName = "Archmage";
        arch.description = $"<b>Game Start</b>:\nI turn a neighbor into an evil {formattedKeyText("Covenant")} Follower.\nI lie and disguise.";
        arch.flavorText = "\"Don't believe the lies of the Mafia! \nThe world of magic is much more friendly!\"";
        arch.hints = customHint("Alignment Hint", "Covenant Preacher");
        arch.ifLies = "";
        arch.notes = "";
        arch.picking = false;
        arch.startingAlignment = EAlignment.Evil;
        arch.type = ECharacterType.Demon;
        arch.abilityUsage = Il2Cpp.EAbilityUsage.Once;
        arch.bluffable = false;
        arch.characterId = "Archmage_POW";
        arch.artBgColor = new Color(0.541f, 0.224f, 0.659f);
        arch.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        arch.cardBorderColor = new Color(0.51f, 0.173f, 0.612f);
        arch.color = new Color(0.455f, 0.129f, 0.541f);
        arch.additionalFlavorTexts = new Il2CppStringArray(1);
        arch.additionalFlavorTexts[0] = death.flavorText;
        arch.gender = EGender.Female;

        Il2Cpp.CharacterData hm = new Il2Cpp.CharacterData();
        hm.role = new HexMaster();
        hm.name = "Hex Master";
        hm.characterName = "Hex Master";
        hm.description = $"<b>At Night</b>:\nI {formattedKeyText("Hex")} one alive player. If all living Good are {formattedKeyText("Hexed")}, you lose. Day lasts half as long.\nI lie and disguise.";
        hm.flavorText = "\"What do you see in the sky? \n A bird? A plane?\"";
        hm.hints = customHint("Alignment Hint", "Covenant Preacher");
        hm.ifLies = "";
        hm.notes = "";
        hm.picking = false;
        hm.startingAlignment = EAlignment.Evil;
        hm.type = ECharacterType.Demon;
        hm.abilityUsage = Il2Cpp.EAbilityUsage.Once;
        hm.bluffable = false;
        hm.characterId = "HexMaster_POW";
        hm.artBgColor = new Color(0.541f, 0.224f, 0.659f);
        hm.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        hm.cardBorderColor = new Color(0.51f, 0.173f, 0.612f);
        hm.color = new Color(0.455f, 0.129f, 0.541f);
        nightPhase.nightCharactersOrder.Add(hm);
        hm.additionalFlavorTexts = new Il2CppStringArray(1);
        hm.additionalFlavorTexts[0] = hm.flavorText;
        hm.gender = EGender.Female;

        Il2Cpp.CharacterData god = new Il2Cpp.CharacterData();
        god.role = new God();
        god.name = "Fallen Prophet";
        god.characterName = "Fallen Prophet";
        god.description = "Luck cannot save you. Judgement is here.";
        god.flavorText = "\"Reality of truth, reality...\nAs the universe turned black... \nDid the sun ever defy fate?\"";
        god.hints = "Even Death can't save you now";
        god.ifLies = "";
        god.notes = "";
        god.picking = false;
        god.startingAlignment = EAlignment.Evil;
        god.type = ECharacterType.Demon;
        god.abilityUsage = Il2Cpp.EAbilityUsage.Once;
        god.bluffable = false;
        god.characterId = "FallenProphet_POW";
        god.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        god.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        god.cardBorderColor = new Color(0.8196f, 0.0f, 0.0275f);
        god.color = new Color(1f, 0.3804f, 0.3804f);
        god.additionalFlavorTexts = new Il2CppStringArray(1);
        god.additionalFlavorTexts[0] = god.flavorText;
        god.gender = EGender.Male;

        Il2Cpp.CharacterData stormyW = new Il2Cpp.CharacterData();
        stormyW.role = new Stormy();
        stormyW.name = "Stormy";
        stormyW.characterName = "Stormy";
        stormyW.description = "<b>Game Start</b>:\nA lot more Outcasts are in-play";
        stormyW.flavorText = "\"Small waves crashes into the windows of the villagers, the streets flooded with water.\nThe Social Outcasts's numbers are greater, hoping to help " +
            "in this hour.\"";
        stormyW.hints = customHint("Alignment Hint", "Weather");
        stormyW.ifLies = "";
        stormyW.notes = "";
        stormyW.picking = false;
        stormyW.startingAlignment = WeatherAlignement.Weather;
        stormyW.type = WeatherType.Weather;
        stormyW.abilityUsage = Il2Cpp.EAbilityUsage.Once;
        stormyW.bluffable = false;
        stormyW.characterId = "Stormy_POW";
        stormyW.color = new Color(1.0f, 0.651f, 0.9725f);
        stormyW.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        stormyW.cardBorderColor = new Color(1.0f, 0.4784f, 0.8784f);
        stormyW.artBgColor = new Color(0.9882f, 0.3451f, 0.8235f);
        stormyW.additionalFlavorTexts = new Il2CppStringArray(1);
        stormyW.additionalFlavorTexts[0] = stormyW.flavorText;

        Il2Cpp.CharacterData foggyW = new Il2Cpp.CharacterData();
        foggyW.role = new Foggy();
        foggyW.name = "Foggy";
        foggyW.characterName = "Foggy";
        foggyW.description = "You cannot see your deckview";
        foggyW.flavorText = "\"The foggy weather hides good, and bad, from sight.\n The latter takes advantage, capitalizing on the plight.\"";
        foggyW.hints = customHint("Alignment Hint", "Weather");
        foggyW.ifLies = "";
        foggyW.notes = "";
        foggyW.picking = false;
        foggyW.startingAlignment = WeatherAlignement.Weather;
        foggyW.type = WeatherType.Weather;
        foggyW.abilityUsage = Il2Cpp.EAbilityUsage.Once;
        foggyW.bluffable = false;
        foggyW.characterId = "Foggy_POW";
        foggyW.color = new Color(1.0f, 0.651f, 0.9725f);
        foggyW.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        foggyW.cardBorderColor = new Color(1.0f, 0.4784f, 0.8784f);
        foggyW.artBgColor = new Color(0.9882f, 0.3451f, 0.8235f);
        foggyW.additionalFlavorTexts = new Il2CppStringArray(1);
        foggyW.additionalFlavorTexts[0] = foggyW.flavorText;

        Il2Cpp.CharacterData sunnyW = new Il2Cpp.CharacterData();
        sunnyW.role = new Sunny();
        sunnyW.name = "Sunny";
        sunnyW.characterName = "Sunny";
        sunnyW.description = "<b>Game Start</b>:\nEach villager has an increasing chance of becoming Corrupted.";
        sunnyW.flavorText = "\"In the harsh sun, those who usually tell truths\n become blinded by the golden hue.\"";
        sunnyW.hints = customHint("Alignment Hint", "Weather");
        sunnyW.ifLies = "";
        sunnyW.notes = "";
        sunnyW.picking = false;
        sunnyW.startingAlignment = WeatherAlignement.Weather;
        sunnyW.type = WeatherType.Weather;
        sunnyW.abilityUsage = Il2Cpp.EAbilityUsage.Once;
        sunnyW.bluffable = false;
        sunnyW.characterId = "Sunny_POW";
        sunnyW.color = new Color(1.0f, 0.651f, 0.9725f);
        sunnyW.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        sunnyW.cardBorderColor = new Color(1.0f, 0.4784f, 0.8784f);
        sunnyW.artBgColor = new Color(0.9882f, 0.3451f, 0.8235f);
        sunnyW.additionalFlavorTexts = new Il2CppStringArray(1);
        sunnyW.additionalFlavorTexts[0] = sunnyW.flavorText;

        Il2Cpp.CharacterData snowyW = new Il2Cpp.CharacterData();
        snowyW.role = new Snowy();
        snowyW.name = "Snowy";
        snowyW.characterName = "Snowy";
        snowyW.description = $"<b>Game Start</b>:\nSome cards become {roleColour("Outcast")}Snowed In</color>, making them useless";
        snowyW.flavorText = "\"The thick white forces the town to stay home.\nSome are trapped inside, forced to be alone.\"";
        snowyW.hints = customHint("Alignment Hint", "Weather");
        snowyW.ifLies = "";
        snowyW.notes = "";
        snowyW.picking = false;
        snowyW.startingAlignment = WeatherAlignement.Weather;
        snowyW.type = WeatherType.Weather;
        snowyW.abilityUsage = Il2Cpp.EAbilityUsage.Once;
        snowyW.bluffable = false;
        snowyW.characterId = "Snowy_POW";
        snowyW.color = new Color(1.0f, 0.651f, 0.9725f);
        snowyW.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        snowyW.cardBorderColor = new Color(1.0f, 0.4784f, 0.8784f);
        snowyW.artBgColor = new Color(0.9882f, 0.3451f, 0.8235f);
        snowyW.additionalFlavorTexts = new Il2CppStringArray(1);
        snowyW.additionalFlavorTexts[0] = snowyW.flavorText;
        snowyW.additionalPossibleCharacters = MakeAddedCharacters(0, 2, 0, 0);

        Il2Cpp.CharacterData snowedIn = new Il2Cpp.CharacterData();
        snowedIn.role = new SnowedInChar();
        snowedIn.name = "Snowed In";
        snowedIn.characterName = "Snowed In";
        snowedIn.description = "I am Good";
        snowedIn.flavorText = "\"HELP ME!!!!\"";
        snowedIn.hints = "";
        snowedIn.ifLies = "";
        snowedIn.notes = "";
        snowedIn.picking = false;
        snowedIn.startingAlignment = EAlignment.Good;
        snowedIn.type = ECharacterType.Outcast;
        snowedIn.abilityUsage = Il2Cpp.EAbilityUsage.Once;
        snowedIn.bluffable = false;
        snowedIn.characterId = "SnowedIn_POW";
        snowedIn.artBgColor = new Color(0.3679f, 0.2014f, 0.1541f);
        snowedIn.cardBgColor = new Color(0.102f, 0.0667f, 0.0392f);
        snowedIn.cardBorderColor = new Color(0.7843f, 0.6471f, 0f);
        snowedIn.color = new Color(0.9659f, 1f, 0.4472f);
        snowedIn.additionalFlavorTexts = new Il2CppStringArray(1);
        snowedIn.additionalFlavorTexts[0] = snowedIn.flavorText;

        CustomScriptData crazedScriptData = new CustomScriptData();
        crazedScriptData.name = "Crazed_1";
        ScriptInfo crazedScript = new ScriptInfo();
        Il2CppSystem.Collections.Generic.List<CharacterData> crazedList = new Il2CppSystem.Collections.Generic.List<CharacterData>();
        crazedList.Add(crazed);
        crazedScript.mustInclude = crazedList;
        crazedScript.startingDemons = crazedList;
        crazedScript.startingTownsfolks = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingTownsfolks;
        crazedScript.startingOutsiders = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingOutsiders;
        crazedScript.startingMinions = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingMinions;
        //JinxCharacter(crazedScript.startingTownsfolks, "Trickster_scm");
       // JinxCharacter(crazedScript.startingMinions, "Accuser_scm");
        CharactersCount crazedCounter1 = setCharacterCount(4, 3, 2, 1);
        CharactersCount crazedCounter2 = setCharacterCount(5, 3, 2, 1);
        Il2CppSystem.Collections.Generic.List<CharactersCount> crazedCounterList = new Il2CppSystem.Collections.Generic.List<CharactersCount>();
        crazedCounterList.Add(crazedCounter1);
        crazedCounterList.Add(crazedCounter2);
        crazedScript.characterCounts = crazedCounterList;
        crazedScriptData.scriptInfo = crazedScript;

        CustomScriptData vortoxScriptData = new CustomScriptData();
        vortoxScriptData.name = "Vortox_1";
        ScriptInfo vortoxScript = new ScriptInfo();
        Il2CppSystem.Collections.Generic.List<CharacterData> vortoxList = new Il2CppSystem.Collections.Generic.List<CharacterData>();
        vortoxList.Add(vortox);
        vortoxScript.mustInclude = vortoxList;
        vortoxScript.startingDemons = vortoxList;
        vortoxScript.startingTownsfolks = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingTownsfolks;
        vortoxScript.startingOutsiders = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingOutsiders;
        vortoxScript.startingMinions = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingMinions;
        CharactersCount vortoxCounter1 = setCharacterCount(6, 2, 2, 1);
        CharactersCount vortoxCounter2 = setCharacterCount(5, 2, 2, 1);
        CharactersCount vortoxCounter3 = setCharacterCount(5, 1, 2, 1);
        Il2CppSystem.Collections.Generic.List<CharactersCount> vortoxCounterList = new Il2CppSystem.Collections.Generic.List<CharactersCount>();
        vortoxCounterList.Add(vortoxCounter1);
        vortoxCounterList.Add(vortoxCounter2);
        vortoxCounterList.Add(vortoxCounter3);
        vortoxScript.characterCounts = vortoxCounterList;
        vortoxScriptData.scriptInfo = vortoxScript;

        CustomScriptData audiScriptData = new CustomScriptData();
        audiScriptData.name = "Auditor_1";
        ScriptInfo audiScript = new ScriptInfo();
        Il2CppSystem.Collections.Generic.List<CharacterData> audiList = new Il2CppSystem.Collections.Generic.List<CharacterData>();
        audiList.Add(audi);
        audiScript.mustInclude = audiList;
        audiScript.startingDemons = audiList;
        audiScript.startingTownsfolks = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingTownsfolks;
        audiScript.startingOutsiders = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingOutsiders;
        audiScript.startingMinions = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingMinions;
        CharactersCount audiCounter1 = setCharacterCount(7, 0, 1, 1);
        CharactersCount audiCounter2 = setCharacterCount(6, 0, 2, 1);
        CharactersCount audiCounter3 = setCharacterCount(6, 0, 1, 1);
        Il2CppSystem.Collections.Generic.List<CharactersCount> audiCounterList = new Il2CppSystem.Collections.Generic.List<CharactersCount>();
        audiCounterList.Add(audiCounter1);
        audiCounterList.Add(audiCounter2);
        audiCounterList.Add(audiCounter3);
        audiScript.characterCounts = audiCounterList;
        audiScriptData.scriptInfo = audiScript;

        CustomScriptData courtScriptData = new CustomScriptData();
        courtScriptData.name = "Court_1";
        ScriptInfo courtScript = new ScriptInfo();
        Il2CppSystem.Collections.Generic.List<CharacterData> courtList = new Il2CppSystem.Collections.Generic.List<CharacterData>();
        courtList.Add(court);
        courtScript.mustInclude = courtList;
        courtScript.startingDemons = courtList;
        courtScript.startingTownsfolks = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingTownsfolks;
        courtScript.startingOutsiders = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingOutsiders;
        courtScript.startingMinions = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingMinions;
        CharactersCount courtCounter1 = setCharacterCount(8, 0, 2, 1);
        CharactersCount courtCounter2 = setCharacterCount(7, 0, 2, 1);
        Il2CppSystem.Collections.Generic.List<CharactersCount> courtCounterList = new Il2CppSystem.Collections.Generic.List<CharactersCount>();
        courtCounterList.Add(courtCounter1);
        courtCounterList.Add(courtCounter2);
        courtScript.characterCounts = courtCounterList;
        courtScriptData.scriptInfo = courtScript;

        CustomScriptData starScriptData = new CustomScriptData();
        starScriptData.name = "Starspawn_1";
        ScriptInfo starScript = new ScriptInfo();
        Il2CppSystem.Collections.Generic.List<CharacterData> starList = new Il2CppSystem.Collections.Generic.List<CharacterData>();
        starList.Add(star);
        starScript.mustInclude = starList;
        starScript.startingDemons = starList;
        starScript.startingTownsfolks = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingTownsfolks;
        starScript.startingOutsiders = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingOutsiders;
        starScript.startingMinions = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingMinions;
        CharactersCount starCounter1 = setCharacterCount(7, 1, 2, 1);
        CharactersCount starCounter2 = setCharacterCount(6, 2, 1, 1);
        CharactersCount starCounter3 = setCharacterCount(6, 1, 1, 1);
        CharactersCount starCounter4 = setCharacterCount(5, 1, 0, 1);
        Il2CppSystem.Collections.Generic.List<CharactersCount> starCounterList = new Il2CppSystem.Collections.Generic.List<CharactersCount>();
        starCounterList.Add(starCounter1);
        starCounterList.Add(starCounter2);
        starCounterList.Add(starCounter3);
        starCounterList.Add(starCounter4);
        starScript.characterCounts = starCounterList;
        starScriptData.scriptInfo = starScript;

        //Code taken from theCaldoMod, the Dependency
        CustomScriptData deathScriptData = new CustomScriptData();
        deathScriptData.name = "Death_1";
        ScriptInfo deathScript = new ScriptInfo();
        Il2CppSystem.Collections.Generic.List<CharacterData> deathList = new Il2CppSystem.Collections.Generic.List<CharacterData>();
        deathList.Add(death);
        deathScript.mustInclude = deathList;
        deathScript.startingDemons = deathList;
        deathScript.startingTownsfolks = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingTownsfolks;
        deathScript.startingOutsiders = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingOutsiders;
        deathScript.startingMinions = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingMinions;
        CharactersCount deathCounter1 = setCharacterCount(8, 0, 0, 1);
        CharactersCount deathCounter2 = setCharacterCount(7, 0, 0, 1);
        Il2CppSystem.Collections.Generic.List<CharactersCount> deathCounterList = new Il2CppSystem.Collections.Generic.List<CharactersCount>();
        deathCounterList.Add(deathCounter1);
        deathCounterList.Add(deathCounter2);
        deathScript.characterCounts = deathCounterList;
        deathScriptData.scriptInfo = deathScript;



        CustomScriptData warScriptData = new CustomScriptData();
        warScriptData.name = "War_1";
        ScriptInfo warScript = new ScriptInfo();
        Il2CppSystem.Collections.Generic.List<CharacterData> warList = new Il2CppSystem.Collections.Generic.List<CharacterData>();
        warList.Add(war);
        warScript.mustInclude = warList;
        warScript.startingDemons = warList;
        warScript.startingTownsfolks = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingTownsfolks;
        warScript.startingOutsiders = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingOutsiders;
        warScript.startingMinions = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingMinions;
        JinxCharacter(warList, "Doppleganger_52694042");
        JinxCharacter(warList, "WING_Dupery_Copycat");
        CharactersCount warCounter1 = setCharacterCount(2, 4, 3, 1);
        CharactersCount warCounter2 = setCharacterCount(2, 3, 3, 1);
        CharactersCount warCounter3 = setCharacterCount(1, 4, 2, 1);
        Il2CppSystem.Collections.Generic.List<CharactersCount> warCounterList = new Il2CppSystem.Collections.Generic.List<CharactersCount>();
        warCounterList.Add(warCounter1);
        warCounterList.Add(warCounter2);
        warCounterList.Add(warCounter3);
        warScript.characterCounts = warCounterList;
        warScriptData.scriptInfo = warScript;

        CustomScriptData famineScriptData = new CustomScriptData();
        famineScriptData.name = "Famine_1";
        ScriptInfo famineScript = new ScriptInfo();
        Il2CppSystem.Collections.Generic.List<CharacterData> famineList = new Il2CppSystem.Collections.Generic.List<CharacterData>();
        famineList.Add(famine);
        famineScript.mustInclude = famineList;
        famineScript.startingDemons = famineList;
        famineScript.startingTownsfolks = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingTownsfolks;
        famineScript.startingOutsiders = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingOutsiders;
        famineScript.startingMinions = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingMinions;
        CharactersCount famineCounter1 = setCharacterCount(8, 1, 1, 1);
        CharactersCount famineCounter2 = setCharacterCount(7, 2, 1, 1);
        CharactersCount famineCounter3 = setCharacterCount(7, 1, 2, 1);
        Il2CppSystem.Collections.Generic.List<CharactersCount> famineCounterList = new Il2CppSystem.Collections.Generic.List<CharactersCount>();
        famineCounterList.Add(famineCounter1);
        famineCounterList.Add(famineCounter2);
        famineCounterList.Add(famineCounter3);
        famineScript.characterCounts = famineCounterList;
        famineScriptData.scriptInfo = famineScript;

        CustomScriptData pestScriptData = new CustomScriptData();
        pestScriptData.name = "Pest_1";
        ScriptInfo pestScript = new ScriptInfo();
        Il2CppSystem.Collections.Generic.List<CharacterData> pestList = new Il2CppSystem.Collections.Generic.List<CharacterData>();
        pestList.Add(pestilence);
        pestScript.mustInclude = pestList;
        pestScript.startingDemons = pestList;
        pestScript.startingTownsfolks = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingTownsfolks;
        pestScript.startingOutsiders = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingOutsiders;
        pestScript.startingMinions = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingMinions;
        CharactersCount pestCounter1 = setCharacterCount(8, 0, 2, 1);
        CharactersCount pestCounter2 = setCharacterCount(7, 1, 2, 1);
        CharactersCount pestCounter3 = setCharacterCount(6, 2, 2, 1);
        Il2CppSystem.Collections.Generic.List<CharactersCount> pestCounterList = new Il2CppSystem.Collections.Generic.List<CharactersCount>();
        pestCounterList.Add(pestCounter1);
        pestCounterList.Add(pestCounter2);
        pestCounterList.Add(pestCounter3);
        pestScript.characterCounts = pestCounterList;
        pestScriptData.scriptInfo = pestScript;

        CustomScriptData GodfatherScriptData = new CustomScriptData();
        GodfatherScriptData.name = "Godfather_1";
        ScriptInfo gfScript = new ScriptInfo();
        Il2CppSystem.Collections.Generic.List<CharacterData> gfList = new Il2CppSystem.Collections.Generic.List<CharacterData>();
        gfList.Add(gf2);
        gfScript.mustInclude = gfList;
        gfScript.startingDemons = gfList;
        gfScript.startingTownsfolks = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingTownsfolks;
        gfScript.startingOutsiders = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingOutsiders;
        gfScript.startingMinions = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingMinions;
        JinxCharacter(gfScript.startingMinions, "Swarm_Good_WING");
        CharactersCount gfCounter1 = setCharacterCount(6, 4, 2, 1);
        CharactersCount gfCounter2 = setCharacterCount(5, 2, 2, 1);
        CharactersCount gfCounter3 = setCharacterCount(5, 1, 2, 1);
        CharactersCount gfCounter4 = setCharacterCount(4, 2, 1, 1);
        CharactersCount gfCounter5 = setCharacterCount(4, 1, 1, 1);
        Il2CppSystem.Collections.Generic.List<CharactersCount> gfCounterList = new Il2CppSystem.Collections.Generic.List<CharactersCount>();
        gfCounterList.Add(gfCounter1);
        gfCounterList.Add(gfCounter2);
        gfCounterList.Add(gfCounter3);
        gfCounterList.Add(gfCounter4);
        gfCounterList.Add(gfCounter5);
        gfScript.characterCounts = gfCounterList;
        GodfatherScriptData.scriptInfo = gfScript;

        CustomScriptData MafiosoScriptData = new CustomScriptData();
        MafiosoScriptData.name = "Mafioso_1";
        ScriptInfo mafScript = new ScriptInfo();
        Il2CppSystem.Collections.Generic.List<CharacterData> mafList = new Il2CppSystem.Collections.Generic.List<CharacterData>();
        mafList.Add(mafio);
        mafScript.mustInclude = mafList;
        mafScript.startingDemons = mafList;
        mafScript.startingTownsfolks = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingTownsfolks;
        mafScript.startingOutsiders = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingOutsiders;
        mafScript.startingMinions = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingMinions;
        JinxCharacter(mafScript.startingMinions, "Swarm_Good_WING");
        CharactersCount mafCounter1 = setCharacterCount(4, 2, 3, 1);
        CharactersCount mafCounter2 = setCharacterCount(5, 3, 2, 1);
        CharactersCount mafCounter3 = setCharacterCount(5, 2, 2, 1);
        CharactersCount mafCounter4 = setCharacterCount(4, 2, 2, 1);
        Il2CppSystem.Collections.Generic.List<CharactersCount> mafCounterList = new Il2CppSystem.Collections.Generic.List<CharactersCount>();
        mafCounterList.Add(mafCounter1);
        mafCounterList.Add(mafCounter2);
        mafCounterList.Add(mafCounter3);
        mafCounterList.Add(mafCounter4);
        mafScript.characterCounts = mafCounterList;
        MafiosoScriptData.scriptInfo = mafScript;

        CustomScriptData ArchScriptData = new CustomScriptData();
        ArchScriptData.name = "Archmage_1";
        ScriptInfo archScript = new ScriptInfo();
        Il2CppSystem.Collections.Generic.List<CharacterData> archList = new Il2CppSystem.Collections.Generic.List<CharacterData>();
        archList.Add(arch);
        archScript.mustInclude = archList;
        archScript.startingDemons = archList;
        archScript.startingTownsfolks = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingTownsfolks;
        archScript.startingOutsiders = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingOutsiders;
        archScript.startingMinions = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingMinions;
        JinxCharacter(archScript.startingMinions, "Swarm_Good_WING");
        CharactersCount archCounter1 = setCharacterCount(6, 3, 2, 1);
        CharactersCount archCounter2 = setCharacterCount(5, 4, 2, 1);
        CharactersCount archCounter3 = setCharacterCount(5, 3, 2, 1);
        CharactersCount archCounter4 = setCharacterCount(4, 2, 1, 1);
        CharactersCount archCounter5 = setCharacterCount(4, 1, 1, 1);
        Il2CppSystem.Collections.Generic.List<CharactersCount> archCounterList = new Il2CppSystem.Collections.Generic.List<CharactersCount>();
        archCounterList.Add(archCounter1);
        archCounterList.Add(archCounter2);
        archCounterList.Add(archCounter3);
        archCounterList.Add(archCounter4);
        archCounterList.Add(archCounter5);
        archScript.characterCounts = archCounterList;
        ArchScriptData.scriptInfo = archScript;

        CustomScriptData HexScriptData = new CustomScriptData();
        HexScriptData.name = "HexMaster_1";
        ScriptInfo hexScript = new ScriptInfo();
        Il2CppSystem.Collections.Generic.List<CharacterData> hexList = new Il2CppSystem.Collections.Generic.List<CharacterData>();
        hexList.Add(hm);
        hexScript.mustInclude = hexList;
        hexScript.startingDemons = hexList;
        hexScript.startingTownsfolks = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingTownsfolks;
        hexScript.startingOutsiders = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingOutsiders;
        hexScript.startingMinions = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingMinions;
        JinxCharacter(hexScript.startingMinions, "Swarm_Good_WING");
        CharactersCount hexCounter1 = setCharacterCount(2, 3, 3, 1);
        CharactersCount hexCounter2 = setCharacterCount(4, 1, 4, 1);
        CharactersCount hexCounter3 = setCharacterCount(3, 2, 4, 1);
        Il2CppSystem.Collections.Generic.List<CharactersCount> hexCounterList = new Il2CppSystem.Collections.Generic.List<CharactersCount>();
        hexCounterList.Add(hexCounter1);
        hexCounterList.Add(hexCounter2);
        hexCounterList.Add(hexCounter3);
        hexScript.characterCounts = hexCounterList;
        HexScriptData.scriptInfo = hexScript;

        CustomScriptData GodScriptData = new CustomScriptData();
        GodScriptData.name = "FallenProphet_1";
        ScriptInfo godScript = new ScriptInfo();
        Il2CppSystem.Collections.Generic.List<CharacterData> godList = new Il2CppSystem.Collections.Generic.List<CharacterData>();
        godList.Add(god);
        godScript.mustInclude = godList;
        godScript.startingDemons = godList;
        godScript.startingTownsfolks = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingTownsfolks;
        godScript.startingOutsiders = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingOutsiders;
        godScript.startingMinions = ProjectContext.Instance.gameData.advancedAscension.possibleScriptsData[0].scriptInfo.startingMinions;
        CharactersCount godCounter1 = setCharacterCount(14, 0, 0, 1);
        Il2CppSystem.Collections.Generic.List<CharactersCount> godCounterList = new Il2CppSystem.Collections.Generic.List<CharactersCount>();
        godCounterList.Add(godCounter1);
        godScript.characterCounts = godCounterList;
        GodScriptData.scriptInfo = godScript;

        AscensionsData advancedAscension = ProjectContext.Instance.gameData.advancedAscension;
      addDemon(advancedAscension, death, "Baa_Difficult", "Death_1", deathScriptData, configCategory.GetEntry<int>("Death_Weight").Value);
        addDemon(advancedAscension, war, "Baa_Difficult", "War_1", warScriptData, configCategory.GetEntry<int>("War_Weight").Value);
        addDemon(advancedAscension, famine, "Baa_Difficult", "Famine_1", famineScriptData, configCategory.GetEntry<int>("Famine_Weight").Value);
       addDemon(advancedAscension, pestilence, "Baa_Difficult", "Pest_1", pestScriptData, configCategory.GetEntry<int>("Pestilence_Weight").Value);
        addDemon(advancedAscension, vortox, "Baa_Difficult", "Vortox_1", vortoxScriptData, configCategory.GetEntry<int>("Vortox_Weight").Value);
       addDemon(advancedAscension, crazed, "Baa_Difficult", "Crazed_1", crazedScriptData, configCategory.GetEntry<int>("Crazed_Weight").Value);
        addDemon(advancedAscension, audi, "Baa_Difficult", "Auditor_1", audiScriptData, configCategory.GetEntry<int>("Auditor_Weight").Value);
        addDemon(advancedAscension, court, "Baa_Difficult", "Court_1", courtScriptData, configCategory.GetEntry<int>("Court_Weight").Value);
        addDemon(advancedAscension, star, "Baa_Difficult", "Starspawn_1", starScriptData, configCategory.GetEntry<int>("Starspawn_Weight").Value);
       if (configCategory.GetEntry<bool>("AllowMafia").Value)
        {
            addDemon(advancedAscension, gf2, "Baa_Difficult", "Godfather_1", GodfatherScriptData, configCategory.GetEntry<int>("Godfather_Weight").Value);
            addDemon(advancedAscension, mafio, "Baa_Difficult", "Mafioso_1", MafiosoScriptData, configCategory.GetEntry<int>("Mafioso_Weight").Value);
        }
        if (configCategory.GetEntry<bool>("AllowCovenant").Value)
        {
          addDemon(advancedAscension, arch, "Baa_Difficult", "Archmage_1", ArchScriptData, configCategory.GetEntry<int>("Archmage_Weight").Value);
            addDemon(advancedAscension, hm, "Baa_Difficult", "HexMaster_1", HexScriptData, configCategory.GetEntry<int>("HexMaster_Weight").Value);
       }
        addDemon(advancedAscension, god, "Baa_Difficult", "FallenProphet_1", GodScriptData, configCategory.GetEntry<int>("FallenProphet_Weight").Value);

        foreach (CustomScriptData scriptData in advancedAscension.possibleScriptsData)
        {
            ScriptInfo script = scriptData.scriptInfo;
           addRole(script.startingTownsfolks, official);
           int randomAmountOfPilgrim = UnityEngine.Random.Range(1, 5);
            int count = 0;
            while (count <= randomAmountOfPilgrim)
            {
                addRole(script.startingTownsfolks, pil);
                count++;
            }
            
            addRole(script.startingTownsfolks, parent);
            addRole(script.startingTownsfolks, dep);
            addRole(script.startingTownsfolks, oracle);
            addRole(script.startingTownsfolks, admi);
            addRole(script.startingTownsfolks, guard);
            addRole(script.startingTownsfolks, sailor);
            addRole(script.startingTownsfolks, scholar);
            addRole(script.startingTownsfolks, choirboy);
            addRole(script.startingTownsfolks, newsman);
            addRole(script.startingTownsfolks, teaLady);
            addRole(script.startingTownsfolks, washerwoman);
            addRole(script.startingTownsfolks, vigilante);
            addRole(script.startingTownsfolks, knowItAll);
              addRole(script.startingTownsfolks, marksman);
            addRole(script.startingTownsfolks, fisherman);
             addRole(script.startingTownsfolks, coroner); 
            addRole(script.startingTownsfolks, seer);
            addRole(script.startingTownsfolks, tracker);
            addRole(script.startingTownsfolks, spy);
            addRole(script.startingTownsfolks, psy);
            addRole(script.startingTownsfolks, invest);
            addRole(script.startingTownsfolks, sher);
            addRole(script.startingTownsfolks, lookout);

            int randomAmountOfOutlier = UnityEngine.Random.Range(1, 4);
            int count2 = 0;
            while (count2 <= randomAmountOfOutlier)
            {
                addRole(script.startingOutsiders, rej);
                count2++;
            }

            addRole(script.startingOutsiders, veteran);
           addRole(script.startingOutsiders, tav);
           addRole(script.startingOutsiders, vanished);
            addRole(script.startingOutsiders, amnesiac);
            addRole(script.startingOutsiders, indust);
           addRole(script.startingOutsiders, goon); 
            addRole(script.startingOutsiders, snakeCharmer);

            addRole(script.startingOutsiders, jester);
            addRole(script.startingOutsiders, cs);
           addRole(script.startingOutsiders, doom);
          addRole(script.startingOutsiders, scapegoat);
           addRole(script.startingOutsiders, apprentice);
            addRole(script.startingOutsiders, pirate);
           addRole(script.startingOutsiders, godfather);
           addRole(script.startingOutsiders, hangman);
            addRole(script.startingOutsiders, psycho);

            
            addRole(script.startingMinions, cerenovus);
            addRole(script.startingMinions, devilsAdvocate);
            addRole(script.startingMinions, boomdandy);
            addRole(script.startingMinions, butcher);
            addRole(script.startingMinions, eTwin);
            addRole(script.startingMinions, traveler);

    
                addRole(script.startingMinions, stormyW);
            addRole(script.startingMinions, foggyW);
            addRole(script.startingMinions, sunnyW);
            addRole(script.startingMinions, snowyW);
            

            }
        // Characters.Instance.startGameActOrder = InsertAtStartOfActOrder(snakeCharmer);
        Characters.Instance.startGameActOrder = InsertAtStartOfActOrder(court);
        Characters.Instance.startGameActOrder = InsertAtStartOfActOrder(gf2);
        Characters.Instance.startGameActOrder = InsertAtStartOfActOrder(mafio);
        Characters.Instance.startGameActOrder = InsertAtStartOfActOrder(arch);
        Characters.Instance.startGameActOrder = InsertAtStartOfActOrder(hm);
        Characters.Instance.startGameActOrder = InsertAtStartOfActOrder(god);
        Characters.Instance.startGameActOrder = insertAfterAct("Court",vortox);
        Characters.Instance.startGameActOrder = insertAfterAct("Vortox", apprentice);
        Characters.Instance.startGameActOrder = insertAfterAct("Vortox", choirboy);
        Characters.Instance.startGameActOrder = insertAfterAct("Vortox", snowyW);
        Characters.Instance.startGameActOrder = insertAfterAct("Vortox", stormyW);
        //Characters.Instance.startGameActOrder = insertAfterAct("Vortox", foggyW);
        Characters.Instance.startGameActOrder = insertAfterAct("Vortox", sunnyW);
        
        Characters.Instance.startGameActOrder = insertAfterAct("Vortox", star);
        Characters.Instance.startGameActOrder = insertAfterAct("Shaman", cerenovus);
        Characters.Instance.startGameActOrder = insertAfterAct("Chancellor", pirate);
        Characters.Instance.startGameActOrder = insertAfterAct("Chancellor", spoke);
        Characters.Instance.startGameActOrder = insertAfterAct("Chancellor", pois2);
        Characters.Instance.startGameActOrder = insertAfterAct("Chancellor", forger);
        Characters.Instance.startGameActOrder = insertAfterAct("Chancellor", pm);
        Characters.Instance.startGameActOrder = insertAfterAct("Chancellor", traveler);
        
        Characters.Instance.startGameActOrder = insertAfterAct("Chancellor", voodooMaster);
        
        Characters.Instance.startGameActOrder = insertAfterAct("Chancellor", jester);
        Characters.Instance.startGameActOrder = insertAfterAct("Chancellor", doom);
        Characters.Instance.startGameActOrder = insertAfterAct("Chancellor", official);
        Characters.Instance.startGameActOrder = insertAfterAct("Chancellor", amnesiac);
        Characters.Instance.startGameActOrder = insertAfterAct("Executive", jailor);
        Characters.Instance.startGameActOrder = insertAfterAct("Jailor", audi);
        // Characters.Instance.startGameActOrder = insertAfterAct("Executive", guard);
        Characters.Instance.startGameActOrder = insertAfterAct("Pirate", hangman);
        Characters.Instance.startGameActOrder = insertAfterAct("Hangman", psycho);
        Characters.Instance.startGameActOrder = insertAfterAct("Shaman", godfather);
        Characters.Instance.startGameActOrder = insertAfterAct("Executive", pestilence);
        Characters.Instance.startGameActOrder = insertAfterAct("Godfather", eTwin);
        Characters.Instance.startGameActOrder = insertAfterAct("Godfather", devilsAdvocate);
        Characters.Instance.startGameActOrder = insertAfterAct("Alchemist", teaLady);
        Characters.Instance.startGameActOrder = insertAfterAct("Alchemist", parent);
        Characters.Instance.startGameActOrder = insertAfterAct("Alchemist", crazed);
        Characters.Instance.startGameActOrder = insertAfterAct("Alchemist", conjurer);
        Characters.Instance.startGameActOrder = insertAfterAct("Alchemist", jinx);
        Characters.Instance.startGameActOrder = insertAfterAct("Alchemist", bootlegger);
        Characters.Instance.startGameActOrder = insertAfterAct("Alchemist", enforcer);
        Characters.Instance.startGameActOrder = insertAfterAct("Alchemist", cons);
        Characters.Instance.startGameActOrder = insertAfterAct("Alchemist", cs);
        Characters.Instance.startGameActOrder = insertAfterAct("Alchemist", scapegoat);
        Characters.Instance.startGameActOrder = insertAfterAct("Alchemist", indust);
        Characters.Instance.startGameActOrder = InsertAtEndOfActOrder(snakeCharmer);
       
    }

    public void addRole(Il2CppSystem.Collections.Generic.List<CharacterData> list, CharacterData data)
    {
        if (list.Contains(data))
        {
            return;
        }
        list.Add(data);
    }
    public Il2Cpp.CharacterData[] allDatas = System.Array.Empty<Il2Cpp.CharacterData>();
    private TextMeshProUGUI gameTextComponent = null;
    public override void OnUpdate()
    {
        if (allDatas.Length == 0)
        {
            var loadedCharList = Resources.FindObjectsOfTypeAll(Il2CppType.Of<CharacterData>());
            if (loadedCharList != null)
            {
                allDatas = new CharacterData[loadedCharList.Length];
                for (int i = 0; i < loadedCharList.Length; i++)
                {
                    allDatas[i] = loadedCharList[i]!.Cast<CharacterData>();
                   
                }
            }
        }
        if (Statics.charactersArray.Length == 0)
        {
            var loadedCharList = Resources.FindObjectsOfTypeAll(Il2CppType.Of<CharacterData>());
            if (loadedCharList != null)
            {
                Statics.charactersArray = new CharacterData[loadedCharList.Length];
                for (int i = 0; i < loadedCharList.Length; i++)
                {
                    CharacterData data = loadedCharList[i]!.Cast<CharacterData>();
                    Statics.CheckAddRole(data);
                    Statics.charactersArray[i] = data;
                }
            }
            if (Statics.charactersArray.Length > 0)
            {
                this.OnFirstUpdate();
            }
        }
    }
    public void OnFirstUpdate()
    {
        ToolTipPatchClass patcher = new();
        for (int i = 0; i < allDatas.Count(); i++)
        {
            MelonLogger.Msg($"Patching role: {allDatas[i].characterName}");
            if (allDatas[i].characterId == "Confessor")
            {
                allDatas[i].description = $"If I am Evil or Corrupted, I Declare that \"I am dizzy\".\nOtherwise, I Declare that \"I am Good\".\n\nI am always Truthful, even if Disguised.";
            }
            allDatas[i].description = patcher.PatchTooltip(allDatas[i].description);
            allDatas[i].hints = patcher.PatchTooltip(allDatas[i].hints);
            allDatas[i].ifLies = patcher.PatchTooltip(allDatas[i].ifLies);
        }
        Transform chars = GameObject.Find("Game/Gameplay/Content/Canvas/Panel/Characters").transform;
        if (chars)
        {
            MelonLogger.Msg("Found chars transform");
        }
        else
        {
            MelonLogger.Msg("Didn't find chars transform, expect an error");
        }
        for (int i = 12; i < 50; i++)
        {
            Statics.checkCreateCircle(chars, i);
        }
        for (int j = 2; j < 5; j++)
        {
            Statics.checkCreateCircle(chars, j);
        }

    }

    public CharactersCount setCharacterCount(int Villagers, int Outcasts, int Minions, int Demons)
    {
        CharactersCount myCharacterCount = new CharactersCount(Villagers + Outcasts + Minions + Demons, Villagers, Demons, Outcasts, Minions);
        myCharacterCount.dOuts = Outcasts + 1;
        return myCharacterCount;
    }

    public CharacterData[] InsertAtStartOfActOrder(CharacterData data)
    {
        CharacterData[] actList = Characters.Instance.startGameActOrder;
        int actSize = actList.Length;
        CharacterData[] newActList = new CharacterData[actSize + 1];
        for (int i = 0; i < actSize; i++)
        {
            newActList[i + 1] = actList[i];
        }
        newActList[0] = data;
        return newActList;
    }
    public CharacterData[] insertAfterAct(string previous, CharacterData data)
    {
        CharacterData[] actList = Characters.Instance.startGameActOrder;
        int actSize = actList.Length;
        CharacterData[] newActList = new CharacterData[actSize + 1];
        bool inserted = false;
        for (int i = 0; i < actSize; i++)
        {
            if (inserted)
            {
                newActList[i + 1] = actList[i];
            }
            else
            {
                if (actList[i] != null)
                {
                    newActList[i] = actList[i];
                    if (actList[i].characterName == previous)
                    {
                        newActList[i + 1] = data;
                        inserted = true;
                    }
                }

            }
        }
        if (!inserted)
        {
            LoggerInstance.Msg("");
        }

        return newActList;
    }
    //Wingidon moment
    public CharacterData[] InsertAtEndOfActOrder(CharacterData data)
    {
        MelonLogger.Msg($"Adding {data.name.ToString()} to end of act order");
        CharacterData[] actList = Characters.Instance.startGameActOrder;
        int actSize = actList.Length;
        CharacterData[] newActList = new CharacterData[actSize + 1];
        for (int i = 0; i < actSize; i++)
        {
            newActList[i] = actList[i];
        }
        newActList[actSize] = data;
        return newActList;
    }
    public CharacterData[] insertBeforeAct(string next, CharacterData data)
    {
        MelonLogger.Msg($"insertBeforeAct called adding {data.name.ToString()} before {next}");
        int actSize = Characters.Instance.startGameActOrder.Length;
        Il2CppSystem.Collections.Generic.List<CharacterData> newActList = new Il2CppSystem.Collections.Generic.List<CharacterData>();
        bool added = false;
        foreach (CharacterData character in Characters.Instance.startGameActOrder)
        {
            MelonLogger.Msg($"Attempting to add {character.name.ToString()} to act order");
            if (character.name.ToString() == next) MelonLogger.Msg($"Found target {character.name.ToString()}");
            if (character.name.ToString() == next && added == false)
            {
                MelonLogger.Msg($"Adding target {data.name.ToString()} to newActList");
                newActList.Add(data);
                MelonLogger.Msg($"Added {data.name.ToString()} to newActList");
            }
            MelonLogger.Msg($"Adding {character.name.ToString()} to newActList");
            newActList.Add(character);
        }
        CharacterData[] newActArray = new CharacterData[actSize + 1];
        int counter = 0;
        MelonLogger.Msg($"Beginning loop");
        foreach (CharacterData character in newActList)
        {
            Debug.Log(string.Format("Adding {0} to act order at array position {1}", character.name.ToString(), counter));
            newActArray[counter] = character;
            counter += 1;
        }
        return newActArray;
    }
    public void addDemon(AscensionsData advancedAscension, CharacterData? data, string oldScriptName, string newScriptName, CustomScriptData w_NewScript, int configAmount)
    {
        if (data == null)
        {
            return;
        }
        if (configAmount == 0)
        {
            return;
        }
        foreach (CustomScriptData scriptData in advancedAscension.possibleScriptsData)
        {
            if (scriptData.name == oldScriptName)
            {
                CustomScriptData newScriptData = GameObject.Instantiate(scriptData);
                newScriptData.name = newScriptName;
                ScriptInfo newScript = new ScriptInfo();
                ScriptInfo script = w_NewScript.scriptInfo;
                newScriptData.scriptInfo = newScript;
                newScript.startingTownsfolks = script.startingTownsfolks;
                newScript.startingOutsiders = script.startingOutsiders;
                newScript.startingMinions = script.startingMinions;
                newScript.startingDemons = script.startingDemons;
                newScript.characterCounts = w_NewScript.scriptInfo.characterCounts;
                //newScript.startingDemons = new Il2CppSystem.Collections.Generic.List<CharacterData>();
                //newScript.startingDemons.Add(data);
                var newPSD = advancedAscension.possibleScriptsData.Append(newScriptData);
                if (configAmount != 1)
                {
                    for (int i = 0; i < configAmount - 1; i++)
                    {
                        newPSD = newPSD.Append(newScriptData);
                    }
                }
                advancedAscension.possibleScriptsData = newPSD.ToArray();
                return;
            }
        }
    }

    public AddedCharacterTypes MakeAddedCharacters(int v, int o, int m, int d)
    {
        AddedCharacterTypes a = new AddedCharacterTypes();
        CharacterCount cv = new CharacterCount();
        cv.count = v;
        cv.type = ECharacterType.Villager;
        CharacterCount co = new CharacterCount();
        co.count = o;
        co.type = ECharacterType.Outcast;
        CharacterCount cm = new CharacterCount();
        cm.count = m;
        cm.type = ECharacterType.Minion;
        CharacterCount cd = new CharacterCount();
        cd.count = d;
        cd.type = ECharacterType.Demon;
        a.count.Add(cv);
        a.count.Add(co);
        a.count.Add(cm);
        a.count.Add(cd);
        return a;
    }
    public AddedCharacterTypes MakeAddedCharactersSpecial(int v, int o, int m, int d)
    {
        AddedCharacterTypes a = new AddedCharacterTypes();
        CharacterCount cv = new CharacterCount();
        cv.count = v - v/2;
        cv.type = ECharacterType.Villager;
        CharacterCount co = new CharacterCount();
        co.count = o + v/2;
        co.type = ECharacterType.Outcast;
        CharacterCount cm = new CharacterCount();
        cm.count = m;
        cm.type = ECharacterType.Minion;
        CharacterCount cd = new CharacterCount();
        cd.count = d;
        cd.type = ECharacterType.Demon;
        a.count.Add(cv);
        a.count.Add(co);
        a.count.Add(cm);
        a.count.Add(cd);
        return a;
    }
    //Taken once again from Wingidon!
    public static Il2CppSystem.Collections.Generic.List<CharacterData> JinxCharacter(Il2CppSystem.Collections.Generic.List<CharacterData> inputList, string ID)
    {
        Il2CppSystem.Collections.Generic.List<CharacterData> outputList = new Il2CppSystem.Collections.Generic.List<CharacterData>();
        foreach (CharacterData character in inputList)
        {
            if (character.characterId != ID)
            {
                outputList.Add(character);
            }
        }
        return outputList;
    }

    public static void checkCreateCircle(Transform parent, int size)
    {
        string name = "Circle_" + size;
        Transform t = parent.FindChild(name);
        if (t != null)
        {
            MelonLogger.Msg("Object Already exists!: " + name);
            return;
        }
        CreateCircle(size);
    }

    public static GameObject CreateCircle(int size)
    {
        GameObject circle = new GameObject();
        circle.name = "Circle_" + size;
        circle.transform.SetParent(Characters.Instance.gameObject.transform);
        RectTransform rt = circle.AddComponent<RectTransform>();
        CharactersPool cp = circle.AddComponent<CharactersPool>();
        GameObject gameObject = Characters.Instance.gameObject.transform.Find("Circle_6").gameObject;
        CharactersPool component = gameObject.GetComponent<CharactersPool>();
        cp.characterPrefab = component.characterPrefab;
        cp.characters = System.Array.Empty<Character>();
        cp.cardPlaceHolders = new CardPlaceholder[size];
        for (int i = 0; i < size; i++)
        {
            GameObject card = new GameObject();
            card.transform.SetParent(circle.transform);
            string text = "CardPlaceholder";
            if (i > 0)
            {
                text = text + " (" + i + ")";
            }
            card.name = text;
            RectTransform card_rt = card.AddComponent<RectTransform>();
            card_rt.anchoredPosition3D = new Vector3(0f, 0f, 0f);
            CardPlaceholder cardPlaceholder = card.AddComponent<CardPlaceholder>();
            int num = i * 360 / size;
            if (num <= 30)
            {
                cardPlaceholder.actedSide = EActedSide.Down;
            }
            else if (num <= 149)
            {
                cardPlaceholder.actedSide = EActedSide.Left;
            }
            else if (num <= 210)
            {
                cardPlaceholder.actedSide = EActedSide.Up;
            }
            else if (num <= 329)
            {
                cardPlaceholder.actedSide = EActedSide.Right;
            }
            else
            {
                cardPlaceholder.actedSide = EActedSide.Down;
            }
            cp.cardPlaceHolders[i] = cardPlaceholder;
        }
        circle.transform.position = new Vector3(0f, 1f, 85.9444f);
        circle.transform.localScale = new Vector3(1f, 1f, 1f);
        circle.SetActive(false);
        addToCharsPool(cp);
        return circle;
    }
    public static void addToCharsPool(CharactersPool pool)
    {
        CharactersPool[] oldpool = Characters.Instance.characterPool;
        CharactersPool[] newPool = new CharactersPool[oldpool.Length + 1];
        for (int i = 0; i < oldpool.Length; i++)
        {
            newPool[i] = oldpool[i];
        }
        newPool[oldpool.Length] = pool;
        Characters.Instance.characterPool = newPool;
    }
    public static Il2CppSystem.Collections.Generic.List<Character> GetGameplayCurrentCharacters()
    {
        Il2CppSystem.Collections.Generic.List<Character> characters = new();
        foreach (Character c in Gameplay.CurrentCharacters)
        {
            characters.Add(c);
        }
        return characters;
    }
   
    string formattedKeyText(string target)
    {
        switch (target)
        {
            // Keywords
            case "Intoxicate": return "<color=#56A3FC>Intoxicate</color>";
            case "Intoxicated": return "<color=#56A3FC>Intoxicated</color>";
            case "Intoxicating": return "<color=#56A3FC>Intoxicating</color>";
            case "Jail": return "<color=#696969>Jail</color>";
            case "Jailed": return "<color=#696969>Jailed</color>";
            case "Jinx": return "<color=#AA41BF>Jinx</color>";
            case "Jinxed": return "<color=#AA41BF>Jinxed</color>";
            case "Mad": return "<color=#FF8000>Mad</color>";
            case "Protect": return "<color=#69D172>Protect</color>";
            case "Protected": return "<color=#69D172>Protected</color>";
            case "Hex": return "<color=#7E3A94>Hex</color>";
            case "Hexed": return "<color=#7E3A94>Hexed</color>";
            case "Starve": return "<color=#C20A0A>Starve</color>";
            case "Starved": return "<color=#C20A0A>Starved</color>";
            case "UO": return "<color=#33327A>UO</color>";
            case "Unknown Obstacle": return "<color=#33327A>Unknown Obstacle</color>";
            //Same as Wingidon
            case "Honest": return "<color=#7AC6FF>Honest</color>";
            case "Pure": return "<color=#7AFBFF>Pure</color>";
            case "Cure": return "<color=#7AFBFF>Cure</color>";
            case "Cured": return "<color=#7AFBFF>Cured</color>";
            case "Heal": return "<color=#2EFF43>Heal</color>";
            case "Max Health": return "<color=#7AFBFF>Max Health</color>";
            case "Health": return "<color=#7AFBFF>Health</color>";
            case "Damage": return "<color=#C72424>Damage</color>";
            case "True Role": return "<color=#57E69C>True Role</color>";
            case "Truthful": return "<color=#3A95D6>Truthful</color>";
            case "Truth": return "<color=#3A95D6>Truth</color>";
            case "Reveal": return "<color=#A1E6E2>Reveal</color>";
            case "Reveals": return "<color=#A1E6E2>Reveals</color>";
            case "Revealed": return "<color=#A1E6E2>Revealed</color>";
            case "Revealing": return "<color=#A1E6E2>Revealing</color>";
            case "Hidden": return "<color=#697D91>Hidden</color>";
            case "Unrevealed": return "<color=#697D91>Unrevealed</color>";
            case "Bluff": return "<color=#D96EDB>Bluff</color>";
            case "Bluffs": return "<color=#D96EDB>Bluffs</color>";
            case "Bluffing": return "<color=#D96EDB>Bluffing</color>";
            case "Attack": return "<color=#FF0037>Attack</color>";
            case "Attacked": return "<color=#FF0037>Attacked</color>";
            case "Kill": return "<color=#FF0037>Kill</color>";
            case "Killed": return "<color=#FF0037>Killed</color>";
            case "Killing": return "<color=#FF0037>Killing</color>";
            case "Dead": return "<color=#B36979>Dead</color>";
            case "Die": return "<color=#B36979>Die</color>";
            case "Dies": return "<color=#B36979>Dies</color>";
            case "Alive": return "<color=#A4EDB7>Alive</color>";
            case "Living": return "<color=#A4EDB7>Living</color>";
            case "Deck": return "<color=#789AF0>Deck</color>";
            case "Lose": return "<color=#FF0000>Lose</color>";
            case "Unmask": return "<color=#B5E9FF>Unmask</color>";
            case "Declare": return "<color=#FFFF00>Declare</color>";
            case "Necronomicon": return "<color=#DD02E0>Necronomicon</color>";

            case "Cycle": return "<color=#99ff99>C</color><color=#99e6b3>y</color><color=#99cccc>c</color><color=#99b3e6>l</color><color=#9999ff>e</color>";
            case "Cycle 1": return "<color=#99ff99>C</color><color=#99e6b3>y</color><color=#99cccc>c</color><color=#99b3e6>l</color><color=#9999ff>e 1</color>";
            case "Cycle 2": return "<color=#99ff99>C</color><color=#99e6b3>y</color><color=#99cccc>c</color><color=#99b3e6>l</color><color=#9999ff>e 2</color>";
            case "Cycle 3": return "<color=#99ff99>C</color><color=#99e6b3>y</color><color=#99cccc>c</color><color=#99b3e6>l</color><color=#9999ff>e 3</color>";
            case "Cycle 4": return "<color=#99ff99>C</color><color=#99e6b3>y</color><color=#99cccc>c</color><color=#99b3e6>l</color><color=#9999ff>e 4</color>";
            case "Cycle 5": return "<color=#99ff99>C</color><color=#99e6b3>y</color><color=#99cccc>c</color><color=#99b3e6>l</color><color=#9999ff>e 5</color>";
            case "Cycle 6": return "<color=#99ff99>C</color><color=#99e6b3>y</color><color=#99cccc>c</color><color=#99b3e6>l</color><color=#9999ff>e 6</color>"; // Cycles beyond 6 are pointless

            case "Alignment": return "<color=#99ff99>A</color><color=#b7f382>l</color><color=#cfe573>i</color><color=#e3d76c>g</color><color=#f2c96d>n</color><color=#fdba73>m</color><color=#ffad7e>e</color><color=#ffa28b>n</color><color=#ff9999>t</color>";
            case "Type": return "<color=#B656DD>T</color><color=#C8A500>y</color><color=#D97400>p</color><color=#FF6161>e</color>";
            case "Subtype": return "<color=#99ff99>Subtype</color>";
            case "Truthfulness": return "<color=#3a95d6>T</color><color=#0ca3da>r</color><color=#00b1da>u</color><color=#00bdd5>t</color><color=#00c9ce>h</color><color=#25d4c4>f</color><color=#51deb8>u</color><color=#76e7ad>l</color><color=#98efa3>n</color><color=#bbf69b>e</color><color=#ddfb98>s</color><color=#ffff99>s</color>";
            case "Honesty": return "<color=#7ac6ff>H</color><color=#5cd3f2>o</color><color=#5fddd9>n</color><color=#7fe2bc>e</color><color=#aae4a3>s</color><color=#d6e296>t</color><color=#ffdd99>y</color>";
            case "Purity": return "<color=#7afbff>P</color><color=#61ecff>u</color><color=#71daff>r</color><color=#80c8ff>i</color><color=#94b2ff>t</color><color=#b199ff>y</color>";

            case "Poison": return "<color=#3F8538>Poison</color>"; // For unused Toxomancer role.
            case "Poisoned": return "<color=#3F8538>Poisoned</color>";
            case "Badly Poison": return "<color=#AA41BF>Badly Poison</color>";
            case "Badly Poisoned": return "<color=#AA41BF>Badly Poisoned</color>";
            case "Trick": return "<color=#70E8FF>Trick</color>"; // Used by Faerie.
            case "Tricked": return "<color=#70E8FF>Tricked</color>";
            case "Bewildered": return "<color=#70E8FF>Bewil</color><color=#FF00DD>dered</color>"; // Also used by Faerie.
            case "Misled": return "<color=#FF00AE>Misled</color>"; // Used by Venelum and Vidiyon.
            case "Trustworthy": return "<color=#9999FF>Trustworthy</color>"; // Used by Empath
            case "Trustworthiness": return "<color=#9999FF>Trustworthiness</color>";
            case "Trust": return "<color=#9999FF>Trust</color>";

            case "VillagerColour": return "<color=#B656DD>";
            case "VillagerAltColour": return "<color=#C080FF>";
            case "OutcastColour": return "<color=#F6FF72>";
            case "OutcastAltColour": return "<color=#C8A500>";
            case "MinionColour": return "<color=#D97400>";
            case "DemonColour": return "<color=#FF6161>";

            // Colours, Alignment Flip
            case "EvilVillagerColour": return "<color=#9B2FAE>";
            case "EvilOutcastColour": return "<color=#FF00DD>";
            case "GoodMinionColour": return "<color=#33D1C6>";
            case "GoodDemonColour": return "<color=#7A5CFF>";

            // Colours, Other Mods
            case "WeatherColour": return "<color=#FF7AE0>"; // Weather (Power Play)
            case "NeutralColour": return "<color=#8FA7B3>"; // Neutral (Power Play)
            case "CovenantColour": return "<color=#6B275D>";
            case "MafiaColour": return "<color=#C20051>";

            // Colours calling for specific types
            case "Weather": return "<color=#FF7AE0>Weather</color>"; // Weather (Power Play)
            case "Neutral": return "<color=#8FA7B3>Neutral</color>"; // Neutral (Power Play)
            case "Covenant": return "<color=#6B275D>Covenant</color>";
            case "Mafia": return "<color=#C20051>Mafia</color>";
        }
        return "Formatted key text invalid, please report this to Wingidon and not Redkiller fr fr";
    }
    string customHint(string type, string parameter)
    {
        string hint = "Custom hint not working, please report to Wingidon";
        if (type == "Alignment Hint")
        {
            if (parameter == "Neutral")
            {
                hint = $"I am a Neutral. \nThis means my {formattedKeyText("Alignment")} changes during <b>Game Start</b>";
            }
            if (parameter == "Weather")
            {
                hint = $"I am Weather. \nI have global effects and turn into a Minion during <b>Game Start</b>";
            }
            if (parameter == "Mafia Member")
            {
                hint = $"I am a member of the Mafia. \nI am Evil. \nYou cannot see me in the Deckview.";
            }
            if (parameter == "Mafia Leader")
            {
                hint = $"I am a leader of the Mafia. \nI am Evil. \nYou can see me in the Deckview.\n If I am in play, all Minions turn into {formattedKeyText("Mafia")} Members during <b>Game Start</b>.";
            }
            if (parameter == "Covenant Follower")
            {
                hint = $"I am a follower of the Covenant. \nI am Evil. \nI may wield the {formattedKeyText("Necronomicon")}, allowing me to kill every night.";
            }
            if (parameter == "Covenant Preacher")
            {
                hint = $"I am a preacher of the Covenant. \nI am Evil. \nI pass the {formattedKeyText("Necronomicon")} to one of the followers.\n If I am in play, all Minions turn into {formattedKeyText("Covenant")} Followers during <b>Game Start</b>.";
            }
        }
        if (type == "Ability Refresh Hint")
        {
            if (parameter == "Each Night")
            {
                hint = "My ability refreshes each night and may be used again each day.";
            }
            if (parameter == "Once Per Game")
            {
                hint = "My ability does not refresh each night.";
            }
        }
        if (type == "Outcast Disguise Hint")
        {
            if (parameter == "Simple")
            {
                hint = "My Disguise choice follows standard Minion Disguise rules.";
            }
            if (parameter == "Advanced")
            {
                hint = "My Disguise choice follows standard Minion Disguise rules.\nThis means I may Disguise as an in-play or out-of-play character, and may even Disguise as another face-up Outcast.";
            }
        }
        if (type == "Interactions")
        {
            if (parameter == "Good Minion")
            {
                hint = $"I am a Good Minion. As a result of this, a Lying {roleColour("Villager")}Oracle</color> may occasionally yield true info about me due to the way her Lying logic works.\nI can also be the other half of a Truthful {roleColour("Villager")}Oracle</color> ping on another Evil.";
            }
        }
        if (type == "Keyword")
        {
            if (parameter == "Setup")
            {
                hint = $"<b>Setup:</b>\nThis ability applies <i>before</i> <b>Game Start</b> abilities. It only works if the current Demon is the primary Demon of the current board.\nThese effects are reflected in the role counts.";
            }
            if (parameter == "Whilst Alive")
            {
                hint = $"<b>Whilst Alive:</b>\nThis ability works whilst any instance of this character is alive.";
            }
            if (parameter == "Bluff")
            {
                hint = $"<b>Bluff</b>:\nCharacters think I have the attribute that I am {formattedKeyText("Bluffing")}.";
            }
         }
        return hint;
    }
    string roleColour(string type)
    {
        switch (type)
        {
            // Types
            case "Villager": return formattedKeyText("VillagerColour");
            case "Outcast": return formattedKeyText("OutcastColour");
            case "Minion": return formattedKeyText("MinionColour");
            case "Demon": return formattedKeyText("DemonColour");
            case "EvilVillager": return formattedKeyText("EvilVillagerColour");
            case "EvilOutcast": return formattedKeyText("EvilOutcastColour");
            case "GoodMinion": return formattedKeyText("GoodMinionColour");
            case "GoodDemon": return formattedKeyText("GoodDemonColour");

            // Power Play
            case "Weather": return formattedKeyText("WeatherColour");
            case "Neutral": return formattedKeyText("NeutralColour");
            case "Covenant": return formattedKeyText("CovenantColour");
            case "Mafia": return formattedKeyText("MafiaColour");
        }
        return formattedKeyText("");
    }
    public static class Statics
    {
        public static Dictionary<string, CharacterData> roles = new Dictionary<string, CharacterData>();
        public static CharacterData[] charactersArray = Il2CppSystem.Array.Empty<CharacterData>();

        public static void checkCreateCircle(Transform parent, int size)
        {
            string name = "Circle_" + size;
            Transform t = parent.FindChild(name);
            if (t != null)
            {
                MelonLogger.Msg("Object Already exists!: " + name);
                return;
            }
            CreateCircle(size);
        }

        public static void GetStartingRoles()
        {
            AscensionsData allCharactersAscension = ProjectContext.Instance.gameData.allCharactersAscension;
            foreach (CharacterData data in allCharactersAscension.startingTownsfolks)
            {
                CheckAddRole(data);
            }
            foreach (CharacterData data in allCharactersAscension.startingOutsiders)
            {
                CheckAddRole(data);
            }
            foreach (CharacterData data in allCharactersAscension.startingMinions)
            {
                CheckAddRole(data);
            }
            foreach (CharacterData data in allCharactersAscension.startingDemons)
            {
                CheckAddRole(data);
            }
        }
        public static void CheckAddRole(CharacterData data)
        {
            string name = data.name;
            if (!roles.ContainsKey(name))
            {
                roles.Add(name, data);
            }
        }

    }
}
