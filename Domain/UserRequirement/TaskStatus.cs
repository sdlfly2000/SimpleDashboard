namespace Domain.UserRequirement
{
    public struct TaskStatus
    {
        private readonly struct Code
        {
            public static readonly string Initial = "INITIAL";
            public static readonly string InPrgress = "INPROGRESS";
            public static readonly string Complete = "COMPLETE";
            public static readonly string Abort = "ABORT";
        }

        private readonly struct Description
        {
            public static readonly string Initial = "Initial";
            public static readonly string InPrgress = "InPrgress";
            public static readonly string Complete = "Complete";
            public static readonly string Abort = "Abort";
        }

        public string Status { get; }

        public TaskStatus(string status)
        {
            Status = status;
        }

        public static TaskStatus Parse(string status)
        {
            return new TaskStatus(status);
        }

        public static TaskStatus Initial => new TaskStatus(Code.Initial);

        public static TaskStatus InProgress => new TaskStatus(Code.InPrgress);

        public static TaskStatus Complete => new TaskStatus(Code.Complete);

        public static TaskStatus Abort => new TaskStatus(Code.Abort);

        public override bool Equals(object? obj)
        {
            return obj != null
                ? Status.Equals(((TaskStatus)obj!).Status)
                : false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
