using System;

public class HospedeService
{
    private readonly HospedeRepository hospedeRepository;

    public HospedeService(HospedeRepository hospedeRepository)
    {
        this.hospedeRepository = hospedeRepository;
    }

    public void CriarHospede(string nome, string email, string telefone, DateTime dataCheckIn, DateTime dataCheckOut)
    {
        // Verificar se o nome e o email do hospede são válidos (pode adicionar mais validações conforme necessário)
        if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("O nome e o email do hospede são obrigatórios.");
        }

        // Criar uma nova instância de Hospede com os dados fornecidos
        Hospede novoHospede = new Hospede(nome, email, telefone, dataCheckIn, dataCheckOut);

        // Chamar o método do HospedeRepository para adicionar o novo hospede ao banco de dados
        hospedeRepository.AdicionarHospede(novoHospede);
    }

    // Outros métodos para manipular hospedes, como LerHospede, AtualizarHospede, ExcluirHospede, etc.
}

