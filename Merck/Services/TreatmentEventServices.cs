using Merck.Interfaces.Repositories;
using Merck.Models;
using Merck.Repositories;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace Merck.Services
{
    public class TreatmentEventServices
    {
        private readonly ITreatmentEventRepository _treatmentEventRepo;
        public TreatmentEventServices(ITreatmentEventRepository treatmentEventRepo)
        {
            _treatmentEventRepo = treatmentEventRepo;
        }   

        public List<TreatmentEvent> GetAllTreatmentEvent()
        {
            return _treatmentEventRepo.Get();
        }
    }
}
