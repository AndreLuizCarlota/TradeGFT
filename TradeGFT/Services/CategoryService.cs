using System.Linq;
using TradeGFT.Enums;
using TradeGFT.Models;
using TradeGFT.Interfaces;
using System.Collections.Generic;

namespace TradeGFT.Services
{
    public class CategoryService
    {
        public List<Category> Categories { get; private set; }

        public CategoryService(List<Category> categories)
        {
            Categories = categories;
        }
        
        public Rules GetTradeCategory(ITrade trade)
        {
            var tradeCategory = Categories.FirstOrDefault(c => trade.Value >= c.OfValue && trade.Value <= c.UntilValue && c.Sector == trade.ClientSector);
            return tradeCategory?.Rule ?? Rules.LOWRISK;
        }
    }
}
