using Il2Cpp;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demon_Bluff_Mods;
[RegisterTypeInIl2Cpp]
public class Huntress : Role
{
    public Huntress() : base(ClassInjector.DerivedConstructorPointer<Huntress>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Huntress(System.IntPtr ptr) : base(ptr)
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
        Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
        Il2CppSystem.Collections.Generic.List<Character> list2 = Characters.Instance.FilterAliveCharacters(list1);
        list2 = Characters.Instance.FilterAlignmentCharacters(list2, EAlignment.Evil);
        list1 = Characters.Instance.FilterCharacterContainsStatus(list1, ECharacterStatus.MessedUpByEvil);
        list1 = Characters.Instance.FilterOutStatus(list1, ECharacterStatus.KilledByEvil);
        ActedInfo actedInfo;
        if (list1.Count > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, list1.Count);
            Character random = list1[randomIndex];
            int randomIndex2 = UnityEngine.Random.Range(0, list2.Count);
            Character random2 = list2[randomIndex2];
            actedInfo = new ActedInfo($"I have tracked #{random2.id} to #{random.id}'s house!", null);
        }
        else
        {
            actedInfo = new ActedInfo($"I couldn't track anyone.", null);
        }


            return actedInfo;
    }
    public override ActedInfo GetBluffInfo(Character charRef)
    {
        Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
        Il2CppSystem.Collections.Generic.List<Character> list2 = Characters.Instance.FilterAliveCharacters(list1);
        list2 = Characters.Instance.FilterAlignmentCharacters(list2, EAlignment.Good);
        list2.Remove(charRef);
        list1 = Characters.Instance.FilterOutStatus(list1, ECharacterStatus.KilledByEvil);
        ActedInfo actedInfo;
        if (list1.Count > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, list1.Count);
            Character random = list1[randomIndex];
            int randomIndex2 = UnityEngine.Random.Range(0, list2.Count);
            Character random2 = list2[randomIndex2];
            actedInfo = new ActedInfo($"I have tracked #{random2.id} to #{random.id}'s house!", null);
        }
        else
        {
            actedInfo = new ActedInfo($"You shouldn't see this message. I am lying.", null);
        }
        return actedInfo;
    }
    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Day)
        {
            if (charRef.statuses.Contains(ECharacterStatus.Corrupted))
            {
                onActed?.Invoke(GetBluffInfo(charRef));
            }
            else
            {
                onActed?.Invoke(GetInfo(charRef));
            }

        }
    }
    public override void BluffAct(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Day)
        {
            this.onActed.Invoke(this.GetBluffInfo(charRef));

        }
    }
    public override CharacterData? GetBluffIfAble(Character charRef)
    {
        return null;
    }
}
