using System;
using ClinicaMedica.Tratamentos;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace ClinicaMedica.MongoDb.Tratamentos;

public class TratamentoRepository : MongoDbRepository<ClinicaMedicaMongoDbContext, Tratamento, Guid>, ITratamentoRepository
    {
        public TratamentoRepository(IMongoDbContextProvider<ClinicaMedicaMongoDbContext> dbContextProvider)
             : base(dbContextProvider)
        {
        }
}