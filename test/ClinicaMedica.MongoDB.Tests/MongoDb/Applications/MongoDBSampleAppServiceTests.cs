using ClinicaMedica.MongoDB;
using ClinicaMedica.Samples;
using Xunit;

namespace ClinicaMedica.MongoDb.Applications;

[Collection(ClinicaMedicaTestConsts.CollectionDefinitionName)]
public class MongoDBSampleAppServiceTests : SampleAppServiceTests<ClinicaMedicaMongoDbTestModule>
{

}
