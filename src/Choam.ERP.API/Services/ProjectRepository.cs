using Choam.ERP.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Choam.ERP.API.Services
{
    public class ProjectRepository : IProjectRepository, IDisposable
    {
        private ProjectContext context;

        public ProjectRepository(ProjectContext context)
        {
            this.context = context;
        }

        public void AddProject(Project project)
        {
            this.context.Projects.Add(project);
        }

        public void DeleteProject(Project project)
        {
            this.context.Remove(project);
        }

        public Project GetProject(Guid id)
        {
            return this.context.Projects.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Project> GetProjects()
        {
            return this.context.Projects
                .OrderBy(p => p.Name).ToList();
        }

        public bool IsProjectOwner(Guid id, string ownerId)
        {
            return this.context.Projects.Any(p => p.Id == id && p.OwnerId == ownerId);
        }

        public bool ProjectExists(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            return (this.context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                    this.context = null;
                }
            }
        }
    }
}