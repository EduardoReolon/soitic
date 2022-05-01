# Desafio técnico Soitic

Essa é a aplicação desenvolvida para o desafio técnico da Soitic

## Instalação

Necessário ter [.Net 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0 ".Net 6") instalado

## Uso

### Configurações iniciais

Todos os procedimentos executados na pasta server.

Copiar o arquivo appsettings.json.example para a mesma pasta mas com o nome appsettings.json. Adicionar nesse as configurações do banco de dados MySQL local. O schema deve existir ou ser criado no banco antes dos próximos passos

Rodar a seguinte linha de comando para que as tabelas sejam criadas
```
dotnet-ef database update
```

### Iniciar a aplicação

```
dotnet run
```

Agora a aplicação deve estar rodando no endereço https://localhost:7132 (caso esse não tenha sido alterado)

### Uso

No endereço acima é possível acessar o cliente, navegar nas páginas, adicionar/excluir/editar filmes e diretores.

### Considerações finais

Acredito que o objetivo do teste seja avaliar a qualidade/organização dos códigos, por tanto não me preocupei com o visual ou até mesmo com as notificações de possíveis erros para o usuário. Se esses forem necessários, me informar que providencio.