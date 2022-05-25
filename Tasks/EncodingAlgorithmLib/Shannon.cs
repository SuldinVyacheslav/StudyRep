using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodingAlgorithmLib
{
    public class Shannon
    {
        char[] message;

        public Alphabet<char, string> alphabet;
        public Shannon(char[] message)
        {
            alphabet = new Alphabet<char,string>();
            this.message = message == null? Array.Empty<char>() : message;
        }
        public char[] Encode()
        {
            CharInfo[] prob = GetInformation(message);
            Array.Sort(prob, (CharInfo x, CharInfo y ) => (x.Value >= y.Value ? (x.Value > y.Value? -1 : 0 ): 1));

            for (int i = 0; i < prob.Length; i++)
            {
                if (i >= 1) prob[i].SumValue = prob[i - 1].SumValue + prob[i - 1].Value;
                int lenght = (int)Math.Round(-Math.Log(prob[i].Value, 2), 0, MidpointRounding.ToPositiveInfinity);
                prob[i].Bin = String.Join("", ToBin(prob[i].SumValue, 10).ToCharArray()[..lenght]);
                alphabet.Add(prob[i].Sign, prob[i].Bin);
            }

            string result = string.Empty;
            foreach (char sign in message)
            {
                result += alphabet[sign];
            }

            return result.ToCharArray();
        }

        
        public CharInfo[] GetInformation(char[] messege)
        {

            Dictionary<char, int> dict = new Dictionary<char, int>();
            List<CharInfo> list = new List<CharInfo>();
            foreach (char sign in messege)
            {
                if (dict.Keys.Contains(sign))
                {
                    dict[sign]++;
                }
                else
                {
                    dict.Add(sign, 1);
                }
            }
            foreach (char key in dict.Keys)
            {
                list.Add(new CharInfo(key, dict[key] / (float)messege.Length));
            }
            return list.ToArray();
        }

        private string ToBin(float sumValue, int v)
        {
            string output = string.Empty;
            for (int i = 0; i < v; i++)
            {
                output += sumValue * 2 < 1 ? "0" : "1";
                sumValue = sumValue * 2 < 1 ? sumValue * 2 : sumValue * 2 - 1;
            }
            return output;
        }
    }

    
}
