using System.Threading.Tasks;
using ADDED.API.Models;
using System.Linq;
using ADDED.API.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ADDED.API.Dtos;
using System;
using ADDED.API.SonedeModels;

namespace ADDED.API.Data
{
    public class ADDEDRepository : IADDEDRepository
    {
        private readonly DataContext _context;
        public ADDEDRepository(DataContext context)
        {
            _context = context;

        }



        public async Task<Portable> GetPortable(int id)
        {
            var portable = await _context.Portables.FirstOrDefaultAsync(u => u.IdPort == id);
            return portable;
        }



        public async Task<Releveur> GetReleveur(int id)
        {
            var releveur = await _context.Releveurs.FirstOrDefaultAsync(u => u.IdReleveur == id);
            return releveur;
        }


        public async Task<string> GetDist(int id)
         {
            var district = await _context.Districts.FirstOrDefaultAsync(u => u.CodDist == id);
             return district.NomDist ;
        }






        public async Task<Releveur> GetAffectation(int id)
        {
            var affectation = await _context.Releveurs
            .Include(p => p.Portable).FirstOrDefaultAsync(u => u.IdReleveur == id);
            return affectation;
        }

        public Tournee GetTournee (int id)
        {
            var tournee = 
             _context.Tournees.FirstOrDefault(u => u.IdTour == id);
            return tournee;
        }



        public async Task<Portable> AddPortable(Portable portable)
        {
            await _context.Portables.AddAsync(portable);
            await _context.SaveChangesAsync();
            return portable;
        }

    
    

        public async Task<Releveur> AddReleveur(Releveur releveur)
        {
            await _context.Releveurs.AddAsync(releveur);
            await _context.SaveChangesAsync();
            return releveur;
        }




        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }



        public void Modify<T>(T entity) where T : class
        {
            _context.Update(entity);
        }



        public async Task<PagedList<Portable>> GetPortables(PortableParam portableParam)
        {
            var portables = _context.Portables.AsQueryable();
            if (!string.IsNullOrEmpty(portableParam.Portable))
            {
                var isId = int.TryParse(portableParam.Portable
                                         , out int idPort);
                if (isId)
                    portables = portables.Where(u => u.IdPort == idPort);
                else
                    portables = portables.Where(u => u.MarquePort
                    .Contains(portableParam.Portable));
            }
            if (portableParam.Etat != null)
                portables = portables.Where(u => u.EtatPort == portableParam.Etat);
            return await PagedList<Portable>.CreateAsync(portables,
                                     portableParam.PageNumber, portableParam.PageSize);
        }

        

        public async Task<PagedList<Releveur>> GetReleveurs(int id, ReleveurParam releveurParam)
        {
            var releveurs = _context.Releveurs.AsQueryable().Where(u => u.LocaliteNavigation.CodDist == id);

            if (!string.IsNullOrEmpty(releveurParam.Releveur))
            {
                var isId = int.TryParse(releveurParam.Releveur, out int idReleveur);
                if (isId)
                    releveurs = releveurs.Where(u => u.IdReleveur == idReleveur);
                else
                    releveurs = releveurs.Where(u => u.TSPUsername
                    .Contains(releveurParam.Releveur));
            }

            if (releveurParam.CodLocalite != null)
                releveurs = releveurs.Where(u => u.CodLocalite == releveurParam.CodLocalite);
            return await PagedList<Releveur>.CreateAsync(releveurs,
             releveurParam.PageNumber, releveurParam.PageSize);
        }





        public async Task<PagedList<Releveur>> GetAffectations(int id, AffectationParam affectationParam)
        {
            var affectations = _context.Releveurs.AsQueryable()
            .Where(u => u.Portable != null
                            && u.LocaliteNavigation.CodDist == id);
            if (!string.IsNullOrEmpty(affectationParam.Releveur))
            {
                var isId = int.TryParse(affectationParam.Releveur, out int idReleveur);
                if (isId)
                    affectations = affectations.Where(u => u.IdReleveur == idReleveur);
                else
                    affectations = affectations.Where(u => u.TSPUsername
                    .Contains(affectationParam.Releveur));
            }
            if (!string.IsNullOrEmpty(affectationParam.Portable))
            {
                var isId = int.TryParse(affectationParam.Portable, out int idPort);
                if (isId)
                    affectations = affectations.Where(u => u.Portable.IdPort == idPort);
                else
                    affectations = affectations.Where(u => u.Portable.MarquePort
                    .Contains(affectationParam.Portable));
            }
            if (affectationParam.CodLocalite != null)
                affectations = affectations
                .Where(u => u.CodLocalite == affectationParam.CodLocalite);

            return await PagedList<Releveur>
            .CreateAsync(affectations, affectationParam.PageNumber, affectationParam.PageSize);
        }




