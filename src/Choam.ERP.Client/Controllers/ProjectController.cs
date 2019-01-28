using Choam.ERP.Client.Services;
using Choam.ERP.Client.ViewModels;
using Choam.ERP.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Choam.ERP.Client.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectHttpClient projectHttpClient;

        public ProjectController(IProjectHttpClient projectHttpClient)
        {
            this.projectHttpClient = projectHttpClient;
        }

        public async Task<IActionResult> Index()
        {

            var httpClient = await this.projectHttpClient.GetClient();

            var response = await httpClient.GetAsync("api/projects").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var projectAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                var projectIndexViewModel = new ProjectIndexViewModel(
                    JsonConvert.DeserializeObject<IList<Project>>(projectAsString).ToList());

                return View(projectIndexViewModel);
            }

            throw new Exception($"A problem happened while calling the API: {response.ReasonPhrase}");
        }

        public async Task<IActionResult> EditProject(Guid id)
        {
            // call the API
            var httpClient = await this.projectHttpClient.GetClient();

            var response = await httpClient.GetAsync($"api/projects/{id}").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var projectAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var deserializedProject = JsonConvert.DeserializeObject<Project>(projectAsString);

                var editProjectViewModel = new EditProjectViewModel()
                {
                    Id = deserializedProject.Id,
                    Name = deserializedProject.Name,
                    Revenue = deserializedProject.Revenue
                };

                return View(editProjectViewModel);
            }

            throw new Exception($"A problem happened while calling the API: {response.ReasonPhrase}");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProject(EditProjectViewModel editProjectViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var projectForUpdate = new ProjectForUpdate()
            { Name = editProjectViewModel.Name };

            var serializedProjectForUpdate = JsonConvert.SerializeObject(projectForUpdate);

            var httpClient = await this.projectHttpClient.GetClient();

            var response = await httpClient.PutAsync(
                $"api/projects/{editProjectViewModel.Id}",
                new StringContent(serializedProjectForUpdate, Encoding.Unicode, "application/json"))
                .ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            throw new Exception($"A problem happened while calling the API: {response.ReasonPhrase}");
        }

        public async Task<IActionResult> DeletProject(Guid id)
        {
            // call the API
            var httpClient = await this.projectHttpClient.GetClient();

            var response = await httpClient.DeleteAsync($"api/projects/{id}").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            throw new Exception($"A problem happened while calling the API: {response.ReasonPhrase}");
        }

        public IActionResult AddProject()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProject(AddProjectViewModel addProjectViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var projectForCreation = new ProjectForCreation()
            {
                Name = addProjectViewModel.Name,
                Revenue = addProjectViewModel.Revenue
            };

            var serializedProjectForCreation = JsonConvert.SerializeObject(projectForCreation);

            // call the API
            var httpClient = await this.projectHttpClient.GetClient();

            var response = await httpClient.PostAsync(
                $"api/projects",
                new StringContent(serializedProjectForCreation, Encoding.Unicode, "application/json"))
                .ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            throw new Exception($"A problem happened while calling the API: {response.ReasonPhrase}");
        }
    }
}
