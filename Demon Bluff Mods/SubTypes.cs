using Il2Cpp;
using HarmonyLib;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem;
using MelonLoader;
using System;
using System.ComponentModel.Design;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using System.Diagnostics;

namespace Demon_Bluff_Mods
{
    /**
     * All Subtypes thought of: 
     * 
     * TOWN: 
     * Town Investigative
     * Town Protective
     * Town Support
     * Town Killing
     * Town Power
     * 
     * OUTCAST: 
     * Outcast Deception
     * Outcast Killing
     * Outcast Harming
     * 
     * MINION:
     * Minion Deception
     * Minion Killing
     * Minion Utility
     * 
     * DEMON: 
     * Demon Killing
     * Demon Power
     * Demon Deception
     * 
     * NEUTRAL:
     * Neutral
     * 
     * WEATHER: 
     * Weather
     * 
     * COVENANT: 
     * Preacher Power
     * Follower Deception
     * Follower Utility
     * Follower Killing
     * 
     * MAFIA:
     * Leader Power
     * Leader Killing
     * 
     * Member Deception
     * Member Utility
     * Member Killing
     */

    //This is possibly the stupidest idea I have ever came up with. 

    public static class SubTypes
    {
        public static ESubType GetESubType(CharacterData charRef)
        {
            if (charRef.type == ECharacterType.Villager)
            {
                return GetVillagerSub(charRef);
            }
            else if (charRef.type == ECharacterType.Outcast)
            {
                return GetOutcastSub(charRef);
            }
            else if (charRef.type == ECharacterType.Minion)
            {
                return GetMinionSub(charRef);
            }
            else if (charRef.type == ECharacterType.Demon)
            {
                return GetDemonSub(charRef);
            }
            else
            {
                return GetWeirdoSub(charRef);
            }
        }
        public static string GetString(ESubType type)
        {
            if (type == ESubType.None)
                return "ERROR";
            else if (type == ESubType.Town_Investigative)
                return "Town Investigative";
            else if (type == ESubType.Town_Protective)
                return "Town Protective";
            else if (type == ESubType.Town_Support)
                return "Town Support";
            else if (type == ESubType.Town_Killing)
                return "Town Killing";
            else if (type == ESubType.Town_Power)
                return "Town Power";
            else if (type == ESubType.Outcast_Deception)
                return "Outcast Deception";
            else if (type == ESubType.Outcast_Harming)
                return "Outcast Harming";
            else if (type == ESubType.Outcast_Killing)
                return "Outcast Killing";
            else if (type == ESubType.Minion_Deception)
                return "Minion Deception";
            else if (type == ESubType.Minion_Killing)
                return "Minion Killing";
            else if (type == ESubType.Minion_Utility)
                return "Minion Utility";
            else if (type == ESubType.Demon_Deception)
                return "Demon Deception";
            else if (type == ESubType.Demon_Killing)
                return "Demon Killing";
            else if (type == ESubType.Demon_Power)
                return "Demon Power";
            else if (type == ESubType.Neutral)
                return "Neutral";
            else if (type == ESubType.Weather)
                return "Weather";
            else return "ERROR 2";
        }
        private static ESubType GetVillagerSub(CharacterData charRef)
        {
            if (IsTI(charRef)) return ESubType.Town_Investigative;
            else if (IsTP(charRef)) return ESubType.Town_Protective;
           else if (IsTS(charRef)) return ESubType.Town_Support;
            else if (IsTK(charRef)) return ESubType.Town_Killing;
            else if (IsTPow(charRef)) return ESubType.Town_Power;
            else return ESubType.None;
        }
        private static ESubType GetOutcastSub(CharacterData charRef)
        {
            if (IsOD(charRef)) return ESubType.Outcast_Deception;
            else if (IsOK(charRef)) return ESubType.Outcast_Killing;
            else if (IsOH(charRef)) return ESubType.Outcast_Harming;
            else return ESubType.None;
        }
        private static ESubType GetMinionSub(CharacterData charRef)
        {
            if (IsMD(charRef)) return ESubType.Minion_Deception;
            else if (IsMK(charRef)) return ESubType.Minion_Killing;
            else if (IsMU(charRef)) return ESubType.Minion_Utility;
            else return ESubType.None;
        }
        private static ESubType GetDemonSub(CharacterData charRef)
        {
            if (IsDD(charRef)) return ESubType.Demon_Deception;
            else if (IsDK(charRef)) return ESubType.Demon_Killing;
            else if (IsDPow(charRef)) return ESubType.Demon_Power;
            else return ESubType.None;
        }
        private static ESubType GetWeirdoSub(CharacterData charRef)
        {
            if (charRef.type == NeutralType.Neutral) return ESubType.Neutral;
            else if (charRef.type == WeatherType.Weather) return ESubType.Weather;
            else return ESubType.None;
        }
        private static bool IsTI(CharacterData charRef)
        {
            string id = charRef.characterId;
            List<string> list = new List<string>();
            list.Add("Architect_39883285");
            list.Add("Athlete_95133291");
            list.Add("Bishop_58855542");
            list.Add("Dreamer_32014895");
            list.Add("Druid_89845092");
            list.Add("Empress_13782227");
            list.Add("Enlightened_62576217");
            list.Add("Fortune Teller_74565681");
            list.Add("Hunter_93427887");
            list.Add("Investigator_34015277");
            list.Add("Jester_41367606"); list.Add("Knitter_32352172");
            list.Add("Oracle_07039445"); list.Add("Scout_88081716");
            list.Add("Lover_91302708"); list.Add("Lookout_41018246");
            list.Add("Archivist_34476114"); list.Add("WING_Dupery_Blood Hound");
            list.Add("WING_Dupery_Artist"); list.Add("WING_Dupery_Weatherman");
            list.Add("WING_Dupery_Therapist"); list.Add("WING_Dupery_Tailor");
            list.Add("WING_Dupery_Romantic"); list.Add("WING_Dupery_Researcher");
            list.Add("WING_Dupery_Reporter"); list.Add("WING_Dupery_Private Eye");
            list.Add("WING_Dupery_Mailman"); list.Add("Arbiter_WING");
            list.Add("Bloodseer_WING"); list.Add("Bounty Hunter_WING");
            list.Add("Cartomancer_WING"); list.Add("Chiromancer_WING");
            list.Add("Clairvoyant_WING"); list.Add("Detective_WING");
            list.Add("Empath_WING"); list.Add("Forager_WING");
            list.Add("Gossip_WING"); list.Add("Gravekeeper_WING");
            list.Add("Hound Tamer_WING"); list.Add("Jewelsmith_WING");
            list.Add("Knave_WING"); list.Add("Lamb_WING");
            list.Add("Paperboy_WING"); list.Add("Performer_WING");
            list.Add("Prince_WING"); list.Add("Ranger_WING");
            list.Add("Sentinel_WING"); list.Add("Spy_WING");
            list.Add("Stray_WING"); list.Add("Visionary_WING");
            list.Add("Warden_WING"); list.Add("Astronaut_scm");
            list.Add("Coach_scm"); list.Add("Comedian_scm");
            list.Add("Commander_scm"); list.Add("Crewmate_scm");
            list.Add("Director_scm"); list.Add("Engineer_scm");
            list.Add("Guide_scm"); list.Add("Obsessor_scm");
            list.Add("Pioneer_scm"); list.Add("Psychic_scm");
            list.Add("Sharpshooter_scm"); list.Add("Tracker_scm");
            list.Add("Weaver_scm"); list.Add("Coroner_POW");
            list.Add("Demographer_POW"); list.Add("Fisherman_POW");
            list.Add("Juror_POW"); list.Add("Know-it-All_POW");
            list.Add("Marksman_POW"); list.Add("Newsman_POW");
            list.Add("Prognosticator_POW"); list.Add("WiseElder_POW");
            list.Add("Constable_POW"); list.Add("Huntress_POW");
            return list.Contains(id);
                 }
        private static bool IsTP(CharacterData charRef)
        {
            List<string> list = new List<string>();
            string id = charRef.characterId;
               list.Add("Knight_47970624"); list.Add("Gambler_WING"); list.Add("Cardshark_WING" );
                list.Add("Scavenger_WING"); list.Add("Innkeeper_scm" );
                list.Add("Armorsmith_POW"); list.Add("Guard_POW" );
                list.Add("Soldier_POW"); list.Add("Herbalist_POW");
            return list.Contains(id);
        }
        private static bool IsTS(CharacterData charRef)
        {
            List<string> list = new List<string>();
            string id = charRef.characterId;
               list.Add("Alchemist_94446803"); list.Add("Baker_22847064" );
                list.Add("Judge_87202475"); list.Add("Gossip_85354100" );
                list.Add("Witness_25155076"); list.Add("Arithmetician_WING" );
                list.Add("Bartender_WING"); list.Add("Underling_V_WING" );
                list.Add("Copycat_WING"); list.Add("Devout_WING" );
                list.Add("Matchmaker_WING"); list.Add("Introvert_WING" );
                list.Add("Overseer_WING"); list.Add("Politician_WING" );
                list.Add("Puzzlemaster_WING"); list.Add("Sheriff_WING" );
                list.Add("WING_Dupery_Doppelganger"); list.Add("WING_Dupery_Empath" );
                list.Add("WING_Dupery_Skeptic"); list.Add("WING_Dupery_Mathematiciansm" );
                list.Add("Cowboy_scm"); list.Add("Developer_scm" );
                list.Add("Governor_scm"); list.Add("Lawyer_scm" );
                list.Add("Mathematician_scm"); list.Add("Motivator_scm" );
                list.Add("Necromancer_scm"); list.Add("Nurse_scm" );
                list.Add("Officer_scm"); list.Add("Recruiter_scm" );
                list.Add("Sphinx_scm"); list.Add("Stylist_scm" );
                list.Add("Surveyor_scm"); list.Add("Swapper_scm" );
                list.Add("Therapist_scm"); list.Add("Lookout_POW" );
                list.Add("Parent_POW"); list.Add("Pilgrim_POW" );
                list.Add("RoyalKnight_POW"); list.Add("Scholar_POW");
            list.Add("Lovestruck_POW"); list.Add("Operative_POW");
            list.Add("Tapper_POW");
            return list.Contains(id);
        }
        private static bool IsTK(CharacterData charRef)
        {
            List<string> list = new List<string>();
            string id = charRef.characterId;
                list.Add("Gambler_42592744"); list.Add("Masquerade_WING" );
                list.Add("Deputy_POW"); list.Add("Vigilante_POW");
            return list.Contains(id);
        }
        private static bool IsTPow(CharacterData charRef)

