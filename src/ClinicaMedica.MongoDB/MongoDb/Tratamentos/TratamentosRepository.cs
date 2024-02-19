using System;
using System.Linq;
using System.Threading.Tasks;
using ClinicaMedica.Tratamentos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace ClinicaMedica.MongoDB.Tratamentos

{
    public class TratamentosRepository : MongoDbRepository<ClinicaMedicaMongoDbContext, ClinicaMedica.Tratamentos.Tratamentos, Guid>
    {
        private readonly IRepository<Pacientes.Pacientes, Guid> _pacientesRepository;
        private readonly IRepository<Medicos.Medicos, Guid> _medicosRepository;

        public TratamentosRepository(IMongoDbContextProvider<ClinicaMedicaMongoDbContext> dbContextProvider,
            IRepository<Pacientes.Pacientes, Guid> pacientesRepository,
            IRepository<Medicos.Medicos, Guid> medicosRepository) : base(dbContextProvider)
        {
            _pacientesRepository = pacientesRepository;
            _medicosRepository = medicosRepository;
        }
    }
}