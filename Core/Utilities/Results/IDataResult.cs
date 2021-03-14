using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }

    }
}

// Iresult'tan gelen success ve message yine var.
// buna ek olarak Data da döndürüyoruz.

// T için kısıtlama yazmıyoruz. Çünkü her şey olabilir.