/**using Il2Cpp;
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

namespace Demon_Bluff_Mods;
[RegisterTypeInIl2Cpp]
public class Vanished : Role
{
    private static Character lastPicker = null;
    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if(trigger == ETriggerPhase.AfterRoundStart)
        {
            charRef.statuses.AddStatus(ECharacterStatus.Silenced, charRef);
            
        }
        if (trigger == ETriggerPhase.OnPicked)
        {
            if (charRef.state == ECharacterState.Dead) return;
            if (lastPicker != null)
            {
                if(lastPicker.alignment == EAlignment.Good)
                {
                    lastPicker.     }
            }
        }
    }
    public override void BluffAct(ETriggerPhase trigger, Character charRef)
    {       if (trigger == ETriggerPhase.AfterRoundStart)
        {
            charRef.statuses.AddStatus(ECharacterStatus.Silenced, charRef);

        }
    }
    public static void SetLastPicker(Character picker)
    {
        lastPicker = picker;
    }
    public Vanished() : base(ClassInjector.DerivedConstructorPointer<Vanished>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);

    }
    public Vanished(System.IntPtr ptr) : base(ptr)
    {
    }
}*/