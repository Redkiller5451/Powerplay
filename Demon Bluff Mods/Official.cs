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
    public class Official : Role
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
                if (CheckTriggerPhases().Contains(trigger))
                {
                    SaintCureStatuses(charRef);
                    charRef.statuses.AddStatus(ECharacterStatus.AppearTruthfull, charRef);
                    if (charRef.alignment == EAlignment.Evil)
                    {
                        charRef.ChangeAlignment(EAlignment.Good);
                        if (charRef.dataRef.characterId != "Executive_POW")
                        {
                            SharedMethods sharedScripts = new SharedMethods();
                            CharacterData saintRef = sharedScripts.GetCharDataViaID("Executive_POW");
                            charRef.Init(saintRef);
                        }
                    }
                }
            }
        }


    public override void BluffAct(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Day)
            {
                this.onActed.Invoke(this.GetBluffInfo(charRef));

            }
        }

        public Il2CppSystem.Collections.Generic.List<ETriggerPhase> CheckTriggerPhases()
        {
            Il2CppSystem.Collections.Generic.List<ETriggerPhase> returnList = new Il2CppSystem.Collections.Generic.List<ETriggerPhase>();
            returnList.Add(ETriggerPhase.Start);
            returnList.Add(ETriggerPhase.AfterRoundStart);
            returnList.Add(ETriggerPhase.Day);
            returnList.Add(ETriggerPhase.Night);
            returnList.Add(ETriggerPhase.OnReveal);
            returnList.Add(ETriggerPhase.OnExecuted);
            returnList.Add(ETriggerPhase.OnPicked);
            returnList.Add(ETriggerPhase.OnDied);
            return returnList;
        }
        public void SaintCureStatuses(Character charRef)
        {
            if (charRef.statuses.Contains((ECharacterStatus)968))
            {
                charRef.statuses.statuses.Remove((ECharacterStatus)968);
            }
            if (charRef.statuses.Contains((ECharacterStatus)907))
            {
                charRef.statuses.statuses.Remove((ECharacterStatus)907);
            }
            if (charRef.statuses.Contains((ECharacterStatus)918919))
            {
                charRef.statuses.statuses.Remove((ECharacterStatus)918919);
            }
            if (charRef.statuses.Contains((ECharacterStatus)880)) // Evil-turned (Skill Cycler's Riddles)
            {
                charRef.statuses.statuses.Remove((ECharacterStatus)880);
            }
            if (charRef.statuses.Contains(ECharacterStatus.AppearLying))
            {
                charRef.statuses.statuses.Remove(ECharacterStatus.AppearLying);
            }
            if (charRef.statuses.Contains(Swapped.swapped))
            {
                charRef.statuses.statuses.Remove(Swapped.swapped);
            }
        }


    }
}
