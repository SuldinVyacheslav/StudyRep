using System;
using EncodingAlgorithmLib;
using GraphsTask3;
using GraphLibrary;
using System.Collections.Generic;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            LZW lzw = new LZW("abacabadabacabae".ToCharArray());
            lzw.Encode();
        }
    }
}
