﻿using Aula.ApiDotnet6.Domain.Entities;
using Aula.ApiDotnet6.Domain.Repositories;
using Aula.ApiDotnet6.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Aula.ApiDotnet6.Infra.Data.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly ApplicationDbContext _db;

        public PurchaseRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Purchase> CreateAsync(Purchase purchase)
        {
            _db.Add(purchase);
            await _db.SaveChangesAsync();
            return purchase;
        }

        public async Task DeleteAsync(Purchase purchase)
        {
            _db.Remove(purchase);
            await _db.SaveChangesAsync();
        }

        public async Task EditAsync(Purchase purchase)
        {
            _db.Update(purchase);
            await _db.SaveChangesAsync();
        }
        public async Task<ICollection<Purchase>> GetAllAsync()
        {
            return await _db.Purchases
                            .Include(x => x.Person)
                            .Include(x => x.Product)
                            .ToListAsync();
        }

        public async Task<Purchase> GetByIdAsync(int id)
        {
            var purshase = await _db.Purchases
                            .Include(x => x.Person)
                            .Include(x => x.Product)
                            .FirstOrDefaultAsync(x => x.Id == id);
#pragma warning disable CS8603 // Possible null reference return.
            return purshase;
#pragma warning restore CS8603 // Possible null reference return.

        }

        public async Task<ICollection<Purchase>> GetByPersonIdAsync(int personId)
        {
            return await _db.Purchases
                            .Include(x => x.Person)
                            .Include(x => x.Product)
                            .Where(x => x.PersonId == personId).ToListAsync();

        }

        public async Task<ICollection<Purchase>> GetByProductIdAsync(int productId)
        {
            return await _db.Purchases
                            .Include(x => x.Person)
                            .Include(x => x.Product)
                            .Where(x => x.ProductId == productId).ToListAsync();


        }

        
    }
}

