using MC.ApplicationServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MC.WcfServices
{
    [ServiceContract]
    public interface IGenre
    {
        [OperationContract]
        List<GenreDto> Get();

        [OperationContract]
        string Post(GenreDto genreDto);

        [OperationContract]
        string Delete(int id);

        [OperationContract]
        GenreDto GetById(int id);
    }
}
