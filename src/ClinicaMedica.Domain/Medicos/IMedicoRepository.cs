using System;
using Volo.Abp.Domain.Repositories;

namespace ClinicaMedica.Medicos;

public interface IMedicoRepository : IRepository<Medico, Guid>
{
    
}