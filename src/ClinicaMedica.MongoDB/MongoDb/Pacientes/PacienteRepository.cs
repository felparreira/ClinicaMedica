using System;
using ClinicaMedica.Pacientes;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace ClinicaMedica.MongoDb.Pacientes;

public class PacienteRepository : MongoDbRepository<ClinicaMedicaMongoDbContext, Paciente, Guid>, IPacienteRepository
{
public PacienteRepository(IMongoDbContextProvider<ClinicaMedicaMongoDbContext> dbContextProvider)
    : base(dbContextProvider)
{
}
}