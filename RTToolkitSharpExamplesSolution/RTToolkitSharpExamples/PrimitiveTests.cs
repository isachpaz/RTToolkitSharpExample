using System;
using System.Linq;
using RTToolkitSharp.RTQuantities.Helpers;
using RTToolkitSharp.RTQuantities.Quantities.Dose;
using Xunit;

namespace RTToolkitSharpExamples
{
    public class PrimitiveTests
    {
        [Fact]
        public void PhysicalDose_Addition_Test()
        {
            var dosis = RangeHelper<XDouble>.Range(0, 1000, 0.001).ToList();
            var xs = Enumerable.Range(1, dosis.Count);

            foreach (var t in dosis.Zip(xs, (d, i) => Tuple.Create(d.Value, i)))
            {
                var sum = PhysicalDoseValue.InGy(t.Item1 + t.Item2) + PhysicalDoseValue.InGy(t.Item2);
                var sum1 = PhysicalDoseValue.InGy(t.Item1 + 2 * t.Item2);
                Assert.Equal(sum, sum1);
            }
        }

        [Fact]
        public void PhysicalDose_Multiplication_Test()
        {
            var dosis = RangeHelper<XDouble>.Range(0, 2, 0.000001);
            var xs = Enumerable.Range(1, 100000000);

            foreach (var t in dosis.Zip(xs, (d, i) => Tuple.Create(d.Value, i)))
            {
                var sum = PhysicalDoseValue.InGy(t.Item1) * t.Item1;
                var sum1 = PhysicalDoseValue.InGy(Math.Round(t.Item1* t.Item1, 9));
                Assert.Equal(sum, sum1);
            }
        }

    }
}