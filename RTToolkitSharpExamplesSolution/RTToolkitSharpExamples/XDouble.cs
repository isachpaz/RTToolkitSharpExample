using System;
using RTToolkitSharp.RTQuantities.Interfaces;

namespace RTToolkitSharpExamples
{
    internal struct XDouble : IQuantityCreation<XDouble>
    {
        public XDouble(double value)
        {
            Value = value;
        }
        public double Value { get; private set; }
        public double GetValue() => Value;
        public string GetUnit()=> String.Empty;
        public XDouble TNew(double value, string unit) => new XDouble(value);

        public static implicit operator XDouble(double dValue)
        {
            return new XDouble(dValue);
        }
    }
}