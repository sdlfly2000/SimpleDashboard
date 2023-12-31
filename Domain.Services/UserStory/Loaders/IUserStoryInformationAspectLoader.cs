﻿using Domain.User;
using Domain.UserStory;

namespace Domain.Services.UserStory.Loaders
{
    public interface IUserStoryInformationAspectLoader
    {
        IUserStoryInformationAspect Load(UserStoryReference Id);

        IList<IUserStoryInformationAspect> LoadByOwner(UserReference owner);
    }
}
