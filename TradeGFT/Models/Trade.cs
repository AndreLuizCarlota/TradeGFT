using TradeGFT.Interfaces;

namespace TradeGFT.Models
{
    public class Trade : ITrade
    {
        public double Value { get; }
        public string ClientSector { get; }
        public string Category { get; private set; }

        public Trade(double value, string clientSector)
        {
            Value = value;
            ClientSector = clientSector;

            // Set category by params
            SetCategory(this);
        }

        public void SetCategory(Trade trade)
        {
            Category = trade.Value switch
            {
                //LOWRISK: Trades with value less than 1,000,000 and client from Public Sector
                double n when (n < 1000.00 && trade.ClientSector == "Public") => "LOWRISK",
                //MEDIUMRISK: Trades with value greater than 1,000,000 and client from Public Sector
                double n when (n >= 1000.00 && trade.ClientSector == "Public") => "MEDIUMRISK",
                //HIGHRISK: Trades with value greater than 1,000,000 and client from Private Sector
                double n when (n >= 1000.00 && trade.ClientSector == "Private") => "HIGHRISK",
                _ => "LOWRISK"
            };
        }
    }
}
