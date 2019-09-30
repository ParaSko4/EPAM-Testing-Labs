using NUnit.Framework;
using TriangleInequality;

namespace Tests
{
    public class TestsTriangleInequalityMethod
    {
        [Test]
        public void TestMethodWithZeroValue() { Assert.AreEqual(false, Program.TriangleInequalityMethod(0, 0, 0)); }

        [Test]
        public void TestMethodWithFloatingValue() { Assert.AreEqual(true, Program.TriangleInequalityMethod(3.2, 5.1, 4.6)); }

        [Test]
        public void TestMethodWithNegativeValue() { Assert.AreEqual(false, Program.TriangleInequalityMethod(-2, -1, -3)); }

        [Test]
        public void TestMethodFalseSolution() { Assert.AreEqual(false, Program.TriangleInequalityMethod(45, 37, 92)); }

        [Test]
        public void TestMethodTrueSolution() { Assert.AreEqual(true, Program.TriangleInequalityMethod(4, 2, 3)); }

        [Test]
        public void TestMethodWithSimilarValue() { Assert.AreEqual(true, Program.TriangleInequalityMethod(1, 1, 1)); }

        [Test]
        public void TestMethodWithTwoSimilarValue() { Assert.AreEqual(true, Program.TriangleInequalityMethod(45, 45, 50)); }

        [Test]
        public void TestMethodWithBigValue() { Assert.AreEqual(true, Program.TriangleInequalityMethod(14_613_351_435, 11_571_345_415, 12_742_671_432)); }

        [Test]
        public void TestMethodWithIntegerAndFloatingValue() { Assert.AreEqual(true, Program.TriangleInequalityMethod(12.5, 11, 10.2222)); }

        [Test]
        public void TestMethodWith—alculatedParameters() { Assert.AreEqual(true, Program.TriangleInequalityMethod((123 * 2), (77 * 3), (555.1243 / 3))); }
    }
}