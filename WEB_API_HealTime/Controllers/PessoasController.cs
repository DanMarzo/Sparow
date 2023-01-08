﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Linq.Expressions;
using WEB_API_HealTime.Data;
using WEB_API_HealTime.Models;

namespace WEB_API_HealTime.Controllers;

[ApiController]
[Route("[controller]")]
public class PessoasController : ControllerBase
{
    private readonly DataContext _context;
    private Guid pkGlobal = new Guid();
    public PessoasController(DataContext context){ _context = context; }

    [HttpPost("Cadastro")]
    public async Task<IActionResult> CadastroAsync(Pessoa pessoa)
    {
		try
		{
            Pessoa buscaP = await _context.Pessoas.FirstOrDefaultAsync(x => x.CpfPessoa == pessoa.CpfPessoa);
            if (buscaP != null)
                throw new Exception("Usuario existe");
            //O endereço tera como auto preenchimento será consumida em outra api

            Guid idGuid;
            while (true)
            {
                idGuid = Guid.NewGuid();

                Pessoa pessoaGuid = await _context.Pessoas.FirstOrDefaultAsync(pId => pId.PessoaId == idGuid);

                if (pessoaGuid != null)
                    continue;
                else
                    break;
            }
            pessoa.PessoaId = idGuid;

            //Uso de variavel Global para criação de contato
            pkGlobal = pessoa.PessoaId;
            
            await _context.Pessoas.AddAsync(pessoa);
            await _context.SaveChangesAsync();
            return Ok($"{pessoa.NomePessoa} salvo!");
        }
		catch (Exception ex)
		{
            return BadRequest(ex.Message);
		}
    }

    [HttpPost("InfoContato")]
    public async Task<IActionResult> InfoContatoAsync(ContatoPessoa ctt, string? cpf)
    {
        try
        {
            ContatoPessoa cttPessoa = await _context.ContatoPessoas
                .Include(x => x.Pessoas)
                .FirstOrDefaultAsync(x => x.PessoaId == pkGlobal);
            if (cttPessoa is null)
                throw new Exception("Error Interno - Tipo 1");


        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("IncluiInfoPacienteIn")]//Cria model so para molde do Pa In?
    public async Task<IActionResult> IncluiInfoPacienteIn(string cpfBusca, string obs)
    {
        try
        {
            if (cpfBusca is null)
                throw new Exception("O CPF é obrigatório");
            
            if (obs is null)
                throw new Exception("O campo Observação não deve estar em branco");
            
            Pessoa buscaInfP = await _context.Pessoas.FirstOrDefaultAsync(p => p.CpfPessoa == cpfBusca);

            if (buscaInfP is null)
                throw new Exception("CPF não cadastrado {Ideia para o front Redirection}");

            if (buscaInfP.ObsPacienteIncapaz is null)
                buscaInfP.ObsPacienteIncapaz = obs;

            buscaInfP.ObsPacienteIncapaz += " - ";
            buscaInfP.ObsPacienteIncapaz += obs;


            _context.Update(buscaInfP);
            await _context.SaveChangesAsync();


            return Ok("");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


}
