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

            var existingBike = allBikes.FirstOrDefault((bicycle) => bicycle.Model == entity.Model);

            if(existingBike != null)
            {
                return existingBike.Id;
            }

            return 0;
        }

        private void RequiredValidator(Bicycle entity, string field)
        {
            var prop = typeof(Bicycle).GetProperty(field);
            var propType = prop.PropertyType;
            object value = prop.GetValue(entity);

            if (propType == typeof(string) && string.IsNullOrWhiteSpace(value as string) || propType == typeof(int) && (int)value <= 0)
            {
                throw new Exception($"{field} is a required field.");
            } 
        }

        private void StringLengthValidator(Bicycle entity, string field, int length = 50)
        {
            string value = typeof(Bicycle).GetProperty(field).GetValue(entity) as string;
            if (!string.IsNullOrWhiteSpace(value) && value.Length > length)
            {
                throw new Exception($"{field} cannot be longer than {length} characters.");
            }
        }

        private void ValidateFields(Bicycle entity)
        {
            RequiredValidator(entity, nameof(entity.Model));
            StringLengthValidator(entity, nameof(entity.Model));

            RequiredValidator(entity, nameof(entity.Type));
            StringLengthValidator(entity, nameof(entity.Type));

            RequiredValidator(entity, nameof(entity.Price));
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
            ValidateFields(entity);

            if (BicycleIdWithSameModel(entity) != 0)
            {
                throw new Exception("A bicycle with this model already exists!");
            }

            var result = _bicycleRepository.Create(entity);

            return result;
        }

        public Bicycle Update(Bicycle entity)
        {
            ValidateFields(entity);

            var bicycleId = BicycleIdWithSameModel(entity);
            if (bicycleId != 0 && bicycleId != entity.Id)
            {
                throw new Exception("A bicycle with this model already exists!");
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
