using Il2Cpp;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace Demon_Bluff_Mods;
[RegisterTypeInIl2Cpp]
public class Counterfeiter : Minion
{
    public Counterfeiter() : base(ClassInjector.DerivedConstructorPointer<Counterfeiter>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Counterfeiter(System.IntPtr ptr) : base(ptr)
    {

    }
    public override string Description
    {
        get
        {
            return "This is a cool role!";
        }
    }
    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        

    }
    public override void BluffAct(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.AfterRoundStart)
        {
            MelonLogger.Msg("Counterfeiter triggered");
            if (!charRef.statuses.statuses.Contains(Obscured.Obscure))
            {
                testMethod(charRef);
                if (!(charRef.bluff.characterId == "Knight_47970624"))
                {
                    charRef.statuses.AddStatus(ECharacterStatus.AppearTruthfull, charRef);
                    charRef.statuses.AddStatus(ECharacterStatus.HealthyBluff, charRef);
                }

            }
        }
        if (trigger == ETriggerPhase.Any)
        {
            charRef.statuses.statuses.Remove(Protected.protect);
        }
    }
    public static string wrongName(string desc)
    {
    char[] allChars = desc.ToCharArray();
    Il2CppSystem.Collections.Generic.List<string> words = new Il2CppSystem.Collections.Generic.List<string>();
    foreach (char c in allChars)
    {
        words.Add(c.ToString());
    }
    int firstRandoNum = UnityEngine.Random.Range(1, words.Count);
    int secondRandoNum = Calculator.RemoveNumberAndGetRandomNumberFromList(firstRandoNum, 1, words.Count);
        
    string temp = words[firstRandoNum];
        
       do {
            secondRandoNum = Calculator.RemoveNumberAndGetRandomNumberFromList(firstRandoNum, 1, words.Count);
        } while (temp == words[secondRandoNum]) ;
    words[firstRandoNum] = words[secondRandoNum];
    words[secondRandoNum] = temp;
    string newString = "";
    foreach (string word in words)
    {
        newString += word;
    }
    return newString;
}
public CharacterData myBluffData;
public override CharacterData GetBluffIfAble(Character charRef)
{
    if (charRef.GetRegisterAs() != charRef.dataRef)
    {
        return charRef.GetRegisterAs();
    }
    int diceRoll = Calculator.RollDice(10);
    CharacterData bluff = Characters.Instance.GetRandomDuplicateBluff();

    if (diceRoll < 5)
    {
        // 100% Double Claim
        bluff = Characters.Instance.GetRandomDuplicateBluff();
    }
    else
    {
        // Become a new character
        bluff = Characters.Instance.GetRandomUniqueBluff();
        Gameplay.Instance.AddScriptCharacterIfAble(bluff.type, bluff);
    }
    return bluff;
}
public override CharacterData GetRegisterAsRole(Character charRef) // May have yoinked this from Linear's expansion pack because fml this guy is *not* working with my code for some reason. Thanks and sorry Linear.
                                                                   //I counteryoinked Wingidon so um... double steal ig?
{
        if (!charRef.statuses.statuses.Contains(Obscured.Obscure))
        {
            if (charRef.bluff == true)
            {
                return charRef.bluff;
            }

            Il2CppSystem.Collections.Generic.List<CharacterData> notInPlayCh = Gameplay.Instance.GetScriptCharacters();
            notInPlayCh = Characters.Instance.FilterCharacterType(notInPlayCh, ECharacterType.Villager);
            notInPlayCh = Characters.Instance.FilterBluffableCharacters(notInPlayCh);

            myBluffData = notInPlayCh[UnityEngine.Random.Range(0, notInPlayCh.Count - 1)];

            return myBluffData;
        }
        return charRef.dataRef;
}
public void testMethod(Character __instance)
{
        GameObject content = GameObject.Find("Game/Gameplay/Content");
        NightPhase nightPhase = content.GetComponent<NightPhase>();
        CharacterData resetData = __instance.bluff;

    // CRITICAL FIX: Clone the object via Unity's Instantiate so you don't corrupt the global game data pool
        CharacterData cd = new();


        // Copy over the roles and states cleanly to the runtime clone
        // Mutate the clone's text properties securely
        cd.role = resetData.role;
        cd.name = wrongName(resetData.name);
        cd.characterName = cd.name;
        cd.description = resetData.description;
        cd.flavorText = resetData.flavorText;
        cd.hints = resetData.hints;
        cd.ifLies = resetData.ifLies;
        cd.notes = resetData.notes;
        cd.picking = resetData.picking;
        cd.startingAlignment = resetData.startingAlignment;
        cd.type = resetData.type;
        cd.abilityUsage = resetData.abilityUsage;
        cd.bluffable = resetData.bluffable;
        cd.characterId = resetData.characterId;
        cd.artBgColor = resetData.artBgColor;
        cd.cardBgColor = resetData.cardBgColor;
        cd.cardBorderColor = resetData.cardBorderColor;
        cd.color = resetData.color;
        nightPhase.nightCharactersOrder.Add(cd);
        cd.additionalFlavorTexts = new Il2CppStringArray(1);
        cd.additionalFlavorTexts[0] = cd.flavorText;
        cd.gender = resetData.gender;
        if(resetData.art_cute != null)
        {
            cd.art_cute = resetData.art_cute;
        }
        // Re-initialize the active entity with your safe runtime clone data
        __instance.GiveBluff(cd);
        __instance.RevealBluff();
        __instance.RefreshCharacter();

}

}