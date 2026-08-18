using HarmonyLib;
using Il2Cpp;
using Il2CppInterop.Runtime;
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

namespace Demon_Bluff_Mods
{
    [RegisterTypeInIl2Cpp]
    public class Mafioso : MafiaLeader
    {
        public override Il2CppSystem.Collections.Generic.List<SpecialRule> GetRules()
        {
            Il2CppSystem.Collections.Generic.List<SpecialRule> sr = new Il2CppSystem.Collections.Generic.List<SpecialRule>();
            sr.Add(new NightModeRule(2));
            return sr;
        }
        public Mafioso() : base(ClassInjector.DerivedConstructorPointer<Mafioso>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public Mafioso(System.IntPtr ptr) : base(ptr)
        {

        }
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Init)
            {
                DjinnPOW.Jinx("Mafioso");
                
            }
            if (trigger == ETriggerPhase.Start)
            {
                SwapToGrunt();
               charRef.statuses.AddStatus(ECharacterStatus.UnkillableByDemon, charRef);
            }
            if (trigger == ETriggerPhase.AfterRoundStart)
            {
                MuddleTheInfo();
            }
                if (charRef.state == ECharacterState.Dead) return;
            if(trigger == ETriggerPhase.Night)
            {
               KillHidden(charRef);
               PlayerController.PlayerInfo.health.Damage(1);
            }
        }
    }
}
