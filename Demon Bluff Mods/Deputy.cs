using Il2Cpp;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demon_Bluff_Mods;
[RegisterTypeInIl2Cpp]
public class Deputy : Role
{
    public Deputy() : base(ClassInjector.DerivedConstructorPointer<Deputy>())
    {
        ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
    }
    public Deputy(System.IntPtr ptr) : base(ptr)
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
        ActedInfo actedInfo = new ActedInfo("I am a Pilgrim!", null);
        return actedInfo;
    }
    public override ActedInfo GetBluffInfo(Character charRef)
    {
        ActedInfo actedInfo = new ActedInfo("I am not a Pilgrim!", null);
        return actedInfo;
    }
    public override void Act(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Day)
        {
            if (charRef.statuses.Contains(ECharacterStatus.Corrupted))
            {
                onActed?.Invoke(GetBluffInfo(charRef));
            }
            else
            {
                Gameplay gameplay = Gameplay.Instance;
                Characters instance = Characters.Instance;
                Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
                list1 = Characters.Instance.FilterAliveCharacters(list1);
                list1.Remove(charRef);
                Il2CppSystem.Collections.Generic.List<Character> list2 = new();
                string line;
                if (list1.Count > 0)
                {
                    int randomIndex = UnityEngine.Random.Range(0, list1.Count);
                    Character random = list1[randomIndex];
                    if (random.alignment == EAlignment.Evil)
                    {
                     random.Kill();

                    line = $"I killed #{random.id}.";
                        if (DjinnPOW.GetCharactersThatCannotDie().Contains(random.dataRef.characterId))
                        {
                            if (random.dataRef.characterId == "Vizier_LRZH")
                            {
                                line = $"#{random.id}, you are a poor excuse of a Vizier.";
                            }
                            else if (random.dataRef.characterId == "WING_Dupery_Scoundrel")
                            {
                                line = $"#{random.id}, a little Scoundrel like yourself should go back and cry to the Syndicate.";
                            }
                            else if (random.dataRef.characterId == "Squire_scm")
                            {
                                line = $"#{random.id}, to give up on the crown is to give up on life, Squire.";
                            }
                            else
                            {
                                line = $"#{random.id},Undying? We will see about that.";
                            }
                        }
                        random.RevealReal();
                    }
                    else
                    {
                        line = $"I shot #{random.id}, but the bullet missed!";
                    }
                    
                    list2.Add(random);
                }
                else
                {
                    line = $"There are no evils to shoot!";
                    list2.Add(charRef);
                }
                
                onActed?.Invoke(new ActedInfo(line, list2));
            }
        }

        }
  
    public override void BluffAct(ETriggerPhase trigger, Character charRef)
    {
        if (trigger == ETriggerPhase.Day)
        {
            Gameplay gameplay = Gameplay.Instance;
            Characters instance = Characters.Instance;
            Il2CppSystem.Collections.Generic.List<Character> list1 = (Gameplay.CurrentCharacters);
            list1 = Characters.Instance.FilterRealCharacterType(list1, ECharacterType.Minion);
            Il2CppSystem.Collections.Generic.List<Character> list2 = new();
            string line;
            if(list1.Count == 0)
            {
                line = $"There are no evils to shoot!";
                list2.Add(charRef);
            }
            else
            {
                int randomIndex = UnityEngine.Random.Range(0, list1.Count);
                Character random = list1[randomIndex];
                 line = $"I shot #{random.id}, but the bullet missed!";
                  list2.Add(random) ;
            }
                
            onActed?.Invoke(new ActedInfo(line, list2));

        }

        }
}
