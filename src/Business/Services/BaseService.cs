using Business.Interface;
using Business.Models;
using Business.Notifications;
using FluentValidation;
using FluentValidation.Results;
using System;

namespace Business.Services
{
    public class BaseService
    {
        private readonly IBroadcaster _broadcaster;

        protected BaseService(IBroadcaster broadcaster)
        {
            _broadcaster = broadcaster;

        }
        protected bool ExecuteValidations<TV,TM>(TV validation, TM model)
            where TV : AbstractValidator<TM> 
            where TM : Entity 
        {
          var result =  validation.Validate(model);
            if (result.IsValid) return true;

            Notify(result);
            return false;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }

        protected void Notify(string errorMessage)
        {
            _broadcaster.ToTransmit(new Notification(errorMessage));
        }
    }
}
