using System;
using System.Collections.Generic;
using System.Linq;

namespace DiamondLib
{
    public class Diamond
    {
        public static IEnumerable<string> GenerateLines(char inputChar)
        {
            const char baseChar = 'A';
            var squareSize = ((inputChar - baseChar) * 2) + 1;
            var increasingTuples = Enumerable.Range(0, squareSize / 2 + 1)
                .Select(i => Tuple.Create(i * 2 + 1, Convert.ToChar(baseChar + i)))
                .ToArray();
            var decreasingTuples = increasingTuples.Reverse().Skip(1);
            var tuples = increasingTuples.Concat(decreasingTuples);

            var lines = new List<string>();

            foreach (var tuple in tuples)
            {
                var patternWidth = tuple.Item1;
                var currentChar = tuple.Item2;
                var numBeforeAndAfterSpaces = (squareSize - patternWidth) / 2;
                var beforeAndAfterSpaces = numBeforeAndAfterSpaces.ToSpaces();
                if (patternWidth > 1)
                {
                    var numCentreSpaces = patternWidth - 2;
                    var centreSpaces = numCentreSpaces.ToSpaces();
                    lines.Add(string.Format("{0}{1}{2}{1}{0}", beforeAndAfterSpaces, currentChar, centreSpaces));
                }
                else
                {
                    lines.Add(string.Format("{0}{1}{0}", beforeAndAfterSpaces, currentChar));
                }
            }

            return lines;
        }
    }
}
