dotnet ef dbcontext scaffold `
"server=homeserver;database=SimpleDashboard;uid=sdlfly2000;password=sdl@1215;TrustServerCertificate=True" "Microsoft.EntityFrameworkCore.SqlServer" `
--project ../Infra.Database.SQLServer.csproj `
--context UserStoryDbContext `
--output-dir ./UserStory/Entities `
--force `
`
--table dbo.UserStoryInformation `
--table dbo.Tasks