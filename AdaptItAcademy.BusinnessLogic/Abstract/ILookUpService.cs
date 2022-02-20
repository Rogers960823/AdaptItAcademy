using AdaptItAcademy.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdaptItAcademy.BusinnessLogic.Abstract
{
    public interface ILookUpService
    {
        IEnumerable<DietaryRequirementsDto> GetAllDietary();
        DietaryRequirementsDto GetDietById(int Id);
        void DeleteDiet(int Id);
        DietaryRequirementsDto InsertDiet(DietaryRequirementsDto dietDto);
        DietaryRequirementsDto UpdateDiet(DietaryRequirementsDto dietDto);
    }
}
