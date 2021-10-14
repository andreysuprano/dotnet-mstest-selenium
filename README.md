# Template para Projetos de automação de testes de interface
_______________

# Tecnologias usadas

- Selenium
- Selenium Grid
- SpecFlow
- .NET Core
- Docker

# Como executar
_____________

### Execução com Selenium Grid

Para uma execução simples, pode-se executar apenas o selenium server e assim executar os testes remotamente, para iniciar o server execute o comando a baixo:
```SHELL
java -jar selenium-server-<version>.jar standalone
```
OBS: Por padrão o selenium server escuta em http://localhost:4444/ 


Para uma execução distribuida, é possível executar a configuração de um hub e consecutivamente os nós e assim distribuir os testes em diversos navegadores, podendo além de tudo paralelizar os testes.

Para executar o selenium server com um hub execute:

```SHELL
java -jar selenium-server-<version>.jar hub
```
As configurações de hub e nós estão sendo feitas dentro do arquivo ```hubConfig.json```

### Execução sem Selenium Grid

Para execução local sem utilização do Selenium Grid, pode-se alterar dentro do arquivo de execução .runsettings para execução local ao invés de remota, sendo assim ele volta a utilizar o webdriver local presente na raiz do projeto.

OBS: Lmebrar de verificar a versão do Chrome e do WebDriver na hora da execução.

