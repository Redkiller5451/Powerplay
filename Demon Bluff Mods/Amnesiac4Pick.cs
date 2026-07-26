using HarmonyLib;
using Il2Cpp;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem;
using MelonLoader;
using System;
using System.ComponentModel.Design;
using UnityEngine;
using static MelonLoader.MelonLaunchOptions;
using static UnityEngine.GraphicsBuffer;

namespace Demon_Bluff_Mods;
[RegisterTypeInIl2Cpp]
public class Amnesiac4Pick : Role
{
    Character chRef;
    public Amnesiac4Pick() : base(ClassInjector.DerivedConstructorPointer<Amnesiac4Pick>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        action1 = new System.Action(CharacterPicked);
        action2 = new System.Action(StopPick);
        action3 = new System.Action(CharacterPickedDrunk);
    }
    public Amnesiac4Pick(System.IntPtr ptr) : base(ptr)
    {
        action1 = new System.Action(CharacterPicked);
        action2 = new System.Action(StopPick);
        action3 = new System.Action(CharacterPickedDrunk);
    }
    public override ActedInfo GetInfo(Character charRef)
    {
        return new ActedInfo("");
    }
    public override ActedInfo GetBluffInfo(Character charRef)
    {
        return new ActedInfo("");
    }
    private Il2CppSystem.Action action1;
    private Il2CppSystem.Action action2;
    private Il2CppSystem.Action action3;
    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger != ETriggerPhase.Day) return;
        chRef = charRef;
        CharacterPicker.Instance.StartPickCharacters(1, charRef);
        CharacterPicker.OnCharactersPicked += action1;
        CharacterPicker.OnStopPick += action2;
    }
    private void StopPick()
    {
        CharacterPicker.OnCharactersPicked -= action1;
        CharacterPicker.OnCharactersPicked -= action3;
        CharacterPicker.OnStopPick -= action2;

    }

    private void CharacterPicked()
    {
        CharacterPicker.OnCharactersPicked -= action1;
        CharacterPicker.OnStopPick -= action2;
        List<Character> outsiders = new List<Character>();
        List<int> ids = new List<int>();
        foreach (Character c in CharacterPicker.PickedCharacters)
        {
            ids.Add(c.id);
            outsiders.Add(c);
        }
        onActed?.Invoke(new ActedInfo(ConjourInfo(DoTheyHaveAStatus(outsiders[0]), outsiders[0])));
    }

    public override void BluffAct(ETriggerPhase trigger, Character charRef)
    {
        if (trigger != ETriggerPhase.Day) return;
        CharacterPicker.Instance.StartPickCharacters(1, charRef);
        CharacterPicker.OnCharactersPicked += action3;
        CharacterPicker.OnStopPick += action2;
    }
    private void CharacterPickedDrunk()
    {
        CharacterPicker.OnCharactersPicked -= action3;
        CharacterPicker.OnStopPick -= action2;
        List<Character> outsiders = new List<Character>();
        List<int> ids = new List<int>();
        foreach (Character c in CharacterPicker.PickedCharacters)
        {
            ids.Add(c.id);
            outsiders.Add(c);
        }
        onActed?.Invoke(new ActedInfo(ConjourInfo(!DoTheyHaveAStatus(outsiders[0]), outsiders[0])));

    }
    public bool DoTheyHaveAStatus(Character picked)
    {
        if(picked.statuses.statuses.Count == 0) return false;
        List<ECharacterStatus> statuses = new List<ECharacterStatus>();
        foreach (ECharacterStatus c in picked.statuses.statuses)
        {
            if(isNotStatus(c)) statuses.Add(c);
        }
        return statuses.Count > 0;
    }
    private bool isNotStatus(ECharacterStatus status)
    {
        List<ECharacterStatus> invalidStatuses = new List<ECharacterStatus>();

        return status.Equals((ECharacterStatus)901) || status.Equals((ECharacterStatus)902) ||
            status.Equals((ECharacterStatus)903) || status.Equals((ECharacterStatus)904) ||
            status.Equals((ECharacterStatus)918918) || status.Equals((ECharacterStatus)82113114) ||
            status.Equals((ECharacterStatus)1618119) || status.Equals((ECharacterStatus)2051879715) ||
            status.Equals((ECharacterStatus)2051879522) || status.Equals((ECharacterStatus)2114495619) ||
            status.Equals((ECharacterStatus)2114495161) || status.Equals((ECharacterStatus)2114495239) ||
            status.Equals((ECharacterStatus)1201) || status.Equals((ECharacterStatus)1202) ||
            status.Equals((ECharacterStatus)1203) || status.Equals((ECharacterStatus)1204) ||
            status.Equals((ECharacterStatus)874) || status.Equals((ECharacterStatus)876) ||
            status.Equals((ECharacterStatus)879) || status.Equals((ECharacterStatus)882) ||
            status.Equals((ECharacterStatus)318251620) || status.Equals(SailorPing.sailorPing) ||
            status.Equals((ECharacterStatus.HealthyBluff)) || status.Equals((ECharacterStatus.AppearDisguised)) ||
            status.Equals((ECharacterStatus.AppearHonest)) || status.Equals((ECharacterStatus.AppearLying)) ||
            status.Equals((ECharacterStatus.AppearTruthfull)) || status.Equals((ECharacterStatus.BrokenAbility)) ||
            status.Equals((ECharacterStatus.HealthyBluff)) || status.Equals((ECharacterStatus.UnkillableByDemon)) ||
            status.Equals((ECharacterStatus.WorkingAbility)) || status.Equals((ECharacterStatus.NoDamage)) ||
            status.Equals((ECharacterStatus.Lying)) || status.Equals((MadVictim.madVictim));
    }
    public string ConjourInfo(bool status, Character picked)
    {
        MelonLogger.Msg($"[LOG] Amne 4 triggered");
        if (status)
        {
            return $"I picked #{picked.id} have received a yes!";
        }
        return $"I picked #{picked.id} have received a no!";
    }
}
