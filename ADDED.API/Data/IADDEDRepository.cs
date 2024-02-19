using System.Collections.Generic;
using System.Threading.Tasks;
using ADDED.API.Dtos;
using ADDED.API.Helpers;
using ADDED.API.Models;

namespace ADDED.API.Data
{
    public interface IADDEDRepository
    {
        Task<bool> SaveAll();
        void Delete<T>(T entity) where T : class;
        Task<Portable> GetPortable(int id);
        Task<Releveur> GetReleveur(int id);
         Task<string> GetDist(int id);
        Task<Releveur> GetAffectation(int id);
        Tournee GetTournee (int id);
        Task<Portable> AddPortable(Portable portable);
        Task<Releveur> AddReleveur(Releveur releveur);
        Task<PagedList<Releveur>> GetReleveurs(int id ,ReleveurParam releveurParam);
        Task<PagedList<Portable>> GetPortables(PortableParam portableparam);
        Task<PagedList<Releveur>> GetAffectations(int id, AffectationParam affectationParam);
        Task<PagedList<Releveur>> GetPlannings(int id, PlanningParam planningParam);
        Task<PagedList<Tournee>> GetTournees(int id, TourneeParam tournneParam);
        Task<PagedList<Index>> GetIndexs(IndexParam indexParam);
        Task<PagedList<ListAnomalie>> GetAnomalies(AnomalieParam anomalieParam);
        Task<PagedList<Creation>> GetCompteurs(CompteurParam compteurParam);
        Task<bool> choixExist(InitDtos initial);

       
        void Modify<T>(T entity) where T : class;
        Task<bool> GetInit(InitDtos initial);
        Task<bool> ImportDetaille(InitDtos initial);
        Task<bool> ImportTournees(InitDtos initial);
        Task<IEnumerable<District>> GetDistrict();
        Task<IEnumerable<Releveur>> GetListReleveurs(int option);
        Task<IEnumerable<Portable>> GetListPortables();
        Task<IEnumerable<Tournee>> GetListTournee();
        Task<IEnumerable<Localite>> GetLocalite(int id);
        Task<bool> ReleveurExisit(string  user);
    }
}
