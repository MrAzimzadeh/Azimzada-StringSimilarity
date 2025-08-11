using System;
using System.Collections.Generic;
using System.Linq;

namespace Azimzada.StringSimilarity
{
    public static class StringSimilarity
    {
        public static double Levenshtein(string s, string t)
        {
            if (string.IsNullOrEmpty(s)) return string.IsNullOrEmpty(t) ? 100 : 0;
            if (string.IsNullOrEmpty(t)) return 0;
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];
            for (int i = 0; i <= n; i++) d[i, 0] = i;
            for (int j = 0; j <= m; j++) d[0, j] = j;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = s[i - 1] == t[j - 1] ? 0 : 1;
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            int maxLen = Math.Max(n, m);
            int dist = d[n, m];
            return (1.0 - (double)dist / maxLen) * 100.0;
        }

        public static double JaroWinkler(string s1, string s2)
        {
            if (s1 == s2) return 100.0;
            int s1Len = s1.Length;
            int s2Len = s2.Length;
            if (s1Len == 0 || s2Len == 0) return 0.0;
            int matchDistance = Math.Max(s1Len, s2Len) / 2 - 1;
            bool[] s1Matches = new bool[s1Len];
            bool[] s2Matches = new bool[s2Len];
            int matches = 0;
            for (int i = 0; i < s1Len; i++)
            {
                int start = Math.Max(0, i - matchDistance);
                int end = Math.Min(i + matchDistance + 1, s2Len);
                for (int j = start; j < end; j++)
                {
                    if (s2Matches[j]) continue;
                    if (s1[i] != s2[j]) continue;
                    s1Matches[i] = true;
                    s2Matches[j] = true;
                    matches++;
                    break;
                }
            }
            if (matches == 0) return 0.0;
            double t = 0.0;
            int k = 0;
            for (int i = 0; i < s1Len; i++)
            {
                if (!s1Matches[i]) continue;
                while (!s2Matches[k]) k++;
                if (s1[i] != s2[k]) t += 0.5;
                k++;
            }
            double m = matches;
            double jaro = ((m / s1Len) + (m / s2Len) + ((m - t) / m)) / 3.0;
            int prefix = 0;
            for (int i = 0; i < Math.Min(4, Math.Min(s1Len, s2Len)); i++)
            {
                if (s1[i] == s2[i]) prefix++;
                else break;
            }
            double winkler = jaro + prefix * 0.1 * (1 - jaro);
            return winkler * 100.0;
        }

        public static List<(string item, double score)> FuzzySearch(string query, IEnumerable<string> items, int top = 5)
        {
            var results = items.Select(item => (item, score: JaroWinkler(query, item)))
                               .OrderByDescending(x => x.score)
                               .Take(top)
                               .ToList();
            return results;
        }
    }
}
