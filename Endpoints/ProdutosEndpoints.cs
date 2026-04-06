using ApiClaudeCode.Data;
using ApiClaudeCode.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiClaudeCode.Endpoints;

public static class ProdutosEndpoints
{
    public static void MapProdutos(this WebApplication app)
    {
        var group = app.MapGroup("/produtos").WithTags("Produtos");

        group.MapGet("/", GetAll);
        group.MapGet("/{id:int}", GetById);
        group.MapPost("/", Create);
        group.MapPut("/{id:int}", Update);
        group.MapDelete("/{id:int}", Delete);
    }

    private static async Task<IResult> GetAll(AppDbContext db)
    {
        var produtos = await db.Produtos
            .AsNoTracking()
            .Select(p => ProdutoResponse.FromEntity(p))
            .ToListAsync();

        return Results.Ok(produtos);
    }

    private static async Task<IResult> GetById(int id, AppDbContext db)
    {
        var produto = await db.Produtos.FindAsync(id);
        return produto is null
            ? Results.NotFound()
            : Results.Ok(ProdutoResponse.FromEntity(produto));
    }

    private static async Task<IResult> Create(ProdutoRequest request, AppDbContext db)
    {
        var produto = new Produto
        {
            Nome = request.Nome,
            Preco = request.Preco,
            Estoque = request.Estoque
        };

        var erros = produto.Validar().ToList();
        if (erros.Count > 0) return Results.BadRequest(erros);

        db.Produtos.Add(produto);
        await db.SaveChangesAsync();

        return Results.Created($"/produtos/{produto.Id}", ProdutoResponse.FromEntity(produto));
    }

    private static async Task<IResult> Update(int id, ProdutoRequest request, AppDbContext db)
    {
        var produto = await db.Produtos.FindAsync(id);
        if (produto is null) return Results.NotFound();

        produto.Nome = request.Nome;
        produto.Preco = request.Preco;
        produto.Estoque = request.Estoque;

        var erros = produto.Validar().ToList();
        if (erros.Count > 0) return Results.BadRequest(erros);

        await db.SaveChangesAsync();
        return Results.Ok(ProdutoResponse.FromEntity(produto));
    }

    private static async Task<IResult> Delete(int id, AppDbContext db)
    {
        var produto = await db.Produtos.FindAsync(id);
        if (produto is null) return Results.NotFound();

        db.Produtos.Remove(produto);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }
}
