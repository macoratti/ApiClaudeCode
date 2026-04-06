namespace ApiClaudeCode.Entities;

public record ProdutoRequest(
    string Nome,
    decimal Preco,
    int Estoque
);

public record ProdutoResponse(
    int Id,
    string Nome,
    decimal Preco,
    int Estoque
)
{
    public static ProdutoResponse FromEntity(Produto p) =>
        new(p.Id, p.Nome, p.Preco, p.Estoque);
}
