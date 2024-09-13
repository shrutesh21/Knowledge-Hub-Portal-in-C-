using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace konwledgeHubPortal.Data
{
    public class ArticlesRepository : IArticlesRepository
    {
        private KHPDbContext db = new KHPDbContext(); // this is good as KHDBDbContext is not having interfcae
        public void Approve(List<int> ids)
        {
            foreach (int id in ids)
            {
                var articleToApprove = db.Articles.Find(id);
                if (articleToApprove != null)
                {
                    articleToApprove.IsApproved = true;
                }
            }
            db.SaveChanges();
        }

        public List<Article> GetArticleForBrowse(int cid = 0)
        {
            if(cid == 0)
            {
                return db.Articles.Where(a => a.IsApproved).ToList();
            }
            else 
                return db.Articles.Where(a => a.IsApproved && a.CatagoryId == cid).ToList();

        }

        public List<Article> GetArticleForReview(int cid = 0)
        {
            if (cid == 0)
            {
                return db.Articles.Include(a => a.Catagory).Where(a => !a.IsApproved).ToList();
            }
            else
                return db.Articles.Include(a => a.Catagory).Where(a => a.IsApproved && a.CatagoryId == cid).ToList();

        }

        public void Reject(List<int> ids)
        {
            foreach (int id in ids)
            {
                var articleToReject = db.Articles.Find(id);
                if(articleToReject != null)
                {
                    db.Articles.Remove(articleToReject);
                }
            }
            db.SaveChanges();
        }

        public void Submit(Article article)
        {
            db.Articles.Add(article);
            db.SaveChanges();
        }
    }
}
