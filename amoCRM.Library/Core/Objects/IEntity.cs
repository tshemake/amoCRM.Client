using System;
using System.Collections.Generic;
using System.Text;

namespace amoCRM.Library.Core.Objects
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
