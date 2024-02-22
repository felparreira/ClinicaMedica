using System;
using Volo.Abp.Domain.Repositories;

namespace ClinicaMedica.Tratamentos;

public interface ITratamentoRepository : IRepository<Tratamento, Guid>
{
    
}