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
        public void AlphabetTest()
        {
            Alphabet<string, int> testAlphabet = new Alphabet<string, int>();
            Assert.That(testAlphabet.Power == 0);
            testAlphabet.Add("test", 100);
            Assert.That(!testAlphabet.ContainsSymbol("test1"));
            Assert.That(testAlphabet.ContainsSymbol("test"));
            Assert.AreEqual(100, testAlphabet["test"]);
            testAlphabet.Add("", -123123);
            Assert.That(testAlphabet.ContainsSymbol(""));
            Assert.AreEqual(-123123, testAlphabet[""]);
        }
        [Test]
        public void ShannonTest()
        {
                                // possible cases
            string testMessage1 = "aabbbbccddeeeeeeefff";
            List<string> resultAlphabet1 = new List<string>() { "1011", "010", "1100", "1110", "00", "100" };
            List<char> charSet1 = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f' };
            char[] resultOfTest1 = "10111011010010010010110011001110111000000000000000100100100".ToCharArray();

            string testMessage2 = "";
            char[] resultOfTest2 = "".ToCharArray();

            char[] testMessage3 = null;
            char[] resultOfTest3 = "".ToCharArray();

            string testMessage4 = "\n\tASD\"\"\':";
            List<string> resultAlphabet4 = new List<string>() { "000", "0011", "0101", "0111", "1000", "1010", "1100", "1110" };
            List<char> charSet4 = new List<char>() { '\"', '\n', '\t', 'A', 'S', 'D', '\'', ':' };
            char[] resultOfTest4 = "0011010101111000101000000011001110".ToCharArray();


            // default string test

            Shannon testShannon1 = new Shannon(testMessage1.ToCharArray());
            Assert.AreEqual(resultOfTest1, testShannon1.Encode());
            for (int i = 0; i < testShannon1.alphabet.Power; i++)
                Assert.AreEqual(resultAlphabet1[i], testShannon1.alphabet[charSet1[i]]);

            // empty string test
            Shannon testShannon2 = new Shannon(testMessage2.ToCharArray());
            Assert.AreEqual(resultOfTest2, testShannon2.Encode());
            Assert.That(testShannon2.alphabet.Power == 0);

            // null test
            Shannon testShannon3 = new Shannon(testMessage3);
            Assert.AreEqual(resultOfTest3, testShannon3.Encode());
            Assert.That(testShannon3.alphabet.Power == 0);

            // service symbols test
            Shannon testShannon4 = new Shannon(testMessage4.ToCharArray());
            Assert.AreEqual(resultOfTest4, testShannon4.Encode());
            for (int i = 0; i < testShannon4.alphabet.Power; i++)
            {
                Assert.AreEqual(resultAlphabet4[i], testShannon4.alphabet[charSet4[i]]);
            }
        }

        [Test]
        public void ShannonFanoTest()
        {

            // possible cases
            string testMessage1 = "bbbeeee  oopp!r";
            List<string> resultAlphabet1 = new List<string>() { "01", "00", "100", "101", "110", "1110", "1111" };
            List<char> charSet1 = new List<char>() { 'b', 'e', ' ', 'o', 'p', '!', 'r' };
            char[] resultOfTest1 = "0101010000000010010010110111011011101111".ToCharArray();

            string testMessage2 = "";
            char[] resultOfTest2 = "".ToCharArray();

            char[] testMessage3 = null;
            char[] resultOfTest3 = "".ToCharArray();

            string testMessage4 = "\n\tASD\"\"\':";
            List<string> resultAlphabet4 = new List<string>() { "00", "010", "011", "100", "101", "110", "1110", "1111" };
            List<char> charSet4 = new List<char>() { '\"', '\n', '\t', 'A', 'S', 'D', '\'', ':' };
            char[] resultOfTest4 = "010011100101110000011101111".ToCharArray();


            // default string test

            ShannonFano testShannonFano1 = new ShannonFano(testMessage1.ToCharArray());
            Assert.AreEqual(resultOfTest1, testShannonFano1.Encode());
            for (int i = 0; i < testShannonFano1.alphabet.Power; i++)
                Assert.AreEqual(resultAlphabet1[i], testShannonFano1.alphabet[charSet1[i]]);

            // empty string test
            ShannonFano testShannonFano2 = new ShannonFano(testMessage2.ToCharArray());
            Assert.AreEqual(resultOfTest2, testShannonFano2.Encode());
            Assert.That(testShannonFano2.alphabet.Power == 0);

            // null test
            ShannonFano testShannonFano3 = new ShannonFano(testMessage3);
            Assert.AreEqual(resultOfTest3, testShannonFano3.Encode());
            Assert.That(testShannonFano3.alphabet.Power == 0);

            // service symbols test
            ShannonFano testShannonFano4 = new ShannonFano(testMessage4.ToCharArray());
            Assert.AreEqual(resultOfTest4, testShannonFano4.Encode());
            for (int i = 0; i < testShannonFano4.alphabet.Power; i++)
            {
                Assert.AreEqual(resultAlphabet4[i], testShannonFano4.alphabet[charSet4[i]]);
            }

        }

        [Test]
        public void LZWTest()
        {
            // possible cases
            string testMessage1 = "abacabadabacabae";
            char[] resultOfTest1 = "9798979925697100260259257101".ToCharArray();

            string testMessage2 = "";
            char[] resultOfTest2 = "".ToCharArray();

            char[] testMessage3 = null;
            char[] resultOfTest3 = "".ToCharArray();

            string testMessage4 = "\n\tASD\"\"\':";
            char[] resultOfTest4 = "10965836834343958".ToCharArray();


            // default string test

            LZW testLZW1 = new LZW(testMessage1.ToCharArray());
            Assert.AreEqual(resultOfTest1, testLZW1.Encode());

            // empty string test
            LZW testLZW2 = new LZW(testMessage2.ToCharArray());
            Assert.AreEqual(resultOfTest2, testLZW2.Encode());
            Assert.That(testLZW2.alphabet.Power == 0);

            // null test
            LZW testLZW3 = new LZW(testMessage3);
            Assert.AreEqual(resultOfTest3, testLZW3.Encode());
            Assert.That(testLZW3.alphabet.Power == 0);

            // service symbols test
            LZW testLZW4 = new LZW(testMessage4.ToCharArray());
            Assert.AreEqual(resultOfTest4, testLZW4.Encode());

        }

        [Test]
        public void HuffmanTest()
        {
                               // possible cases
            string testMessage1 = "bbbeeee  oopp!r";
            List<string> resultAlphabet1 = new List<string>() { "00", "11", "011", "010", "101", "1001", "1000" };
            List<char> charSet1 = new List<char>() { 'b', 'e', ' ', 'o', 'p', '!', 'r' };
            char[] resultOfTest1 = "0000001111111101101101001010110110011000".ToCharArray();

            string testMessage2 = "";
            char[] resultOfTest2 = "".ToCharArray();

            char[] testMessage3 = null;
            char[] resultOfTest3 = "".ToCharArray();

            string testMessage4 = "\n\tASD\"\"\':";
            List<string> resultAlphabet4 = new List<string>() { "000", "001", "010", "011", "10", "110", "1110", "1111" };
            List<char> charSet4 = new List<char>() { 'D', 'S', ':', '\'', '\"', '\n', 'A', '\t' };
            char[] resultOfTest4 = "110111111100010001010011010".ToCharArray();


            // default string test

            Huffman testHuffman1 = new Huffman(testMessage1.ToCharArray());
            Assert.AreEqual(resultOfTest1, testHuffman1.Encode());
            for (int i = 0; i < testHuffman1.alphabet.Power; i++)
                Assert.AreEqual(resultAlphabet1[i], testHuffman1.alphabet[charSet1[i]]);

            // empty string test
            Huffman testHuffman2 = new Huffman(testMessage2.ToCharArray());
            Assert.AreEqual(resultOfTest2, testHuffman2.Encode());
            Assert.That(testHuffman2.alphabet.Power == 0);

            // null test
            Huffman testHuffman3 = new Huffman(testMessage3);
            Assert.AreEqual(resultOfTest3, testHuffman3.Encode());
            Assert.That(testHuffman3.alphabet.Power == 0);

            // service symbols test
            Huffman testHuffman4 = new Huffman(testMessage4.ToCharArray());
            Assert.AreEqual(resultOfTest4, testHuffman4.Encode());
            for (int i = 0; i < testHuffman4.alphabet.Power; i++)
            {
                Assert.AreEqual(resultAlphabet4[i], testHuffman4.alphabet[charSet4[i]]);
            }
        }

        [Test]
        public void AdaptiveHuffmanTest()
        {
            // possible cases
            string testMessage1 = "bbbeeee  oopp!r";
            char[] resultOfTest1 = "00000010010100110010100000".ToCharArray();

            string testMessage2 = "";
            char[] resultOfTest2 = "".ToCharArray();

            char[] testMessage3 = null;
            char[] resultOfTest3 = "".ToCharArray();

            string testMessage4 = "\n\tASD\"\"\':";
            char[] resultOfTest4 = "001010000011000".ToCharArray();


            // default string test

            AdaptiveHuffman testAdHuffman1 = new AdaptiveHuffman(testMessage1.ToCharArray());
            Assert.AreEqual(resultOfTest1, testAdHuffman1.Encode());

            // empty string test
            AdaptiveHuffman testAdHuffman2 = new AdaptiveHuffman(testMessage2.ToCharArray());
            Assert.AreEqual(resultOfTest2, testAdHuffman2.Encode());

            // null test
            AdaptiveHuffman testAdHuffman3 = new AdaptiveHuffman(testMessage3);
            Assert.AreEqual(resultOfTest3, testAdHuffman3.Encode());

            // service symbols test
            AdaptiveHuffman testAdHuffman4 = new AdaptiveHuffman(testMessage4.ToCharArray());
            Assert.AreEqual(resultOfTest4, testAdHuffman4.Encode());

        }

        [Test]
        public void ArithmeticTest()
        {
            // possible cases
            string testMessage1 = "abaabaaca!";
            string resultOfTest1 = "38858";

            string testMessage2 = "";
            string resultOfTest2 = "";

            char[] testMessage3 = null;
            string resultOfTest3 = "";

            string testMessage4 = "\n\tASD\"\"\':";
            string resultOfTest4 = "26561066";


            // default string test

            Arithmetic testArithmetic1 = new Arithmetic(testMessage1.ToCharArray());
            Assert.AreEqual(resultOfTest1, testArithmetic1.Encode());

            // empty string test
            Arithmetic testArithmetic2 = new Arithmetic(testMessage2.ToCharArray());
            Assert.AreEqual(resultOfTest2, testArithmetic2.Encode());

            // null test
            Arithmetic testArithmetic3 = new Arithmetic(testMessage3);
            Assert.AreEqual(resultOfTest3, testArithmetic3.Encode());

            // service symbols test
            Arithmetic testArithmetic4 = new Arithmetic(testMessage4.ToCharArray());
            Assert.AreEqual(resultOfTest4, testArithmetic4.Encode());

        }

        [Test]
        public void KruskalTest()
        {
            // Graphs for test

            Graph testGraph1 = new Graph(new int[,] {
            { 0, 5, 7, 0, 0, 0, 0, 0 },
            { 5, 0, 0, 9, 8, 0, 0, 0 },
            { 7, 0, 0, 1, 0, 0, 0, 0 },
            { 0, 9, 1, 0, 8, 2, 0, 0 },
            { 0, 8, 0, 8, 0, 6, 3, 0 },
            { 0, 0, 0, 2, 6, 0, 0, 4},
            { 0, 0, 0, 0, 3, 0, 0, 7 },
            { 0, 0, 0, 0, 0, 4, 7, 0 },
            }); //connected graph
            Graph testGraph2 = new Graph(new int[,] {
            { 0, 5, 7, 0, 0, 0, 0, 0 },
            { 5, 0, 0, 9, 0, 0, 0, 0 },
            { 7, 0, 0, 1, 0, 0, 0, 0 },
            { 0, 9, 1, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 6, 3, 0 },
            { 0, 0, 0, 0, 6, 0, 0, 4},
            { 0, 0, 0, 0, 3, 0, 0, 7 },
            { 0, 0, 0, 0, 0, 4, 7, 0 },
            }); //disconnected graph
            Graph testGraph3 = new Graph(new int[,] {
            { 0, 7, 7, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 7, 0, 0, 0, 0 },
            { 0, 0, 0, 7, 0, 0, 0, 0 },
            }); //wrong graph
            Graph testGraph4 = new Graph(new List<Vertex>()
            {
                new Vertex("0"),
                new Vertex("1"),
                new Vertex("2"),
            }); // graph without edges

            // Tests 
            Kruskal kruskal = new Kruskal();

            // Spanning tree in connected graph
            List<Edge> edgesCase1 = new List<Edge>() {
                new Edge(1,new Vertex("3"),new Vertex("2")),
                new Edge(2,new Vertex("5"),new Vertex("3")),
                new Edge(3,new Vertex("6"),new Vertex("4")),
                new Edge(4,new Vertex("7"),new Vertex("5")),
                new Edge(5,new Vertex("1"),new Vertex("0")),
                new Edge(6,new Vertex("5"),new Vertex("4")),
                new Edge(7,new Vertex("2"),new Vertex("0")),
            };
            Graph spanningTree1 = kruskal.GetSpanningTree(testGraph1);
            Assert.AreEqual(7, spanningTree1.Edges.Count);
            for (int i = default; i < spanningTree1.Edges.Count; i++)
            {
                Assert.AreEqual(edgesCase1[i].Value, spanningTree1.Edges[i].Value);
                Assert.AreEqual(edgesCase1[i].X.Name, spanningTree1.Edges[i].X.Name);
                Assert.AreEqual(edgesCase1[i].Y.Name, spanningTree1.Edges[i].Y.Name);
            }

            // Spanning forest in disconnected graph
            List<Edge> edgesCase2 = new List<Edge>() {
                new Edge(1,new Vertex("3"),new Vertex("2")),
                new Edge(3,new Vertex("6"),new Vertex("4")),
                new Edge(4,new Vertex("7"),new Vertex("5")),
                new Edge(5,new Vertex("1"),new Vertex("0")),
                new Edge(6,new Vertex("5"),new Vertex("4")),
                new Edge(7,new Vertex("2"),new Vertex("0")),
            };
            Graph spanningTree2 = kruskal.GetSpanningTree(testGraph2);
            Assert.AreEqual(6, spanningTree2.Edges.Count);
            for (int i = default; i < spanningTree2.Edges.Count; i++)
            {
                Assert.AreEqual(edgesCase2[i].Value, spanningTree2.Edges[i].Value);
                Assert.AreEqual(edgesCase2[i].X.Name, spanningTree2.Edges[i].X.Name);
                Assert.AreEqual(edgesCase2[i].Y.Name, spanningTree2.Edges[i].Y.Name);
            }

            // Cant create graph - wrong matrix
            Graph spanningTree3 = kruskal.GetSpanningTree(testGraph3);
            Assert.AreEqual(null, spanningTree3);

            // Spanning tree of vertex forest is that vertex forest
            Graph spanningTree4 = kruskal.GetSpanningTree(testGraph4);
            Assert.AreEqual(3, spanningTree4.Vertexes.Count);
        }

        [Test]
        public void PrimTest()
        {
            // Graphs for test

            Graph testGraph1 = new Graph(new int[,] {
            { 0, 5, 7, 0, 0, 0, 0, 0 },
            { 5, 0, 0, 9, 8, 0, 0, 0 },
            { 7, 0, 0, 1, 0, 0, 0, 0 },
            { 0, 9, 1, 0, 8, 2, 0, 0 },
            { 0, 8, 0, 8, 0, 6, 3, 0 },
            { 0, 0, 0, 2, 6, 0, 0, 4},
            { 0, 0, 0, 0, 3, 0, 0, 7 },
            { 0, 0, 0, 0, 0, 4, 7, 0 },
            }); //connected graph
            Graph testGraph2 = new Graph(new int[,] {
            { 0, 5, 7, 0, 0, 0, 0, 0 },
            { 5, 0, 0, 9, 0, 0, 0, 0 },
            { 7, 0, 0, 1, 0, 0, 0, 0 },
            { 0, 9, 1, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 6, 3, 0 },
            { 0, 0, 0, 0, 6, 0, 0, 4},
            { 0, 0, 0, 0, 3, 0, 0, 7 },
            { 0, 0, 0, 0, 0, 4, 7, 0 },
            }); //disconnected graph
            Graph testGraph3 = new Graph(new int[,] {
            { 0, 7, 7, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 7, 0, 0, 0, 0 },
            { 0, 0, 0, 7, 0, 0, 0, 0 },
            }); //wrong graph
            Graph testGraph4 = new Graph(new List<Vertex>()
            {
                new Vertex("0"),
                new Vertex("1"),
                new Vertex("2"),
            }); // graph without edges

            // Tests 
            Prim prim = new Prim();

            // Spanning tree in connected graph
            List<Edge> edgesCase1 = new List<Edge>() {
                new Edge(1,new Vertex("3"),new Vertex("2")),
                new Edge(2,new Vertex("5"),new Vertex("3")),
                new Edge(3,new Vertex("6"),new Vertex("4")),
                new Edge(4,new Vertex("7"),new Vertex("5")),
                new Edge(5,new Vertex("1"),new Vertex("0")),
                new Edge(6,new Vertex("5"),new Vertex("4")),
                new Edge(7,new Vertex("2"),new Vertex("0")),
            };
            Graph spanningTree1 = prim.GetSpanningTree(testGraph1);
            Assert.AreEqual(7, spanningTree1.Edges.Count);
            for (int i = default; i < spanningTree1.Edges.Count; i++)
            {
                Assert.AreEqual(edgesCase1[i].Value, spanningTree1.Edges[i].Value);
                Assert.AreEqual(edgesCase1[i].X.Name, spanningTree1.Edges[i].X.Name);
                Assert.AreEqual(edgesCase1[i].Y.Name, spanningTree1.Edges[i].Y.Name);
            }
            // Spanning forest in disconnected graph
            List<Edge> edgesCase2 = new List<Edge>() {
                new Edge(1,new Vertex("3"),new Vertex("2")),
                new Edge(3,new Vertex("6"),new Vertex("4")),
                new Edge(4,new Vertex("7"),new Vertex("5")),
                new Edge(5,new Vertex("1"),new Vertex("0")),
                new Edge(6,new Vertex("5"),new Vertex("4")),
                new Edge(7,new Vertex("2"),new Vertex("0")),
            };
            Graph spanningTree2 = prim.GetSpanningTree(testGraph2);
            Assert.AreEqual(6, spanningTree2.Edges.Count);
            for (int i = default; i < spanningTree2.Edges.Count; i++)
            {
                Assert.AreEqual(edgesCase2[i].Value, spanningTree2.Edges[i].Value);
                Assert.AreEqual(edgesCase2[i].X.Name, spanningTree2.Edges[i].X.Name);
                Assert.AreEqual(edgesCase2[i].Y.Name, spanningTree2.Edges[i].Y.Name);
            }

            // Cant create graph - wrong matrix
            Graph spanningTree3 = prim.GetSpanningTree(testGraph3);
            Assert.AreEqual(null, spanningTree3);

            // Spanning tree of vertex forest is that vertex forest
            Graph spanningTree4 = prim.GetSpanningTree(testGraph4);
            Assert.AreEqual(3, spanningTree4.Vertexes.Count);
        }

        [Test]
        public void BottleneckTest()
        {
            Bottleneck mbn = new Bottleneck();

                                // Graphs for test

            // graphs from   matrix

            Graph testGraph1 = new Graph(new int[,] {
            { 0, 7, 0, 5, 0, 0, 0 },
            { 7, 0, 8, 9, 7, 0, 0 },
            { 0, 8, 0, 0, 5, 0, 0 },
            { 5, 9, 0, 0, 15, 6, 0 },
            { 0, 7, 5, 15, 0, 8, 7 },
            { 0, 0, 0, 6, 8, 0, 11 },
            { 0, 0, 0, 0, 7, 11, 0 },
            }); //connected graph

            Graph testGraph2 = new Graph(new int[,] { { 0 } }); //just vertex

            // graphs from edges and vertexes

            Vertex A = new Vertex("A");
            Vertex B = new Vertex("B");
            Edge AB = new Edge(7, A, B);

            Graph testGraph3 = new Graph(new List<Edge>() { AB }); // just edge
            Graph testGraph4 = new Graph(new List<Vertex>() { A }); //just vertex
            Graph testGraph5 = new Graph(new List<Edge>()); // null graph
            Graph testGraph6 = new Graph(new List<Vertex>()); // null graph

                                //Test on graphs

            // mbst of connected graph
            List<Edge> result = new List<Edge>() {
                new Edge(5,testGraph1.Vertexes[3],testGraph1.Vertexes[0]),
                new Edge(5,testGraph1.Vertexes[4],testGraph1.Vertexes[2]),
                new Edge(6,testGraph1.Vertexes[5],testGraph1.Vertexes[3]),
                new Edge(7,testGraph1.Vertexes[1],testGraph1.Vertexes[0]),
                new Edge(7,testGraph1.Vertexes[4],testGraph1.Vertexes[1]),
                new Edge(7,testGraph1.Vertexes[6],testGraph1.Vertexes[4])
            };
            Graph testGraph1ST = mbn.GetSpanningTree(testGraph1);
            for (int i = 0; i < testGraph1ST.Edges.Count; i++)
            {
                Assert.AreEqual(result[i].Value, testGraph1ST.Edges[i].Value);
                Assert.AreEqual(result[i].X, testGraph1ST.Edges[i].X);
                Assert.AreEqual(result[i].Y, testGraph1ST.Edges[i].Y);
            }
            // mbst of null graph is null
            Graph testGraph2ST = mbn.GetSpanningTree(testGraph2);
            Assert.AreEqual(0, testGraph2ST.Edges.Count);

            // One-edge graph mbst is it vertex 
            Graph testGraph3ST = mbn.GetSpanningTree(testGraph3);
            Assert.AreEqual(1, testGraph3ST.Edges.Count);
            Assert.AreEqual(AB.Value, testGraph3ST.Edges.First().Value);
            Assert.AreEqual(AB.X, testGraph3ST.Edges.First().X);
            Assert.AreEqual(AB.Y, testGraph3ST.Edges.First().Y);

            // One-vertex graph mbst is it vertex
            Graph testGraph4ST = mbn.GetSpanningTree(testGraph4);
            Assert.AreEqual(0, testGraph4ST.Edges.Count);
            Assert.AreEqual(1, testGraph4ST.Vertexes.Count);

            // mbst of null graph is null
            Graph testGraph5ST = mbn.GetSpanningTree(testGraph5);
            Assert.AreEqual(0, testGraph5ST.Edges.Count);

            // mbst of null graph is null
            Graph testGraph6ST = mbn.GetSpanningTree(testGraph6);
            Assert.AreEqual(0, testGraph6ST.Edges.Count);
        }

        [Test]
        public void Dijkstra()
        {
            Graph testGraph1 = new Graph(new int[,] {
            { 0, 5, 7, 0, 0, 0, 0, 0 },
            { 5, 0, 0, 9, 8, 0, 0, 0 },
            { 7, 0, 0, 1, 0, 0, 0, 0 },
            { 0, 9, 1, 0, 8, 2, 0, 0 },
            { 0, 8, 0, 8, 0, 6, 3, 0 },
            { 0, 0, 0, 2, 6, 0, 0, 4},
            { 0, 0, 0, 0, 3, 0, 0, 7 },
            { 0, 0, 0, 0, 0, 4, 7, 0 },
            }); //connected graph
            Graph testGraph2 = new Graph(new int[,] {
            { 0, 5, 7, 0, 0, 0, 0, 0 },
            { 5, 0, 0, 9, 0, 0, 0, 0 },
            { 7, 0, 0, 1, 0, 0, 0, 0 },
            { 0, 9, 1, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 6, 3, 0 },
            { 0, 0, 0, 0, 6, 0, 0, 4},
            { 0, 0, 0, 0, 3, 0, 0, 7 },
            { 0, 0, 0, 0, 0, 4, 7, 0 },
            }); //disconnected graph
            Graph testGraph3 = new Graph(new int[,] {
            { 0, 7, 7, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 7, 0, 0, 0, 0 },
            { 0, 0, 0, 7, 0, 0, 0, 0 },
            }); //wrong graph
            Graph testGraph4 = new Graph(new List<Vertex>()
            {
                new Vertex("0"),
                new Vertex("1"),
                new Vertex("2"),
            }); // graph without edges


            // Tests 
            Dijkstra dijkstra = new Dijkstra();

            // Path in connected graph
            int[] resulted1 = new int[8] { 0, 5, 7, 14, 13, 19, 16, 23 };
            Dictionary<Vertex, int> minPaths1a = dijkstra.GetMinPath(testGraph1, testGraph1.Vertexes.First());
            Assert.AreEqual(testGraph1.Vertexes.Count, minPaths1a.Count);
            for (int i = default; i < resulted1.Length; i++)
                Assert.AreEqual(resulted1[i], minPaths1a[testGraph1.Vertexes[i]]);

            // From vertex that not in graph
            Dictionary<Vertex, int> minPaths1b = dijkstra.GetMinPath(testGraph1, new Vertex("-1"));
            Assert.AreEqual(null, minPaths1b);

            // Path in disconnected graph
            int[] resulted2 = new int[8] { 0, 5, 7, 14, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue };
            Dictionary<Vertex, int> minPaths2 = dijkstra.GetMinPath(testGraph2, testGraph2.Vertexes.First());
            Assert.AreEqual(testGraph2.Vertexes.Count, minPaths2.Count);
            for (int i = default; i < resulted2.Length; i++)
                Assert.AreEqual(resulted2[i], minPaths2[testGraph2.Vertexes[i]]);


            // Cant create graph - wrong matrix
            Dictionary<Vertex, int> minPaths3 = dijkstra.GetMinPath(testGraph3, new Vertex("-1"));
            Assert.AreEqual(null, minPaths3);

            // Paths in forest of vertexes is +inf all 
            int[] resulted4 = Enumerable.Repeat(int.MaxValue, testGraph4.Vertexes.Count).ToArray();
            Dictionary<Vertex, int> minPaths4 = dijkstra.GetMinPath(testGraph4, testGraph4.Vertexes.First());
            Assert.AreEqual(testGraph4.Vertexes.Count, minPaths4.Count);
            for (int i = 1; i < resulted4.Length; i++)
                Assert.AreEqual(resulted4[i], minPaths4[testGraph4.Vertexes[i]]);
        }

        [Test]
        public void VertexNeighborInfoTest()
        {
            VertexNeighborInfo testInfo = new VertexNeighborInfo();
            OrEdge edgeA = new OrEdge(10, 0, 1);
            OrEdge edgeB = new OrEdge(10, 1, 2);
            Assert.That(testInfo.NumberOfNeighbors == 0);
            Assert.That(testInfo.Add(edgeA));
            Assert.That(testInfo.NumberOfNeighbors == 1);
            Assert.That(!testInfo.Add(edgeA));
            Assert.That(testInfo.NumberOfNeighbors == 1);
            Assert.That(testInfo.Add(edgeB));
            Assert.That(testInfo.NumberOfNeighbors == 2);
        }

        [Test]
        public void FordFulkersonTest()
        {
            FordFulkerson ff = new FordFulkerson();

                                          // Graphs for test

            int[,] testGraph1 = new int[,] {
            { 0, 10, 10, 0, 10, 0 },
            { 0, 0, 0, 10, 0, 0 },
            { 0, 0, 0, 10, 0, 0 },
            { 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 10 },
            { 0, 0, 0, 10, 0, 0 }
            }; //connected graph
            int[,] testGraph2 = new int[,] {
            { 0, 7, 7, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 7, 0, 0, 0, 0 },
            { 0, 0, 0, 7, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 7, 7, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 7 },
            { 0, 0, 0, 0, 0, 0, 0, 7 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            }; //disconnected graph
            int[,] testGraph3 = new int[,] {
            { 0, 7, 7, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 7, 0, 0, 0, 0 },
            { 0, 0, 0, 7, 0, 0, 0, 0 },
            }; //wrong graph
            int[,] testGraph4 = new int[,] {
            { 0, 7, 7, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 7, 0, 4, 0, 0 },
            { 0, 0, 0, 7, 0, 0, 0, 0 },
            { 1, 0, 3, 0, 0, 0, 6, 0 },
            { 0, 0, 0, 0, 0, 7, 7, 0 },
            { 0, 6, 5, 0, 0, 0, 0, 7 },
            { 0, 0, 0, 0, 0, 7, 0, 7 },
            { 0, 0, 6, 0, 5, 0, 0, 0 },
            }; //default connected
            int[,] taskGraph = new int[,]
            {
                //, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15  - 0
                {0, 0, 0, 0, 8, 1, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0},
                //, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15  - 1
                {0, 0, 6, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                //, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15  - 2
                {0, 0, 0, 3, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                //, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15  - 3
                {0, 0, 0, 0, 4, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0},
                //, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15  - 4
                {0, 0, 0, 0, 0, 3, 0, 0, 5, 10, 0, 0, 0, 0, 0, 0},
                //, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15  - 5
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0},
                //, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15  - 6
                {0, 0, 0, 9, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0},
                //, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15  - 7
                {0, 0, 0, 0, 10, 0, 8, 0, 0, 0, 0,  5, 0, 0, 0, 0},
                //, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15  - 8
                {0, 0, 0, 0, 0, 0, 0, 8, 0, 0, 0,   0,  5, 12, 0,  0},
                //, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15  - 9
                {0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0,   0, 0,   7, 0, 0},
                //, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15  - 10
                {0, 0, 0, 0, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 6, 0},
                //, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15  - 11
                {0, 0, 0, 0, 0, 0, 0, 0, 12, 0, 8,  0,  0,  0,  9, 0},
                //, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15  - 12
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,   8, 0, 0, 0, 7},
                //, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15  - 13
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,   0, 7, 0, 0, 6},
                //, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15  - 14
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                //, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15  - 15
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            };  //task graph

                                          // DFS Tests

            // DFS in connected graph, path exists

            int[] path = new int[testGraph1.GetLength(0)];
            int[] case1Path = new int[] { -1, 0, 0, 5, 0, 4 };
            int[] case2Path = new int[] { -1, 0, -1, 2, 0, 4 };
            Assert.That(ff.DFS(testGraph1, 0, 3, path)); //case 1
            for (int i = default; i < testGraph1.GetLength(0); i++)
                Assert.AreEqual(case1Path[i],path[i]);

            Assert.That(ff.DFS(testGraph1, 2, 3, path)); //case 2
            for (int i = default; i < testGraph1.GetLength(0); i++)
                Assert.AreEqual(case2Path[i], path[i]);

            // DFS in connected graph, path doesn't exists

            path = new int[testGraph2.GetLength(0)];

            Assert.That(!ff.DFS(testGraph1, 3, 0, path)); 

            Assert.That(!ff.DFS(testGraph1, 5, 4, path)); 

            // DFS in disconnected graph, path exists

            path = new int[testGraph2.GetLength(0)];
            case1Path = new int[] { -1, 0, 0, 2, 0, 0, 0, 0 };
            case2Path = new int[] { -1, 0, -1, 2, 0, 0, 0, 0 };

            Assert.That(ff.DFS(testGraph2, 0, 3, path)); //case 1
            for (int i = default; i < testGraph2.GetLength(0); i++)
                Assert.AreEqual(case1Path[i], path[i]);

            Assert.That(ff.DFS(testGraph2, 2, 3, path)); //case 2
            for (int i = default; i < testGraph2.GetLength(0); i++)
                Assert.AreEqual(case2Path[i], path[i]);

            // DFS in disconnected graph, path doesn't exists

            path = new int[testGraph2.GetLength(0)];

            Assert.That(!ff.DFS(testGraph2, 0, 7, path)); //case 1

            Assert.That(!ff.DFS(testGraph2, 7, 5, path)); //case 2


                                        //Test on graphs

            int flow = default;

            // Simple connected graph
            
            flow = ff.GetMaxFlow(testGraph1, 0, 3);
            Assert.AreEqual(30, flow);

            // Simple disconnected graph, source and sink in one component
            flow = ff.GetMaxFlow(testGraph2, 0, 3);
            Assert.AreEqual(14, flow);

            // Simple disconnected graph, source and sink in different components
            flow = ff.GetMaxFlow(testGraph2, 0, 7);
            Assert.AreEqual(0, flow);

            // Not suitable matrix graph
            flow = ff.GetMaxFlow(testGraph3, 0, 2);
            Assert.AreEqual(-1, flow);

            // Source / sink not exist in graph 
            Assert.AreEqual(-1, ff.GetMaxFlow(testGraph4, 1, 10));
            Assert.AreEqual(-1, ff.GetMaxFlow(testGraph4, 21, 7));
            Assert.AreEqual(-1, ff.GetMaxFlow(testGraph4, -123, 7));
            Assert.AreEqual(-1, ff.GetMaxFlow(testGraph4, 0, -123));
            Assert.AreEqual(-1, ff.GetMaxFlow(testGraph4, -12, 123));

            // Test on task3 figure 3 graph
            //https://skr.sh/sE67Js14hDW
            Assert.AreEqual(15, ff.GetMaxFlow(taskGraph, 0, 14));
            //https://skr.sh/sE6Re8KVjxo
            Assert.AreEqual(13, ff.GetMaxFlow(taskGraph, 0, 15));
            //https://skr.sh/sE6idvZScxy
            Assert.AreEqual(12, ff.GetMaxFlow(taskGraph, 1, 14));
            //https://skr.sh/sE67JRg240U
            Assert.AreEqual(12, ff.GetMaxFlow(taskGraph, 1, 15));
        }

        [Test]
        public void DinicTest()
        {
            int[,] testGraph1 = new int[,] {
            { 0, 10, 10, 0, 10, 0 },
            { 0, 0, 0, 10, 0, 0 },
            { 0, 0, 0, 10, 0, 0 },
            { 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 10 },
            { 0, 0, 0, 10, 0, 0 }
            }; //connected graph
            int[,] testGraph2 = new int[,] {
            { 0, 7, 7, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 7, 0, 0, 0, 0 },
            { 0, 0, 0, 7, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 7, 7, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 7 },
            { 0, 0, 0, 0, 0, 0, 0, 7 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            }; //disconnected graph
            int[,] testGraph3 = new int[,] {
            { 0, 7, 7, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 7, 0, 0, 0, 0 },
            { 0, 0, 0, 7, 0, 0, 0, 0 },
            }; //wrong graph
            int[,] testGraph4 = new int[,] {
            { 0, 7, 7, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 7, 0, 4, 0, 0 },
            { 0, 0, 0, 7, 0, 0, 0, 0 },
            { 1, 0, 3, 0, 0, 0, 6, 0 },
            { 0, 0, 0, 0, 0, 7, 7, 0 },
            { 0, 6, 5, 0, 0, 0, 0, 7 },
            { 0, 0, 0, 0, 0, 7, 0, 7 },
            { 0, 0, 6, 0, 5, 0, 0, 0 },
            }; //default connected graph

                                         //DFS test

            Dinic dinicDFSTest = new Dinic(testGraph1);
            Assert.AreEqual(0, dinicDFSTest.DFS(0, 3, int.MaxValue));
            Assert.AreEqual(0, dinicDFSTest.DFS(0, 3, 5));
            Assert.AreEqual(0, dinicDFSTest.DFS(0, 3, 0));
            Assert.AreEqual(0, dinicDFSTest.DFS(2, 0, 122));
            Assert.AreEqual(0, dinicDFSTest.DFS(1, 3, 2));

                                        //AddEdge test

            Dinic dinicAddEdgeTest = new Dinic(3);
            Assert.That(dinicAddEdgeTest.AddEdge(0, 1, 10));
            Assert.That(!dinicAddEdgeTest.AddEdge(-12, 132, 01));

                                        //Test on graphs

            int flow = default;

            // Simple connected graph
            Dinic dinicTest1 = new Dinic(testGraph1);
            flow = dinicTest1.MaxFlow(0, 3);
            Assert.AreEqual(30, flow);

            // Simple disconnected graph, source and sink in one component
            Dinic dinicTest2 = new Dinic(testGraph2);
            flow = dinicTest2.MaxFlow(0, 3);
            Assert.AreEqual(14, flow);

            // Simple disconnected graph, source and sink in different components
            Dinic dinicTest3 = new Dinic(testGraph2);
            flow = dinicTest3.MaxFlow(0, 7);
            Assert.AreEqual(0, flow);

            // Not suitable matrix graph
            Dinic dinicTest4 = new Dinic(testGraph3);
            flow = dinicTest4.MaxFlow(0, 2);
            Assert.AreEqual(-1, flow);

            // Source / sink not exist in graph 
            Dinic dinicTest5 = new Dinic(testGraph4);
            Assert.AreEqual(-1, dinicTest5.MaxFlow(1, 10));
            Assert.AreEqual(-1, dinicTest5.MaxFlow(21, 7));
            Assert.AreEqual(-1, dinicTest5.MaxFlow(-123, 7));
            Assert.AreEqual(-1, dinicTest5.MaxFlow(0, -123));
            Assert.AreEqual(-1, dinicTest5.MaxFlow(-12, 123));
        }

        [Test]
        public void EdmondKarpTest()
        {

            int[,] testGraph1 = new int[,] {
            { 0, 10, 10, 0, 10, 0 },
            { 0, 0, 0, 10, 0, 0 },
            { 0, 0, 0, 10, 0, 0 },
            { 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 10 },
            { 0, 0, 0, 10, 0, 0 }
            }; //connected graph
            int[,] testGraph2 = new int[,] {
            { 0, 7, 7, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 7, 0, 0, 0, 0 },
            { 0, 0, 0, 7, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 7, 7, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 7 },
            { 0, 0, 0, 0, 0, 0, 0, 7 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            }; //disconnected graph
            int[,] testGraph3 = new int[,] {
            { 0, 7, 7, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 7, 0, 0, 0, 0 },
            { 0, 0, 0, 7, 0, 0, 0, 0 },
            }; //wrong graph
            int[,] testGraph4 = new int[,] {
            { 0, 7, 7, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 7, 0, 4, 0, 0 },
            { 0, 0, 0, 7, 0, 0, 0, 0 },
            { 1, 0, 3, 0, 0, 0, 6, 0 },
            { 0, 0, 0, 0, 0, 7, 7, 0 },
            { 0, 6, 5, 0, 0, 0, 0, 7 },
            { 0, 0, 0, 0, 0, 7, 0, 7 },
            { 0, 0, 6, 0, 5, 0, 0, 0 },
            }; //default connected graph


            //AddEdge test

            EdmondKarp ekAddEdgeTest = new EdmondKarp(3);
            Assert.That(ekAddEdgeTest.AddEdge(0, 1, 10));
            Assert.That(!ekAddEdgeTest.AddEdge(-12, 132, 01));

                                        //Test on graphs

            int flow = default;

            // Simple connected graph
            EdmondKarp ekTest1 = new EdmondKarp(testGraph1);
            flow = ekTest1.GetMaxFlow(0, 3);
            Assert.AreEqual(30, flow);

            // Simple disconnected graph, source and sink in one component
            EdmondKarp ekTest2 = new EdmondKarp(testGraph2);
            flow = ekTest2.GetMaxFlow(0, 3);
            Assert.AreEqual(14, flow);

            // Simple disconnected graph, source and sink in different components
            EdmondKarp ekTest3 = new EdmondKarp(testGraph2);
            flow = ekTest3.GetMaxFlow(0, 7);
            Assert.AreEqual(0, flow);

            // Not suitable matrix graph
            EdmondKarp ekTest4 = new EdmondKarp(testGraph3);
            flow = ekTest4.GetMaxFlow(0, 2);
            Assert.AreEqual(-1, flow);

            // Source / sink not exist in graph 
            EdmondKarp ekTest5 = new EdmondKarp(testGraph4);
            Assert.AreEqual(-1, ekTest5.GetMaxFlow(1, 10));
            Assert.AreEqual(-1, ekTest5.GetMaxFlow(21, 7));
            Assert.AreEqual(-1, ekTest5.GetMaxFlow(-123, 7));
            Assert.AreEqual(-1, ekTest5.GetMaxFlow(0, -123));
            Assert.AreEqual(-1, ekTest5.GetMaxFlow(-12, 123));
        }

        [Test]
        public void ScalingFlowTest()
        {
            int[,] testGraph1 = new int[,] {
            { 0, 2, 4, 8, 0, 0 },
            { 0, 0, 0, 9, 0, 0 },
            { 0, 0, 0, 0, 10, 0 },
            { 0, 0, 6, 0, 10, 0 },
            { 0, 0, 0, 0, 0, 0 },
            { 10, 10, 0, 0, 0, 0 }
            }; //connected graph
            int[,] testGraph2 = new int[,] {
            { 0, 7, 7, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 7, 0, 0, 0, 0 },
            { 0, 0, 0, 7, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 7, 7, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 7 },
            { 0, 0, 0, 0, 0, 0, 0, 7 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            }; //disconnected graph
            int[,] testGraph3 = new int[,] {
            { 0, 7, 7, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 7, 0, 0, 0, 0 },
            { 0, 0, 0, 7, 0, 0, 0, 0 },
            }; //wrong graph
            int[,] testGraph4 = new int[,] {
            { 0, 7, 7, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 7, 0, 4, 0, 0 },
            { 0, 0, 0, 7, 0, 0, 0, 0 },
            { 1, 0, 3, 0, 0, 0, 6, 0 },
            { 0, 0, 0, 0, 0, 7, 7, 0 },
            { 0, 6, 5, 0, 0, 0, 0, 7 },
            { 0, 0, 0, 0, 0, 7, 0, 7 },
            { 0, 0, 6, 0, 5, 0, 0, 0 },
            }; //default connected graph

                                    //DFS test

            ScalingFlow skDFSTest = new ScalingFlow(testGraph1);
            Assert.AreEqual(int.MaxValue, skDFSTest.DFS(0, int.MaxValue));
            Assert.AreEqual(0, skDFSTest.DFS(2, 5));
            Assert.AreEqual(0, skDFSTest.DFS(4, 0));
            Assert.AreEqual(122, skDFSTest.DFS(0, 122));

                                    //AddEdge test

            ScalingFlow skAddEdgeTest = new ScalingFlow(3);
            Assert.That(skAddEdgeTest.AddEdge(0, 1, 10));
            Assert.That(!skAddEdgeTest.AddEdge(-12, 132, 01));

                                    //Test on graphs

            int flow = default;

            // Simple connected graph
            ScalingFlow skTest1 = new ScalingFlow(testGraph1);
            flow = skTest1.GetMaxFlow(5, 4);
            Assert.AreEqual(16, flow);

            // Simple disconnected graph, source and sink in one component
            ScalingFlow skTest2 = new ScalingFlow(testGraph2);
            flow = skTest2.GetMaxFlow(0, 3);
            Assert.AreEqual(14, flow);

            // Simple disconnected graph, source and sink in different components
            ScalingFlow skTest3 = new ScalingFlow(testGraph2);
            flow = skTest3.GetMaxFlow(0, 7);
            Assert.AreEqual(0, flow);

            // Not suitable matrix graph
            ScalingFlow skTest4 = new ScalingFlow(testGraph3);
            flow = skTest4.GetMaxFlow(0, 2);
            Assert.AreEqual(-1, flow);

            // Source / sink not exist in graph 
            ScalingFlow skTest5 = new ScalingFlow(testGraph4);
            Assert.AreEqual(-1, skTest5.GetMaxFlow(1, 10));
            Assert.AreEqual(-1, skTest5.GetMaxFlow(21, 7));
            Assert.AreEqual(-1, skTest5.GetMaxFlow(-123, 7));
            Assert.AreEqual(-1, skTest5.GetMaxFlow(0, -123));
            Assert.AreEqual(-1, skTest5.GetMaxFlow(-12, 123));

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