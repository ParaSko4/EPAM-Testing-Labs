using NUnit.Framework;
using TriangleInequality;

namespace Tests
{
    public class TestsTriangleInequalityMethod
    {
        [Test]
        public void WithZeroValue() { Assert.IsFalse(Program.TriangleInequalityMethod(0, 0, 0)); }

        [Test]
        public void WithFloatingValue() { Assert.IsTrue(Program.TriangleInequalityMethod(3.2, 5.1, 4.6)); }

        [Test]
        public void WithNegativeValue() { Assert.IsFalse(Program.TriangleInequalityMethod(-2, -1, -3)); }

        [Test]
        public void FalseSolution() { Assert.IsFalse(Program.TriangleInequalityMethod(45, 37, 92)); }

        [Test]
        public void TrueSolution() { Assert.IsTrue(Program.TriangleInequalityMethod(4, 2, 3)); }

        [Test]
        public void WithSimilarValue() { Assert.IsTrue(Program.TriangleInequalityMethod(1, 1, 1)); }

        [Test]
        public void WithTwoSimilarValue() { Assert.IsTrue(Program.TriangleInequalityMethod(45, 45, 50)); }

        [Test]
        public void WithBigValue() { Assert.IsTrue(Program.TriangleInequalityMethod(14_613_351_435, 11_571_345_415, 12_742_671_432)); }

        [Test]
        public void WithIntegerAndFloatingValue() { Assert.IsTrue(Program.TriangleInequalityMethod(12.5, 11, 10.2222)); }

        [Test]
        public void With—alculatedParameters() { Assert.IsTrue(Program.TriangleInequalityMethod((123 * 2), (77 * 3), (555.1243 / 3))); }
    }
}