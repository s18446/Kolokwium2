using Kolokwium2.DTOs;
using Kolokwium2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Services
{
    public interface IChampionshipsDbService
    {
        ICollection<TeamResponse> GetChampionships(int id);

        void AddToTeam(int id);

    }
}
