using Il2Cpp;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Based off Alice Thymefield! Check out Zenless Zone Zero, available on Steam (Not Sponsored btw I just like the game)
namespace Demon_Bluff_Mods
{
    [RegisterTypeInIl2Cpp]
    public class Noblewoman : Role
    {
        public Noblewoman() : base(ClassInjector.DerivedConstructorPointer<Noblewoman>())
        {
            ClassInjector.DerivedConstructorBody((Il2CppObjectBase)this);
        }
        public Noblewoman(System.IntPtr ptr) : base(ptr)
        {

        }
        public override string Description
        => "Learn which side of the circle is more Evil";

        public enum ECircleSide
        {
            Left = 0,
            Right = 1,
            Both = 2,
        }


        public class NoblewomanInfo
        {
            public ECircleSide sideEvil;
            public ECircleSide sideOutcast;
            public ECircleSide sideVillager;
            public Il2CppSystem.Collections.Generic.List<Character> characters = new Il2CppSystem.Collections.Generic.List<Character>();
        }

        public override ActedInfo GetInfo(Character charRef)
        {
            NoblewomanInfo infos = GetSideOfCircle(charRef, true);

            string info = ConjourInfo(infos, charRef);

            ActedInfo newInfo = new ActedInfo(info, infos.characters);
            return newInfo;
        }

        public override void Act(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Day)
                onActed?.Invoke(GetInfo(charRef));
        }
        public override void BluffAct(ETriggerPhase trigger, Character charRef)
        {
            if (trigger == ETriggerPhase.Day)
                onActed?.Invoke(GetBluffInfo(charRef)); ;
        }

        public override ActedInfo GetBluffInfo(Character charRef)
        {
            NoblewomanInfo infos = GetSideOfCircle(charRef, false);

            string info = ConjourInfo(infos, charRef);

            ActedInfo newInfo = new ActedInfo(info, infos.characters);
            return newInfo;
        }

