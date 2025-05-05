using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vives.Services.Model.Extensions
{
    public static class ServiceResultExtensions

    {
        public static ServiceResult<T> NotFound<T>(this ServiceResult<T> serviceResult, string propertyName, ServiceMessageType  serviceMessageType = ServiceMessageType.Error)
            where T : class
        {
            var message = new ServiceMessage
            {
                Code = "NotFound",
                Message = $"Could not find person {propertyName}",
                Type = serviceMessageType
            };
            
            serviceResult.Messages.Add(message);
            return serviceResult;
        }

        public static ServiceResult NothingChanged(this ServiceResult serviceResult, ServiceMessageType serviceMessageType = ServiceMessageType.Warning)
        {
            var message = new ServiceMessage
            {
                Code = "NothingChanged",
                Message = "Nothing Changed.",
                Type = serviceMessageType
            };

            serviceResult.Messages.Add(message);

            return serviceResult;
        }
    }
}
