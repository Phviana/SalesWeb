using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int sellerId)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(x => x.Id == sellerId);
        }
       
        public void Remove(int sellerId)
        {
            var obj = _context.Seller.Find(sellerId);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
    }
}
