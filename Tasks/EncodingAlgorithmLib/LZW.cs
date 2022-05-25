using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodingAlgorithmLib
{
    public class LZW
    {
        char[] message;

        public Alphabet<string, int> alphabet;
        public LZW(char[] message)
        {
            alphabet = new Alphabet<string, int>();
            this.message = message;
        }

        public string Encode()
        {
            string result = string.Empty;

            if (message == null || message.Length == 0) return result;

            for (int i = 0; i < 256; i++)
                alphabet.Add(((char)i).ToString(), i);

            string w = string.Empty;

            foreach (char c in message)
            {
                string wc = w + c;
                if (alphabet.ContainsSymbol(wc))
                {
                    w = wc;
                }
                else
                {
                    result += alphabet[w];
                    alphabet.Add(wc, alphabet.Power);
                    w = c.ToString();
                }
            }
            if (!string.IsNullOrEmpty(w))
                result += alphabet[w];

            return result;
        }
    }
}
