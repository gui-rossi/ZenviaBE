# Zenvia challenge web app

A aplicação é formada por um frontend (ZenviaFE) em ReactJS e um backend (ZenviaBE) em .NET. Com SQL Server na azure.

## Sobre o Backend:

A solução foi dividida nos seguintes projetos: WebAPI que possui controllers, UserBusiness que possui a services, UserRepository que possui as
chamadas de database e a UserDomain que possui as entidades e view models.

O projeto usa entity framework code-first com SQL server. 
Nas controllers temos 3 endpoints: um Get que pega todos os usuarios da app, um Post que adiciona usuario e um Put que atualiza usuario.
Há alguma validação de cpf, rg e id na adição de modificação de usuarios. Além do mapeamento entre entidades e view models.
O mapeamento esta nas services, o ideal seria colocar elas em uma classe separada.

O projeto segue conceitos de clean code, utilização de inversão de controle com injeção de dependencia e generics.
Há um repositorio base com metodos em comum entre os outros repositorios.

A estrutura funciona com o usuario tendo as informações base em uma tabela e referencias para outras 2 tabelas, de telefones e endereços, ja que o mesmo pode ter muitos de cada.
Portanto a estrutura fica que o usuario tem uma relacao de 1:n com telefones e enderecos

![merr](https://user-images.githubusercontent.com/70178925/174519620-2c4dc831-b562-49be-8f72-da01b01553c7.png)
