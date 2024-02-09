using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace ClinicaMedica.MongoDB;

[ConnectionStringName("Default")]
public class ClinicaMedicaMongoDbContext : AbpMongoDbContext
{
    
    public IMongoCollection<Pacientes.Pacientes> Pacientes => Collection<Pacientes.Pacientes>(); 
    
    public IMongoCollection<Medicos.Medicos> Medicos => Collection<Medicos.Medicos>(); 
    
    public IMongoCollection<Tratamentos.Tratamentos> Tratamentos => Collection<Tratamentos.Tratamentos>(); 

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        //modelBuilder.Entity<YourEntity>(b =>
        //{
        //    //...
        //});
    }
}
