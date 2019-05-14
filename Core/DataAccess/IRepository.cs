using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IRepository<T>
        where T:class,new()
    {
        /// <summary>
        /// Aldığı Entity türünü kaydeder
        /// </summary>
        /// <param name="entity">İlgili türdeki kaydedilecek entity</param>
        /// <returns>Etkilenen satır sayısı</returns>
        int Add(T entity);

        /// <summary>
        /// Aldığı Entity türündeki değişiklikleri kaydeder
        /// </summary>
        /// <param name="entity">İlgili türdeki kaydedilecek entity</param>
        /// <returns>Etkilenen satır sayısı</returns>
        int Update(T entity);

        /// <summary>
        /// Aldığı lambda expression ifadesini ilgili entitynin dbsetine filtre olarak uygular ve sadece tek değer döner. Eğer filtre nedeniyle birden fazla result oluşuyor ise exception fırlatır.
        /// </summary>
        /// <param name="filter">Uygulanacak lambda expression</param>
        /// <returns>filter sonucunda bulunan entity</returns>
        T Get(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Aldığı lambda expression ifadesini ilgili entity nin dbsetine filtre olarak uygular ve liste olarak döner. Eğer filter verilmeden kullanılır ise getAll gibi çalışır.
        /// </summary>
        /// <param name="filter">Uygulanacak lambda expression</param>
        /// <returns>filter sonucunda bulunan entityler</returns>
        List<T> GetList(Expression<Func<T, bool>> filter=null);

        /// <summary>
        /// Aldığı lambda expression ifadesini ilgili entity nin dbsetine filtre olarak uygular ve gecikmeli sorgu olarak döner. Eğer filter verilmeden kullanılır ise getAll gibi çalışır.
        /// </summary>
        /// <param name="filter">Uygulanacak lambda expression</param>
        /// <returns>filter sonucu sorgu</returns>
        IQueryable<T> GetQuery(Expression<Func<T, bool>> filter = null);

        /// <summary>
        /// (Soft Delete) Parametre olarak aldığı entity nin IsDelete propertysini true atar ve kaydeder.
        /// </summary>
        /// <param name="entity">Silinmek istenen entity</param>
        /// <returns>Etkilenen satır sayısı</returns>
        int Delete(T entity); 
    }
}
