using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MC.ApplicationServices.DTOs;
using MC.ApplicationServices.Implementations;

namespace MC.WcfServices
{
    public class Rating : IRating
    {
        #region Variables
        // _service
        private readonly RatingManagementService _service;
        #endregion

        #region Constructor
        public Rating()
        {
            _service = new RatingManagementService();
        }
        #endregion

        #region Methods
        // Get
        public List<RatingDto> Get()
        {
            return _service.Get();
        }

        // Post
        public string Post(RatingDto ratingDto)
        {
            if (_service.Save(ratingDto) == -1)
                return "Rating is not inserted";

            return "Rating is inserted";
        }

        // Delete
        public string Delete(int id)
        {
            if (_service.Delete(id) == -1)
                return $"Rating with id {id} is not deleted";

            return $"Rating with id {id} deleted";
        }

        // GetById
        public RatingDto GetById(int id)
        {
            return _service.GetById(id);
        }
        #endregion
    }
}