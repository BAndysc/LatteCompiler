using LatteBase;
using LatteBase.AST.Impl;
using NUnit.Framework;

namespace QuadruplesGenerator.Tests
{
    public class LocalValuesCounterTests
    {
        private ValueMaxCounter maxCounter;
        private LocalValuesCounter counter;

        [SetUp]
        public void Setup()
        {
            maxCounter = new ValueMaxCounter();
            counter = new LocalValuesCounter(maxCounter);
        }
        
        [Test]
        public void TestEmptyNode()
        {
            Assert.AreEqual(0, counter.Visit(new EmptyNode(null)));
            Assert.AreEqual(0, maxCounter.Max);
            Assert.AreEqual(0, maxCounter.Value);
        }
        
        [Test]
        public void TestDeclarationNode()
        {
            Assert.AreEqual(2, counter.Visit(new DeclarationNode(null, LatteType.Void, new SingleDeclaration("a", null), new SingleDeclaration("b", null))));
            Assert.AreEqual(2, maxCounter.Max);
            Assert.AreEqual(2, maxCounter.Value);
        }
        
        
        [Test]
        public void TestIncrementDecrement()
        {
            Assert.AreEqual(0, counter.Visit(new DecrementNode(null, "a")));
            Assert.AreEqual(0, counter.Visit(new IncrementNode(null, "b")));
            Assert.AreEqual(0, maxCounter.Max);
            Assert.AreEqual(0, maxCounter.Value);
        }
        
        
        [Test]
        public void TestBlock()
        {
            var declaration = new DeclarationNode(null, LatteType.Bool, new SingleDeclaration("a", null));
            
            Assert.AreEqual(1, counter.Visit(declaration));
            
            Assert.AreEqual(0, counter.Visit(new BlockNode(null, declaration)));
            Assert.AreEqual(2, maxCounter.Max);
            Assert.AreEqual(1, maxCounter.Value);
        }

        [Test]
        public void TestComplex()
        {
//            int a;
//            {
//                int b;
//                int c;
//                {
//                    int d;
//                }
//                {
//                    int e;
//                }
//            }
//            int d;
//            {
//                int c;
//            }
            
            var declaration = new DeclarationNode(null, LatteType.Int, new SingleDeclaration("a", null));
            
            counter.Visit(declaration);
            
            Assert.AreEqual(1, maxCounter.Max);
            Assert.AreEqual(1, maxCounter.Value);
            
            var complexBlock = new BlockNode(null, declaration, declaration, new BlockNode(null, declaration), new BlockNode(null, declaration));

            counter.Visit(complexBlock);
            
            Assert.AreEqual(4, maxCounter.Max);
            Assert.AreEqual(1, maxCounter.Value);


            counter.Visit(declaration);
            
            Assert.AreEqual(4, maxCounter.Max);
            Assert.AreEqual(2, maxCounter.Value);
            
            counter.Visit(new BlockNode(null, declaration));
            
            Assert.AreEqual(4, maxCounter.Max);
            Assert.AreEqual(2, maxCounter.Value);
        }
    }
}