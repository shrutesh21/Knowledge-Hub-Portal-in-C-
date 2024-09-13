using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.Domain.Repository;
using konwledgeHubPortal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeHubPortal.Data
{
	public class MockCategoryRepo : ICatagoryRepository
	{
		public void Create(Catagory category)
		{
			throw new NotImplementedException();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public List<Catagory> GetAll()
		{
			return new List<Catagory>()
			{
				new Catagory {CatagoryId=111, Name="Test 1", Description="test 1"} ,
				 new Catagory {CatagoryId=222, Name="Test 2", Description="test 2"} ,
				  new Catagory {CatagoryId=333, Name="Test 3", Description="test 3"} ,
			};
		}

        public Task<List<Catagory>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Catagory GetById(int id)
		{
			throw new NotImplementedException();
		}

		public void Update(Catagory category)
		{
			throw new NotImplementedException();
		}
	}
}