        public async Task<PagedList<Releveur>> GetPlannings(int id, PlanningParam planningParam)
        {
            var plannings = _context.Releveurs.AsQueryable()
            .Where(u => u.Tournee.FirstOrDefault(a => a.IdChef == id) != null);
            if (!string.IsNullOrEmpty(planningParam.Releveur))
            {
                var isId = int.TryParse(planningParam.Releveur, out int idReleveur);
                if (isId)
                    plannings = plannings.Where(u => u.IdReleveur == idReleveur);
                else
                    plannings = plannings.Where(u => u.TSPUsername
                    .Contains(planningParam.Releveur));
            }
            if (!string.IsNullOrEmpty(planningParam.Portable))
            {
                var isId = int.TryParse(planningParam.Portable, out int idPort);
                if (isId)
                    plannings = plannings.Where(u => u.Portable.IdPort == idPort);
                else
                    plannings = plannings.Where(u => u.Portable.MarquePort
                    .Contains(planningParam.Portable));
            }
            if (planningParam.Tour != null)
                plannings = plannings.Where(u => u.Tournee
                .FirstOrDefault(a => a.Tour == planningParam.Tour || a.IdTour == planningParam.Tour ) != null);

            return await PagedList<Releveur>
            .CreateAsync(plannings, planningParam.PageNumber, planningParam.PageSize);
        }




        public async Task<PagedList<Tournee>> GetTournees(int id, TourneeParam tournneParam)
        {
            var tournees = _context.Tournees.AsQueryable()
            .Where(u => u.IdChef == id && u.IdReleveur == null);
            if (tournneParam.Tour != null)
                tournees = tournees
                .Where(u => u.Tour == tournneParam.Tour || u.IdTour == tournneParam.Tour);

            return await PagedList<Tournee>.
            CreateAsync(tournees, tournneParam.PageNumber, tournneParam.PageSize);
        }




        public async Task<IEnumerable<District>> GetDistrict()
        {
            var districts = await _context.Districts.ToListAsync();
            return districts;
        }

        public async Task<IEnumerable<Portable>> GetListPortables()
        {
            var portable = await _context.Portables.Where(u => u.IdReleveur == null && u.EtatPort == 1).ToListAsync();
            return portable;
        }
         public async Task<IEnumerable<Releveur>> GetListReleveurs(int option)
        {  
            IEnumerable<Releveur> releveurs;
            if(option == 1){
                releveurs = await _context.Releveurs.Where(u => u.Tournee
                .FirstOrDefault() == null && u.Portable != null).ToListAsync();
            }
            else {
                releveurs = await _context.Releveurs.Where(u =>  u.Portable == null).ToListAsync();
            }
            return releveurs;
        }

         public async Task<IEnumerable<Tournee>> GetListTournee()
        {
            var tournees = await _context.Tournees.Where(u => u.IdReleveur == null).ToListAsync();
            return tournees;
        }







        public async Task<PagedList<Index>> GetIndexs(IndexParam indexParam)
        {
            
            var indexs = _context.Indexs.AsQueryable();
             if (indexParam.Ordre != null)
                indexs = indexs.Where(u => u.IdOrdrNavigation.Ordre == indexParam.Ordre);
            if (indexParam.Tournee != null)
                indexs = indexs.Where(u => u.IdOrdrNavigation.IdTourNavigation.Tour == indexParam.Tournee);
            return await PagedList<Index>.CreateAsync(indexs,
                                     indexParam.PageNumber, indexParam.PageSize);
        }
        
