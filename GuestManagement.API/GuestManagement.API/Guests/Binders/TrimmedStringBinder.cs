using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GuestManagement.API.Guests.Binders
{
    public class TrimmedStringBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if(bindingContext == null)
            throw new ArgumentNullException();

           string value = bindingContext.ValueProvider.GetValue("email").FirstValue;

           string trimmedValue = value.Trim();

           bindingContext.Result = ModelBindingResult.Success(trimmedValue);

           return Task.CompletedTask;

        }
    }
}