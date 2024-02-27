using ClinicaMedica.Tratamentos;
using Xunit;

namespace ClinicaMedica.MongoDb.Domains.Tratamentos;

[Collection(ClinicaMedicaTestConsts.CollectionDefinitionName)]
public class MongoTratamentoManagerTests : TratamentoManagerTest<ClinicaMedicaMongoDbTestModule>
{
    
}