using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace ClinicaMedica.Tratamentos;

public class TratamentosManager : DomainService
{
    private readonly IRepository<Pacientes.Pacientes, Guid> _pacientesRepository;
    private readonly IRepository<Medicos.Medicos, Guid> _medicosRepository;

    public TratamentosManager(
        IRepository<Pacientes.Pacientes, Guid> pacientesRepository,
        IRepository<Medicos.Medicos, Guid> medicosRepository)
    {
        _pacientesRepository = pacientesRepository;
        _medicosRepository = medicosRepository;
    }

    public async Task<Tratamentos> Create()
    {
        return null;
    }
}