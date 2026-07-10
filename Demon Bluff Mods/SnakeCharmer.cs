using Il2Cpp;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Demon_Bluff_Mods;
[RegisterTypeInIl2Cpp]
public class SnakeCharmer : Role
{

    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Start)
        {
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            list1 = Characters.Instance.FilterAlignmentCharacters(list1, EAlignment.Evil);
            int randomIndex = UnityEngine.Random.Range(0, list1.Count);
            Character random = list1[randomIndex];
            CharacterData pickedEvil = random.dataRef;
            MelonLogger.Msg($"{random.id} is the Evil");
            random.Init(charRef.dataRef);
            charRef.Init(pickedEvil);
            random.DisableStartAbility();
            MelonLogger.Msg($"{random.id} is the Evil");
            MelonLogger.Msg($"The Snake Charmer has swapped #{charRef.id} and #{random.id}");
        }
        if(trigger == ETriggerPhase.Day)
        {
            onActed?.Invoke(new ActedInfo($"I have been charmed by the Flutist!", null));
        }
    }
    public override CharacterData GetRegisterAsRole(Character charRef)
    {
        //Taken from the Wretches code. Used to make the current Flutist still register as evil!
        Il2CppSystem.Collections.Generic.List<CharacterData> allChars = Gameplay.Instance.GetScriptCharacters();
        allChars = Characters.Instance.FilterCharacterAlignment(allChars, EAlignment.Evil);
        CharacterData randomMinion = allChars[UnityEngine.Random.Range(0, allChars.Count)];

        return randomMinion;
    }
    public SnakeCharmer() : base(ClassInjector.DerivedConstructorPointer<SnakeCharmer>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public SnakeCharmer(System.IntPtr ptr) : base(ptr)
    {
    }
}