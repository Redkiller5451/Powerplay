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
    Character sacrifice = null;
    string whoMySacrifice = "";
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
                list1.Remove(charRef);
                int randomIndex = UnityEngine.Random.Range(0, list1.Count);
                Character random = list1[randomIndex];
                random.statuses.AddStatus(Sacrifice.sacrifice, random);
                sacrifice = random;
                whoMySacrifice = $"#{random.id}";
            }
            else
            {
                Gameplay gameplay = Gameplay.Instance;
                Characters instance = Characters.Instance;
                Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                list1 = Characters.Instance.FilterAlignmentCharacters(list1, EAlignment.Good);
                list1.Remove(charRef);
                int randomIndex = UnityEngine.Random.Range(0, list1.Count);
                Character random = list1[randomIndex];
                random.statuses.AddStatus(Sacrifice.sacrifice, random);
                sacrifice = random;
                whoMySacrifice = $"#{random.id}";
            }

            
        }
        if (trigger == ETriggerPhase.AfterRoundStart)
            {

                if (!sacrifice.statuses.statuses.Contains(Sacrifice.sacrifice))
                {
                    sacrifice.statuses.AddStatus(Sacrifice.sacrifice, sacrifice);
                }
            }
            if (trigger == ETriggerPhase.Day)
            {
                MelonLogger.Msg("Acting!");
                onActed?.Invoke(new ActedInfo($"I am protecting {whoMySacrifice}"));
                if (!sacrifice.statuses.statuses.Contains(Sacrifice.sacrifice))
                {
                    sacrifice.statuses.AddStatus(Sacrifice.sacrifice, sacrifice);
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
}
