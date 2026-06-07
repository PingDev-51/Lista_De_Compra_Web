using System.Text.Json;
using System.Text.Json.Serialization;
using ListaDeCompra.WebApp.ModuloItens.Dominio;
using ListaDeCompra.WebApp.ModuloLista.Dominio;
using ListaDeCompra.WebApp.ModuloProdutos;
using ListaDeCompra.WebApp.ModuloProdutos.Dominio;
using ListaDeCompras.ConsoleApp.ModuloCategoria;

namespace ListaDeCompra.WebApp.Arquivos.Infra.Arquivos;

public sealed class ContextoJson
{
    public List<Categoria> Categorias { get; set; } = new List<Categoria>();
    public List<Produto> Produtos { get; set; } = new List<Produto>();
    public List<ListaCompra> ListaDeCompras { get; set; } = new List<ListaCompra>();
    public List<Itens> Itens { get; set; } = new List<Itens>();
    private readonly string caminhoArquivo;

    public ContextoJson()
    {
        string caminhoAppData = Environment
            .GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        string caminhoDiretorio = Path.Combine(caminhoAppData, "ClubeDaLeituraWeb");

        Directory.CreateDirectory(caminhoDiretorio);

        caminhoArquivo = Path.Combine(caminhoDiretorio, "dados.json");
    }

    public void Salvar()
    {
        JsonSerializerOptions opcoesJson = new JsonSerializerOptions();
        opcoesJson.WriteIndented = true;
        opcoesJson.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        opcoesJson.ReferenceHandler = ReferenceHandler.Preserve;

        string jsonString = JsonSerializer.Serialize(this, opcoesJson);

        File.WriteAllText(caminhoArquivo, jsonString);
    }

    public void Carregar()
    {
        if (!File.Exists(caminhoArquivo))
            return;

        string jsonString = File.ReadAllText(caminhoArquivo);

        JsonSerializerOptions opcoesJson = new JsonSerializerOptions();
        opcoesJson.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        opcoesJson.ReferenceHandler = ReferenceHandler.Preserve;

        ContextoJson? contextoSalvo = JsonSerializer
            .Deserialize<ContextoJson>(jsonString, opcoesJson);

        if (contextoSalvo == null)
            return;

        Categorias = contextoSalvo.Categorias;
        Produtos = contextoSalvo.Produtos;
        ListaDeCompras = contextoSalvo.ListaDeCompras;
        Itens = contextoSalvo.Itens;
    }
}