using Il2Cpp;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using Microsoft.VisualBasic;
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
        string info = "";
        if (trigger == ETriggerPhase.Start)
        {
            Gameplay gameplay = Gameplay.Instance;
            Characters instance = Characters.Instance;
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            Il2CppSystem.Collections.Generic.List<Character> list2 = GetNeighbors();
            int nOfOutcasts = 0;
            if (list2.Count > 0)
            {
                if (list2[0].GetCharacterType() is ECharacterType.Outcast)
                {
                    whatOutcast(list2[0]);
                    nOfOutcasts++;
                }
                if (list2[1].GetCharacterType() is ECharacterType.Outcast)
                {
                    whatOutcast(list2[1]);
                    nOfOutcasts++;
                }
                if (list2[2].GetCharacterType() is ECharacterType.Outcast)
                {
                    whatOutcast(list2[2]);
                    nOfOutcasts++;
                }
                if (list2[3].GetCharacterType() is ECharacterType.Outcast)
                {
                    whatOutcast(list2[3]);
                    nOfOutcasts++;
                }

            }
            if (nOfOutcasts == 1)
            {
                info = "I cured a single Outcast";
            }
            else if (nOfOutcasts == 0)
            {
                info = "I couldn't cure a singular Outcast";
            }
            else
            {
                info = $"I cured {nOfOutcasts} Outcasts";
            }
        }
        if(trigger == ETriggerPhase.Day)
        {
            onActed?.Invoke(new ActedInfo(info, null));
        }
       
    }
   
    public override void BluffAct(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Day)
        {
            this.onActed.Invoke(this.GetBluffInfo(charRef));

        }
    }
   
        public override CharacterData? GetBluffIfAble(Character charRef)
    {
        return null;
    }
    public Il2CppSystem.Collections.Generic.List<Character> GetNeighbors()
    {
        Il2CppSystem.Collections.Generic.List<Character> myList = CharactersHelper.GetSortedListWithCharacterFirst(Gameplay.CurrentCharacters, charRef);
        myList.RemoveAt(0);
        Il2CppSystem.Collections.Generic.List<Character> neighbors = new Il2CppSystem.Collections.Generic.List<Character>();
        neighbors.Add(myList[0]);
        neighbors.Add(myList[1]);
        neighbors.Add(myList[myList.Count - 2]);
        neighbors.Add(myList[myList.Count - 1]);

        return neighbors;
    }
    private void whatOutcast(Character character)
    {
        if(character.role is Drunk)
        {
            character.RevealReal();
            character.statuses.statuses.Remove(ECharacterStatus.Corrupted);
        }
        else if (character.role is Doppleganger)
        {
            character.RevealReal();
        }
        else
        {
            character.statuses.AddStatus(ECharacterStatus.Corrupted, character);
        }
    }
}