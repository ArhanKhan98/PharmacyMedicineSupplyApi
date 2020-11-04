using PharmacyMedicineSupplyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyMedicineSupplyApi.Respository
{
    public interface ISupply
    {
        // public IEnumerable<PharmacyMedicineSupply> GetSupplies(List<MedicineDemand> demand);

        public Task<IEnumerable<PharmacyMedicineSupply>> GetSupplies(string med, int demand);
    }
}
