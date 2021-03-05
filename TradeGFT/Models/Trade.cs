using TradeGFT.Interfaces;

namespace TradeGFT.Models
{
    public class Trade : ITrade
    {
        public double Value { get; }
        public string ClientSector { get; }

        public Trade(double value, string clientSector)
        {
            Value = value;
            ClientSector = clientSector;
        }
    }
}