        public NoblewomanInfo GetSideOfCircle(Character charRef, bool truth)
        {
            Il2CppSystem.Collections.Generic.List<Character> tempList = (Gameplay.CurrentCharacters);

            int circleSize = tempList.Count;

            tempList.Add(tempList[0]);

            int i = 0;
            int leftEvils = 0;
            int rightEvils = 0;
            int leftOutcasts = 0;
            int rightOutcasts = 0;
            int leftVillager = 0;
            int rightVillager = 0;
            Il2CppSystem.Collections.Generic.List<Character> leftChars = new Il2CppSystem.Collections.Generic.List<Character>();
            Il2CppSystem.Collections.Generic.List<Character> rightChars = new Il2CppSystem.Collections.Generic.List<Character>();
            foreach (Character c in tempList)
            {
                if (i <= circleSize / 2)
                {
                    leftChars.Add(c);
                    if (c.GetRegisterAlignment() == EAlignment.Evil)
                        leftEvils++;
                    if (c.GetRegisterAs().type == ECharacterType.Villager)
                        leftVillager++;
                    if (c.GetRegisterAs().type == ECharacterType.Outcast)
                        leftOutcasts++;
                }
                if (i >= (circleSize + 1) / 2)
                {
                    rightChars.Add(c);
                    if (c.GetRegisterAlignment() == EAlignment.Evil)
                        rightEvils++;
                    if (c.GetRegisterAs().type == ECharacterType.Villager)
                        rightVillager++;
                    if (c.GetRegisterAs().type == ECharacterType.Outcast)
                        rightOutcasts++;
                }
                i++;
            }


            NoblewomanInfo infos = new NoblewomanInfo();

            infos.sideEvil = ECircleSide.Both;
            if (leftEvils > rightEvils)
                infos.sideEvil = ECircleSide.Left;
            if (leftEvils < rightEvils)
                infos.sideEvil = ECircleSide.Right;
            infos.sideOutcast = ECircleSide.Both;
            if (leftOutcasts > rightOutcasts)
                infos.sideOutcast = ECircleSide.Left;
            if (leftOutcasts < rightOutcasts)
                infos.sideOutcast = ECircleSide.Right;
            infos.sideVillager = ECircleSide.Both;
            if (leftVillager > rightVillager)
                infos.sideVillager = ECircleSide.Left;
            if (leftVillager < rightVillager)
                infos.sideVillager = ECircleSide.Right;

            if (!truth)
            {
                bool isBoth = Calculator.RollDice(10) > 9 ? true : false;

                if (infos.sideEvil == ECircleSide.Left)
                    infos.sideEvil = ECircleSide.Right;
                else if (infos.sideEvil == ECircleSide.Right)
                    infos.sideEvil = ECircleSide.Left;

                if (infos.sideEvil == ECircleSide.Both)
                {
                    if (Calculator.RollDice(10) >= 5)
                        infos.sideEvil = ECircleSide.Left;
                    else
                        infos.sideEvil = ECircleSide.Right;
                }
                else if (infos.sideEvil != ECircleSide.Both)
                    if (isBoth)
                        infos.sideEvil = ECircleSide.Both;
                isBoth = Calculator.RollDice(10) > 9 ? true : false;

                if (infos.sideOutcast == ECircleSide.Left)
                    infos.sideOutcast = ECircleSide.Right;
                else if (infos.sideOutcast == ECircleSide.Right)
                    infos.sideOutcast = ECircleSide.Left;

                if (infos.sideOutcast == ECircleSide.Both)
                {
                    if (Calculator.RollDice(10) >= 5)
                        infos.sideOutcast = ECircleSide.Left;
                    else
                        infos.sideOutcast = ECircleSide.Right;
                }
                else if (infos.sideOutcast != ECircleSide.Both)
                    if (isBoth)
                        infos.sideOutcast = ECircleSide.Both;
                isBoth = Calculator.RollDice(10) > 9 ? true : false;

                if (infos.sideVillager == ECircleSide.Left)
                    infos.sideVillager = ECircleSide.Right;
                else if (infos.sideVillager == ECircleSide.Right)
                    infos.sideVillager = ECircleSide.Left;

                if (infos.sideVillager == ECircleSide.Both)
                {
                    if (Calculator.RollDice(10) >= 5)
                        infos.sideVillager = ECircleSide.Left;
                    else
                        infos.sideVillager = ECircleSide.Right;
                }
                else if (infos.sideVillager != ECircleSide.Both)
                    if (isBoth)
                        infos.sideVillager = ECircleSide.Both;
            }
            ECircleSide unevenSide = whoIsMoreUneven(infos);
            if (unevenSide == ECircleSide.Left)
                infos.characters = leftChars;
            if (unevenSide == ECircleSide.Right)
                infos.characters = rightChars;

            return infos;
        }
        public ECircleSide whoIsMoreUneven(NoblewomanInfo infos)
        {
            int leftSide = 0;
            int rightSide = 0;
            if (infos.sideVillager == ECircleSide.Left)
                leftSide++;
            if (infos.sideVillager == ECircleSide.Right)
                rightSide++;
            if (infos.sideOutcast == ECircleSide.Left)
                leftSide++;
            if (infos.sideOutcast == ECircleSide.Right)
                rightSide++;
            if (infos.sideEvil == ECircleSide.Left)
                leftSide++;
            if (infos.sideEvil == ECircleSide.Right)
                rightSide++;
            if (leftSide > rightSide)
                return ECircleSide.Left;
            else if (rightSide > leftSide)
                return ECircleSide.Right;
            return ECircleSide.Both;
        }

        public string ConjourInfo(NoblewomanInfo infos, Character charRef)
        {
            string info = "";
            if (infos.sideEvil!=ECircleSide.Both)
                info += $"Evils are horrifically asymmetrical!\n";
            if (infos.sideOutcast != ECircleSide.Both)
                info += $"Outcasts are horrifically asymmetrical!\n";
            if (infos.sideVillager != ECircleSide.Both)
                info += $"Villagers are horrifically asymmetrical!\n";
            if(info.Length == 0)
            {
                info = "The Town is in perfect symmetry!";
            }
            return info;
        }
    }
}
