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

namespace Demon_Bluff_Mods;
[RegisterTypeInIl2Cpp]
public class Scapegoat : Neutrals
{

    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Start)
        {
            changeAlignement(charRef);
            if (charRef.alignment == EAlignment.Evil)
            {
                Gameplay gameplay = Gameplay.Instance;
                Characters instance = Characters.Instance;
                Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                list1 = Characters.Instance.FilterAlignmentCharacters(list1, EAlignment.Evil);
                int randomIndex = UnityEngine.Random.Range(0, list1.Count);
                Character random = list1[randomIndex];
                random.statuses.AddStatus(Sacrifice.sacrifice, random);
            }
            else
            {
                Gameplay gameplay = Gameplay.Instance;
                Characters instance = Characters.Instance;
                Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                list1 = Characters.Instance.FilterAlignmentCharacters(list1, EAlignment.Good);
                int randomIndex = UnityEngine.Random.Range(0, list1.Count);
                Character random = list1[randomIndex];
                random.statuses.AddStatus(Sacrifice.sacrifice, random);
            }
        }        
    }   
    public Scapegoat() : base(ClassInjector.DerivedConstructorPointer<Scapegoat>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Scapegoat(System.IntPtr ptr) : base(ptr)
    {
    }

    //Thank you to Caldo for the PoKill status
    public static class Sacrifice
    {
        public static ECharacterStatus sacrifice = (ECharacterStatus)270;
        [HarmonyPatch(typeof(Character), nameof(Character.Kill))]
        public static class ChangeKillByDemonText
        {
            public static bool Prefix(Character __instance)
            {
                if (__instance.statuses.Contains(sacrifice))
                {
                    Gameplay gameplay = Gameplay.Instance;
                    Characters instance = Characters.Instance;
                    Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                    list1 = Characters.Instance.FilterAliveCharacters(list1);
                    foreach (Character c in list1)
                    {
                        if (c.role is Scapegoat)
                        {
                            c.Kill();
                            if (c.alignment is EAlignment.Evil)
                            {
                                PlayerController.PlayerInfo.health.Damage(5);
                            }
                            return false;
                        }
                    }
                    return true;

                }
                return true;
            }
        }
    }
}
