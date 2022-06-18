using UserDomain.UserProperties;

namespace UserDomain.ViewModels
{
    public class UserViewModel
    {
        public Informacoes informacoes { get; set; }
        public List<Endereco> enderecos { get; set; }
        public List<Telefone> telefones { get; set; }
    }
}
