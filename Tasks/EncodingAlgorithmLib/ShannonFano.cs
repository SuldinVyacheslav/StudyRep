﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodingAlgorithmLib
{
    public class ShannonFano
    {
        public char[] Message;

        public Alphabet<char, string> alphabet;
        public ShannonFano(char[] message)
        {
            alphabet = new Alphabet<char, string>();
            this.Message = message;
        }

        public char[] Encode()
        {
            CharInfo[] sumInfo = GetMessage(Message);
            Array.Sort(sumInfo, (CharInfo x, CharInfo y) => (x.Value >= y.Value ? (x.Value > y.Value ? -1 : 0) : 1));
            foreach (CharInfo info in sumInfo)
            {
                Console.WriteLine($"{info.Sign} --- {info.Value}");
            }

            Tree root = new Tree(sumInfo, "");

            foreach (var search in root.Value)
            {
                alphabet.Add(search.Sign, root.Search(search));
            }

            string result = string.Empty;
            foreach (char sign in Message)
            {
                result += alphabet[sign];
            }

            return result.ToCharArray();
        }
        public CharInfo[] GetMessage(char[] message)
        {

            Dictionary<char, int> dict = new Dictionary<char, int>();
            List<CharInfo> list = new List<CharInfo>();
            foreach (char sign in message)
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
                list.Add(new CharInfo(key, dict[key] / (float)message.Length));
            }
            return list.ToArray();
        }
    }

    public class Tree
    {
        public Tree Zero;
        public Tree One;

        public string ThisIs = string.Empty;

        public List<CharInfo> Value;
        public Tree(CharInfo[] prob, string code)
        {
            if (prob.Length == 1)
            {
            }
            else
            {
                double[] min = new double[2] { 2, 1 };
                for (int i = 1; i < prob.Length; i++)
                {
                    List<CharInfo> forZero = prob[..^(prob.Length - i)].ToList();
                    List<CharInfo> forOne = prob[i..].ToList();
                    var a1 = forZero.AsQueryable().Average(s => s.Value) * i;
                    var a2 = forOne.AsQueryable().Average(s => s.Value) * (prob.Length - i);
                    double curDiff = forZero.AsQueryable().Average(s => s.Value) * i -
                        forOne.AsQueryable().Average(s => s.Value) * (prob.Length - i);
                    if (min[0] > Math.Abs(curDiff))
                    {
                        min[0] = Math.Abs(curDiff);
                        min[1] = i;
                    }
                }


                Zero = new Tree(prob[..^(int)(prob.Length - min[1])], code + "0");
                One = new Tree(prob[(int)min[1]..], code + "1");
            }
            Value = prob.ToList();
            ThisIs = code;
        }

        public string Search(CharInfo ch)
        {
            return Zero == null ?
                ThisIs :
                One == null ?
                    ThisIs :
                    Zero.Value.Contains(ch) ?
                        Zero.Search(ch) :
                        One.Search(ch);
        }
    }
}
