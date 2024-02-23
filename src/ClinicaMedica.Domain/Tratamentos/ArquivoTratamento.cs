namespace ClinicaMedica.Tratamentos;

public class ArquivoTratamento
{
    public ArquivoTratamento(string nomeArquivo)
    {
        NomeArquivo = nomeArquivo;
    }

    public string NomeArquivo { get; set; }
}