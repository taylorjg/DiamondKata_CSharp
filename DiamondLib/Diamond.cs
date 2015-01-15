using System;
using System.Collections.Generic;
using System.Linq;

namespace DiamondLib
{
    public class Diamond
    {
        private const char BaseChar = 'A';

        public static IEnumerable<string> GenerateLines(char inputChar)
        {
            var squareSize = CalculateSquareSize(inputChar);
            var lines = new List<string>();

            foreach (var tuple in GenerateTuples(squareSize))
            {
                var patternWidth = tuple.Item1;
                var currentChar = tuple.Item2;
                var beforeAndAfterSpaces = ((squareSize - patternWidth) / 2).ToSpaces();
                if (patternWidth > 1)
                {
                    var centreSpaces = (patternWidth - 2).ToSpaces();
                    lines.Add(string.Format("{0}{1}{2}{1}{0}", beforeAndAfterSpaces, currentChar, centreSpaces));
                }
                else
                {
                    lines.Add(string.Format("{0}{1}{0}", beforeAndAfterSpaces, currentChar));
                }
            }

            return lines;
        }

        private static int CalculateSquareSize(char inputChar)
        {
            return ((inputChar - BaseChar) * 2) + 1;
        }

        private static IEnumerable<Tuple<int, char>> GenerateTuples(int squareSize)
        {
            var increasingTuples = Enumerable.Range(0, squareSize / 2 + 1)
                .Select(i => Tuple.Create(i * 2 + 1, Convert.ToChar(BaseChar + i)))
                .ToArray();
            var decreasingTuples = increasingTuples.Reverse().Skip(1);
            return increasingTuples.Concat(decreasingTuples);
        }
    }
}
