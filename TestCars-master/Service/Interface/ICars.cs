using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ICars
    {
        public Task EnterCar(string placa);
        public Task<List<Record>> GetPayStatuts();
        public Task UpgradeCarOficial(string placa);
        public Task UpgradeCarResident(string placa);
        public Task LeaveCar(string placa);


    }
}
