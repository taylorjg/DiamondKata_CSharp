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
            var tuples = GenerateTuples(squareSize);
            return tuples.Aggregate(new List<string>(), (lines, tuple) =>
            {
                var patternWidth = tuple.Item1;
                var currentChar = tuple.Item2;
                lines.Add(FormatLine(squareSize, patternWidth, currentChar));
                return lines;
            });
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

        private static string FormatLine(int squareSize, int patternWidth, char currentChar)
        {
            string line;
            var beforeAndAfterSpaces = ((squareSize - patternWidth) / 2).ToSpaces();
            if (patternWidth > 1)
            {
                var centreSpaces = (patternWidth - 2).ToSpaces();
                line = string.Format("{0}{1}{2}{1}{0}", beforeAndAfterSpaces, currentChar, centreSpaces);
            }
            else
            {
                line = string.Format("{0}{1}{0}", beforeAndAfterSpaces, currentChar);
            }
            return line;
        }
    }
}
