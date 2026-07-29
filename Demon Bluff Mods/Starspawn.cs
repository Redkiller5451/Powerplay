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
public class Starspawn : Demon
{
    public Starspawn() : base(ClassInjector.DerivedConstructorPointer<Starspawn>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Starspawn(System.IntPtr ptr) : base(ptr)
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
        ActedInfo actedInfo = new ActedInfo("I have declared a Tribunal!", null);
        return actedInfo;
    }


    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.AfterRoundStart)
        {
            Gameplay gameplay = Gameplay.Instance;
            Characters instance = Characters.Instance;
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            Il2CppSystem.Collections.Generic.List<Character> list3 = new();
            foreach(Character chara in list1)
                list3.Add(chara);
            Il2CppSystem.Collections.Generic.List<Character> list2 = new Il2CppSystem.Collections.Generic.List<Character>();
            if (list1.Count > 0)
            {
                Character random = list3[UnityEngine.Random.Range(0, list3.Count)];
                random.statuses.AddStatus(ECharacterStatus.MessedUpByEvil, charRef);
                random.statuses.AddStatus(StarspawnCheck.starspawnCheck, charRef);
                list2.Add(random);
                list3.Remove(random);
                if (list1.Count > 0)
                {
                    random = list3[UnityEngine.Random.Range(0, list3.Count)];
                    random.statuses.AddStatus(ECharacterStatus.MessedUpByEvil, charRef);
                    random.statuses.AddStatus(StarspawnCheck.starspawnCheck, charRef);
                    list2.Add(random);
                    list3.Remove(random);
                    if (list1.Count > 0)
                    {
                        random = list3[UnityEngine.Random.Range(0, list3.Count)];
                        random.statuses.AddStatus(ECharacterStatus.MessedUpByEvil, charRef);
                        random.statuses.AddStatus(StarspawnCheck.starspawnCheck, charRef);
                        list2.Add(random);
                        list3.Remove(random);
                    }
                }
            }

            foreach (Character character in list2)
            {
                character.statuses.AddStatus(UO.UnknownObstacle, character);
            }

        }
        if(trigger == ETriggerPhase.OnExecuted)
        {
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            list1 = Characters.Instance.FilterCharacterContainsStatus(list1, StarspawnCheck.starspawnCheck);
            foreach (Character character in list1)
            {
                character.statuses.statuses.Remove(UO.UnknownObstacle);
            }
        }
    }

    //Taken from Wingidons Undying 
}
