using MC.ApplicationServices.DTOs;
using MC.Data.Contexts;
using MC.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.ApplicationServices.Implementations
{
    public class RatingManagementService
    {
        #region Variables
        // _context
        private readonly MovieCatalogDbContext _context = new MovieCatalogDbContext();
        #endregion

        #region Methods
        // Get
        public List<RatingDto> Get()
        {
            return _context
                .Ratings
                .ToList()
                .Select(x => new RatingDto(x))
                .ToList();
        }

        // GetById
        public RatingDto GetById(int id)
        {
            return new RatingDto(_context.Ratings.Find(id));
        }

        // Save
        public int Save(RatingDto ratingDto)
        {
            try
            {
                Rating rating = new Rating
                {
                    IsActive = ratingDto.IsActive,
                    RatingValue = ratingDto.RatingValue
                };

                _context.Ratings.Add(rating);
                _context.SaveChanges();

                // Return id
                return rating.Id;
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
                Rating rating = _context.Ratings.Find(id);

                if (rating == null)
                {
                    return -1;
                }

                _context.Ratings.Remove(rating);
                _context.SaveChanges();

                return id;
            }
            catch (System.Exception)
            {
                return -1;
            }
        }
        #endregion
    }
}