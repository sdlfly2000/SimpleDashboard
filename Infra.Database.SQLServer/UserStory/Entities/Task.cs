using System;
using System.Collections.Generic;

namespace Infra.Database.SQLServer.UserStory.Entities;

public partial class Task
{
    public long Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? OwnerId { get; set; }

    public DateTime? StartedOn { get; set; }

    public string? Status { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedById { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? CreatedById { get; set; }

    public long? UserStoryId { get; set; }

    public long? Period { get; set; }

    public virtual UserStoryInformation? UserStory { get; set; }
}
