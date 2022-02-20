using AdaptItAcademy.BusinnessLogic.Abstract;
using AdaptItAcademy.DataAccess;
using AutoMapper;
using AdaptItAcademy.EFDataAccess.Models;
using AdaptItAcademy.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace AdaptItAcademy.BusinnessLogic.Data
{
    public class LookUpService : ILookUpService
    {
        private readonly ILookUpService _lookUpService;
        private readonly AdaptItAcademyContext _context;
        private readonly IMapper _mapper;

        public LookUpService(ILookUpService lookUpService, IMapper mapper)
        {
            _lookUpService = lookUpService;
            _mapper = mapper;
        }
            #region Dietary
            //Dietary
            //Get all
            public IEnumerable<DietaryRequirementsDto> GetAllDietary()
            {
                var records = _context.LUT_DietaryRequirements.ToList();
                var results = _mapper.Map<IEnumerable<DietaryRequirementsDto>>(records);
                return results;
            }

            //Get by Id
            public DietaryRequirementsDto GetDietById(int Id)
            {
                var record = _context.LUT_DietaryRequirements.AsNoTracking().Where(x => x.Id == Id).FirstOrDefault();
                var result = _mapper.Map<DietaryRequirementsDto>(record);
                return result;
            }

            //Delete
            public void DeleteDiet(int Id)
            {
                var record = GetDietById(Id);
                if (record != null)
                {
                    var result = _mapper.Map<LUT_DietaryRequirement>(record);
                    _context.LUT_DietaryRequirements.Remove(result);
                    _context.SaveChanges();
                }
            }
            //Insert
            public DietaryRequirementsDto InsertDiet(DietaryRequirementsDto dietDto)
            {
                try
                {
                    DietaryRequirementsDto diet = new DietaryRequirementsDto();
                    var record = _context.LUT_DietaryRequirements.Where(x => x.Name == dietDto.Name).FirstOrDefault();
                    if (record == null)
                    {
                        var result = _mapper.Map<LUT_DietaryRequirement>(dietDto);
                        _context.LUT_DietaryRequirements.Add(result);
                        _context.SaveChanges();
                        diet = _mapper.Map<DietaryRequirementsDto>(result);

                        return diet;
                    }
                    else
                    {
                        return diet;
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

            //Update
            public DietaryRequirementsDto UpdateDiet(DietaryRequirementsDto dietDto)
            {
                DietaryRequirementsDto diet = new DietaryRequirementsDto();
                var record = GetDietById(dietDto.Id);
                if (record != null)
                {
                    var result = _mapper.Map<LUT_DietaryRequirement>(dietDto);
                    _context.LUT_DietaryRequirements.Update(result);
                    _context.SaveChanges();

                    diet = _mapper.Map<DietaryRequirementsDto>(result);

                    return diet;
                }
                else
                {
                    return diet;
                }

            }
            #endregion
        }
    }
