using NUnit.Framework;
using TriangleInequality;

namespace Tests
{
    public class TestsTriangleInequalityMethod
    {
        [Test]
        public void WithZeroValue() { Assert.IsFalse(Program.IsTriangle(0, 0, 0)); }

        [Test]
        public void WithFloatingValue() { Assert.IsTrue(Program.IsTriangle(3.2, 5.1, 4.6)); }

        [Test]
        public void WithNegativeValue() { Assert.IsFalse(Program.IsTriangle(-2, -1, -3)); }

        [Test]
        public void FalseSolution() { Assert.IsFalse(Program.IsTriangle(45, 37, 92)); }

        [Test]
        public void TrueSolution() { Assert.IsTrue(Program.IsTriangle(4, 2, 3)); }

        [Test]
        public void WithSimilarValue() { Assert.IsTrue(Program.IsTriangle(1, 1, 1)); }

        [Test]
        public void WithTwoSimilarValue() { Assert.IsTrue(Program.IsTriangle(45, 45, 50)); }

        [Test]
        public void WithBigValue() { Assert.IsTrue(Program.IsTriangle(14_613_351_435, 11_571_345_415, 12_742_671_432)); }

        [Test]
        public void WithIntegerAndFloatingValue() { Assert.IsTrue(Program.IsTriangle(12.5, 11, 10.2222)); }

        [Test]
        public void With—alculatedParameters() { Assert.IsTrue(Program.IsTriangle((123 * 2), (77 * 3), (555.1243 / 3))); }
    }
}