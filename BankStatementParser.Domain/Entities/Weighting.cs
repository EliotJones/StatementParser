namespace BankStatementParser.Domain.Entities
{
    using System;

    public struct Weighting
    {
        public int Value { get; private set; }

        public Weighting(int value)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentOutOfRangeException();
            }

            Value = value;
        }
    }
}
