using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodingAlgorithmLib
{
    
    public class AdaptiveHuffman
    {
        char[] message;

        Alphabet<char, string> alphabet;
        public AdaptiveHuffman(char[] message)
        {
            alphabet = new Alphabet<char, string>();
            this.message = message;
        }

        public char[] Encode()
        {

            if (message == null || message.Length == 0) return Array.Empty<char>();

            string result = string.Empty;

            Huffman huff = new Huffman(message);

            for (int i = 1; i < message.Length; i++)
            {
                huff.Message = message[..i];
                alphabet = huff.SetAlphabet();

                result += alphabet[message[i - 1]];
            }

            return result.ToCharArray();
        }
    }
}
