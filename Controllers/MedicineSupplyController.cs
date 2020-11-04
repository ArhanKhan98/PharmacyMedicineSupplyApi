using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyMedicineSupplyApi.Models;
using PharmacyMedicineSupplyApi.Respository;
using PharmacyMedicineSupplyApi.Service;

namespace PharmacyMedicineSupplyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class MedicineSupplyController : ControllerBase
    {
        /*
        private List<MedicineDemand> demands = new List<MedicineDemand>() {
        new MedicineDemand{Medicine="A",Demand=100 },
        new MedicineDemand{Medicine="B",Demand=200 },
        new MedicineDemand{Medicine="C",Demand=150 },
        new MedicineDemand{Medicine="D",Demand=400 }
        };*/
        private IMedicineSupplyService medicineRepo;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(MedicineSupplyController));
        public MedicineSupplyController(IMedicineSupplyService medcineRepo)
        {
            this.medicineRepo = medcineRepo;
        }
        
        //[Route("GetSupplies/{medicine}/{demand}")]
        // public IActionResult GetSupplies(string medicine,int demand)

        /*[HttpGet]
        [Route("GetSupplies")]
        public IActionResult GetSupplies(List<MedicineDemand> demands)
        {
            try
            {
                var supplylist = supplyrepo.GetSupplies(demands);
                if(supplylist!=null)
                {
                    return Ok(supplylist);
                }
                return BadRequest("Some Error While fetching request");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }*/

        [HttpGet]
        [Route("GetSupplies/{medicineName}/{count}")]
        public IActionResult GetSupplies(string medicineName,int count)
        {
            _log4net.Info(" Http GetSupplies request Initiated");
            if (medicineName==""||count==0)
            {
                _log4net.Error("Null values passed to GetSupplies Method");
                return BadRequest("Please provide some values");
            }
            try
            {
                var supplylist = medicineRepo.MedcineSupply(medicineName, count);
                if (supplylist != null)
                {
                    return Ok(supplylist);
                }
                return BadRequest("Some Error While fetching request");
            }
            catch (Exception e)
            {
                _log4net.Error(" Http GetSupplies encountered an Excpetion :"+e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}