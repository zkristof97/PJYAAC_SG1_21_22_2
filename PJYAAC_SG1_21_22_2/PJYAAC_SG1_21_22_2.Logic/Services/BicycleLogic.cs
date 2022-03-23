using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PJYAAC_SG1_21_22_2.Logic.Interfaces;
using PJYAAC_SG1_21_22_2.Models.Entities;
using PJYAAC_SG1_21_22_2.Repository.DbContexts;
using PJYAAC_SG1_21_22_2.Repository.Interfaces;

namespace PJYAAC_SG1_21_22_2.Logic.Services
{
    public class BicycleLogic : IBicycleLogic
    {
        private readonly IBicycleRepository _bicycleRepository;
        private readonly BicycleAppDbContext _dbContext;

        public BicycleLogic(IBicycleRepository bicycleRepository, BicycleAppDbContext dbContext)
        {
            _bicycleRepository = bicycleRepository;
            _dbContext = dbContext;
        }

        private int BicycleIdWithSameModel(Bicycle entity)
        {
            var allBikes = ReadAll();

            var existingBike = allBikes.First((bicycle) => bicycle.Model == entity.Model);

            if(existingBike != null)
            {
                _dbContext.Entry(existingBike).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                return existingBike.Id;
            }

            return 0;
        }
        public IList<Bicycle> ReadAll()
        {
            return _bicycleRepository.ReadAll().ToList();
        }

        public Bicycle Read(int id)
        {
            return _bicycleRepository.Read(id);
        }

        public Bicycle Create(Bicycle entity)
        {
            if(BicycleIdWithSameModel(entity) != 0)
            {
                throw new Exception("A bicycle with this modell already exists!");
            }

            var result = _bicycleRepository.Create(entity);

            return result;
        }

        public Bicycle Update(Bicycle entity)
        {
            // TODO check access

            var bicycleId = BicycleIdWithSameModel(entity);
            if (bicycleId != entity.Id)
            {
                throw new Exception("A bicycle with this modell already exists!");
            }

            var result = _bicycleRepository.Update(entity);

            return result;
        }

        public void Delete(int id)
        {
            _bicycleRepository.Delete(id);
        }
    }
}
