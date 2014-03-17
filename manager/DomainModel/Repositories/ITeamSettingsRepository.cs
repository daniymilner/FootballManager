﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Entities;

namespace DomainModel.Repositories
{
    public interface ITeamSettingsRepository : IRepository<TeamSettings>
    {
        TeamSettings GetSettingsForCurrentMatchAndTeam(Team team, Match match);
    }
}
