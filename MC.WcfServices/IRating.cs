using MC.ApplicationServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MC.WcfServices
{
    [ServiceContract]
    public interface IRating
    {
        [OperationContract]
        List<RatingDto> Get();

        [OperationContract]
        string Post(RatingDto ratingDto);

        [OperationContract]
        string Delete(int id);

        [OperationContract]
        RatingDto GetById(int id);
    }
}
