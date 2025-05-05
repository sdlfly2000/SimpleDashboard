dotnet ef dbcontext scaffold `
"server=homeserver2;database=SimpleDashboard;uid=sdlfly2000;password=sdl@1215;TrustServerCertificate=True" "Microsoft.EntityFrameworkCore.SqlServer" `
--project ../Infra.Database.SQLServer.csproj `
--context UserStoryDbContext `
--context-dir ./UserStory/Context `
--output-dir ./UserStory/Entities `
--force `
`
--table dbo.UserStoryInformation `
--table dbo.UserRequirements `
--table dbo.Tasks