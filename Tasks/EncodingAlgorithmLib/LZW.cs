using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodingAlgorithmLib
{
    public class LZW
    {
        public char[] Message;

        public char EOF;

        public Dictionary<string, int> Dict;
        public LZW(char[] message)
        {
            EOF = message.Last();
            Dict = new Dictionary<string, int>();
            this.Message = message;
        }

        public string Encode()
        {
            string result = string.Empty;

            for (int i = 0; i < 256; i++)
                Dict.Add(((char)i).ToString(), i);

            string w = string.Empty;

            foreach (char c in Message)
            {
                string wc = w + c;
                if (Dict.ContainsKey(wc))
                {
                    w = wc;
                }
                else
                {
                    result += Dict[w];
                    Dict.Add(wc, Dict.Count);
                    w = c.ToString();
                }
            }
            if (!string.IsNullOrEmpty(w))
                result += Dict[w];

            return result;
        }
    }
}
