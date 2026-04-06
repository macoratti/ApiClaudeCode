namespace ApiClaudeCode.Entities;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int Estoque { get; set; }

    public IEnumerable<string> Validar()
    {
        if (string.IsNullOrWhiteSpace(Nome))
            yield return "Nome é obrigatório.";

        if (Preco <= 0)
            yield return "Preço deve ser maior que zero.";

        if (Estoque < 0)
            yield return "Estoque não pode ser negativo.";
    }
}
