namespace ClinicaMedica.Permissions;

public sealed class ClinicaMedicaPermissions
{
    public const string GroupName = "ClinicaMedica";
    
    public struct Pacientes
    {
        public const string Default = GroupName + ".Pacientes";
        public const string Create = Default + ".CriarPacientes";
        public const string Update = Default + ".AtualizarPacientes";
        public const string Get = Default + ".ListarPacientes";
        public const string GetAll = Default + ".ListarTodosPacientes";
        public const string Delete = Default + ".DeletarPacientes";
    }
    public struct Medicos
    {
        public const string Default = GroupName + ".Medicos";
        public const string Create = Default + ".CriarMedicos";
        public const string Update = Default + ".AtualizarMedicos";
        public const string Get = Default + ".ListarMedicos";
        public const string GetAll = Default + ".ListarTodosMedicos";
        public const string Delete = Default + ".DeletarMedicos";
    } 
    public struct Tratamentos
    {
        public const string Default = GroupName + ".Tratamentos";
        public const string Create = Default + ".CriarTratamentos";
        public const string Update = Default + ".AtualizarTratamentos";
        public const string Get = Default + ".ListarTratamentos";
        public const string GetAll = Default + ".ListarTodosTratamentos";
        public const string Delete = Default + ".DeletarTratamentos";
    }
}
