using System;
using TradeGFT.Models;

namespace TradeGFT.Interfaces
{
    public interface ICategoryRepository
    {
        bool Remove(Guid id);
        void Add(Category category);
        bool Update(Category category);
    }
}
