using ClinicaMedica.Samples;
using Xunit;

namespace ClinicaMedica.MongoDb.Domains;

[Collection(ClinicaMedicaTestConsts.CollectionDefinitionName)]
public class MongoDBSampleDomainTests : SampleDomainTests<ClinicaMedicaMongoDbTestModule>
{

}
