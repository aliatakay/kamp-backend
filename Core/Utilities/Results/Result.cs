using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }
        public string Message { get; }

    }
}

// yalnızca get özelliğine sahip olan property'ler readonly'dir.
// yani herhangi bir değer set edilemez demektir.

// ancak readonly olan prop'lar sadece ve sadece constructor içinde set edilebilirler.
// biz de bu yöntemi kullanarak set işlemi yaptık.

// biz set de kleyebilirdik ancak programcıların kısıtlanması ve daha güzel bir yapı kurmak adına
// bu şekilde kodladık. Bu şekilde sadece bizim belirlediğimiz şekilde Result kullanılabilecek.