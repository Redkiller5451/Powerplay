using Il2Cpp;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem;
using MelonLoader;
using System;
using System.ComponentModel.Design;
using UnityEngine;
namespace Demon_Bluff_Mods
{
    [RegisterTypeInIl2Cpp]
    public class Official: Role
    {
        public Official() : base(ClassInjector.DerivedConstructorPointer<Official>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public Official(System.IntPtr ptr) : base(ptr)
        {
            ClassInjector.DerivedConstructorBody(this);
        }
        public CharacterData[] allDatas = Il2CppSystem.Array.Empty<CharacterData>();
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Start)
            {
  //NOT MY OWN CODE
                Il2CppSystem.Collections.Generic.List<CharacterData> possibleTPOWs = new Il2CppSystem.Collections.Generic.List<CharacterData>();
                Il2CppSystem.Collections.Generic.List<string> possibleTPOWIDs = new Il2CppSystem.Collections.Generic.List<string>();
                // Possible TPOWs: 
                possibleTPOWIDs.Add("Prosecutor_POW"); // Prosecutor
                possibleTPOWIDs.Add("Mayor_POW"); // Mayor
                possibleTPOWIDs.Add("Monarch_POW"); // Emperor
                possibleTPOWIDs.Add("Marshal_POW"); // Marshal
                possibleTPOWIDs.Add("Jailor_POW"); // Warden
                possibleTPOWIDs.Add("Pacifist_POW"); // Pacifist

                if (allDatas.Length == 0)
                {
                    var loadedCharList = Resources.FindObjectsOfTypeAll(Il2CppType.Of<CharacterData>());
                    if (loadedCharList != null)
                    {
                        allDatas = new CharacterData[loadedCharList.Length];
                        for (int j = 0; j < loadedCharList.Length; j++)
                        {
                            allDatas[j] = loadedCharList[j]!.Cast<CharacterData>();
                        }
                    }
                }

                for (int j = 0; j < allDatas.Length; j++)
                {
                    if (possibleTPOWIDs.Contains(allDatas[j].characterId))
                    {
                        possibleTPOWs.Add(allDatas[j]);
                    }
                }
               
                CharacterData chosenTPOW = possibleTPOWs[UnityEngine.Random.RandomRangeInt(0, possibleTPOWs.Count)];
                /*if (chosenTPOW.role is Jailor)
                {
                    Gameplay.Instance.AddScriptCharacterIfAble(ECharacterType.Outcast, chosenTPOW);
                }
                else
                {
                    Gameplay.Instance.AddScriptCharacterIfAble(ECharacterType.Villager, chosenTPOW);
                }*/
                charRef.Init(chosenTPOW);
            }
        }
        public override void BluffAct(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Start)
            {
                this.onActed.Invoke(this.GetBluffInfo(charRef));

            }
        }
        public override ActedInfo GetBluffInfo(Character charRef)
        {
            ActedInfo actedInfo = new ActedInfo("I am corrupted", null);
            return actedInfo;
        }
    }
}
