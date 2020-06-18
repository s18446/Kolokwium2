using Kolokwium2.DTOs;
using Kolokwium2.Exceptions;
using Kolokwium2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Services
{
    public class SqlServerChampionshipsDbService : IChampionshipsDbService
    {
        private readonly ChampionshipsDbContext _context;

        public SqlServerChampionshipsDbService(ChampionshipsDbContext context)
        {
            _context = context;
        }

        public void AddToTeam(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<TeamResponse> GetChampionships(int id)
        {
            var championship = _context.Championships
                            .SingleOrDefault(e => e.IdChampionship == id);

            if( championship == null)
            {
                throw new ChampionshipDoesNotExistException($"Championship with id = {id} does not exist.");
            }

            var teams = from t in _context.Teams
                        join ct in _context.Championship_Teams on t.IdTeam equals ct.IdTeam
                        join c in _context.Championships on ct.IdChampionship equals c.IdChampionship
                        where c.IdChampionship == id
                        orderby ct.Score descending
                        select new TeamResponse()
                        {
                            TeamId = t.IdTeam,
                            TeamName = t.TeamName,
                            TeamScore = ct.Score
                        };


            return teams.ToList();
                                    
        }
    }
}
