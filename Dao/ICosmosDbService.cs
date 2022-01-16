using PPPK_Delivery_6_CosmosOsoba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PPPK_Delivery_6_CosmosOsoba.Dao
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<Person>> GetPeopleAsync(string queryString);
        Task<Person> GetPersonAsync(string id);
        Task AddPersonAsync(Person person);
        Task UpdatPersonAsync(Person person);
        Task DeletePersonAsync(Person person);
    }
}