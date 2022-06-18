using UserDomain.UserProperties;

namespace UserDomain.ViewModels
{
    public class UserViewModel
    {
        public Informacoes informacoes { get; set; }
        public ICollection<Endereco> enderecos { get; set; }
        public ICollection<Telefone> telefones { get; set; }
    }
}
