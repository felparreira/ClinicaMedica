using System;
using System.Threading.Tasks;
using ClinicaMedica.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ClinicaMedica.Pacientes;

[Authorize]
public class PacientesAppService :
    CrudAppService<
        Paciente,
        PacienteDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdatePacienteDto>,
    IPacientesAppService
{
    public PacientesAppService(IRepository<Paciente, Guid> repository)
        : base(repository)
    {
        CreatePolicyName = ClinicaMedicaPermissions.Pacientes.Create;
        GetPolicyName = ClinicaMedicaPermissions.Pacientes.Get;
        GetListPolicyName = ClinicaMedicaPermissions.Pacientes.GetAll;
        UpdatePolicyName = ClinicaMedicaPermissions.Pacientes.Update;
        DeletePolicyName = ClinicaMedicaPermissions.Pacientes.Delete;
    }
}