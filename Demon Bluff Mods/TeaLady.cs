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
using static UnityEngine.GraphicsBuffer;

namespace Demon_Bluff_Mods
{
    [RegisterTypeInIl2Cpp]
    public class TeaLady : Role
    {
        public override ActedInfo GetInfo(Character charRef)
        {
            return new ActedInfo("");
        }
        public override ActedInfo GetBluffInfo(Character charRef)
        {
            return new ActedInfo("");
        }
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Start)
            {
                if (isNextToMinion(charRef))
                {
                    charRef.statuses.statuses.Add(ECharacterStatus.Corrupted);
                }
                if (charRef.statuses.Contains(ECharacterStatus.Corrupted))
                {
                    onActed?.Invoke(GetBluffInfo(charRef));
                }
                else
                {
                    Il2CppSystem.Collections.Generic.List<Character> neighbors = GetNeighbors(charRef);
                    foreach (Character neighbor in neighbors)
                    {
                        neighbor.statuses.AddStatus(ECharacterStatus.UnkillableByDemon, neighbor);
                        neighbor.statuses.AddStatus(Protected.protect, neighbor);
                    }
                }
            }
        }
        public override void BluffAct(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Day)
            {
                onActed?.Invoke(GetBluffInfo(charRef));
            }
        }
        public Il2CppSystem.Collections.Generic.List<Character> GetNeighbors(Character charRef)
        {
            Il2CppSystem.Collections.Generic.List<Character> myList = CharactersHelper.GetSortedListWithCharacterFirst(Gameplay.CurrentCharacters, charRef);
            myList.RemoveAt(0);
            Il2CppSystem.Collections.Generic.List<Character> neighbors = new Il2CppSystem.Collections.Generic.List<Character>();
            neighbors.Add(myList[0]);
            neighbors.Add(myList[myList.Count - 1]);
            return neighbors;
        }
        public bool isNextToMinion(Character charRef)
        {
            Il2CppSystem.Collections.Generic.List<Character> neighbors = GetNeighbors(charRef);
            return neighbors[0].GetRealAlignment() is EAlignment.Evil || neighbors[1].GetRealAlignment() is EAlignment.Evil;

        }
        public TeaLady() : base(ClassInjector.DerivedConstructorPointer<TeaLady>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public TeaLady(System.IntPtr ptr) : base(ptr)
        {
        }
    }
    public static class Protected
    {
        public static ECharacterStatus protect = (ECharacterStatus)210;
        
    }

}
