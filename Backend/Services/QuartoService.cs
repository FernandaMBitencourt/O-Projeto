using Backend.DataAccess; // Importa o namespace onde está definido o QuartoRepository
using Backend.Models;

namespace Backend.Services // Adiciona um namespace para suas classes de serviço
{
    public class QuartoService
    {
        private readonly QuartoRepository _quartoRepository;

        public QuartoService(QuartoRepository quartoRepository)
        {
            _quartoRepository = quartoRepository;
        }

        public void CriarQuarto(Quarto quarto)
        {
            _quartoRepository.CriarQuarto(quarto);
        }

        public Quarto ObterQuartoPorNumero(string numero)
        {
            return _quartoRepository.ObterQuartoPorNumero(numero);
        }
    }
}
