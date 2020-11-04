using PharmacyMedicineSupplyApi.Models;
using PharmacyMedicineSupplyApi.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyMedicineSupplyApi.Service
{
    public class MedicineSupplyService : IMedicineSupplyService
    {
        private ISupply supplyrepo;

        public MedicineSupplyService(ISupply supplyrepo)
        {
            this.supplyrepo = supplyrepo;
        }
        public List<PharmacyMedicineSupply> MedcineSupply(string medicine, int demand)
        {
            var medList = supplyrepo.GetSupplies(medicine, demand);
            return medList.Result.ToList();
        }
    }
}
