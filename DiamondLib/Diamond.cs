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
            var numRows = ((inputChar - baseChar) * 2) + 1;
            var maxWidth = (numRows / 2) + 1;
            var increasingWidths = Enumerable.Range(0, maxWidth);
            var decreasingWidths = Enumerable.Range(0, maxWidth - 1).Reverse();
            var widths = increasingWidths.Concat(decreasingWidths);

            var lines = new List<string>();

            foreach (var width in widths)
            {
                var currentChar = Convert.ToChar(baseChar + width);
                string line;
                var beforeAndAfterSpaces = new string(' ', maxWidth - width - 1);
                if (width > 0)
                {
                    var centreSpaces = new string(' ', (width - 1) * 2 + 1);
                    line = string.Format("{0}{1}{2}{1}{0}", beforeAndAfterSpaces, currentChar, centreSpaces);
                }
                else
                {
                    line = string.Format("{0}{1}{0}", beforeAndAfterSpaces, currentChar);
                }
                lines.Add(line);
            }

            return lines;
        }

        // int.ToSpaces
    }
}
