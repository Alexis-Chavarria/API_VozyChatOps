﻿using API_VozyChatOps.Data;
using API_VozyChatOps.Models;
using API_VozyChatOps.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace API_VozyChatOps.Repositories.Implementations
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly AppDBContext _context;

        public ScheduleRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<ScheduleModel>> GetByNumIdentificacionAsync(string numIdentificacion)
        {
            var schedule = await _context.Horarios
               .Where(h => h.NUM_IDENTIFICACION == numIdentificacion)
               .ToListAsync();

            //var schedule = await _context.Horarios
            //    .FromSqlRaw($"SELECT * FROM CUN.Horarios WHERE NUM_IDENTIFICACION = {numIdentificacion}")
            //    .ToListAsync();


            return schedule;

        }


    }
}
