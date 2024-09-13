using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowledgeHubPortal.Domain.Entities;

namespace KnowledgeHubPortal.Domain.Repository
{
    public interface ICatagoryRepository
    {
        void Create(Catagory catagory);
        void Update(Catagory catagory);

        List<Catagory> GetAll();
        Task<List<Catagory>> GetAllAsync();

        Catagory GetById(int id);
        void Delete(int id);
    }
}
