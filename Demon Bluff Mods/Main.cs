// See https://aka.ms/new-console-template for more information
using Demon_Bluff_Mods;
using Il2Cpp;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using MelonLoader;
using UnityEngine;
using Patty_CustomScenario_MOD;
[assembly: MelonInfo(typeof(Demon_Bluff_Mods.Main), "Demon Bluff Mods", "1.0", "Redkiller")]
[assembly: MelonGame("UmiArt", "Demon Bluff")]

namespace Demon_Bluff_Mods;

public class Main : MelonMod
{
    public override void OnInitializeMelon()
    {
        
        UniversalUtility.AddEnum<EAlignment>("Neutral", (EAlignment)(30));
        UniversalUtility.AddEnum<ECharacterType>("Neutral", (EAlignment)(40));

        ClassInjector.RegisterTypeInIl2Cpp<Coroner>();
        ClassInjector.RegisterTypeInIl2Cpp<Marksman>();
        ClassInjector.RegisterTypeInIl2Cpp<Prosecutor>();
        ClassInjector.RegisterTypeInIl2Cpp<Mayor>();
        ClassInjector.RegisterTypeInIl2Cpp<Marshal>();
        ClassInjector.RegisterTypeInIl2Cpp<Monarch>();
        ClassInjector.RegisterTypeInIl2Cpp<Pacifist>();
        ClassInjector.RegisterTypeInIl2Cpp<Official>();
        ClassInjector.RegisterTypeInIl2Cpp<Fisherman>();
        ClassInjector.RegisterTypeInIl2Cpp<KnowItAll>();
        ClassInjector.RegisterTypeInIl2Cpp<TeaLady>();

        ClassInjector.RegisterTypeInIl2Cpp<Jailor>();
        ClassInjector.RegisterTypeInIl2Cpp<Veteran>();
        ClassInjector.RegisterTypeInIl2Cpp<SnakeCharmer>();
        
        ClassInjector.RegisterTypeInIl2Cpp<Psychopath>();
        ClassInjector.RegisterTypeInIl2Cpp<Pirate>();
        ClassInjector.RegisterTypeInIl2Cpp<Godfather>();
        ClassInjector.RegisterTypeInIl2Cpp<Hangman>();

        ClassInjector.RegisterTypeInIl2Cpp<Conjurer>();
        ClassInjector.RegisterTypeInIl2Cpp<Boomdandy>();
       
        ClassInjector.RegisterTypeInIl2Cpp<Death>();
        ClassInjector.RegisterTypeInIl2Cpp<Famine>();
        ClassInjector.RegisterTypeInIl2Cpp<Pestilence>();
        ClassInjector.RegisterTypeInIl2Cpp<War>();
        
    }
    public override void OnLateInitializeMelon()
    {
        GameObject content = GameObject.Find("Game/Gameplay/Content");
        NightPhase nightPhase = content.GetComponent<NightPhase>();

        Il2Cpp.CharacterData marksman = new Il2Cpp.CharacterData();
        marksman.role = new Marksman();
        marksman.name = "Marksman";
        marksman.characterName = "Marksman";
        marksman.description = "Learn how many Minions are revealed. \nIf there are none, learn it.";
        marksman.flavorText = "\"He has a sharp eye.\n Sees less than the Slayer though...\"";
        marksman.hints = "";
        marksman.ifLies = "I say a false amount of revealed Minions";
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

        Il2Cpp.CharacterData coroner = new Il2Cpp.CharacterData();
        coroner.role = new Coroner();
        coroner.name = "Coroner";
        coroner.characterName = "Coroner";
        coroner.description = "If there is a card killed by an Evil, learn an Evil character.";
        coroner.flavorText = "\"Has valuable information!\nOnly in niche circumstances.\"";
        coroner.hints = "If no one is dead, even a lying Coroner won't state a killer.";
        coroner.ifLies = "Points to a Good player instead.";
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

        Il2Cpp.CharacterData teaLady = new Il2Cpp.CharacterData();
        teaLady.role = new TeaLady();
        teaLady.name = "Soldier";
        teaLady.characterName = "Soldier";
        teaLady.description = "Good characters next to me cannot die.\n If I sit next to Evil I am Corrupted.";
        teaLady.flavorText = "\"Defends all Good people\nIs the only friend of the Wretch.\"";
        teaLady.hints = "I see the Wretch as Good.";
        teaLady.ifLies = "Good Character next to me can die";
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

        Il2Cpp.CharacterData prosecutor = new Il2Cpp.CharacterData();
        prosecutor.role = new Prosecutor();
        prosecutor.name = "Prosecutor";
        prosecutor.characterName = "Prosecutor";
        prosecutor.description = "Upon revealing, I kill a Minion!";
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

        Il2Cpp.CharacterData mayor = new Il2Cpp.CharacterData();
        mayor.role = new Mayor();
        mayor.name = "Mayor";
        mayor.characterName = "Mayor";
        mayor.description = "I reveal disguised characters 2 cards away from me!";
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

        Il2Cpp.CharacterData marshal = new Il2Cpp.CharacterData();
        marshal.role = new Marshal();
        marshal.name = "Marshal";
        marshal.characterName = "Marshal";
        marshal.description = "Grants you 10 extra health points!";
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
        // This is taken from Wingidon's DBExpansion mod


        Il2Cpp.CharacterData jailor = new Il2Cpp.CharacterData();
        jailor.role = new Jailor();
        jailor.name = "Jailor";
        jailor.characterName = "Jailor";
        jailor.description = "Outcasts 2 cards away from me don't hurt the village.";
        jailor.flavorText = "\"Takes away suspicious people. They are usually social outcasts.\"";
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

        Il2Cpp.CharacterData snakeCharmer = new Il2Cpp.CharacterData();
        snakeCharmer.role = new SnakeCharmer();
        snakeCharmer.name = "Flutist";
        snakeCharmer.characterName = "Flutist";
        snakeCharmer.description = "I swap with an Evil.";
        snakeCharmer.flavorText = "\"Tries to charm the Evils into revealing themselves. \n Become one instead.\"";
        snakeCharmer.hints = "";
        snakeCharmer.ifLies = "";
        snakeCharmer.notes = "";
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

        Il2Cpp.CharacterData veteran = new Il2Cpp.CharacterData();
        veteran.role = new Veteran();
        veteran.name = "Veteran";
        veteran.characterName = "Veteran";
        veteran.description = "I kill any Good players that pick me\n I deal 2 damage to you. \nI disguise.";
        veteran.flavorText = "\"Tries to bait the Demon\nOnly Villagers fall for the bait.\"";
        veteran.hints = "";
        veteran.ifLies = "I dont kill anyone that picks me";
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

        Il2Cpp.CharacterData pirate = new Il2Cpp.CharacterData();
        pirate.role = new Pirate();
        pirate.name = "Pirate";
        pirate.characterName = "Pirate";
        pirate.description = "I duel someone, preventing them from getting information\nI Lie and Disguise.";
        pirate.flavorText = "\"You've got a fine coin there!\n Mind if I take it?\"";
        pirate.hints = "I am a Neutral. I have a 50% chance of becoming Evil on start.";
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

        Il2Cpp.CharacterData godfather = new Il2Cpp.CharacterData();
        godfather.role = new Godfather();
        godfather.name = "Godfather";
        godfather.characterName = "Godfather";
        godfather.description = "I change someones alignement to my own.";
        godfather.flavorText = "\"Do you wish to join the hidden family?\nIt will always be worth your time.\"";
        godfather.hints = "I am a Neutral. I have a 50% chance of becoming Evil on start.";
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

        Il2Cpp.CharacterData psycho = new Il2Cpp.CharacterData();
        psycho.role = new Psychopath();
        psycho.name = "Psychopath";
        psycho.characterName = "Psychopath";
        psycho.description = "I kill at night, dealing 4 damage. I kill cards opposite of my alignement.\n I disguise and lie";
        psycho.flavorText = "\"Has a select few targets in mind\nFriendly or Adversary\"";
        psycho.hints = "I am a Neutral. I have a 50% chance of becoming Evil on start.";
        psycho.ifLies = "I lie and Disguise. I am Evil.";
        psycho.notes = "If I am Good:\n I kill Evil at night. I disguise and still lie.";
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

        Il2Cpp.CharacterData hangman = new Il2Cpp.CharacterData();
        hangman.role = new Hangman();
        hangman.name = "Hangman";
        hangman.characterName = "Hangman";
        hangman.description = "I point to a player, and call them Evil\n If I am Good, I am saying Truth. \n If I am Evil, I lie.";
        hangman.flavorText = "\"Is always convinced someone is Evil. \n Is sometimes correct \"";
        hangman.hints = "I am a Neutral. I have a 50% chance of becoming Evil on start.";
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

        Il2Cpp.CharacterData devilsAdvocate = new Il2Cpp.CharacterData();
        devilsAdvocate.role = new DevilsAdvocate();
        devilsAdvocate.name = "Supporter";
        devilsAdvocate.characterName = "Supporter";
        devilsAdvocate.description = "The Demon can't be executed as long as I am alive. \n The Demon doesn't disguise. \n I lie and disguise.";
        devilsAdvocate.flavorText = "\"Has an excellent reason on why the Demon should stay alive. \n Never actually says.\"";
        devilsAdvocate.hints = "";
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

        Il2Cpp.CharacterData conjurer = new Il2Cpp.CharacterData();
        conjurer.role = new Conjurer();
        conjurer.name = "Slinger";
        conjurer.characterName = "Slinger";
        conjurer.description = "I kill someone before the round starts.";
        conjurer.flavorText = "\"Takes too much joy in throwing rocks\"";
        conjurer.hints = "";
        conjurer.ifLies = "";
        conjurer.notes = "";
        conjurer.picking = false;
        conjurer.startingAlignment = EAlignment.Evil;
        conjurer.type = ECharacterType.Minion;
        conjurer.abilityUsage = EAbilityUsage.Once;
        conjurer.bluffable = false;
        conjurer.characterId = "Slinger_POW";
        conjurer.artBgColor = new Color(0.111f, 0.0833f, 0.1415f);
        conjurer.cardBgColor = new Color(0.0941f, 0.0431f, 0.0431f);
        conjurer.cardBorderColor = new Color(0.8196f, 0.0f, 0.0275f);
        conjurer.color = new Color(0.8510f, 0.4549f, 0.0f);
        conjurer.additionalFlavorTexts = new Il2CppStringArray(1);
        conjurer.additionalFlavorTexts[0] = conjurer.flavorText;

        Il2Cpp.CharacterData boomdandy = new Il2Cpp.CharacterData();
        boomdandy.role = new Boomdandy();
        boomdandy.name = "Grenadier";
        boomdandy.characterName = "Grenadier";
        boomdandy.description = "When Executed, I kill 2 Villagers. I deal 3 Damage upon being executed.";
        boomdandy.flavorText = "\"Plays too much with bombs\nIs the Bombardier's brother\"";
        boomdandy.hints = "If I am the last evil executed, I don't deal 3 damage.";
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

        Il2Cpp.CharacterData gTwin = new Il2Cpp.CharacterData();
        gTwin.role = new GoodTwin();
        gTwin.name = "Good Twin";
        gTwin.characterName = "Good Twin";
        gTwin.description = "I point at the Evil Twin";
        gTwin.flavorText = "\"It's the other one I swear!\"";
        gTwin.hints = "";
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

        Il2Cpp.CharacterData eTwin = new Il2Cpp.CharacterData();
        eTwin.role = new EvilTwin();
        eTwin.name = "Evil Twin";
        eTwin.characterName = "Evil Twin";
        eTwin.description = "I disguise as the Good Twin and point at her";
        eTwin.flavorText = "\"It's the other one I swear!\"";
        eTwin.hints = "";
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
      
        Il2Cpp.CharacterData pestilence = new Il2Cpp.CharacterData();
        pestilence.role = new Pestilence();
        pestilence.name = "Pestilence";
        pestilence.characterName = "Pestilence";
        pestilence.description = "Every Villager has a 80% chance of being Corrupted\n At night, I kill all revealed Corrupted cards.";
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

        Il2Cpp.CharacterData famine = new Il2Cpp.CharacterData();
        famine.role = new Famine();
        famine.name = "Famine";
        famine.characterName = "Famine";
        famine.description = "5 cards become starved. \nWhen Executed: I kill all revealed starved cards.";
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

        Il2Cpp.CharacterData war = new Il2Cpp.CharacterData();
        war.role = new War();
        war.name = "War";
        war.characterName = "War";
        war.description = "I kill 2 people per night, dealing 2 damage. \n Outcasts and Minions are far more abundant.";
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
        deathCounterList.Add(deathCounter1);
        deathCounterList.Add(deathCounter1);
        deathCounterList.Add(deathCounter1);
        deathCounterList.Add(deathCounter1);
        deathCounterList.Add(deathCounter1);
        deathCounterList.Add(deathCounter2);
        deathCounterList.Add(deathCounter2);
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
        CharactersCount warCounter1 = setCharacterCount(2, 4, 3, 1);
        CharactersCount warCounter2 = setCharacterCount(2, 3, 3, 1);
        CharactersCount warCounter3 = setCharacterCount(1, 4, 2, 1);
        Il2CppSystem.Collections.Generic.List<CharactersCount> warCounterList = new Il2CppSystem.Collections.Generic.List<CharactersCount>();
        warCounterList.Add(warCounter1);
        warCounterList.Add(warCounter1);
        warCounterList.Add(warCounter1);
        warCounterList.Add(warCounter1);
        warCounterList.Add(warCounter1);
        warCounterList.Add(warCounter1);
        warCounterList.Add(warCounter2);
        warCounterList.Add(warCounter2);
        warCounterList.Add(warCounter2);
        warCounterList.Add(warCounter3);
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
        famineCounterList.Add(famineCounter1);
        famineCounterList.Add(famineCounter1);
        famineCounterList.Add(famineCounter1);
        famineCounterList.Add(famineCounter2);
        famineCounterList.Add(famineCounter2);
        famineCounterList.Add(famineCounter2);
        famineCounterList.Add(famineCounter3);
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
        pestCounterList.Add(pestCounter1);
        pestCounterList.Add(pestCounter1);
        pestCounterList.Add(pestCounter1);
        pestCounterList.Add(pestCounter1);
        pestCounterList.Add(pestCounter1);
        pestCounterList.Add(pestCounter1);
        pestCounterList.Add(pestCounter1);
        pestCounterList.Add(pestCounter2);
        pestCounterList.Add(pestCounter2);
        pestCounterList.Add(pestCounter2);
        pestCounterList.Add(pestCounter3);
        pestCounterList.Add(pestCounter3);
        pestScript.characterCounts = pestCounterList;
        pestScriptData.scriptInfo = pestScript;


        AscensionsData advancedAscension = ProjectContext.Instance.gameData.advancedAscension;
        addDemon(advancedAscension, death, "Baa_Difficult", "Death_1", deathScriptData);
        addDemon(advancedAscension, war, "Baa_Difficult", "War_1", warScriptData);
        addDemon(advancedAscension, famine, "Baa_Difficult", "Famine_1", famineScriptData);
        addDemon(advancedAscension, pestilence, "Baa_Difficult", "Pest_1", pestScriptData);

        foreach (CustomScriptData scriptData in advancedAscension.possibleScriptsData)
        {
            ScriptInfo script = scriptData.scriptInfo;
            addRole(script.startingTownsfolks, official);
            addRole(script.startingTownsfolks, teaLady);
            addRole(script.startingTownsfolks, knowItAll);
            addRole(script.startingTownsfolks, marksman);
            addRole(script.startingTownsfolks, fisherman);
            addRole(script.startingTownsfolks, coroner);
            addRole(script.startingOutsiders, veteran);
            addRole(script.startingOutsiders, snakeCharmer);
            addRole(script.startingOutsiders, pirate);
            addRole(script.startingOutsiders, godfather);
            addRole(script.startingOutsiders, hangman);
            addRole(script.startingOutsiders, psycho);
            addRole(script.startingMinions, conjurer);
            addRole(script.startingMinions, devilsAdvocate);
            addRole(script.startingMinions, boomdandy);
            addRole(script.startingMinions, eTwin);

        }
        //Characters.Instance.startGameActOrder = insertAfterAct("Shaman", conjurer);
        Characters.Instance.startGameActOrder = insertAfterAct("Chancellor", pirate);
        Characters.Instance.startGameActOrder = insertAfterAct("Baa", official);
        Characters.Instance.startGameActOrder = insertAfterAct("Executive", jailor);
        Characters.Instance.startGameActOrder = insertAfterAct("Jailor", snakeCharmer);
        Characters.Instance.startGameActOrder = insertAfterAct("Pirate", hangman);
        Characters.Instance.startGameActOrder = insertAfterAct("Hangman", psycho);
        Characters.Instance.startGameActOrder = insertAfterAct("Shaman", godfather);
        Characters.Instance.startGameActOrder = insertAfterAct("Executive", pestilence);
        Characters.Instance.startGameActOrder = insertAfterAct("Godfather", eTwin);
        Characters.Instance.startGameActOrder = insertAfterAct("Godfather", devilsAdvocate);
        Characters.Instance.startGameActOrder = insertAfterAct("Godfather", teaLady);
        List<CharacterData> characters = new List<CharacterData>();
        characters.Add(official);
        characters.Add(conjurer);
        characters.Add(boomdandy);
        characters.Add(veteran);
        characters.Add(prosecutor);
        characters.Add(mayor);
        characters.Add(marshal);
        characters.Add(monarch);
        characters.Add(famine);
        characters.Add(death);
        characters.Add(war);
        characters.Add(jailor);
        foreach (CharacterData characterData in characters)
        {
            setRoleArt(characterData);
        }
    }
    public void setRoleArt(CharacterData charRef)
    {
        // This is taken from Wingidon's DBExpansion mod
        Il2CppSystem.Collections.Generic.List<string> refIDs = new Il2CppSystem.Collections.Generic.List<string>();
        refIDs = GetRoleArt(charRef);
        MelonLogger.Msg($"refIDs[0] = {refIDs[0]}");
        MelonLogger.Msg($"refIDs[1] = {refIDs[1]}");
        CharacterData backgroundRef = ProjectContext.Instance.gameData.GetCharacterDataOfId(refIDs[0]);
        CharacterData artRef = ProjectContext.Instance.gameData.GetCharacterDataOfId(refIDs[1]);
        charRef.art_cute = artRef.art_cute;
        charRef.backgroundArt = backgroundRef.backgroundArt;
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
    public override void OnUpdate()
    {
        if (allDatas.Length == 0)
        {
            var loadedCharList = UnityEngine.Resources.FindObjectsOfTypeAll<Il2Cpp.CharacterData>();
            if (loadedCharList != null)
            {
                allDatas = new Il2Cpp.CharacterData[loadedCharList.Length];
                for (int i = 0; i < loadedCharList.Length; i++)
                {
                    allDatas[i] = loadedCharList[i]!.Cast<Il2Cpp.CharacterData>();
                   
                }
            }
        }
    }

    public CharactersCount setCharacterCount(int Villagers, int Outcasts, int Minions, int Demons)
    {
        CharactersCount myCharacterCount = new CharactersCount(Villagers + Outcasts + Minions + Demons, Villagers, Demons, Outcasts, Minions);
        myCharacterCount.dOuts = Outcasts + 1;
        return myCharacterCount;
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
    public void addDemon(AscensionsData advancedAscension, CharacterData? data, string oldScriptName, string newScriptName, CustomScriptData NewScript, int weight = 1)
    {
        if (data == null)
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
                ScriptInfo script = NewScript.scriptInfo;
                newScriptData.scriptInfo = newScript;
                newScript.startingTownsfolks = script.startingTownsfolks;
                newScript.startingOutsiders = script.startingOutsiders;
                newScript.startingMinions = script.startingMinions;
                newScript.startingDemons = script.startingDemons;
                newScript.characterCounts = NewScript.scriptInfo.characterCounts;
                var newPSD = advancedAscension.possibleScriptsData.Append(newScriptData);
                for (int i = 0; i < weight - 1; i++)
                {
                    newPSD = newPSD.Append(newScriptData);
                }
                advancedAscension.possibleScriptsData = newPSD.ToArray();
                return;
            }
        }
    }
    public static Il2CppSystem.Collections.Generic.List<string> GetRoleArt(CharacterData cd)
    {
        Il2CppSystem.Collections.Generic.List<string> returnList = new Il2CppSystem.Collections.Generic.List<string>();
            
            switch (cd.characterId)
            {
            case "Official_ID":
                returnList.Add("Bishop_58855542");
                returnList.Add("Bishop_58855542"); // Evil Outcast: Bombardier
                break;
            case "Boomdandy_ID":
                    returnList.Add("Minion_71804875");
                    returnList.Add("Boomdandy_ID"); // Evil Outcast: Bombardier
                    break;
            default:
                returnList = GetRolePlaceholderArt(cd.type, cd.startingAlignment);
                break;
            }
        return returnList;
        }
    //Shamelessly stolen code goes here: 

