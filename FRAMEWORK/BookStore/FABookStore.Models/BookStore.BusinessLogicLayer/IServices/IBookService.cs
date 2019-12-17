using BookStore.BusinessLogicLayer.BaseServices;
using FA.BookStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogicLayer.IServices
{
    public interface IBookService : IBaseService<Book>
    {
    }
}
