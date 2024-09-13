using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace konwledgeHubPortal.Data
{
    public class CatagoryRepository : ICatagoryRepository // client cannot access dbcontect object directly, so created this class
    {
        private KHPDbContext db = new KHPDbContext(); // Dependency Inversion Principle
        public void Create(Catagory catagory)
        {
            db.Catagories.Add(catagory);
            db.SaveChanges();
        }

        public List<Catagory> GetAll()
        {
            return db.Catagories.ToList();
        }

        public Catagory GetById(int id)
        {
            return db.Catagories.Find(id);
        }

        public void Update(Catagory catagory)
        {
            db.Catagories.Update(catagory);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
		    db.Catagories.Remove(db.Catagories.Find(id));
            db.SaveChanges();

		}

        public async Task<List<Catagory>> GetAllAsync()
        {
            return await db.Catagories.ToListAsync();
        }
    }
}
