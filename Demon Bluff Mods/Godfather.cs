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
public class Godfather : Neutrals
{

    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Start)
        { 
                changeAlignement(charRef);
                if (charRef.alignment == EAlignment.Evil)
                {
                MelonLogger.Msg("The Godfather is Evil");
                    Gameplay gameplay = Gameplay.Instance;
                    Characters instance = Characters.Instance;
                    Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                    list1 = Characters.Instance.FilterAlignmentCharacters(list1, EAlignment.Good);
                    Character random = list1[UnityEngine.Random.Range(0, list1.Count)];
                    random.ChangeAlignment(EAlignment.Evil);
                }
                else
                {
                MelonLogger.Msg("The Godfather is Good");
                Gameplay gameplay = Gameplay.Instance;
                    Characters instance = Characters.Instance;
                    Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                    list1 = Characters.Instance.FilterCharacterType(list1, ECharacterType.Minion);
                    Character random = list1[UnityEngine.Random.Range(0, list1.Count)];
                    random.ChangeAlignment(EAlignment.Good);
                }
            }
        }
    public Godfather() : base(ClassInjector.DerivedConstructorPointer<Godfather>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Godfather(System.IntPtr ptr) : base(ptr)
    {
    }
}