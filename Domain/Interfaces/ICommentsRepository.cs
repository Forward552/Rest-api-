using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICommentsRepository
    {
        IEnumerable<Comments> GetAll();
        Comments GetById(int id);
        Comments Add(Comments comment);
        void Update(Comments comment);
        void Delete(int id);


    }
}
