using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodingAlgorithmLib
{
    public class Huffman
    {
        public char[] Message;

        public Alphabet<char, string> alphabet;
        public Huffman(char[] messege)
        {
            alphabet = new Alphabet<char, string>();
            this.Message = messege;
        }

        public char[] Encode()
        {

            SetAlphabet();

            string result = string.Empty;
            foreach (char sign in Message)
            {
                result += alphabet[sign];
            }

            return result.ToCharArray();
        }

        public Alphabet<char, string> SetAlphabet()
        {

            Queue queue = new Queue(GetStartNodes(Message));

            if (queue.Elements.Count == 1)
            {
                alphabet[queue.Elements.First().Chars.First().Sign] = "0";
                return alphabet;
            }
            while (queue.Elements.Count != 1)
            {
                queue.Merge();
            }

            foreach (Char ch in queue.Elements[0].Chars)
            {
                if (alphabet.ContainsSymbol(ch.Sign))
                {
                    alphabet[ch.Sign] = queue.Elements[0].Search(ch);
                }
                else
                {
                    alphabet.Add(ch.Sign, queue.Elements[0].Search(ch));
                }
            }

            return alphabet;
        }
        public List<Node> GetStartNodes(char[] messege)
        {

            Dictionary<char, int> dict = new Dictionary<char, int>();
            List<Node> list = new List<Node>();
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
                list.Add(new Node(new List<Char>() { new Char(key, dict[key]) }));
            }
            return list;
        }
    }
    public class Char
    {
        public char Sign;
        public int Rarity;

        public Char(char sign, int count)
        {
            Sign = sign;
            Rarity = count;
        }
    }

    public class Queue
    {
        public List<Node> Elements;

        public Queue(List<Node> elements)
        {
            Elements = elements;
            Elements.Sort((Node x, Node y) => (x.Value >= y.Value ? (x.Value > y.Value ? -1 : 0) : 1));
        }

        public void Add(Node node)
        {
            Elements.Add(node);

            for (int i = Elements.Count - 1; i > 0; i--)
            {
                if (Elements[i].Value > Elements[i - 1].Value)
                {
                    var temp = Elements[i - 1];
                    Elements[i - 1] = Elements[i];
                    Elements[i] = temp;
                }
            }
        }

        public void Merge()
        {
            Node newNode = new Node(Elements[^1].Chars.Concat(Elements[^2].Chars).ToList());
            newNode.Zero = Elements.Last();
            Elements.Remove(Elements.Last());
            newNode.One = Elements.Last();
            Elements.Remove(Elements.Last());
            this.Add(newNode);
        }

    }
    public class Node
    {
        public int Value = 0;

        public List<Char> Chars;

        public Node One;
        public Node Zero;
        public Node(List<Char> list)
        {
            Chars = list;
            foreach (var ch in list)
            {
                Value += ch.Rarity;
            }
        }

        public string Search(Char ch)
        {
            return Zero == null ?
                string.Empty:
                One == null ?
                    string.Empty :
                    Zero.Chars.Contains(ch) ?
                        "0" +Zero.Search(ch):
                        "1" + One.Search(ch);
        }
    }
}
