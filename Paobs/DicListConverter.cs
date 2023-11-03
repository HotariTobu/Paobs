using System.Collections.Generic;
using System.Linq;

namespace Paobs
{
    class DicListConverter
    {
        public static string[] DicToList(Dictionary<string, string> dic) => dic?.Select(x => $"{x.Key},{x.Value}")?.ToArray() ?? new string[0];

        public static Dictionary<string, string> ListToDic(string[] list)
        {
            if (list == null)
            {
                return new Dictionary<string, string>();
            }

            Dictionary<string, string> dic = new Dictionary<string, string>(list.Length);
            foreach (string x in list)
            {
                string[] tokens = x.Split(',');
                switch (tokens.Length)
                {
                    case 1:
                        dic.Add(tokens[0], null);
                        break;
                    case 2:
                        dic.Add(tokens[0], string.IsNullOrWhiteSpace(tokens[1]) ? null : tokens[1]);
                        break;
                }
            }
            return dic;
        }
    }
}
