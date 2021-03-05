using System;

namespace TradeGFT.Interfaces
{
    public interface ITrade
    {
        double Value { get; }
        string ClientSector { get; }
    }
}
