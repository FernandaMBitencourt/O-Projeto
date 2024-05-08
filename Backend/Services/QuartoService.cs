using System;

public class QuartoRepository
{
    // Construtor vazio (default)
    public QuartoRepository() { }

    // Método para criar um quarto
    public Quarto CriarQuarto(string numero, string tipo, decimal precoDiaria, bool disponivel)
    {
        return new Quarto(numero, tipo, precoDiaria, disponivel);
    }
}
