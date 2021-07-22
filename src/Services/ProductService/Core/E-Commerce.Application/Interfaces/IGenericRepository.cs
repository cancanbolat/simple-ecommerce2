using E_Commerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Interfaces
{
    public interface IGenericRepository<T, TKey> : IMainRepository<T, TKey>
        where T : BaseModel
        where TKey : IEquatable<TKey>
    {
    }
}
