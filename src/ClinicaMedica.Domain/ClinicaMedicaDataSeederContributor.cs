using System;
using System.Threading.Tasks;
using ClinicaMedica.Pacientes;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace ClinicaMedica;

public class ClinicaMedicaDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Pacientes.Pacientes, Guid> _pacientesRepository;

    public ClinicaMedicaDataSeederContributor(IRepository<Pacientes.Pacientes, Guid> pacientesRepository)
    {
        _pacientesRepository = pacientesRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _pacientesRepository.GetCountAsync() <= 0)
        {
            await _pacientesRepository.InsertAsync(
                new Pacientes.Pacientes
                {
                    Nome = "Pedro Augusto de Lima",
                    Sexo = Sexo.Masculino,
                    DataNascimento = new DateTime(1989, 3, 28),
                    Telefone = "(31)98934-2342"
                },
                autoSave: true
            );
            await _pacientesRepository.InsertAsync(
                new Pacientes.Pacientes
                {
                    Nome = "Fernanda Pereira Souza",
                    Sexo = Sexo.Feminino,
                    DataNascimento = new DateTime(1992, 9, 3),
                    Telefone = "(31)96372-9856"
                },
                autoSave: true
            );
        }
    }
}