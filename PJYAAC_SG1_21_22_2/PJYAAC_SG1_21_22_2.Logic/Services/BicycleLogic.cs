using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PJYAAC_SG1_21_22_2.Logic.Interfaces;
using PJYAAC_SG1_21_22_2.Models.Entities;
using PJYAAC_SG1_21_22_2.Repository.Interfaces;

namespace PJYAAC_SG1_21_22_2.Logic.Services
{
    public class BicycleLogic : IBicycleLogic
    {
        private readonly IBicycleRepository _bicycleRepository;

        public BicycleLogic(IBicycleRepository bicycleRepository)
        {
            _bicycleRepository = bicycleRepository;
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
            // TODO check access

            // TODO: validate !!!

            var result = _bicycleRepository.Create(entity);

            // TODO: log

            return result;
        }

        public Bicycle Update(Bicycle entity)
        {
            // TODO check access

            // TODO: validate !!!

            // TODO: map

            var result = _bicycleRepository.Update(entity);

            // TODO: log

            return result;
        }

        public void Delete(int id)
        {
            // TODO check access

            // TODO: check relations

            _bicycleRepository.Delete(id);
        }
    }
}
