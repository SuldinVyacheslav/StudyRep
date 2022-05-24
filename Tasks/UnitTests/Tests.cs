using NUnit.Framework;
using EncodingAlgorithmLib;
using GraphLibrary;
using GraphsTask2;
using System.Collections.Generic;
using GraphsTask3;
using System.Linq;

namespace UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShannonTest()
        {
            string messege = "aabbbbccddeeeeeeefff";
            char[] result = "10111011010010010010110011001110111000000000000000100100100".ToCharArray();
            Shannon shannon = new Shannon(messege.ToCharArray());
            Assert.AreEqual(result, shannon.Encode());
            Assert.AreEqual(new Dictionary<char, string>()
            {
                {'a',"1011" },
                {'b',"010" },
                {'c',"1100" },
                {'d',"1110"},
                {'e',"00"},
                {'f',"100"},

            }
            , shannon.Dict);
        }


        [Test]
        public void ShannonFanoTest()
        {
            string messege = "bbbeeee  oopp!r";
            char[] result = "0101010000000010010010110111011011101111".ToCharArray();
            ShannonFano shannonFano = new ShannonFano(messege.ToCharArray());
            Assert.AreEqual(result, shannonFano.Encode());
            Assert.AreEqual(new Dictionary<char, string>()
            {
                {'b',"01" },
                {'e',"00" },
                {' ',"100"},
                {'o',"101"},
                {'p',"110"},
                {'!',"1110"},
                {'r',"1111"},

            }
            , shannonFano.Dict);
        }

        [Test]
        public void LZWTest()
        {
            LZW lzw = new LZW("abacabadabacabae".ToCharArray());
            string asd = lzw.Encode();
            Assert.AreEqual("9798979925697100260259257101", asd);
        }

        [Test]
        public void HuffmanTest()
        {
            string messege = "bbbeeee  oopp!r";
            Huffman huffman = new Huffman(messege.ToCharArray());
            Assert.AreEqual("0000001111111101101101001010110110011000", huffman.Encode());
            Assert.AreEqual(new Dictionary<char, string>()
            {
                {'b',"00" },
                {'e',"11" },
                {' ',"011"},
                {'o',"010"},
                {'p',"101"},
                {'!',"1001"},
                {'r',"1000"},

            }
            , huffman.Dict);
        }

        [Test]
        public void AdaptiveHuffmanTest()
        {
            string messege = "bbbeeee  oopp!r";
            AdaptiveHuffman adaptiveHuffman = new AdaptiveHuffman(messege.ToCharArray());
            Assert.AreEqual("00000010010100110010100000", adaptiveHuffman.Encode());
        }

        [Test]
        public void ArithmeticTest()
        {
            string messege = "abaabaaca!";
            Arithmetic shannon = new Arithmetic(messege.ToCharArray());
            Assert.AreEqual("38858", shannon.Encode());
        }

        [Test]
        public void KruskalTest()
        {
            Vertex A = new Vertex("A");
            Vertex B = new Vertex("B");
            Vertex C = new Vertex("C");
            Vertex D = new Vertex("D");
            Edge AB = new Edge(33, A, B);
            Edge BC = new Edge(123, B, C);
            Edge AC = new Edge(3125, A, C);
            Edge CD = new Edge(45, C, D);
            Edge DA = new Edge(122, D, A);
            List<Edge> list = new List<Edge>() {
                AB, BC, CD, DA, AC
            };
            Graph gr = new Graph(list);


            Kruskal kr = new Kruskal();
            var sad = kr.GetSpanningTree(gr);
            Assert.That(sad.Edges[0].Value == AB.Value);
            Assert.That(sad.Edges[1].Value == CD.Value);
            Assert.That(sad.Edges[2].Value == DA.Value);
        }

        [Test]
        public void PrimTest()
        {
            Vertex A = new Vertex("A");
            Vertex B = new Vertex("B");
            Vertex C = new Vertex("C");
            Vertex D = new Vertex("D");
            Edge AB = new Edge(33, A, B);
            Edge BC = new Edge(123, B, C);
            Edge AC = new Edge(3125, A, C);
            Edge CD = new Edge(45, C, D);
            Edge DA = new Edge(122, D, A);
            List<Edge> list = new List<Edge>() {
                AB, BC, CD, DA, AC
            };
            Graph gr = new Graph(list);

            Prim kr = new Prim();
            var sad = kr.GetSpanningTree(gr);
            Assert.That(sad.Edges[0].Value == AB.Value);
            Assert.That(sad.Edges[1].Value == CD.Value);
            Assert.That(sad.Edges[2].Value == DA.Value);
        }

        [Test]
        public void BottleneckTest()
        {
            Vertex A = new Vertex("A");
            Vertex B = new Vertex("B");
            Vertex C = new Vertex("C");
            Vertex D = new Vertex("D");
            Vertex E = new Vertex("E");
            Vertex F = new Vertex("F");
            Vertex G = new Vertex("G");
            Edge AB = new Edge(7, A, B);
            Edge BC = new Edge(8, B, C);
            Edge AD = new Edge(5, A, D);
            Edge BE = new Edge(7, B, E);
            Edge BD = new Edge(9, B, D);
            Edge DE = new Edge(15, D, E);
            Edge DF = new Edge(6, D, F);
            Edge GF = new Edge(11, F, G);
            Edge FE = new Edge(8, E, F);
            Edge CE = new Edge(5, C, E);
            Edge GE = new Edge(7, G, E);
            List<Edge> list = new List<Edge>() {
                AB, BC, AD, BE, BD, DE, DF, GF, FE, CE, GE
            };
            List<Edge> result = new List<Edge>() {
                AD, CE, DF, AB, BE, GE
            };
            Graph gr = new Graph(list);

            Bottleneck mbn = new Bottleneck();


            Graph test0 = mbn.GetSpanningTree(gr);
            Assert.AreEqual(result.Count, test0.Edges.Count);
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(result[i].Value, test0.Edges[i].Value);
                Assert.AreEqual(result[i].X, test0.Edges[i].X);
                Assert.AreEqual(result[i].Y, test0.Edges[i].Y);
            }

            Graph test1 = mbn.GetSpanningTree(new Graph(new List<Edge>() { AB }));
            Assert.AreEqual(1, test1.Edges.Count);
            Assert.AreEqual(AB.Value, test1.Edges.First().Value);
            Assert.AreEqual(AB.X, test1.Edges.First().X);
            Assert.AreEqual(AB.Y, test1.Edges.First().Y);

            Graph test2 = mbn.GetSpanningTree(new Graph(new List<Edge>()));
            Assert.AreEqual(0, test2.Edges.Count);

            Graph test3 = mbn.GetSpanningTree(new Graph(new List<Vertex>()));
            Assert.AreEqual(0, test3.Edges.Count);

            Graph test4 = mbn.GetSpanningTree(new Graph(new List<Vertex>() { A } ));
            Assert.AreEqual(0, test4.Edges.Count);
            Assert.AreEqual(1, test4.Vertexes.Count);
        }

        [Test]
        public void Dijkstra()
        {
            Vertex A = new Vertex("A");
            Vertex B = new Vertex("B");
            Vertex C = new Vertex("C");
            Vertex D = new Vertex("D");
            Edge AB = new Edge(33, A, B);
            Edge BC = new Edge(123, B, C);
            Edge AC = new Edge(3125, A, C);
            Edge CD = new Edge(45, C, D);
            Edge DA = new Edge(122, D, A);
            List<Edge> list = new List<Edge>() {
                AB, BC, CD, DA, AC
            };
            Graph gr = new Graph(list);

            Dijkstra d = new Dijkstra();
            var sad = d.GetMinPath(gr, A);
            int[] result = new int[4] { 0, 33, 156, 122 };


            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(result[i], sad[sad.Keys.ToList()[i]]);
            }
            Assert.AreEqual(null, d.GetMinPath(gr, new Vertex("ASD")));
        }

        [Test]
        public void FordFulkersonTest()
        {
            int[,] graph = new int[,] {
            { 0, 16, 13, 0, 0, 0 }, { 0, 0, 10, 12, 0, 0 },
            { 0, 4, 0, 0, 14, 0 },  { 0, 0, 9, 0, 0, 20 },
            { 0, 0, 0, 7, 0, 4 },   { 0, 0, 0, 0, 0, 0 }
            };
            FordFulkerson ff = new FordFulkerson();
            int sdf = ff.GetMinFlow(graph, 0, 5);
            Assert.AreEqual(23, sdf);
        }

        [Test]
        public void DinicTest()
        {
            Dinic d = new Dinic(4);
            d.AddEdge(0, 1, 10);
            d.AddEdge(0, 2, 10);
            d.AddEdge(1, 3, 10);
            d.AddEdge(2, 3, 10);
            int sad = d.MaxFlow(0, 3);
            Assert.AreEqual(20, sad);
        }

        [Test]
        public void EdmondKarpTest()
        {

            EdmondKarp ek = new EdmondKarp(4);
            ek.AddEdge(0, 1, 10);
            ek.AddEdge(0, 2, 10);
            ek.AddEdge(1, 3, 10);
            ek.AddEdge(2, 3, 10);
            int asd = ek.GetMaxFlow(0, 3);
            Assert.AreEqual(20, asd);
        }

        [Test]
        public void ScalingFlowTest()
        {
            
            ScalingFlow sk = new ScalingFlow(6);
            sk.AddEdge(5, 0, 10);
            sk.AddEdge(5, 1, 10);
            sk.AddEdge(2, 4, 10);
            sk.AddEdge(3, 4, 10);
            sk.AddEdge(0, 1, 2);
            sk.AddEdge(0, 2, 4);
            sk.AddEdge(0, 3, 8);
            sk.AddEdge(1, 3, 9);
            sk.AddEdge(3, 2, 6);
            int asd = sk.GetMaxFlow(5, 4);
            Assert.AreEqual(16, asd);
        }

       
    }

}