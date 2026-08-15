# Powerplay, a DB mod inspired by Town of Salem 2

This is a mod for Demon Bluff, inspired by Town Of Salem 2, which introduces many VERY powerful roles and problems for you to face.

Credit to TheCaldo and Wingidon for helping me learn the basics and certain more complex additions. Credits to WWW for the Character creation tutorial.
And Credit to Digital Bandido for the roles.

Anyhow: Here are the Characters/Gimmicks

# MASSIVE WARNING:
It is HIGHLY RECOMMENDED, if you are very new to modding, to one: 
Start with Wingidon's Expansion Pack or Riddler before this one. This is the HARDEST mod being currently updated. It introduces a LOT of mechanics,
which can easily overwhelm players if they aren't used to modded Demon Bluff
If you have already played Wingidon's or Riddler, another thing is to DISABLE Covenant and Mafia from spawning, as well as the Fallen Prophet. To do this,
go to your files, where your mods are. There should be a file titled "UserData". Open it, click on "PowerplayConfig.cfg" and follow the instructions in the config file.
Trust me, it's better for you to GRADUALLY introduce the mechanics then to be bombarded with them.

## Gimmicks

### Silence
Taken from TheCaldosMod2, this effect makes a card unable to say information.

### Madness
Mad cards register as the wrong thing.

### Protection
Protected cards cannot die.

### Unknown Obstacle
You cannot click on cards with Unknown Obstacle.

### Intoxicate
Intoxicated On-Pick cards become useless.

## VILLAGERS

### Armorsmith (Good, Villager)
I point at a card. Learn if I Protected them or not.

### Coroner (Good, Villager)
If a card dies by an evil, I learn an Evil card. If no card died by Evil, I have a 50% chance of pointing at an evil

### Constable (Good, Villager)
Each night, I search a house. Learn if they are Innocent or Suspicious

### Demographer (Good, Villager)
Pick 3 cards, I say one in-play Villager between them

### Deputy (Good, Villager)
I shoot a card. Learn if I missed. If I hit they die. 

### Fisherman (Good, Villager)
Learn how far away a specific villager is to their nearest Villager.

### Guard (Good, Villager) 
A random Villager is protected

### Herbalist (Good, Villager)
An unrevealed Villager role is cured of Corruption. Learn which.

### Huntress (Good, Villager)
If a card was affected by an evil, learn an evil that can deceive you.

### Juror (Good, Villager)
I only spawn in Court. I point towards a card and call them Innocent if Good or Guilty if Evil.

### Know-It-All (Good, Villager)
Learn a factually true or false statement, and learn if it is true or false.

### Lookout (Good, Villager)
Learn how many characters were affected by evils.

### Lovestruck (Good, Villager)
Learn an unrevealed Subtype of Villager.

### Marksman (Good, Villager)
I learn how many Minions have been revealed.

### Newsman (Good, Villager)
Learn the closest Mad character to me.

### Operative (Good, Villager)
Pick a card. Learn one of 4 possible crimes they committed.

### Parent (Good, Villager)
I am unbluffable. Learn a the role of my child. I take on the alignment of my child

### Pilgrim (Good, Villager)
I am a failsafe between another Villager and a Demon from Powerplay. Learn if i'm the Pilgrim.

### Royal Knight (Good, Villager)
I can only spawn with the Executive. If the Executive has a status or is dead, learn the Demon.

### Scholar (Good, Villager)
Learn cryptic advice.

### Soldier (Good, Villager)
If both cards next to me are good, they cannot die. Or else I am corrupted.

### Tapper (Good, Villager)
Pick a card. Learn the statuses that affect them and their neighbours.

### Vigilante (Good, Villager)
When revealed, I choose a target. The following night I shoot them. If they are Good I die as well.

### Wise Elder (Good, Villager)
Each odd night, learn two cards. At least one is Good. Each even night, learn three cards. At least one is Evil.

## Executive (Good, Villager)
This Villager is special, as you will never see it in a village. Instead, the Executive, on Start, immediately transforms into one of 6 possible POWER roles!
Hence the name of the mod. The Executive CANNOT be bluffed by Evils.

### Marshal (Good, Villager) _POWER ROLE_
I give 10 extra Max HP.

### Mayor (Good, Villager) _POWER ROLE_
I undisguise cards 2 cards away from me.

### Prosecutor (Good, Villager) _POWER ROLE_
I kill a Minion when revealed.

### Emperor (Good, Villager) _POWER ROLE_
I point to 3 Cards, they are Villagers.

### Jailor (Good, Villager) _POWER ROLE_
The Demon cannot act.

### Pacifist (Good, Villager) _POWER ROLE_
Pick 4 cards. If all are good, you win.

## OUTCASTS

### Amnesiac (Good, Outcast)
I have 6 random abilities. You dont learn which.

### Flutist (Good, Outcast)
I swap with an Evil. They say if they have been swapped. I register as Evil, I cannot be Evil.

### Industrialist (Good, Outcast)
One character is Mad. Learn a mad card.

### Mobster (Good, Outcast)
I turn into the alignement of the card that last picks me. Learn if I swapped alignments.

### Outlier (Good, Outcast)
I am a failsafe between another Outcast and a Demon from Powerplay.

### Repossessed (Good, Outcast)
I only spawn with the Auditor. Learn 3 cards, one is the Auditor.

### Snowed In (Good, Outcast)
I am a good card turned into the Snowed in.

### Vanished (Good, Outcast)
I cast Unknown Obstacle on myself. I silence my closest evil.

