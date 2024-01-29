﻿using API_VozyChatOps.DTOs;
using API_VozyChatOps.Models;
using API_VozyChatOps.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API_VozyChatOps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly ScheduleService _scheduleService;

        public ScheduleController(ScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpPost("query")]
        public async Task<ActionResult<List<ScheduleModel>>> GetSchedulesByNumIdentificacion([FromBody] ScheduleRequestDTO scheduleRequestDTO)
        {
            var numIdentificacion = scheduleRequestDTO.NUM_IDENTIFICACION;

            if (numIdentificacion == null)
            {
                return BadRequest(new { Status = false, Code = HttpStatusCode.NotFound, Messagge = "Número de identificación no válido." });
            }

            var schedules = await _scheduleService.GetSchedulesByNumIdentificacionAsync(numIdentificacion);

            if (schedules == null || schedules.Count == 0)
            {
                return NotFound(new { Status = false, Code = HttpStatusCode.NotFound, Messagge = $"No se encontro horario para el estudiante: {numIdentificacion}" });
            }
            return Ok(new { Status = true, Code = HttpStatusCode.OK, Message = "Horario generado con exito", schedules });
            
        }

        [HttpPost("generate-pdf")]
        public async Task<ActionResult<List<ScheduleModel>>> GetPDFSchedulesByNumIdentificacion([FromBody] ScheduleRequestDTO scheduleRequestDTO)
        {
            var numIdentificacion = scheduleRequestDTO.NUM_IDENTIFICACION;

            if(numIdentificacion == null)
            {
                return BadRequest(new { Status = false, Code = HttpStatusCode.NotFound, Messagge = "Número de identificación no válido." });
            }

            var schedules = await _scheduleService.GetSchedulesByNumIdentificacionAsync(numIdentificacion);

            if (schedules == null || schedules.Count == 0)
            {
                return NotFound(new { Status = false, Code = HttpStatusCode.NotFound, Messagge = $"No se encontro horario para el estudiante: {numIdentificacion}" });
            }
            return Ok(new { Status = true, Code = HttpStatusCode.OK, Message = "Horario generado con exito", schedules });

        }


    }
}