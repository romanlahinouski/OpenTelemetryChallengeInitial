using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GuestManagement.Domain.Base
{
    ///<summary>Contract for business rule</summary>
    ///<typeparam name="T">Type is entity model</typeparam>
  public interface IBusinessRule<T> where T : class
    {
        public Task<ValidationResult> Validate(T entity);

        public string ReasonPhrase { get; }
    }
}
