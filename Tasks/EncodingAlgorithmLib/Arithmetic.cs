using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodingAlgorithmLib
{
    
    public class Arithmetic
    {
        public char[] Message;

        Dictionary<char, Section> Sections = new Dictionary<char, Section>();
        public Arithmetic(char[] message)
        {
            this.Message = message;
            SetSections(message);
        }

        public string Encode()
        {
            string result = string.Empty;
            foreach (char sign in Message[..^1])
            {
                RefreshSections(Sections[sign].Start, Sections[sign].End);
            }

            int rounded1 = (int)Math.Round(Sections[Message[^1]].End);
            int rounded2 = (int)Math.Round(Sections[Message[^1]].Start);
            int num = (int)Math.Pow(10, (rounded1 - rounded2).ToString().Length - 1);
            
            return (((rounded2 - rounded2 % num) / num + 1)).ToString();

        }

        public void RefreshSections(double start, double end)
        {
            Section[] sect = Sections.Values.ToArray();

            sect[0].Start = start;
            sect[0].End = sect[0].Start + (end - start) * sect[0].Percent;
            for (int i = 1; i < sect.Length - 1; i++)
            {
                sect[i].Start = sect[i-1].End;
                sect[i].End = sect[i].Start + (end - start) * sect[i].Percent;
            }
            sect[^1].End = end;
            sect[^1].Start = sect[^2].End;
            return;
        }

        public void SetSections(char[] messege)
        {
            Dictionary<char, double> dict = new Dictionary<char, double>();
            List<Section> list = new List<Section>();
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

            dict = dict.OrderBy(x => -x.Value).ToDictionary(x => x.Key, x => x.Value);
            foreach (char x in dict.Keys)
            {
                Sections.Add(x, new Section(
                    Sections.Count == 0 ? 0 : Sections.Last().Value.End,
                    Sections.Count == dict.Count ? 100000000 : Sections.Count == 0 ? dict[x] * 100000000 / messege.Length : Sections.Last().Value.End + dict[x] * 100000000 / messege.Length
                    ));
            }
        }
    }

    public class Section
    {
        public double End;
        public double Start;
        public double Percent;
        public Section(double start, double end)
        {
            this.End = end;
            this.Start = start;
            Percent = (End - Start) /100000000;
        }
    }
}
