using Il2Cpp;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
    using static MelonLoader.MelonLaunchOptions;
    using static MelonLoader.Modules.MelonModule;

    namespace Demon_Bluff_Mods;
    [RegisterTypeInIl2Cpp]
    public class ChoirBoy : Role
    {
        public ChoirBoy() : base(ClassInjector.DerivedConstructorPointer<ChoirBoy>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public ChoirBoy(System.IntPtr ptr) : base(ptr)
        {

        }
        public override string Description
        {
            get
            {
                return "This is a cool role!";
            }
        }
        public override ActedInfo GetInfo(Character charRef)
        {
        Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
        Il2CppSystem.Collections.Generic.List<Character> list2 = Characters.Instance.FilterByRole(list1, "Executive_POW");
        if (list2.Count == 0)
        {
            list2 = Characters.Instance.FilterByRole(list1, "Mayor_POW");
        }
        if (list2.Count == 0)
        {
            list2 = Characters.Instance.FilterByRole(list1, "Monarch_POW");
        }
        if (list2.Count == 0)
        {
            list2 = Characters.Instance.FilterByRole(list1, "Marshal_POW");
        }
        if (list2.Count == 0)
        {
            list2 = Characters.Instance.FilterByRole(list1, "Prosecutor_POW");
        }
        if (list2.Count == 0)
        {
            list2 = Characters.Instance.FilterByRole(list1, "Jailor_POW");
        }
        if (list2.Count == 0)
        {
            list2 = Characters.Instance.FilterByRole(list1, "Pacifist_POW");
        }
        if (list2.Count == 0)
        {
            ActedInfo actedInfo = new ActedInfo("The Executive is absent!", null);
            return actedInfo;
        }
        else
        {
            bool executiveIsHurt = false;
            foreach (Character character in list2)
            {
                if (character.state == ECharacterState.Dead || DoTheyHaveAStatus(character))
                {
                    executiveIsHurt = true;
                }
            }
            string info = "";
            if (executiveIsHurt)
            {
                Il2CppSystem.Collections.Generic.List<Character> list3 = (Gameplay.CurrentCharacters);
                list3 = Characters.Instance.FilterRealCharacterType(list3, ECharacterType.Demon);
                info = $"I saw the Demon! They are ";
                int stringCount = 0;
                foreach (Character character in list3)
                {
                    info += $"#{character.id}";
                    stringCount++;
                    if (stringCount < list3.Count)
                    {
                        info += ", ";
                    }
                }
                ActedInfo actedInfo = new ActedInfo(info, list3);
                return actedInfo;
            }
            else
            {
                info = "The Executive is all fine!";
                ActedInfo actedInfo = new ActedInfo(info, null);
                return actedInfo;
            }
        }


            
        }
    public bool DoTheyHaveAStatus(Character picked)
    {
        if (picked.statuses.statuses.Count == 0) return false;
        Il2CppSystem.Collections.Generic.List<ECharacterStatus> statuses = new Il2CppSystem.Collections.Generic.List<ECharacterStatus>();
        foreach (ECharacterStatus c in picked.statuses.statuses)
        {
            if (isNotStatus(c)) statuses.Add(c);
        }
        return statuses.Count > 0;
    }
    private bool isNotStatus(ECharacterStatus status)
    {
        Il2CppSystem.Collections.Generic.List<ECharacterStatus> invalidStatuses = new Il2CppSystem.Collections.Generic.List<ECharacterStatus>();

        return status.Equals((ECharacterStatus)901) || status.Equals((ECharacterStatus)902) ||
            status.Equals((ECharacterStatus)903) || status.Equals((ECharacterStatus)904) ||
            status.Equals((ECharacterStatus)918918) || status.Equals((ECharacterStatus)82113114) ||
            status.Equals((ECharacterStatus)1618119) || status.Equals((ECharacterStatus)2051879715) ||
            status.Equals((ECharacterStatus)2051879522) || status.Equals((ECharacterStatus)2114495619) ||
            status.Equals((ECharacterStatus)2114495161) || status.Equals((ECharacterStatus)2114495239) ||
            status.Equals((ECharacterStatus)1201) || status.Equals((ECharacterStatus)1202) ||
            status.Equals((ECharacterStatus)1203) || status.Equals((ECharacterStatus)1204) ||
            status.Equals((ECharacterStatus)874) || status.Equals((ECharacterStatus)876) ||
            status.Equals((ECharacterStatus)879) || status.Equals((ECharacterStatus)882) ||
            status.Equals((ECharacterStatus)197) ||
            status.Equals((ECharacterStatus)318251620) || status.Equals(SailorPing.sailorPing) ||
            status.Equals((ECharacterStatus.HealthyBluff)) || status.Equals((ECharacterStatus.AppearDisguised)) ||
            status.Equals((ECharacterStatus.AppearHonest)) || status.Equals((ECharacterStatus.AppearLying)) ||
            status.Equals((ECharacterStatus.AppearTruthfull)) || status.Equals((ECharacterStatus.BrokenAbility)) ||
            status.Equals((ECharacterStatus.HealthyBluff)) || status.Equals((ECharacterStatus.UnkillableByDemon)) ||
            status.Equals((ECharacterStatus.WorkingAbility)) || status.Equals((ECharacterStatus.NoDamage)) ||
            status.Equals((ECharacterStatus.Lying)) || status.Equals((MadVictim.madVictim));
    }
    public override ActedInfo GetBluffInfo(Character charRef)
        {
        Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
        Il2CppSystem.Collections.Generic.List<Character> list2 = Characters.Instance.FilterByRole(list1, "Executive_POW");
        if (list2.Count == 0)
        {
            list2 = Characters.Instance.FilterByRole(list1, "Mayor_POW");
        }
        if (list2.Count == 0)
        {
            list2 = Characters.Instance.FilterByRole(list1, "Monarch_POW");
        }
        if (list2.Count == 0)
        {
            list2 = Characters.Instance.FilterByRole(list1, "Marshal_POW");
        }
        if (list2.Count == 0)
        {
            list2 = Characters.Instance.FilterByRole(list1, "Prosecutor_POW");
        }
        if (list2.Count == 0)
        {
            list2 = Characters.Instance.FilterByRole(list1, "Jailor_POW");
        }
        if (list2.Count == 0)
        {
            list2 = Characters.Instance.FilterByRole(list1, "Pacifist_POW");
        }
        if (list2.Count == 0)
        {
            ActedInfo actedInfo = new ActedInfo("The Executive is all fine!", null);
            return actedInfo;
        }
        else
        {
            bool executiveIsHurt = true;
            foreach (Character character in list2)
            {
                if (character.state == ECharacterState.Dead || DoTheyHaveAStatus(character))
                {
                    executiveIsHurt = false;
                }
            }
            string info = "";
            if (executiveIsHurt)
            {
                Il2CppSystem.Collections.Generic.List<Character> list3 = (Gameplay.CurrentCharacters);
                list3 = Characters.Instance.FilterOutCharacterType(list3, ECharacterType.Demon);
                Il2CppSystem.Collections.Generic.List<Character> list4 = new();
                info = $"I saw the Demon! They are ";
                int nOfDemons = Gameplay.CurrentScript.demon;
                int stringCount = 0;
                for(int i = 0; i < nOfDemons; i++)
                {
                    int randomIndex = UnityEngine.Random.Range(0, list3.Count);
                    Character random = list3[randomIndex];
                    list4.Add(random);
                    list3.Remove(random);
                }
                foreach (Character character in list4)
                {
                    info += $"#{character.id}";
                    stringCount++;
                    if (stringCount < list4.Count)
                    {
                        info += ", ";
                    }
                }
                ActedInfo actedInfo = new ActedInfo(info, list4);
                return actedInfo;
            }
            else
            {
                info = "The Executive is all fine!";
                ActedInfo actedInfo = new ActedInfo(info, null);
                return actedInfo;
            }
        }
    }
        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if(trigger == ETriggerPhase.Start)
            {
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            Il2CppSystem.Collections.Generic.List<Character> list2 = Characters.Instance.FilterByRole(list1, "Executive_POW");
            if (list2.Count == 0)
            {
                list2 = Characters.Instance.FilterByRole(list1, "Mayor_POW");
            }
            if (list2.Count == 0)
            {
                list2 = Characters.Instance.FilterByRole(list1, "Monarch_POW");
            }
            if (list2.Count == 0)
            {
                list2 = Characters.Instance.FilterByRole(list1, "Marshal_POW");
            }
            if (list2.Count == 0)
            {
                list2 = Characters.Instance.FilterByRole(list1, "Prosecutor_POW");
            }
            if (list2.Count == 0)
            {
                list2 = Characters.Instance.FilterByRole(list1, "Jailor_POW");
            }
            if (list2.Count == 0)
            {
                list2 = Characters.Instance.FilterByRole(list1, "Pacifist_POW");
            }
            if (list2.Count == 0)
            {
                CreateExecutive(charRef);
            }
            }
            if (trigger == ETriggerPhase.Day)
            {

            if (charRef.statuses.Contains(ECharacterStatus.Corrupted))
            {
                onActed?.Invoke(GetBluffInfo(charRef));
            }
            else
            {
                onActed?.Invoke(GetInfo(charRef));
            }

            }
        }
        public override void BluffAct(ETriggerPhase trigger, Character charRef)
        {
        if (trigger == ETriggerPhase.Start)
        {
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            Il2CppSystem.Collections.Generic.List<Character> list2 = Characters.Instance.FilterByRole(list1, "Executive_POW");
            if (list2.Count == 0)
            {
                list2 = Characters.Instance.FilterByRole(list1, "Mayor_POW");
            }
            if (list2.Count == 0)
            {
                list2 = Characters.Instance.FilterByRole(list1, "Monarch_POW");
            }
            if (list2.Count == 0)
            {
                list2 = Characters.Instance.FilterByRole(list1, "Marshal_POW");
            }
            if (list2.Count == 0)
            {
                list2 = Characters.Instance.FilterByRole(list1, "Prosecutor_POW");
            }
            if (list2.Count == 0)
            {
                list2 = Characters.Instance.FilterByRole(list1, "Jailor_POW");
            }
            if (list2.Count == 0)
            {
                list2 = Characters.Instance.FilterByRole(list1, "Pacifist_POW");
            }
            if (list2.Count == 0)
            {
                CreateExecutive(charRef);
            }
        }
        if (trigger == ETriggerPhase.Day)
            {
                this.onActed.Invoke(this.GetBluffInfo(charRef));

            }
        }
        public override CharacterData? GetBluffIfAble(Character charRef)
        {
            return null;
        }
       private void CreateExecutive(Character charRef)
    {
        Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
        list1 = Characters.Instance.FilterRealCharacterType(list1, ECharacterType.Villager);
        list1.Remove(charRef);
        int randomIndex = UnityEngine.Random.Range(0, list1.Count);
        Character random = list1[randomIndex];
        CharacterData[] allDatas = Il2CppSystem.Array.Empty<CharacterData>();
        var loadedCharList = Resources.FindObjectsOfTypeAll(Il2CppType.Of<CharacterData>());
        if (loadedCharList != null)
        {
            allDatas = new CharacterData[loadedCharList.Length];
            for (int j = 0; j < loadedCharList.Length; j++)
            {
                allDatas[j] = loadedCharList[j]!.Cast<CharacterData>();
            }
        }
        for (int j = 0; j < allDatas.Length; j++)
        {
            if (allDatas[j].characterId =="Executive_POW")
            {
                if (random.GetRegisterAs().characterId != allDatas[j].characterId)
                {
                    random.Init(allDatas[j]);
                    Gameplay.Instance.AddScriptCharacter(ECharacterType.Villager, allDatas[j]);
                }
            }
        }
        if(charRef.GetRealAlignment() == EAlignment.Evil)
        {
            random.statuses.statuses.Add(ECharacterStatus.Corrupted);
        }
    }
    }
