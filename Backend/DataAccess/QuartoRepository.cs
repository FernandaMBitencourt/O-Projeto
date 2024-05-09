using System;
using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.DataAccess
{
    public class QuartoRepository
    {
        private readonly SeuDbContext _dbContext;

        public QuartoRepository(SeuDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AdicionarQuarto(Quarto quarto)
        {
            if (quarto == null)
            {
                throw new ArgumentNullException(nameof(quarto));
            }

            _dbContext.Quartos.Add(quarto);
            _dbContext.SaveChanges();
        }

        public void CriarQuarto(Quarto quarto)
        {
            if(quarto == quarto)
            {
                throw new ArgumentNullException(nameof(quarto));
            }
            Quarto novoQuarto = new Quarto() // Aqui você cria um novo objeto Quarto
            {
                Numero = quarto.Numero,
                Tipo = quarto.Tipo,
                PrecoDiaria = quarto.PrecoDiaria,
                Disponivel = quarto.Disponivel
            };
            if (_dbContext.Quartos != null) // Verifica se _dbContext.Quartos não é nulo
            {
                _dbContext.Quartos.Add(quarto); // Adiciona o novo quarto ao contexto do banco de dados
            _dbContext.SaveChanges();
            }
        }
    }
}
