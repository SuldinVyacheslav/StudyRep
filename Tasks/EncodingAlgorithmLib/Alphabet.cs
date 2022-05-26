using System;
using System.Collections.Generic;

namespace EncodingAlgorithmLib
{
    public class Alphabet<TSymbol, TCode>
    {
        Dictionary<TSymbol, TCode> dict;
        public int Power { get => dict.Count; }
        public bool ContainsSymbol(TSymbol sym) => dict.ContainsKey(sym);
        public Alphabet()
        {
            dict = new Dictionary<TSymbol, TCode>();
        }
        public TCode this[TSymbol index] {get => dict[index]; set => dict[index] = value; }

        public void Add(TSymbol sign, TCode bin)
        {
            dict.Add(sign, bin);
        }
    }
}