    // This method is by Wingidon, used in their DBExpansionpack mod. Pls check them out
    public static Il2CppSystem.Collections.Generic.List<string> GetRolePlaceholderArt(ECharacterType type, EAlignment alignment) // First item of the list is the background, second is the art.
    {
        Il2CppSystem.Collections.Generic.List<string> returnList = new Il2CppSystem.Collections.Generic.List<string>();
        if (alignment == EAlignment.Good)
        {
            returnList.Add("Bishop_58855542");
        }
        else
        {
            returnList.Add("Minion_71804875");
        }
        if (type == ECharacterType.Villager)
        {
            if (alignment == EAlignment.Good)
            {
                returnList.Add("Knight_47970624"); // Good Villager: Knight
            }
            if (alignment == EAlignment.Evil)
            {
                returnList.Add("Gambler_42592744"); // Evil Villager: Slayer
            }
        }
        if (type == ECharacterType.Outcast)
        {

            if (alignment == EAlignment.Good)
            {
                returnList.Add("Wretch_80988916"); // Good Outcast: Wretch
            }
            if (alignment == EAlignment.Evil)
            {
                returnList.Add("Bombardier_79093372"); // Evil Outcast: Bombardier
            }
        }
        if (type == ECharacterType.Minion)
        {
            if (alignment == EAlignment.Good)
            {
                returnList.Add("Witch_25286521"); // Good Minion: Witch
            }
            if (alignment == EAlignment.Evil)
            {
                returnList.Add("Poisoner_64796285"); // Evil Minion: Poisoner
            }
        }
        if (type == ECharacterType.Demon)
        {
            if (alignment == EAlignment.Good)
            {
                returnList.Add("Confessor_18741708"); // Good Demon: Confessor
            }
            if (alignment == EAlignment.Evil)
            {
                returnList.Add("Lillith_90453844"); // Evil Demon: Lilis
            }
        }
        return returnList;
    }
}

