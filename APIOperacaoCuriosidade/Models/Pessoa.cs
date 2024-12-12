using System.ComponentModel.DataAnnotations;

namespace APIOperacaoCuriosidade.Models; 
public class Pessoa {
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório")]
    [Length(3, 30, ErrorMessage = "O nome deve ter entre 3 e 30 letras")]
    public string? Nome { get; set; }

    public int Idade { get; set; }

    [Required(ErrorMessage = "O email é obrigatório")]
    [EmailAddress]
    [MaxLength(50, ErrorMessage = "O email deve ter no máximo 50 letras")]
    public string? Email { get; set; }

    [MaxLength(130, ErrorMessage = "O campo deve ter no máximo 130 letras")]
    public string? Endereco { get; set; }
    
    [MaxLength(300, ErrorMessage = "O campo deve ter no máximo 300 letras")]
    public string? OutrasInformacoes { get; set; }

    [MaxLength(600, ErrorMessage = "O campo deve ter no máximo 600 letras")]
    public string? Interesses { get; set; }

    [MaxLength(600, ErrorMessage = "O campo deve ter no máximo 600 letras")]
    public string? Sentimentos { get; set; }

    [MaxLength(600, ErrorMessage = "O campo deve ter no máximo 600 letras")]
    public string? Valores { get; set; }
    public DateTime DataCadastro { get; set; }
    public bool Ativo { get; set; }
    public bool Deletado { get; set; }
}