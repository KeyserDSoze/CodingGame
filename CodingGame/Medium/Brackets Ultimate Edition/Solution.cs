using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CodinGame.Medium.Brackets_Ultimate_Edition
{
    internal class Solution : ICodinGame
    {
        private readonly static Regex Regex = new Regex(@"[^\(\)\[\]\{\}<>]*");
        private static readonly Dictionary<string, int> PossibleValues = new Dictionary<string, int>()
        {
            { "()", 0},
            { "[]", 0},
            { "{}", 0},
            { "<>", 0},
            { "((", 1},
            { "))", 1},
            { "[[", 1},
            { "]]", 1},
            { "{{", 1},
            { "}}", 1},
            { "<<", 1},
            { ">>", 1},
            { "][", 2},
            { ")(", 2},
            { "}{", 2},
            { "><", 2},
        };
        static List<string> Inputs = new List<string>()
        {
            "ShH3xi678soQJ9KxLG4NLgD7Rx3uMpAOe53SPVsWswOful8iaOh5RV7FAZfnQPBNH7X2iUvP2XNTC36nO9Gb5hxXY{wzn2KuaEaKzyQ3DLRMaQ2u5pbe5J7LLgf0G6PlyZC6xiDBSlXvpCpE7Utqokvx5iOL8IWP2LIbNIeP3KGOK3Izvtx{azS2RzPRg4RsTbDtYkzgChFVNiJSTAttHdpjq4b61sOkjCKNHKyLfe9RTrXR6jhJoDXfAyc6Soss1E4eHo9MDaVik}mNS4YvEeVeJhyYev1m1RS1yWSz30zCbIz09h2B2r1qcLjcoK5VICSn3j2yHpRLUf2z0dZisKlj7fOALjYnlxR82FP}8ZyVBOKUfCcnaFsbKK6KyntbXegwrc4uJ8MZKm24wMMnx1ooXVjE4Ltmyp0p1BLCPIfDrJCNkwmBtQ3SwoJptb4f4(7BJwu03HekY346YiRR09nthQgp2yE1sFbODYy1gog4AncGef7JZf5M5FjKisg0l5vpCRqkqYBTtaVZxGklDu92prq(EisaLdeXxIMOfWPxnESeW0RnrlytfqEiyjdFFXeujSJNUQ7YxkBEDW5Xq8b220sd6MjwZYAnqIEYd6a6vxcKe1Pi6[Xkut2OpgtFF9sOKwr8Fsp7D0AG5XUYA1mHmsflpIR83t6nF0hrbYzX6AuvpSU4nbI99bM4U3jblXSKxWoP8sT1ZbI]fQiZQkrEijqO3BWDNCGG1gw5j5lQ3QIzlhN0Oqs9TKiU2PVryXgIkRuPA0puxcw23Dwje4quuF0hhggKl1zKJCjOL)Gx9YnlHIzOp6bd70uY0HvGk4mNgXnamkeobRlipjWn3RhMoall0YxNn7KVu20BLfvCVN7dutrAzR5RcOQ5TCbZf3E(QPdLtdtZAKEyeoX137YNoD9Emu5ur3cNOIbFR4mK4kCkiJiHJe6wRE7vSvpv953VH7hiA135MTS6F67xbJsh6Upn4",
            "<{[(abc>}])"
        };
        private static (string Value, int Count) Contains(string input)
        {
            foreach (var s in PossibleValues)
                if (input.Contains(s.Key))
                    return (s.Key, s.Value);
            return (string.Empty, -1);
        }
        public void Run()
        {
            int N = Inputs.Count;
            for (int j = 0; j < N; j++)
            {
                string initial = Inputs[j];
                int count = 0;
                initial = Regex.Replace(initial, string.Empty);
                while (!string.IsNullOrWhiteSpace(initial))
                {
                    var c = Contains(initial);
                    if (c.Count == -1)
                        break;
                    initial = initial.ReplaceFirst(c.Value, string.Empty);
                    count += c.Count;
                }
                if (initial.Length > 0)
                    Console.WriteLine("-1");
                else
                    Console.WriteLine(count);
            }
        }
    }
    internal static class StringExtensionMethods
    {
        public static string ReplaceFirst(this string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
                return text;
            return $"{text.Substring(0, pos)}{replace}{text.Substring(pos + search.Length)}";
        }
    }
}
