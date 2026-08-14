using Il2Cpp;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSoftMasking.Samples;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using System;
using UnityEngine;
using static MelonLoader.MelonLaunchOptions;
using static MelonLoader.Modules.MelonModule;

namespace Demon_Bluff_Mods;
[RegisterTypeInIl2Cpp]
public class Oracle2 : Role
{
    public Oracle2() : base(ClassInjector.DerivedConstructorPointer<Oracle2>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Oracle2(System.IntPtr ptr) : base(ptr)
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
        ActedInfo actedInfo = new ActedInfo("There was no roles I could protect!", null);
        return actedInfo;
    }
    public override ActedInfo GetBluffInfo(Character charRef)
    {
        ActedInfo actedInfo = new ActedInfo("I am not a Pilgrim!", null);
        return actedInfo;
    }
    public override void Act(ETriggerPhase trigger, Character charRef)
    {
            if (trigger == ETriggerPhase.Day)
        {
            if (charRef.statuses.Contains(ECharacterStatus.Corrupted))
            {
                Il2CppSystem.Collections.Generic.List<Character> unrevealedCharacters = Characters.Instance.FilterHiddenCharacters(Gameplay.CurrentCharacters);
                unrevealedCharacters = Characters.Instance.FilterBluffingCharacters(unrevealedCharacters);
                Il2CppSystem.Collections.Generic.List<string> unrevealedRoles = new();
                foreach (Character character in unrevealedCharacters)
                {
                    if (!unrevealedRoles.Contains(character.bluff.characterId))
                    {
                        unrevealedRoles.Add(character.bluff.characterId);
                    }
                }
                if (unrevealedRoles.Count == 0)
                {
                    onActed?.Invoke(GetInfo(charRef));
                }
                else
                {
                    string protectedRole = unrevealedRoles[UnityEngine.Random.Range(0, unrevealedRoles.Count)];
                    string protectedRoleName = "";
                    foreach (Character character in unrevealedRoles)
                    {
                        if (character.dataRef.characterId == protectedRole)
                        {
                            protectedRoleName = character.dataRef.characterName;
                            break;
                        }
                    }
                    onActed?.Invoke(new ActedInfo($"I protected {protectedRoleName} from Corruption!"));

                }
            }
            else
            {
                Il2CppSystem.Collections.Generic.List<Character> unrevealedCharacters = Characters.Instance.FilterHiddenCharacters(Gameplay.CurrentCharacters);
                unrevealedCharacters = Characters.Instance.FilterCharacterType(unrevealedCharacters, ECharacterType.Villager);
                Il2CppSystem.Collections.Generic.List<string> unrevealedRoles = new();
                foreach(Character character in unrevealedCharacters)
                {
                    if (!unrevealedRoles.Contains(character.dataRef.characterId))
                    {
                        unrevealedRoles.Add(character.dataRef.characterId);
                    }
                }
                if (unrevealedRoles.Count == 0)
                {
                    onActed?.Invoke(GetInfo(charRef));
                }
                else
                {
                    string protectedRole = unrevealedRoles[UnityEngine.Random.Range(0, unrevealedRoles.Count)];
                    string protectedRoleName = "";
                    foreach(Character character in unrevealedCharacters)
                    {
                        if(character.dataRef.characterId == protectedRole)
                        {
                            character.statuses.statuses.Remove(ECharacterStatus.Corrupted);
                            character.statuses.AddResistance(ECharacterStatus.Corrupted, charRef);
                            protectedRoleName = character.dataRef.characterName;
                        }
                    }
                    onActed?.Invoke(new ActedInfo($"I protected {protectedRoleName} from Corruption!"));

                }
            }

        }
    }
    public override void BluffAct(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Day)
        {
            Il2CppSystem.Collections.Generic.List<Character> unrevealedCharacters = Characters.Instance.FilterHiddenCharacters(Gameplay.CurrentCharacters);
            unrevealedCharacters = Characters.Instance.FilterBluffingCharacters(unrevealedCharacters);
            Il2CppSystem.Collections.Generic.List<string> unrevealedRoles = new();
            foreach (Character character in unrevealedCharacters)
            {
                if (!unrevealedRoles.Contains(character.bluff.characterId))
                {
                    unrevealedRoles.Add(character.bluff.characterId);
                }
            }
            if (unrevealedRoles.Count == 0)
            {
                onActed?.Invoke(GetInfo(charRef));
            }
            else
            {
                string protectedRole = unrevealedRoles[UnityEngine.Random.Range(0, unrevealedRoles.Count)];
                string protectedRoleName = "";
                foreach (Character character in unrevealedCharacters)
                {
                    if (character.dataRef.characterId == protectedRole)
                    {
                        protectedRoleName = character.dataRef.characterName;
                        break;
                    }
                }
                onActed?.Invoke(new ActedInfo($"I protected {protectedRoleName} from Corruption!"));

            }

        }
    }
    public override CharacterData? GetBluffIfAble(Character charRef)
    {
        return null;
    }
}
