using System;
using ClinicaMedica.Tratamentos;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace ClinicaMedica.MongoDB.Tratamentos;

public class TratamentoRepository : MongoDbRepository<ClinicaMedicaMongoDbContext, ClinicaMedica.Tratamentos.Tratamento, Guid>, ITratamentoRepository
    {
        public TratamentoRepository(IMongoDbContextProvider<ClinicaMedicaMongoDbContext> dbContextProvider)
             : base(dbContextProvider)
        {
        }
}