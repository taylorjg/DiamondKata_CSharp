using System;
using System.Collections.Generic;
using System.Linq;

namespace DiamondLib
{
    public static class Diamond
    {
        private const char BaseChar = 'A';

        public static IEnumerable<string> GenerateLines(char inputChar)
        {
            var squareSize = CalculateSquareSize(inputChar);
            var tuples = GenerateTuples(squareSize);
            return tuples.Aggregate(Enumerable.Empty<string>(), (lines, tuple) =>
            {
                var patternWidth = tuple.Item1;
                var currentChar = tuple.Item2;
                return lines.Append(FormatLine(squareSize, patternWidth, currentChar));
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
            var padding = ((squareSize - patternWidth) / 2).ToSpaces();
            return (patternWidth == 1)
                ? FormatLineWithOneChar(currentChar, padding)
                : FormatLineWithTwoChars(currentChar, padding, patternWidth);
        }

        private static string FormatLineWithOneChar(char currentChar, string padding)
        {
            return padding + currentChar + padding;
        }

        private static string FormatLineWithTwoChars(char currentChar, string padding, int patternWidth)
        {
            var filling = (patternWidth - 2).ToSpaces();
            return padding + currentChar + filling + currentChar + padding;
        }
    }
}
