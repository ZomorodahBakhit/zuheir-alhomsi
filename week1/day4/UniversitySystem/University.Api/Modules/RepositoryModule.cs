using Autofac;
using University.Data.Repositories.StudentRepositories;

namespace University.Api.Modules;

public class RepositoryModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(typeof(StudentRepository).Assembly)
              .Where(t => t.Name.EndsWith("Repository"))
              .AsImplementedInterfaces()
              .InstancePerLifetimeScope();
    }
}
