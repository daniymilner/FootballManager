﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Generator;
using DomainModel;
using DomainModel.Repositories;
using manager.Components;

namespace manager.Controllers.API
{
    public class GeneratorController : DefaultController
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IEntityFactory _entityFactory;
        private readonly ITeamRepository _teamRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ITeamSettingsRepository _teamSettingsRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IArrangementRepository _arrangementRepository;

        public GeneratorController(IMatchRepository matchRepository,
                                    IEntityFactory entityFactory,
                                    ITeamRepository teamRepository,
                                    ICountryRepository countryRepository, 
                                    ITeamSettingsRepository teamSettingsRepository,
                                    IPlayerRepository playerRepository,
                                    IArrangementRepository arrangementRepository)
        {
            _entityFactory = entityFactory;
            _matchRepository = matchRepository;
            _teamRepository = teamRepository;
            _countryRepository = countryRepository;
            _teamSettingsRepository = teamSettingsRepository;
            _playerRepository = playerRepository;
            _arrangementRepository = arrangementRepository;
        }

        [HttpPost]
        [Route("api/generator/run")]
        public ActionResult Run()
        {
            Generator generator = new Generator();
            generator.Run(_matchRepository, _entityFactory, _teamRepository, _countryRepository, _teamSettingsRepository,
                _playerRepository, _arrangementRepository);
            return JsonSuccess();
        }
    }
}