        public async Task<PagedList<ListAnomalie>> GetAnomalies(AnomalieParam anomalieParam)
        {
            var Anomalies = _context.ListAnomalies.AsQueryable();
             if (anomalieParam.Anomalie != null)
                Anomalies = Anomalies.Where(u => u.IdAno== anomalieParam.Anomalie);
            return await PagedList<ListAnomalie>.CreateAsync(Anomalies,
                                     anomalieParam.PageNumber, anomalieParam.PageSize);
        }
        public async Task<PagedList<Creation>> GetCompteurs(CompteurParam compteurParam)
        {
            var compteurs = _context.Creations.AsQueryable();
             if (compteurParam.Compteur != null)
                compteurs = compteurs.Where(u => u.CreaNumCtr == compteurParam.Compteur);
            if (compteurParam.Tournee != null)
                compteurs = compteurs.Where(u => u.CreaTour== compteurParam.Tournee);
            return await PagedList<Creation>.CreateAsync(compteurs,
                                     compteurParam.PageNumber, compteurParam.PageSize);
        }


        public async Task<bool> choixExist(InitDtos initial)
        {
            if ((await _context.ChoixPlans.AnyAsync(x => x.IdPeriode == Convert.ToString(initial.annee)  + Convert.ToString(initial.Trim)
                  + Convert.ToString(initial.Tier)   + Convert.ToString(initial.Six) )))
            { return true; }
            return false;
        }

        public async Task<bool> GetInit(InitDtos initial)
        {
            var bases = await _context.Base20231
            .Where(u => u.Zan == initial.annee && u.Ztier == initial.Tier 
            && u.Zsix == initial.Six && u.Ztri == initial.Trim).FirstOrDefaultAsync();
            if (bases != null)
            {
                var choix = new ChoixPlan
                {   IdPeriode  = Convert.ToString(initial.annee)  + Convert.ToString(initial.Trim)
                  + Convert.ToString(initial.Tier)   + Convert.ToString(initial.Six),
                    IdChef = initial.IdChef,
                    DatExploi = DateTime.Now
                };
                _context.Add(choix);
                var Result = await this.SaveAll();
                return Result;
            }
            return false;
        }




        public async Task<bool> ImportDetaille(InitDtos initial)
        {
            var bases = await _context.Base20231
            .Where(u => u.Zan == initial.annee && u.Ztier == initial.Tier 
            && u.Zsix == initial.Six && u.Ztri == initial.Trim).ToListAsync();


            foreach (Base20231 element in bases)
            {
                if (!await _context.Detailles
                .AnyAsync(x => x.Ordre == element.Ord && x.IdTourNavigation.Tour == element.Tou))
                {
                    var tour = await _context.Tournees
                    .Where(u => u.Tour == element.Tou).FirstOrDefaultAsync();
                    var detaille = new Detaille
                    {
                        IdTour = tour.IdTour,
                        Ordre = element.Ord,
                        Police = element.Pol,
                        NomAbn = element.Nomadr,
                        AncienIndex = element.Aindex,
                        Categ = element.Categ,
                    };
                    _context.Add(detaille);
                }
            }
            var Result = await this.SaveAll();
            return Result;
        }





        public async Task<bool> ImportTournees(InitDtos initial)
        {
            var bases = await _context.Base20231
            .Where(u => u.Zan == initial.annee && u.Ztier
            == initial.Tier && u.Zsix == initial.Six && u.Ztri == initial.Trim).Select(a=> a.Tou).Distinct().ToListAsync();


            var choix = await _context.ChoixPlans.Where(u => u.IdChef == initial.IdChef)
                .OrderByDescending(u => u.DatExploi).FirstOrDefaultAsync();
            foreach (int element in bases)
            {
                if (!await _context.Tournees.AnyAsync(x => x.Tour == element))
                {
                    var tournee = new Tournee
                    {
                        Tour = element,
                        IdChef = choix.IdChef,
                        IdPeriode = choix.IdPeriode
                    };
                    _context.Add(tournee);
                }

            }
            var Result = await this.SaveAll();
            return Result;
        }





        public async Task<IEnumerable<Localite>> GetLocalite(int id)
        {
            var Localites = await _context.Localites.Where(u => u.CodDist == id).ToListAsync();
            return Localites;
        }
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

         public async Task<bool> ReleveurExisit(string  user)
        {
            if ((await _context.Releveurs.AnyAsync(x => x.TSPUsername == user )))
            { return true; }
            return false;
        }


       
    }
}