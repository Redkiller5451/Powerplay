using Demon_Bluff_Mods;
using Il2Cpp;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Demon_Bluff_Mods

{

    public enum EWeatherPhase
    {
        Clear = 0,
        HarshSun = 10,
        HeavyRain = 20,
        Fog = 30,
    }
    [RegisterTypeInIl2Cpp]
    public class Weather : Demon
    {
        
    }
}
