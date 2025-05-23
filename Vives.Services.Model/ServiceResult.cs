﻿namespace Vives.Services.Model
{
    public class ServiceResult
    {

        public IList<ServiceMessage> Messages { get; set; } = new List<ServiceMessage>();

        public bool IsSucceeded => Messages.All(m => m.Type != ServiceMessageType.Error);
    }
}