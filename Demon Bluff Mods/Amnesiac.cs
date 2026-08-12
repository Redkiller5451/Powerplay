using HarmonyLib;
using Il2Cpp;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppSystem;
using MelonLoader;
using System;
using System.ComponentModel.Design;
using UnityEngine;
using static MelonLoader.MelonLaunchOptions;
using static UnityEngine.GraphicsBuffer;

namespace Demon_Bluff_Mods;
[RegisterTypeInIl2Cpp]
public class Amnesiac : Role
{
    public Amnesiac() : base(ClassInjector.DerivedConstructorPointer<Amnesiac>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);

    }
    public Amnesiac(System.IntPtr ptr) : base(ptr)
    {

    }
    public CharacterData[] allDatas = Il2CppSystem.Array.Empty<CharacterData>();
    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Day)
        {
            
            Il2CppSystem.Collections.Generic.List<Role> possibleTPOWs = new();
            //This is such a janky fix but it works so f- it
            charRef.dataRef.picking = true;
            
            possibleTPOWs.Add(new Amnesiac1Pick()); // First Amne
            possibleTPOWs.Add(new Amnesiac2Pick()); // Second Amne
            possibleTPOWs.Add(new Amnesiac3Pick()); // Third Amne
            possibleTPOWs.Add(new Amnesiac4Pick()); // Fourth Amne
            possibleTPOWs.Add(new Amnesiac5Pick()); // Fifth Amne
            possibleTPOWs.Add(new Amnesiac6Pick()); // Sixth Amne
            int randomize = UnityEngine.Random.RandomRangeInt(0, possibleTPOWs.Count);
            Role chosenTPOW = possibleTPOWs[randomize];

            MelonLogger.Msg($"[LOG] Amnesiac chose ability {randomize}");
            charRef.role = chosenTPOW;
        }
    }

    public override void BluffAct(ETriggerPhase trigger, Character charRef)
    {
       
        if (trigger == ETriggerPhase.Day)
        {

            MelonLogger.Msg($"[LOG] Fake Amnesiac ping");
            Il2CppSystem.Collections.Generic.List<Role> possibleTPOWs = new();
            //This is such a janky fix but it works so f- it
            charRef.bluff.picking = true;

            possibleTPOWs.Add(new Amnesiac1Pick()); // First Amne
            possibleTPOWs.Add(new Amnesiac2Pick()); // Second Amne
            possibleTPOWs.Add(new Amnesiac3Pick()); // Third Amne
            possibleTPOWs.Add(new Amnesiac4Pick()); // Fourth Amne
            possibleTPOWs.Add(new Amnesiac5Pick()); // Fifth Amne
            possibleTPOWs.Add(new Amnesiac6Pick()); // Sixth Amne
            int randomize = UnityEngine.Random.RandomRangeInt(0, possibleTPOWs.Count);
            Role chosenTPOW = possibleTPOWs[randomize];

            MelonLogger.Msg($"[LOG] Fake Amnesiac chose ability {randomize}");
            charRef.bluffRole = chosenTPOW;
        }
    }

}
//5 on-pick abilities
//5 non on-pick abilities
