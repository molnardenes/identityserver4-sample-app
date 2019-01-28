using Choam.ERP.API.Entities;
using System;
using System.Collections.Generic;

namespace Choam.ERP.API.Services
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetProjects();

        bool IsProjectOwner(Guid id, string ownerId);

        Project GetProject(Guid id);

        bool ProjectExists(Guid id);

        void AddProject(Project project);

        void DeleteProject(Project project);

        bool Save();
    }
}