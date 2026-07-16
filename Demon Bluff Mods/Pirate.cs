using HarmonyLib;
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
using static MelonLoader.MelonLaunchOptions;
using static UnityEngine.GraphicsBuffer;

namespace Demon_Bluff_Mods;
[RegisterTypeInIl2Cpp]
public class Pirate : Neutrals
{

    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Start)
        {

            changeAlignement(charRef);

            Gameplay gameplay = Gameplay.Instance;
            Characters instance = Characters.Instance;
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            list1.Remove(charRef);
            int characterId = UnityEngine.Random.Range(0, list1.Count);
            list1[characterId].statuses.statuses.Add(Dueled.dueled);
        }
        if (trigger == ETriggerPhase.Day)
        {
            Gameplay gameplay = Gameplay.Instance;
            Characters instance = Characters.Instance;
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            Character character = Characters.Instance.FilterCharacterContainsStatus(list1, Dueled.dueled)[0];
            if (PickedAlignment(character,charRef))
            {
                charRef.KillByDemon(character);
            }
            else
            {
                character.KillByDemon(charRef);
                onActed?.Invoke(new ActedInfo($"I have successfully plundered #{character.id}", Characters.Instance.FilterCharacterContainsStatus(list1, Dueled.dueled)));
            }
        }
    }
    public bool PickedAlignment(Character picked, Character charRef)
    {
        if (picked.role is Goon)
        {
            return charRef.alignment == EAlignment.Good;
        }
        return charRef.GetRegisterAlignment() == picked.GetRegisterAlignment();
    }
    public Pirate() : base(ClassInjector.DerivedConstructorPointer<Pirate>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Pirate(System.IntPtr ptr) : base(ptr)
    {
    }

    //Thank you to Caldo for the PoKill status
    public static class Dueled
    {
        public static ECharacterStatus dueled = (ECharacterStatus)195;
    }
}
