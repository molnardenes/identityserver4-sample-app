using AutoMapper;
using Choam.ERP.API.Services;
using Choam.ERP.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Choam.ERP.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : Controller
    {
        private readonly IProjectRepository projectRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public ProjectsController(IProjectRepository projectRepository,
            IHostingEnvironment hostingEnvironment)
        {
            this.projectRepository = projectRepository;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet()]
        public IActionResult GetProjects()
        {
            // get from repo
            var projectsFromRepo = this.projectRepository.GetProjects();

            // map to model
            var projectsToReturn = Mapper.Map<IEnumerable<Model.Project>>(projectsFromRepo);

            // return
            return Ok(projectsToReturn);
        }

        [HttpGet("{id}", Name = "GetProject")]
        public IActionResult GetProject(Guid id)
        {
            var projectFromRepo = this.projectRepository.GetProject(id);

            if (projectFromRepo == null)
            {
                return NotFound();
            }

            var projectToReturn = Mapper.Map<Model.Project>(projectFromRepo);

            return Ok(projectFromRepo);
        }

        [HttpPost()]
        public IActionResult CreateProject([FromBody] ProjectForCreation projectForCreation)
        {
            if (projectForCreation == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            var projectEntity = Mapper.Map<Entities.Project>(projectForCreation);
            //projectEntity.OwnerId = ...;

            this.projectRepository.AddProject(projectEntity);

            if (!this.projectRepository.Save())
            {
                throw new Exception($"Adding an project failed on save.");
            }

            var projectToReturn = Mapper.Map<Project>(projectEntity);

            return CreatedAtRoute("GetProject",
                new { id = projectToReturn.Id },
                projectToReturn);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProject(Guid id)
        {
            var projectFromRepo = this.projectRepository.GetProject(id);

            if (projectFromRepo == null)
            {
                return NotFound();
            }

            this.projectRepository.DeleteProject(projectFromRepo);

            if (!this.projectRepository.Save())
            {
                throw new Exception($"Deleting project with {id} failed on save.");
            }

            return NoContent();
        }
    }
}