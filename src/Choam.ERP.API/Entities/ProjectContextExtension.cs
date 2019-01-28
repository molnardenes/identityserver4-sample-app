using System;
using System.Collections.Generic;

namespace Choam.ERP.API.Entities
{
    public static class ProjectContextExtension
    {
        public static void Seed(this ProjectContext context)
        {
            context.Projects.RemoveRange(context.Projects);
            context.SaveChanges();

            var projects = new List<Project>()
            {
                new Project()
                {
                    Id = new Guid("8b79411d-e678-4c38-a5fe-c90f3b4d514e"),
                    Name = "Spacing Guilds Report",
                    Revenue = 32000000,
                    OwnerId = "14527f77-4682-48ec-99b6-037464a0a8dc"
                },
                new Project()
                {
                    Id = new Guid("6e06387d-f913-4b85-9af0-9d7796a2d516"),
                    Name = "Chirox development",
                    Revenue = 11000000,
                    OwnerId = "7d8ba357-cb82-4252-8f18-4d8b0591144d"
                },
                 new Project()
                {
                    Id = new Guid("27945c77-fece-4bb6-901f-96f9738937c7"),
                    Name = "Spice harvest methodology",
                    Revenue = 1400000,
                    OwnerId = "14527f77-4682-48ec-99b6-037464a0a8dc"
                },
                  new Project()
                {
                    Id = new Guid("5cc015c3-d02c-422a-b186-4e8b89278bae"),
                    Name = "Training of Topri",
                    Revenue = 6000000,
                    OwnerId = "14527f77-4682-48ec-99b6-037464a0a8dc"
                },
                   new Project()
                {
                    Id = new Guid("32e07220-7ae0-4312-a06d-2ec1b2746b84"),
                    Name = "Harvesting methodologies on Arrakis",
                    Revenue = 320000000,
                    OwnerId = "7d8ba357-cb82-4252-8f18-4d8b0591144d"
                },
                    new Project()
                {
                    Id = new Guid("7823a1a5-30b0-4b9c-b99b-fe578dc56951"),
                    Name = "Suk training",
                    Revenue = 16400000,
                    OwnerId = "7d8ba357-cb82-4252-8f18-4d8b0591144d"
                },
                     new Project()
                {
                    Id = new Guid("ff8b1c1c-fdc1-4384-af6b-c3c00de32a0e"),
                    Name = "Top secret project",
                    Revenue = 11000000,
                    OwnerId = "7d8ba357-cb82-4252-8f18-4d8b0591144d"
                },
                      new Project()
                {
                    Id = new Guid("65a9f1a4-3f68-4691-aabe-25f61a5af0e3"),
                    Name = "Secret side project",
                    Revenue = 11000000,
                    OwnerId = "14527f77-4682-48ec-99b6-037464a0a8dc"
                }
            };

            context.Projects.AddRange(projects);
            context.SaveChanges();
        }
    }
}