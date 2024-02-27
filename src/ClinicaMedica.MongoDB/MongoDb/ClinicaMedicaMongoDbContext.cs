using ClinicaMedica.Medicos;
using ClinicaMedica.Pacientes;
using ClinicaMedica.Tratamentos;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace ClinicaMedica.MongoDb;

[ConnectionStringName("Default")]
public class ClinicaMedicaMongoDbContext : AbpMongoDbContext
{
    
    public IMongoCollection<Paciente> Pacientes => Collection<Paciente>(); 
    
    public IMongoCollection<Medico> Medicos => Collection<Medico>(); 
    
    public IMongoCollection<Tratamento> Tratamentos => Collection<Tratamento>(); 

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        //modelBuilder.Entity<YourEntity>(b =>
        //{
        //    //...
        //});
    }
}
