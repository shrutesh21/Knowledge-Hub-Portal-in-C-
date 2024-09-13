using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using KnowledgeHubPortal.Domain.Entities;

namespace KnowledgeHubPortal.Domain.Repository
{
    public interface IArticlesRepository
    {
        void Submit(Article article);
        void Approve(List<int> ids);
        void Reject(List<int> ids);
        List<Article> GetArticleForBrowse(int cid = 0);
        List<Article> GetArticleForReview(int cid = 0);
    }
}
