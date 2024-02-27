using System;
using ClinicaMedica.Medicos;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace ClinicaMedica.MongoDb.Medicos;

public class MedicoRepository : MongoDbRepository<ClinicaMedicaMongoDbContext, Medico, Guid>, IMedicoRepository
{
    public MedicoRepository(IMongoDbContextProvider<ClinicaMedicaMongoDbContext> dbContextProvider) : base(
        dbContextProvider)
    {
        
    }
}