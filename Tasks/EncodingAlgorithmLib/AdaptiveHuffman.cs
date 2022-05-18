using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodingAlgorithmLib
{
    
    public class AdaptiveHuffman
    {
        public char[] message;

        Dictionary<char, string> dict;
        public AdaptiveHuffman(char[] messege)
        {
            dict = new Dictionary<char, string>();
            this.message = messege;
        }

        public string Encode()
        {
            string result = string.Empty;

            Huffman huff = new Huffman(message);

            for (int i = 1; i < message.Length; i++)
            {
                huff.Message = message[..i];
                dict = huff.MakeDict();

                result += dict[message[i - 1]];
            }

            return result;
        }
    }
}
