﻿using Domain.User;

namespace Domain.UserStory
{
    public interface ITaskAspect
    {
        public TaskReference Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public UserReference Owner { get; set; }
        public DateTime StartedOn { get; set; }
        public TimeSpan Period { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime ModifiedOn { get; set; }
        public UserReference ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public UserReference CreatedBy { get; set; }
    }
}
