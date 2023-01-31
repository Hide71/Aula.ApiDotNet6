using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.ApiDotnet6.Domain.Validations
{
    public  class DomainValidationException:Exception
    {
        public DomainValidationException(string error) : base(error)
        {

        }
        public static void When(bool hasError, string message)
        {
            if (hasError)
            {
                throw new DomainValidationException(message);
            }
        }
    }
}
