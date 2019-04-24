using MC.ApplicationServices.DTOs;
using MC.Data.Contexts;
using MC.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MC.ApplicationServices.Implementations
{
    public class DirectorManagementService
    {
        #region Variables
        // _context
        private readonly MovieCatalogDbContext _context = new MovieCatalogDbContext();
        #endregion

        #region Methods
        // Get
        public List<DirectorDto> Get()
        {
            return _context
                .Directors
                .ToList()
                .Select(x => new DirectorDto(x))
                .ToList();
        }

        // GetById
        public DirectorDto GetById(int id)
        {
            return new DirectorDto(_context.Directors.ToList().FirstOrDefault(x => (x.Id == id)));
        }

        // GetByUsername
        public List<DirectorDto> GetByUsername(string username)
        {
            List<Director> directors = _context
                .Directors
                .Where(x => (x.Username == username))
                .ToList();

            return directors
                .Select(x => new DirectorDto(x))
                .ToList();
        }

        // GetByFirstName
        public List<DirectorDto> GetByFirstName(string fName)
        {
            List<Director> directors = _context
                .Directors
                .Where(x => x.FName == fName)
                .ToList();

            return directors
                .Select(x => new DirectorDto(x))
                .ToList();
        }

        // Save
        public int Save(DirectorDto directorDto)
        {
            try
            {
                Director director = new Director
                {
                    IsActive = directorDto.IsActive,
                    Username = directorDto.Username,
                    FName = directorDto.FName,
                    LName = directorDto.LName,
                    Description = directorDto.Description
                };

                _context.Directors.Add(director);
                _context.SaveChanges();

                return director.Id;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        // Delete
        public int Delete(int id)
        {
            try
            {
                Director director = _context.Directors.Find(id);

                if (director == null)
                {
                    return -1;
                }

                _context.Directors.Remove(director);
                _context.SaveChanges();

                return id;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        #endregion
    }
}