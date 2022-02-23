using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PJYAAC_SG1_21_22_2.Models.Entities;
using PJYAAC_SG1_21_22_2.Repository.DbContexts;
using PJYAAC_SG1_21_22_2.Repository.Interfaces;

namespace PJYAAC_SG1_21_22_2.Repository.Repositories
{
    public class BicycleRepository: RepositoryBase<Bicycle, int>, IBicycleRepository
    {
        public BicycleRepository(BicycleAppDbContext context) : base(context)
        {
            
        }

        public override Bicycle Read(int id)
        {
            return ReadAll().SingleOrDefault(x => x.Id == id);
        }
    }
}
