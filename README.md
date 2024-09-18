# Projeto de API dA LoremIpsumLogistica

## Descrição

Esta é uma API RESTful para gerenciar [descreva brevemente o propósito da API, como "clientes e endereços"]. Ela oferece endpoints para [listar/criar/atualizar/excluir] recursos, permitindo [descreva funcionalidades principais, como "gerenciar informações de clientes e endereços associados"].

## Pré-requisitos
Certifique-se de ter os seguintes pré-requisitos instalados:

Node.js (versão X.X.X ou superior)
npm (gerenciador de pacotes Node.js)
Banco de Dados Microsoft SQL Server

## Instalação
Siga os passos abaixo para configurar e executar a API:

1. **Clone o repositório:**

```git clone https://github.com/brunodotnetdeveloper/LoremIpsumLogisticaApi.git```

```cd LoremIpsumLogisticaApi```

2. **Abra a solução com o Visual Studio ou VS Code:**

3. **Configure o appsettings.json para apontar para seu banco de dados**

```{
  "ConnectionStrings": {
    "LoremIpsumLogisticaConnectionString": "Server=BRUNO\\INNOVACODE;Database=LoremIpsumLogistica;User Id=sa;Password=123456;TrustServerCertificate=True;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}```
