using System;
using System.Linq;
using TradeGFT.Models;
using TradeGFT.Interfaces;
using System.Collections.Generic;

namespace TradeGFT.Repositories
{
    class CategoryRepository : ICategoryRepository
    {
        public List<Category> Categories { get; }

        public CategoryRepository()
        {
            Categories = new List<Category>();
        }

        public void Add(Category category)
        {
            Categories.Add(category);
        }

        public bool Update(Category category)
        {
            try
            {
                var row = Categories.FirstOrDefault(c => c.Id == category.Id);
                if (row == null)
                    return false;

                Categories.Remove(row);
                Categories.Add(category);

                return true;
            }
            catch (Exception ef)
            {
                Console.Write($"Problems updating the record: {ef.Message}");
                return false;
            }
        }

        public bool Remove(Guid id)
        {
            try
            {
                var category = Categories.FirstOrDefault(c => c.Id == id);
                if (category == null)
                    return false;

                Categories.Remove(category);
                return true;
            }
            catch (Exception ef)
            {
                Console.Write($"Problems remove the record: {ef.Message}");
                return false;
            }
        }
    }
}
