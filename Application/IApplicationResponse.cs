﻿namespace Application
{
    public interface IApplicationResponse
    {
        public bool IsSuccess { get; }

        public IList<Exception> Exceptions { get; set; }

        public string TraceId { get; set; }
    }
}
