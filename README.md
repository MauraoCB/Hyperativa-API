# Hyperativa-API

Preparando o projeto para execução:
1 - Executar o script Create_Database.sql da pasta SQL do projeto
2 - Criar o diretório C:\CartaoLote (pode ser outro nome e em outro disco, nesse caso deve alterar a chave CartaoLotePath do app.settings do projeto)
3 - Baixar o arquivo DESAFIO-HYPERATIVA.TXT no diretório criado no passo acima

Executando a aplicação:
1 - Carregar a solution no Visual Studio (preferencialmente 2019)
2 - Executar (será carregada a interface do Swagger)
3 - Executar o método Login antes de qualquer outro e copiar o token retornado
4 - Clicar no botão Authorize
5 - No campo value digitar Bearer um espaço em branco e colar o token copiado no passo 3 
6 - Clique no botão Authorize da caixa de diálogo e em seguida no botão close

Seguidos os passos acima a API está pronta para ser testada.

Obs. Caso opte por fazer o teste pelo SoapUI ou pelo Postman, deve colocar o token no cabeçalho da chamada da API
