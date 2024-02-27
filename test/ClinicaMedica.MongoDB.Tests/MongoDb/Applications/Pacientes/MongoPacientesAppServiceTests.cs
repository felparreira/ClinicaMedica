using ClinicaMedica.Pacientes;
using Xunit;

namespace ClinicaMedica.MongoDb.Applications.Pacientes;

[Collection(ClinicaMedicaTestConsts.CollectionDefinitionName)]
public class MongoPacientesAppServiceTests : PacienteAppServiceTest<ClinicaMedicaMongoDbTestModule>
{
    
}