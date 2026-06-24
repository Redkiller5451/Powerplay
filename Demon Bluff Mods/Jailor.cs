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

namespace Demon_Bluff_Mods;
[RegisterTypeInIl2Cpp]
public class Jailor : Role
{
    public Jailor() : base(ClassInjector.DerivedConstructorPointer<Jailor>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Jailor(IntPtr ptr) : base(ptr)
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
        ActedInfo actedInfo = new ActedInfo("I have declared a Tribunal!", null);
        return actedInfo;
    }
    public override ActedInfo GetBluffInfo(Character charRef)
    {
        ActedInfo actedInfo = new ActedInfo("I am corrupted", null);
        return actedInfo;
    }
    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        Il2CppSystem.Collections.Generic.List<Character> randomizedList = new Il2CppSystem.Collections.Generic.List<Character>();
        if (trigger == ETriggerPhase.Day)
        {
            Gameplay gameplay = Gameplay.Instance;
            Characters instance = Characters.Instance;
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            Il2CppSystem.Collections.Generic.List<Character> list2 = Characters.Instance.FilterRealCharacterType(list1, ECharacterType.Villager);
            Il2CppSystem.Collections.Generic.List<Character> list3 = Characters.Instance.FilterAlignmentCharacters(list1, EAlignment.Evil);

            if (list2.Count + list3.Count > 2)
            {
                int randomIndex = UnityEngine.Random.Range(0, list2.Count);
                Il2CppSystem.Collections.Generic.List<Character> list5 = list2;
                list5.RemoveAt(randomIndex);
                int randomIndex2 = UnityEngine.Random.Range(0, list5.Count);
                int randomIndex3 = UnityEngine.Random.Range(0, list3.Count);
                Character random = list2[randomIndex];
                Character random2 = list5[randomIndex2];
                Character demon = list3[randomIndex3];
                randomizedList.Add(random);
                randomizedList.Add(random2);
                randomizedList.Add(demon);
                random.statuses.statuses.Add(ECharacterStatus.Silenced);
                random2.statuses.statuses.Add(ECharacterStatus.Silenced);
                demon.statuses.statuses.Add(ECharacterStatus.Silenced);

            }
        }
        if(trigger == ETriggerPhase.Day)
        {
            string info = ConjourInfo(randomizedList);
            onActed?.Invoke(new ActedInfo(info, randomizedList));
        }
       
    }
   
    public override void BluffAct(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Day)
        {
            this.onActed.Invoke(this.GetBluffInfo(charRef));

        }
    }
    public string ConjourInfo(Il2CppSystem.Collections.Generic.List<Character> randomizedList)
    {
        //Used AI to generate this cause I am lazy
        Random rng = new Random();
        int n = randomizedList.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1); // Random index between 0 and n
            // Swap elements
            Character temp = randomizedList[k];
            randomizedList[k] = randomizedList[n];
            randomizedList[n] = temp;
        }
        string info = $"I have jailed #{randomizedList[0].id}, #{randomizedList[1].id} and #{randomizedList[2].id}";
       
        return info;
    }
   
        public override CharacterData? GetBluffIfAble(Character charRef)
    {
        return null;
    }
}