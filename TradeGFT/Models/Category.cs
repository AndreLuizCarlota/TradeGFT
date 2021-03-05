using System;
using TradeGFT.Enums;

namespace TradeGFT.Models
{
    public class Category
    {
        public Guid Id { get; private set; }
        public Rules Rule { get; private set; }
        public string Sector { get; private set; }
        public double OfValue { get; private set; }
        public double UntilValue { get; private set; }

        public Category(Rules rule, double ofValue, double untilValue, string sector)
        {
            Id = Guid.NewGuid();

            Rule = rule;
            Sector = sector;
            OfValue = ofValue;
            UntilValue = untilValue;

            Validation();
        }

        private void Validation()
        {
            if (String.IsNullOrEmpty(Sector))
                throw new ArgumentException("`SECTOR` cannot be null or empty!");

            if (OfValue > UntilValue)
                throw new ArgumentException("`VALUE OF` cannot be greater than `VALUE UNTIL`!");
        }
    }
}
