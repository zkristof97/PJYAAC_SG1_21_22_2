using System;
using System.Collections.Generic;
using System.Text;
using PJYAAC_SG1_21_22_2.Models.Entities;

namespace PJYAAC_SG1_21_22_2.Logic.Interfaces
{
    public interface IBicycleLogic
    {
        IList<Bicycle> ReadAll();

        Bicycle Read(int id);

        Bicycle Create(Bicycle entity);

        Bicycle Update(Bicycle entity);

        void Delete(int id);
    }
}
