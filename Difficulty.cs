using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    public enum Difficulty
    {
        Easy = 0,
        Normal = 1,
        Hard = 2
    }

    public class DifficultyOfGame
    {

        public static int[] DifficultyToSize(Difficulty diff)
        {
            switch (diff)
            {
                case Difficulty.Easy:
                    return new int[2] { 12, 24 };
                case Difficulty.Normal:
                    return new int[2] { 8, 16 };
                case Difficulty.Hard:
                    return new int[2] { 6, 12 };
                default:
                    return new int[2] { 1, 1 };
            }
        }

        public static Difficulty ToDifficulty(string diff)
        {
            switch (diff)
            {
                case "Easy":
                    return Difficulty.Easy;
                case "Normal":
                    return Difficulty.Normal;
                case "Hard":
                    return Difficulty.Hard;
                default:
                    throw new Exception("Unknown difficulty");
            }
        }
    }
}
