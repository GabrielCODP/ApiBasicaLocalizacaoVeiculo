﻿using ApiParaLocalizarTransporte.Context;
using ApiParaLocalizarTransporte.Models;
using ApiParaLocalizarTransporte.Repositories.Interfaces;

namespace ApiParaLocalizarTransporte.Repositories
{
    public class ParadaRepository : Repository<Parada>, IParadaRepository
    {
        public ParadaRepository(AppDbContext context) : base(context)
        {
        }
    }
}
