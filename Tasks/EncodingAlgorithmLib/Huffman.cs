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

        public Dictionary<char, string> Dict;
        public Huffman(char[] messege)
        {
            Dict = new Dictionary<char, string>();
            this.Message = messege;
        }

        public char[] Encode()
        {

            MakeDict();

            string result = string.Empty;
            foreach (char sign in Message)
            {
                result += Dict[sign];
            }

            return result.ToCharArray();
        }

        public Dictionary<char, string> MakeDict()
        {

            Queue queue = new Queue(GetStartNodes(Message));

            if (queue.Elements.Count == 1)
            {
                Dict[queue.Elements.First().Chars.First().Sign] = "0";
                return Dict;
            }
            while (queue.Elements.Count != 1)
            {
                queue.Merge();
            }

            foreach (Char ch in queue.Elements[0].Chars)
            {
                if (Dict.Keys.Contains(ch.Sign))
                {
                    Dict[ch.Sign] = queue.Elements[0].Search(ch);
                }
                else
                {
                    Dict.Add(ch.Sign, queue.Elements[0].Search(ch));
                }
            }

            return Dict;
        }
        public List<NotNode> GetStartNodes(char[] messege)
        {

            Dictionary<char, int> dict = new Dictionary<char, int>();
            List<NotNode> list = new List<NotNode>();
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
                list.Add(new NotNode(new List<Char>() { new Char(key, dict[key]) }));
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
        public List<NotNode> Elements;

        public Queue(List<NotNode> elements)
        {
            Elements = elements;
            Elements.Sort((NotNode x, NotNode y) => (x.Value >= y.Value ? (x.Value > y.Value ? -1 : 0) : 1));
        }

        public void Add(NotNode node)
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
            NotNode newNode = new NotNode(Elements[^1].Chars.Concat(Elements[^2].Chars).ToList());
            newNode.Zero = Elements.Last();
            Elements.Remove(Elements.Last());
            newNode.One = Elements.Last();
            Elements.Remove(Elements.Last());
            this.Add(newNode);
        }

    }
    public class NotNode
    {
        public int Value = 0;

        public List<Char> Chars;

        public NotNode One;
        public NotNode Zero;
        public NotNode(List<Char> list)
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
