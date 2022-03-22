using PJYAAC_SG1_21_22_2.Models.Models;
using System.Collections.Generic;

namespace PJYAAC_SG1_21_22_2.WpfClient.Infrastructure.Interfaces
{
    public interface IHttpService
    {
        ApiResult Create<T>(T entity, string actionName = null);
        ApiResult Delete<TKey>(TKey id, string actionName = null);
        T Get<T, TKey>(TKey id, string actionName = null);
        List<T> GetAll<T>(string actionName = null);
        ApiResult Update<T>(T entity, string actionName = null);
    }
}