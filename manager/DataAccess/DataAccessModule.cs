﻿using Autofac;
using DataAccess.Repositories;
using DomainModel.Entities;
using DomainModel.Repositories;

namespace DataAccess
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DataContext>()
                .As<IDataContext>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserRepository>()
                .As<IUserRepository>()
                .As<IQuerableRepository<User>>();

            builder.RegisterType<PlayerRepository>()
                .As<IPlayerRepository>()
                .As<IQuerableRepository<Player>>();

            builder.RegisterType<PositionRepository>()
                .As<IPositionRepository>()
                .As<IQuerableRepository<Position>>();

            builder.RegisterType<CountryRepository>()
               .As<ICountryRepository>()
               .As<IQuerableRepository<Country>>();

            builder.RegisterType<TeamRepository>()
                .As<ITeamRepository>()
                .As<IQuerableRepository<Team>>();

            builder.RegisterType<SkillRepository>()
                .As<ISkillRepository>()
                .As<IQuerableRepository<Skill>>();

            builder.RegisterType<SkillsPlayerRepository>()
                .As<ISkillsPlayerRepository>()
                .As<IQuerableRepository<SkillsPlayer>>();

            base.Load(builder);
        }
    }
}
