using Il2Cpp;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demon_Bluff_Mods
{
    [RegisterTypeInIl2Cpp]
    public class Fisherman : Role
    {
        public Fisherman() : base(ClassInjector.DerivedConstructorPointer<Fisherman>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public Fisherman(System.IntPtr ptr) : base(ptr)
        {
            ClassInjector.DerivedConstructorBody(this);
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
            Gameplay gameplay = Gameplay.Instance;
            Characters instance = Characters.Instance;
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            list1 = Characters.Instance.FilterRealCharacterType(list1, ECharacterType.Villager);
            string line = "";
            if (list1.Count > 1)
            {
                Character random = list1[UnityEngine.Random.Range(0, list1.Count)];
                int closestVillager = GetClosestVillagerToVillager(random, charRef);
                if (closestVillager == 0)
                {
                    line = $"#{random.id} is {closestVillager + 1} card away from their nearest Villager.";
                }
                else
                {
                    line = $"#{random.id} is {closestVillager + 1} cards away from their nearest Villager.";
                }
            }
            else
            {
                line = $"I am running fishing ranked solo";
            }
            return new ActedInfo(line);
        }
        public override ActedInfo GetBluffInfo(Character charRef)
        {

            float randomId = UnityEngine.Random.Range(0f, 1f);
            Il2CppSystem.Collections.Generic.List<Character> allVillagers = (Gameplay.CurrentCharacters);
            allVillagers = Characters.Instance.FilterCharacterType(allVillagers, ECharacterType.Villager);
            Character random = allVillagers[UnityEngine.Random.Range(0, allVillagers.Count)];
            int closestVillager = GetClosestVillagerToVillager(random, charRef);
            closestVillager = Calculator.RemoveNumberAndGetRandomNumberFromList(closestVillager, 0, 3);
            string line = "";
            if (closestVillager == 0)
                {
                    line = $"#{random.id} is {closestVillager + 1} card away from their nearest Villager.";
                }
                else
                {
                    line = $"#{random.id} is {closestVillager + 1} cards away from their nearest Villager.";
                }
            ActedInfo newInfo = new ActedInfo(line);
            return newInfo;
        }
        public int GetClosestVillagerToVillager(Character pickedGood, Character chRef)
        {
            int count = 0;
            int savedCount = 100;

            Il2CppSystem.Collections.Generic.List<Character> myList = (Gameplay.CurrentCharacters);
            myList = CharactersHelper.GetSortedListWithCharacterFirst(myList, pickedGood);

            myList.RemoveAt(0);
            for (int i = 0; i < myList.Count; i++)
            {
                if (myList[i].GetCharacterType() == ECharacterType.Villager)
                {
                    savedCount = count;
                    count = 0;
                    break;
                }
                count++;
            }
            count = 0;
            for (int i = myList.Count - 1; i > 0; i--)
            {
                if (myList[i].GetCharacterType() == ECharacterType.Villager)
                {
                    if (count < savedCount)
                    {
                        savedCount = count;
                        count = 0;
                    }
                    break;
                }
                count++;
            }

            return savedCount;
        }
    public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Day)
            {
                if (charRef.statuses.statuses.Contains(ECharacterStatus.Corrupted))
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
            if (trigger == ETriggerPhase.Day)
            {
                onActed?.Invoke(GetBluffInfo(charRef));
            }
        }
    }
}