using Database;
using Database.Models;
using Service.Interface;

namespace Service.Service
{
    public class Crud: ICars
    {
        private readonly ParkinDbContext _dbContext;

        public Crud(ParkinDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task EnterCar(string placa)
        {
            var datacar = new Cars
            {
                Placa = placa,
                enterCar = DateTime.Now,
                rol = "Invitado",
                leaveCar = DateTime.Now,
                
            };
            _dbContext.Cars.Add(datacar);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<Record>> GetPayStatuts() 
        {
            var cars = _dbContext.Records.ToList();
            return cars;
        }
        public async Task UpgradeCarOficial(string placa) 
        {
            var car = _dbContext.Cars.FirstOrDefault(c => c.Placa == placa);

            car.rol = "Oficial";
            _dbContext.SaveChanges();
        }
        public async Task UpgradeCarResident(string placa)
        {
            var car = _dbContext.Cars.FirstOrDefault(c => c.Placa == placa);

            car.rol = "Residente";
            _dbContext.SaveChanges();
        }

        public async Task LeaveCar(string placa)
        {
            var car = _dbContext.Cars.FirstOrDefault(c => c.Placa == placa);
            double totalPay = 0;
            // Calcular el tiempo en minutos
            TimeSpan tiempoEstacionado = DateTime.Now - car.enterCar;
            double minutosEstacionado = tiempoEstacionado.TotalMinutes;

            // Calcular el precio
             if (car.rol == "Invitado")
             {
               totalPay = 0.5 * minutosEstacionado;
               var record = new Record
               {
                Placa = placa,
                Importe = totalPay,
                CreatedAt = DateTime.Now,
               };
               _dbContext.Records.Add(record);
             }
             else if (car.rol == "Residente")
             {
               totalPay = 0.05 * minutosEstacionado;
               var record = new Record
               {
                Placa = placa,
                Importe = totalPay,
                CreatedAt = DateTime.Now,
               };
                _dbContext.Records.Add(record);
             }
             // Actualizar la propiedad leaveCar con la fecha y hora actual
             car.leaveCar = DateTime.Now;
              _dbContext.SaveChanges();
        }
    }
}
