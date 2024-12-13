using System.ComponentModel.DataAnnotations;

namespace APIOperacaoCuriosidade.Models; 
public class Usuario {
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório")]
    [Length(3, 30, ErrorMessage = "O nome deve ter entre 3 e 30 letras")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "O email é obrigatório")]
    [EmailAddress]
    [MaxLength(50, ErrorMessage = "O email deve ter no máximo 50 letras")]
    public string? Email { get; set; }

    [MinLength(3, ErrorMessage = "A senha deve ter no mínimo 3 caracteres")]
    public string? Senha { get; set; }
    public bool Deletado { get; set; }
}