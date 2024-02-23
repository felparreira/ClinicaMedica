using System;
using System.Threading.Tasks;
using ClinicaMedica.Tratamentos.Events.Eto;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;


namespace ClinicaMedica.Tratamentos.Events;

public class AtualizaStatusTratamentoEventHandler : ILocalEventHandler<AtualizaStatusTratamentoEto>, ITransientDependency

{
    private readonly ITratamentoRepository _tratamentoRepository;

    public AtualizaStatusTratamentoEventHandler(ITratamentoRepository tratamentoRepository)
    {
        _tratamentoRepository = tratamentoRepository;
    }

    public async Task HandleEventAsync(AtualizaStatusTratamentoEto eventData)
    {
        var tratamento  = await _tratamentoRepository.FindAsync(tratamento => tratamento.Id == eventData.Id);

        tratamento.Status = StatusTratamento.EmAndamento;
        
        await _tratamentoRepository.UpdateAsync(tratamento);
    }
    
}
