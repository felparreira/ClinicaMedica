using Volo.Abp.ExceptionHandling;

namespace ClinicaMedica.Exceptions;

public class ExceptionConsts : IHasErrorCode
{
    private const string Default = "Exception:";

    public struct TratamentoManager
    {
        public const string SintomaInexistente = $"{Default}404:Sintoma Inexistente";
        public const string MedicoInexistente = $"{Default}404:Medico Inexistente";
        public const string PacienteInexistente = $"{Default}404:Paciente Inexistente";
        public const string TratamentoInexistente = $"{Default}404:Tratamento Inexistente";
        public const string EspecialidadeNaoPermitida = $"{Default}404:EspecialidadeNaoPermitida";
    }


    public string? Code { get; }
}