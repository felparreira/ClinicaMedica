using System;
using System.Collections.Generic;
using ClinicaMedica.Tratamentos;
using Volo.Abp.Caching;

namespace ClinicaMedica.Tratamentos;

[CacheName(TratamentoCacheNames.TratamentoCacheItem)]

public class TratamentoCacheItem
{
    public Guid PacienteId { get; set; }
    
    public Guid MedicoId { get; set; }
    
    public List<string> Sintomas { get; set; }
    
    public string Diagnostico { get; set; }
    
    public StatusTratamento Status { get; set; }
}