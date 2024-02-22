using System;
using ClinicaMedica.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ClinicaMedica.Medicos;

[Authorize]
public class MedicosAppService :
    CrudAppService<
        Medico,
        MedicoDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateMedicoDto>,
    IMedicoAppServices
{
    public MedicosAppService(IRepository<Medico, Guid> repository)
        : base(repository)
    {
        CreatePolicyName = ClinicaMedicaPermissions.Medicos.Create;
        GetPolicyName = ClinicaMedicaPermissions.Medicos.Get;
        GetListPolicyName = ClinicaMedicaPermissions.Medicos.GetAll;
        UpdatePolicyName = ClinicaMedicaPermissions.Medicos.Update;
    }
}