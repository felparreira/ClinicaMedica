using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ClinicaMedica.Pacientes;

public class PacientesAppService :
    CrudAppService<
        Pacientes,
        PacientesDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdatePacientesDto>,
    IPacientesAppService
{
    public PacientesAppService(IRepository<Pacientes, Guid> repository)
        : base(repository)
    {
        
    }
}