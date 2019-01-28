using Choam.ERP.Model;
using System.Collections.Generic;

namespace Choam.ERP.Client.ViewModels
{
    public class ProjectIndexViewModel
    {
        public IEnumerable<Project> Projects { get; private set; }
            = new List<Project>();

        public ProjectIndexViewModel(List<Project> projects)
        {
            Projects = projects;
        }
    }
}