using Il2Cpp;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using HarmonyLib;

namespace Demon_Bluff_Mods;
[RegisterTypeInIl2Cpp]
public class Doomsayer : Neutrals
{

    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Start)
        {
            changeAlignement(charRef);
        }
        
            if (trigger == ETriggerPhase.Day)
        {
            
            if (charRef.alignment == EAlignment.Evil)
            {
                MelonLogger.Msg("The Doomsayer is Evil");
                Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                list1 = Characters.Instance.FilterCharacterType(list1, ECharacterType.Villager);
                list1 = Characters.Instance.FilterRealAlignmentCharacters(list1, EAlignment.Good);
                Il2CppSystem.Collections.Generic.List<Character> list2 = new Il2CppSystem.Collections.Generic.List<Character>();
                list1 = Characters.Instance.FilterRealCharacterType(list1, ECharacterType.Villager);
                list1 = Characters.Instance.FilterAliveCharacters(list1);
                string line;

                if (list1.Count > 0)
                {
                     int randomIndex = UnityEngine.Random.Range(0, list1.Count);
                    Character random = list1[randomIndex];
                    line = $"#{random.id} is a Villager!";
                    list2.Add(random);
                    list1.Remove(random);
                    if (list1.Count > 0)
                    {
                        randomIndex = UnityEngine.Random.Range(0, list1.Count);
                        random = list1[randomIndex];
                        line += $"\n#{random.id} is a Villager!";
                        list2.Add(random);
                        list1.Remove(random);
                    }
                }
                if (list2.Count>0)
                    list2[0].KillByDemon(charRef);
                else
                {
                    onActed?.Invoke(new ActedInfo("There is noone else to doom!"));
                    charRef.dataRef.picking = false;
                }
                if (list2.Count > 1)
                    list2[1].KillByDemon(charRef);
                else
                {
                    onActed?.Invoke(new ActedInfo("There is noone else to doom!"));
                    charRef.dataRef.picking = false;
                }
                Health health = PlayerController.PlayerInfo.health;
                health.Damage(6);
            }
            else
            {
                MelonLogger.Msg("The Doomsayer is Good");
                Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                Il2CppSystem.Collections.Generic.List<Character> list3 = Characters.Instance.FilterRealAlignmentCharacters(list1, EAlignment.Evil);
                list1 = Characters.Instance.FilterRealCharacterType(list1, ECharacterType.Villager);
                list1 = Characters.Instance.FilterRealAlignmentCharacters(list1, EAlignment.Good);
                Il2CppSystem.Collections.Generic.List<Character> list2 = new Il2CppSystem.Collections.Generic.List<Character>();
                list1 = Characters.Instance.FilterRealCharacterType(list1, ECharacterType.Villager);
                list1 = Characters.Instance.FilterAliveCharacters(list1);
                list3 = Characters.Instance.FilterAliveCharacters(list3);
                if (list1.Count > 0)
                {
                    int randomIndex = UnityEngine.Random.Range(0, list1.Count);
                    Character random = list1[randomIndex];
                    list2.Add(random);
                    list1.Remove(random);
                    
                }               
                if (list3.Count > 0)
                    {
                    int randomIndex = UnityEngine.Random.Range(0, list3.Count);
                    Character random = list3[randomIndex];
                    list2.Add(random);
                    list3.Remove(random);
                    }
                if (list2.Count > 0)
                    list2[0].KillByDemon(charRef);
                else
                {
                    onActed?.Invoke(new ActedInfo("There is noone else to doom!"));
                    charRef.dataRef.picking = false;
                }
                if (list2.Count > 1)
                    list2[1].KillByDemon(charRef);
                else
                {
                    onActed?.Invoke(new ActedInfo("There is noone else to doom!"));
                    charRef.dataRef.picking = false;
                }
                Health health = PlayerController.PlayerInfo.health;
                health.Damage(3);
            }
        }
    }
    public Doomsayer() : base(ClassInjector.DerivedConstructorPointer<Doomsayer>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Doomsayer(System.IntPtr ptr) : base(ptr)
    {
    }
}