        {
            List<string> list = new List<string>();
            string id = charRef.characterId;
             list.Add("Confessor_18741708"); list.Add("Saint_WING" );
               list.Add("WING_Dupery_Priest"); list.Add("WING_Dupery_Good Cop" );
               list.Add("WING_Dupery_Partner"); list.Add("Preacher_scm" );
               list.Add("Trickster_scm" );
               list.Add("Trickster_v_scm" );
               list.Add("Trickster_o_scm" );
               list.Add("Trickster_m_scm"); list.Add("Riddler_scm" );
               list.Add("Jailor_POW"); list.Add("Pacifist_POW" );
               list.Add("Executive_POW"); list.Add("Mayor_POW" );
               list.Add("Monarch_POW"); list.Add("Marshal_POW" );
               list.Add("Prosecutor_POW");
            return list.Contains(id);
        }
        //Outcasts
        private static bool IsOD(CharacterData charRef)
        {
            List<string> list = new List<string>();
            string id = charRef.characterId;
                list.Add("Doppleganger_52694042"); list.Add("Drunk_15369527");
            list.Add("Plague Doctor_49312486"); list.Add("Rambler_57930131");
            list.Add("Wretch_80988916"); list.Add("Chatterbox_WING");
            list.Add("Echo_WING"); list.Add("Lunatic_WING");
            list.Add("Marionette_WING"); list.Add("Underling_O_WING");
            list.Add("WING_Dupery_Copycat"); list.Add("WING_Dupery_Bounty Hunter");
            list.Add("WING_Dupery_Drunkard"); list.Add("WING_Dupery_Fall Guy");
            list.Add("WING_Dupery_Wannabe"); list.Add("Gambler_scm");
            list.Add("Reflector_scm"); list.Add("Captivator_scm");
            list.Add("Confectioner_scm"); list.Add("Ghost_scm");
            list.Add("Muddler_scm"); list.Add("Architect_39883285");
            list.Add("Amnesiac_POW"); list.Add("Flutist_POW");
            list.Add("Industrialist_POW"); list.Add("Outlier_POW");
            list.Add("Vanished_POW"); list.Add("Winemaker_POW");
            return list.Contains(id);
        }
        private static bool IsOK(CharacterData charRef)
        {
            List<string> list = new List<string>();
            string id = charRef.characterId;
               list.Add("Revolutionary_WING"); list.Add("Switchblade_WING");
            list.Add("Hitman_scm"); list.Add("WING_Dupery_Surgeon");
            list.Add("Veteran_POW");
            return list.Contains(id);
        }
        private static bool IsOH(CharacterData charRef)
        {
            List<string> list = new List<string>();
            string id = charRef.characterId;
             list.Add("Bombardier_79093372"); list.Add("Lycanthrope_16077432");
            list.Add("Mutant_WING"); list.Add("Tergiversator_WING");
            list.Add("Renegade_WING"); list.Add("WING_Dupery_Youngster");
            list.Add("Anchor_scm"); list.Add("Prankster_scm");
            list.Add("MadScientist_scm"); list.Add("Mobster_POW");
            list.Add("Repossessed_POW"); list.Add("SnowedIn_POW");
            return list.Contains(id);
        }
        //Minions
        private static bool IsMD(CharacterData charRef)
        {
            List<string> list = new List<string>();
            string id = charRef.characterId;
             list.Add("Minion_71804875"); list.Add("Poisoner_64796285");
            list.Add("Twin Minion_15695218"); list.Add("Acolyte_WING");
            list.Add("Fanatic_WING"); list.Add("Heretic_WING");
            list.Add("Professional_WING"); list.Add("Saboteur_WING");
            list.Add("Swarm_Evil_WING");
            list.Add("Swarm_Good_WING"); list.Add("Turncoat_WING");
            list.Add("Underling_M_WING");
            list.Add("Zealot_WING"); list.Add("WING_Dupery_Mobster");
            list.Add("WING_Dupery_Poisoner"); list.Add("Accuser_scm");
            list.Add("BabyMinion_scm"); list.Add("Baffler_scm");
            list.Add("Enigma_scm"); list.Add("Hypnotist_scm");
            list.Add("Mastermind_scm"); list.Add("Slanderer_scm");
            list.Add("Covenite_POW"); list.Add("Manipulator_POW");
            list.Add("Bootlegger_POW");
            list.Add("Brewer_POW");
            list.Add("CultMember_POW");
            list.Add("Forger_POW");
            list.Add("Grunt_POW");
            list.Add("Influencer_POW");
            list.Add("VoodooMaster_POW");
            return list.Contains(id);
        }
        private static bool IsMU(CharacterData charRef)
        {
            List<string> list = new List<string>();
            string id = charRef.characterId;
              list.Add("Baron_04539999"); list.Add("Mezepheles_09511163");
            list.Add("Puppet_15989619"); list.Add("Shaman_26945607");
            list.Add("Witch_25286521"); list.Add("WING_Dupery_Travel Agent");
            list.Add("Cryptid_WING"); list.Add("Undying_WING");
            list.Add("WING_Dupery_Bad Cop"); list.Add("WING_Dupery_Barkeep");
            list.Add("WING_Dupery_Casanova"); list.Add("WING_Dupery_Conman");
            list.Add("WING_Dupery_Scoundrel"); list.Add("Channeler_scm");
            list.Add("Guardian_scm"); list.Add("PitHag_scm");
                list.Add("Sleeper_scm"); list.Add("Squire_scm");
            list.Add("Wizard_scm"); list.Add("EvilTwin_POW");
            list.Add("GoodTwin_POW"); list.Add("Supporter_POW");
            list.Add("Traveler_POW"); list.Add("Enforcer_POW");
            list.Add("Wildling_POW");
            return list.Contains(id);
        }
        private static bool IsMK(CharacterData charRef)
        {
            List<string> list = new List<string>();
            string id = charRef.characterId;
             list.Add("Werewolf_78350415"); list.Add("Ritualist_WING");
            list.Add("Snake Charmer_WING"); list.Add("WING_Dupery_Serial Killer");
            list.Add("Balancer_POW"); list.Add("Grenadier_POW"); list.Add("Ambusher_POW");
            list.Add("Gangster_POW"); list.Add("PowderMaker_POW"); list.Add("Slinger_POW");
            list.Add("Spokesperson_POW");
            return list.Contains(id);
        }
        //Demons
        private static bool IsDD(CharacterData charRef)
        {
            List<string> list = new List<string>();
            string id = charRef.characterId;
             list.Add("Imp_58992273"); list.Add("Pooka_13445289");
            list.Add("WING_Dupery_Idol"); list.Add("Iris_WING");
            list.Add("Mendaverte_WING"); list.Add("Praesect_WING");
            list.Add("Tenecaligo_WING"); list.Add("Mezepheles_WING");
            list.Add("WING_Dupery_Kingpin"); list.Add("TwinDemon_WING");
            list.Add("TwinDemonTwin_WING"); list.Add("TwinDemonTriplet_WING");
            list.Add("Escapist_scm"); list.Add("Fracture_scm");
            list.Add("Kingmaker_scm"); list.Add("Mystifier_scm");
            list.Add("Veil_scm"); list.Add("Auditor_POW");
            list.Add("Crazed_POW"); list.Add("Starspawn_POW");
            return list.Contains(id);
        }
        private static bool IsDK(CharacterData charRef)
        {
            List<string> list = new List<string>();
            string id = charRef.characterId;
             list.Add("Lillith_90453844"); list.Add("Caedoccidere_WING");
            list.Add("Carnicarius_WING"); list.Add("Follower_scm");
            list.Add("WING_Dupery_Hitman"); list.Add("Infestation_scm");
            list.Add("Mafioso_POW");
            return list.Contains(id);
        }
        private static bool IsDPow(CharacterData charRef)
        {
            List<string> list = new List<string>();
            string id = charRef.characterId;
             list.Add("Legion_WING"); list.Add("Pandemonium_WING");
            list.Add("Leviathan_WING"); list.Add("Minos_WING");
            list.Add("WING_Dupery_Critic"); list.Add("WING_Dupery_Recruiter");
            list.Add("Atheist_scm"); list.Add("RainbowJoker_scm");
            list.Add("Summoner_scm"); list.Add("Court_POW");
            list.Add("Death_POW"); list.Add("FallenProphet_POW");
            list.Add("Famine_POW"); list.Add("Pestilence_POW");
            list.Add("Vortox_POW"); list.Add("War_POW");
            list.Add("Archmage_POW"); list.Add("Godfather2_POW");
            list.Add("HexMaster_POW");
            return list.Contains(id);
        }
    }
    public enum ESubType
    {
        None = 0,
        Town_Investigative = 1,
        Town_Protective = 2,
        Town_Support = 3,
        Town_Killing = 4,
        Town_Power = 5,
        Outcast_Deception = 11,
        Outcast_Killing = 12,
        Outcast_Harming = 13,
        Minion_Deception = 21,
        Minion_Killing = 22,
        Minion_Utility = 23,
        Demon_Deception = 31,
        Demon_Killing = 32,
        Demon_Power = 33,
        Mafia = 41,
        Covenant = 42,
        Neutral = 43,
        Weather = 44,

    }
}