### Veteran (Good, Outcast)
If a Good card picks me, I kill them, deal 2 damage and undisguise. I disguise.

### Winemaker (Good, Outcast)
I intoxicate a random card. Learn an intoxicated card.

## MINIONS

### Balancer (Evil, Minion)
Each time you kill a card, I kill a good card and deal 1 damage to you. I don't deal damage if I am killed.

### Covenite (Evil, Minion)
I am a failsafe between another Minion and a Demon from Powerplay.

### Evil Twin (Evil, Minion)
I disguise as the Good twin and point at the Good twin, calling her evil.

### Good Twin (Good, Minion)
Learn the Evil Twin.

### Grenadier (Evil, Minion)
When executed, I deal 2 damage and kill 2 good cards. I dont deal damage if I am the last evil killed.

### Manipulator (Evil, Minion)
One character is Mad.

### Supporter (Evil, Minion)
You cannot kill the Demon whilst I am alive.

### Traveler (Evil, Minion)
A card next to me becomes a Traveler. I sit next to them.

## DEMONS

### Famine (Evil, Demon)
5 cards become Starved. If I am executed, all revealed Starved cards are killed, dealing 2 damage each.

### Pestilence (Evil, Demon)
Every Villager has an 80% chance of being corrupted. At night, I kill every revealed Corrupted card, dealing 1 damage per killed card. I lie and disguise. One card cannot be corrupted

### War (Evil, Demon)
Every night, I kill 2 cards, dealing 2 damage. I lie and disguise. More Outcasts and Minions are in-play.

### Death (Evil, Demon)
You have one day. Good luck.

### Auditor (Evil, Demon)
I corrupt two Villagers and turn another into the Repossessed.

### Court (Evil, Demon)
I turn every Good card into the Juror and every Evil into the Court. I lie and disguise as the Juror.

### Crazed (Evil, Demon)
All Good cards are Mad. 

### Starspawn (Evil, Demon)
3 cards have Unknown Obstacle.

### Vortox (Evil, Demon)
A random Weather card is summoned.

### Fallen Prophet (Evil, Demon)
The world is chaos itself!

# COVENANT
Covenant can only spawn with fellow Covenant. A member of the Covenant is deemed to have the Necronomicon, and may kill every night.

## COVENANT DEMONS

### Archmage (Evil, Covenant)
I turn a random Villager into a Cult Member. I sit next to a Covenant.

### Hex Master (Evil, Covenant)
I Hex a Good card every night. If every Good card is hexed, you lose.

## COVENANT MINIONS

### Brewer (Evil, Covenant)
One card randomly has one of three affects: Mad, Corrupted or Unknown Obstacle.

### Cult Member (Evil, Covenant)
I do nothing.

### Powder Maker (Evil, Covenant)
I badly poison a card. If that card dies, another Good card is killed.

### Slinger (Evil, Covenant)
Upon starting, I kill a Good card.

### Voodoo Master (Evil, Covenant)
I silence a Good card.

### Wildling (Evil, Covenant)
A random evil becomes truthful. They are marked as being affected by evil.

# MAFIA
Mafia can only spawn with fellow Mafia. You cannot see which Minions spawned in a Mafia round.

## MAFIA DEMONS

### Godfather (Evil, Mafia)
I turn a random Villager into a Grunt. I sit next to a Mafia.

### Mafioso (Evil, Mafia)
I kill every night, dealing 1 damage. Day lasts half as long.

## MAFIA MINIONS

### Ambusher (Evil, Mafia)
One card dies upon being revealed.

### Bootlegger (Evil, Mafia)
2 cards are Intoxicated. I prioritize affecting On-Pick cards.

### Enforcer (Evil, Mafia)
One card has Unknown Obstacle on them.

### Forger (Evil, Mafia)
A Good and Evil card swap registered cards.

### Gangster (Evil, Mafia)
If I am next to an Evil and a Good card, at night, I kill my neighboring Good card, dealing 2 damage.

### Grunt (Evil, Mafia)
I do nothing.

### Influencer (Evil, Mafia)
A Good card is corrupted and registers as disguised.

### Spokesperson (Evil, Mafia)
One villager turns into an Outcast. If any Outcasts die, I kill at night, dealing 2 damage.

## NEUTRALS
The 2nd Gimmick. Neutrals! Neutral characters take up an Outcast slot. On Roundstart, there is a 50% chance they turn Evil, or turn Good. Their
effects might change depending on their alignment.

### Actress
I disguise as a random Villager. If I am good, they are Corrupted. If I am evil, I lie.

### Advisor
On Roundstart, I change an opposing card's alignment to my own. 

### Apprentice
I become an in-play Villager or Minion.

### Court Fool
I lie and disguise. I register as Evil. If I am executed, I kill Good if I am Evil, and Evil if I am Good.

### Doomsayer
On Pick, I kill 2 cards, one is always a Villager, the other is opposing my alignment.

### Hangman
When revealed, I call a card Evil. I am truthful if Good and lying if Evil. Killing my target if I am Evil deals 3 extra damage.

### Pirate
On Roundstart, I duel a card. If I duel my alignment, I fail to plunder them. If not, they die. 

### Psychopath
Every night, I kill a card. I kill Good if I am Evil, and Evil if I am Good. I deal 2 damage per kill if I am Good.

### Scapegoat
If you kill my target, I die and deal 5 damage to you

## WEATHER 

Weather are effects applied to villages as a whole.

### Stormy
More Outcasts are in-play

### Foggy
You cannot see your deckview

### Sunny
Villagers have an increasing chance of becoming corrupted

### Snowy
2 cards become Snowed in, and become useless
