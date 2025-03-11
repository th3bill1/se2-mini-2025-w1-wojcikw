using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace SE2;
internal class LongConversion
{
    public static long calc(string s)
    {
        if (string.IsNullOrEmpty(s)) return 0;
        if (long.TryParse(s, out long v))
        {
            if (v < 0) throw new FormatException();
            return v;
        }
        List<string> delimiters = [",", "\n"];
        if (s.StartsWith("["))
        {
            var match = Regex.Match(s, @"^\[(.*?)\]+");
            if (match.Success)
            {
                string delimiterSection = match.Value;
                s = s[delimiterSection.Length..];
                var delimiterMatches = Regex.Matches(delimiterSection, @"\[(.*?)\]");
                delimiters.AddRange(delimiterMatches.Select(m => m.Groups[1].Value));
            }
        }
        else if (!char.IsDigit(s[0])) delimiters.Add(s[0].ToString());
        string[] result = s.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
        long sum = 0;
        foreach (var nx in result)
        {
            if (long.TryParse(nx, out long value))
            {
                if (value < 0) throw new FormatException();
                if (value < 1001) sum += value;
            }
        }
        return sum;
    }
}
