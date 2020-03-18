using CoffeeSlotMachine.Core.Contracts;
using CoffeeSlotMachine.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeSlotMachine.Persistence
{
    public class CoinRepository : ICoinRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CoinRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddCoin(int coin)
        {
            var dbCoin = _dbContext
                         .Coins
                         .SingleOrDefault(c => c.CoinValue == coin);

            if (dbCoin != null)
            {
                dbCoin.Amount++;
            }

            _dbContext.SaveChanges();
        }

        public Coin[] GetAllCoins() => _dbContext
                                        .Coins
                                        .ToArray();


        public void RemoveCoin(int coin)
        {
            var dbCoin = _dbContext
                         .Coins
                         .SingleOrDefault(c => c.CoinValue == coin);

            if (dbCoin != null)
            {
                dbCoin.Amount--;
            }

            _dbContext.SaveChanges();
        }
    }
}
