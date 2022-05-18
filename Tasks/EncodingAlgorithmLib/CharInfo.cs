using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodingAlgorithmLib
{
    public class CharInfo
    {
        public char Sign;

        public float Value;

        public float SumValue = 0;

        public string Bin;
        public CharInfo(char sign, float probability)
        {
            Sign = sign;
            Value = probability;
        }
    }
}
