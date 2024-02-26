using System;
using System.Threading.Tasks;
using ClinicaMedica.Pacientes;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace ClinicaMedica;

public class ClinicaMedicaDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Paciente, Guid> _pacientesRepository;

    public ClinicaMedicaDataSeederContributor(IRepository<Paciente, Guid> pacientesRepository)
    {
        _pacientesRepository = pacientesRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _pacientesRepository.GetCountAsync() <= 0)
        {
            await _pacientesRepository.InsertAsync(
                new Paciente
                ( 
                    "Pedro Augusto",
                    "de Lima",
                    28,
                    Sexo.Masculino,
                    "(31)98934-2342"
                    )
                ,
                autoSave: true
            );
            await _pacientesRepository.InsertAsync(
                new Paciente
                (
                    "Fernanda",
                    "Pereira Souza",
                    15,
                    Sexo.Feminino,
                    "(31)96372-9856"
                ),
                autoSave: true
            );
        }
    }
}