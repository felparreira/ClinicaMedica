using Volo.Abp.ExceptionHandling;

namespace ClinicaMedica.Exceptions;

public class ExceptionConsts : IHasErrorCode
{
    private const string Default = "Exception:";

    public struct TratamentoManager
    {
        public const string SintomaInexistente = $"{Default}404:SintomaInexistente";
        public const string MedicoInexistente = $"{Default}404:MedicoInexistente";
        public const string PacienteInexistente = $"{Default}404:PacienteInexistente";
        public const string TratamentoInexistente = $"{Default}404:TratamentoInexistente";
    }


    public string? Code { get; }
}