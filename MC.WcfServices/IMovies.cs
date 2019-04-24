using MC.ApplicationServices.DTOs;
using System.Collections.Generic;
using System.ServiceModel;

namespace MC.WcfServices
{
    [ServiceContract]
    public interface IMovies
    {
        [OperationContract]
        List<MovieDto> Get();

        [OperationContract]
        string Post(MovieDto movieDto);

        [OperationContract]
        string Delete(int id);

        [OperationContract]
        MovieDto GetById(int id);

        [OperationContract]
        string Edit(MovieDto movieDto);

        [OperationContract]
        string Message();
    }
}