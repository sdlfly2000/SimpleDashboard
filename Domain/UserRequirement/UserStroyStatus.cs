using System.Numerics;

namespace Domain.UserRequirement
{
    public struct UserStroyStatus
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

        public UserStroyStatus(string status)
        {
            Status = status;
        }

        public static explicit operator UserStroyStatus(string status)
        {
            return new UserStroyStatus(status);
        }

        public static UserStroyStatus Parse(string status)
        {
            return new UserStroyStatus(status);
        }

        public static UserStroyStatus Initial => new UserStroyStatus(Code.Initial);

        public static UserStroyStatus InProgress => new UserStroyStatus(Code.InPrgress);

        public static UserStroyStatus Complete => new UserStroyStatus(Code.Complete);

        public static UserStroyStatus Abort => new UserStroyStatus(Code.Abort);

        public override bool Equals(object? obj)
        {
            return obj != null
                ? Status.Equals(((UserStroyStatus)obj!).Status)
                : false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
