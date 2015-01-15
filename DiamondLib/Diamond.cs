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
            var increasingPatternWidths = Enumerable.Range(0, squareSize / 2 + 1).ToArray();
            var decreasingPatternWidths = increasingPatternWidths.Reverse().Skip(1);
            var patternWidths = increasingPatternWidths.Concat(decreasingPatternWidths);

            var lines = new List<string>();

            foreach (var patternWidth in patternWidths)
            {
                var currentChar = Convert.ToChar(baseChar + patternWidth);
                var numBeforeAndAfterSpaces = (squareSize / 2 - patternWidth);
                var beforeAndAfterSpaces = numBeforeAndAfterSpaces.ToSpaces();
                if (patternWidth > 0)
                {
                    var numCentreSpaces = squareSize - numBeforeAndAfterSpaces * 2 - 2;
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
