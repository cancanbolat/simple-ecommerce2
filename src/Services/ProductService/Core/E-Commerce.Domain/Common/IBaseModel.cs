using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Common
{
    public interface IBaseModel
    {
    }

    public interface IBaseModel<out TKey> : IBaseModel
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; }
    }

}
