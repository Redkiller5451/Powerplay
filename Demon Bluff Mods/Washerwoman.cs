using Il2Cpp;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static MelonLoader.MelonLogger;

namespace Demon_Bluff_Mods;
[RegisterTypeInIl2Cpp]

//THis 
public class Washerwoman : Role // Druid :
{
    Character chRef;
    public Washerwoman() : base(ClassInjector.DerivedConstructorPointer<Washerwoman>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        action1 = new System.Action(CharacterPicked);
        action2 = new System.Action(StopPick);
        action3 = new System.Action(CharacterPickedDrunk);
    }
    public Washerwoman(System.IntPtr ptr) : base(ptr)
    {
        ClassInjector.DerivedConstructorBody(this);
        action1 = new System.Action(CharacterPicked);
        action2 = new System.Action(StopPick);
        action3 = new System.Action(CharacterPickedDrunk);
    }
    public override string Description
        => "Pick 2 players. Learn which Outsider is among them (if any)";

    string drunkId = "Drunk_15369527";

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
        CharacterPicker.Instance.StartPickCharacters(3, charRef);
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
            if (c.GetRegisterAs().type == ECharacterType.Villager)
                outsiders.Add(c);
        }

        ids = ids
            .OrderBy(c => c)
            .ThenBy(_ => UnityEngine.Random.value)
            .ToList();

        string info = ConjourInfo(ids[0], ids[1], ids[2], null);

        if (outsiders.Count > 0)
        {
            Character randomOutsider = outsiders[UnityEngine.Random.Range(0, outsiders.Count)];

            info = ConjourInfo(ids[0], ids[1], ids[2], randomOutsider.GetCharacterData());
        }

        Il2CppSystem.Collections.Generic.List<Character> chars = CharacterPicker.PickedCharacters;
        onActed?.Invoke(new ActedInfo(info, chars));
        Debug.Log($"{info}");
    }

    public override void BluffAct(ETriggerPhase trigger, Character charRef)
    {
        if (trigger != ETriggerPhase.Day) return;
        chRef = charRef;
        CharacterPicker.Instance.StartPickCharacters(3, charRef);
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
            if (c.GetRegisterAs().type == ECharacterType.Villager)
                outsiders.Add(c);
        }

        ids = ids
            .OrderBy(c => c)
            .ThenBy(_ => UnityEngine.Random.value)
            .ToList();

        string info = $"";
        //All this code is courtesy of BetterLies. Go thank Skill Cycler
        if (outsiders.Count > 0)
            info = ConjourInfo(ids[0], ids[1], ids[2], null);
        // picking an outcast + minion disguised as a different outcast should say the minion disguise
        CharacterData fake = null;
        foreach (Character c in CharacterPicker.PickedCharacters)
        {
            if (c.bluff)
            {
                if (c.bluff.type == ECharacterType.Villager)
                {
                    bool valid = true;
                    foreach (Character c2 in CharacterPicker.PickedCharacters)
                    {
                        if (c.bluff.characterId == c2.dataRef.characterId)
                        {
                            valid = false;
                        }
                    }
                    if (valid) fake = c.bluff;
                }
            }
        }
        if (fake != null)
        {
            info = ConjourInfo(ids[0], ids[1], ids[2], fake);
        }
        else
        {
            Il2CppSystem.Collections.Generic.List<CharacterData> scriptOutsiders = Gameplay.Instance.GetScriptCharacters();
            Il2CppSystem.Collections.Generic.List<CharacterData> pickedOutsiders = new Il2CppSystem.Collections.Generic.List<CharacterData>();
            scriptOutsiders = Characters.Instance.FilterCharacterType(scriptOutsiders, ECharacterType.Villager);

            foreach (CharacterData c in scriptOutsiders)
                if (!c.bluffable)
                    pickedOutsiders.Add(c);

            if (pickedOutsiders.Count == 0)
            {
                scriptOutsiders = Gameplay.Instance.GetAllAscensionCharacters();
                scriptOutsiders = Characters.Instance.FilterCharacterType(scriptOutsiders, ECharacterType.Villager);

                foreach (CharacterData c in scriptOutsiders)
                    if (!c.bluffable && c.name != "Saint")
                        pickedOutsiders.Add(c);

                if (pickedOutsiders.Count == 0)
                {
                    foreach (CharacterData c in scriptOutsiders)
                        if (c.name != "Saint")
                            pickedOutsiders.Add(c);
                }
            }
            else
            {
                foreach (CharacterData c in scriptOutsiders)
                    if (c.bluffable && c.name != "Saint")
                        pickedOutsiders.Add(c);
            }

            CharacterData randomOutsider = pickedOutsiders[UnityEngine.Random.Range(0, pickedOutsiders.Count)];
           info = ConjourInfo(ids[0], ids[1], ids[2], randomOutsider);
            
        }

        Il2CppSystem.Collections.Generic.List<Character> chars = CharacterPicker.PickedCharacters;

        onActed?.Invoke(new ActedInfo(info, chars));
        Debug.Log($"{info}");
    }

    public string ConjourInfo(int id1, int id2, int id3, CharacterData cd)
    {

        string info = $"";

        if (cd == null)
            info = $"Among #{id1}, #{id2}, #{id3}\nthere are NO Villagers";
        else
            info = $"Among #{id1}, #{id2}, #{id3}\nthere is: {cd.GetCharacterName()}";

        return info;
    }
}
