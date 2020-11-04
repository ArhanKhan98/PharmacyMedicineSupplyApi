using PharmacyMedicineSupplyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyMedicineSupplyApi.Service
{
    public interface IMedicineSupplyService
    {
        public List<PharmacyMedicineSupply> MedcineSupply(string medicine,int demand);
    }
}
