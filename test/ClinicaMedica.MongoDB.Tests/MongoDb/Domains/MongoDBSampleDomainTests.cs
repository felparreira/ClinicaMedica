using ClinicaMedica.Samples;
using Xunit;

namespace ClinicaMedica.MongoDB.Domains;

[Collection(ClinicaMedicaTestConsts.CollectionDefinitionName)]
public class MongoDBSampleDomainTests : SampleDomainTests<ClinicaMedicaMongoDbTestModule>
{

}
