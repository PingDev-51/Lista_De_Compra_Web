<div align="center">

# 🛒 Lista de Compras

### Sistema de gerenciamento de compras em **ASP.NET MVC com POO**
Controle de categorias, produtos, listas e itens com separação de responsabilidades e regras de negócio reais.

---

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![ASP.NET MVC](https://img.shields.io/badge/ASP.NET-MVC-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white)
![OOP](https://img.shields.io/badge/Paradigm-OOP-blue?style=for-the-badge)
![Status](https://img.shields.io/badge/Status-Concluído-brightgreen?style=for-the-badge)

</div>

---

## 📌 Sobre o Projeto

O **Lista de Compras** nasceu de uma necessidade real: Maria faz as compras da família toda semana, mas sempre esquece algum item ou compra coisas que já tem em casa. Para resolver isso, foi criado um sistema simples e prático para cadastrar produtos, organizar listas e registrar as compras realizadas.

O projeto foi desenvolvido com foco em:

- Organização em camadas (MVC)
- Separação de responsabilidades
- Regras de negócio reais
- Encapsulamento e boas práticas de OOP
- Comunicação entre objetos
- Interface web responsiva e intuitiva

---

## 🎬 Demonstração

> _Veja abaixo o GIF demonstrando o funcionamento da aplicação_

![Demonstração do Sistema](./demo.gif)

---

## ✅ Funcionalidades

### 🏷️ Categorias

- Cadastro de categorias
- Visualização, edição e exclusão
- Seleção de cor via paleta ou hexadecimal

**Regras:**
- Nome obrigatório e único (máx. 50 caracteres)
- Cor obrigatória
- Não é permitido excluir uma categoria com produtos vinculados

---

### 📦 Produtos

- Cadastro de produtos
- Visualização, edição e exclusão
- Associação com categorias

**Regras:**
- Nome obrigatório (2 a 100 caracteres)
- Categoria obrigatória
- Unidade de medida obrigatória (ex: kg, unidade, litro, caixa)
- Preço aproximado obrigatório
- Não pode haver dois produtos com o mesmo nome na mesma categoria

---

### 📋 Listas de Compras

- Criação de listas de compras
- Visualização, edição e exclusão
- Exibição do total de itens e valor estimado por lista

**Regras:**
- Nome obrigatório (3 a 100 caracteres)
- Data de criação gerada automaticamente
- Status possíveis: `Aberta` / `Concluída`
- Não é permitido excluir uma lista que já tenha itens vinculados

---

### 🛍️ Itens da Lista

- Adição e remoção de itens em uma lista
- Visualização de todos os itens com suas categorias
- Cálculo automático do valor total da lista

**Regras:**
- Produto obrigatório
- Quantidade obrigatória (número positivo)
- Não é permitido adicionar o mesmo produto duas vezes na mesma lista
- Valor total calculado automaticamente (preço estimado × quantidade)

---

## 🧠 Conceitos Aplicados

| Conceito | Aplicação |
|---|---|
| 🏗️ Classes e Objetos | Modelagem das entidades do sistema |
| 🔒 Encapsulamento | Proteção dos dados internos |
| 📐 Padrão MVC | Separação entre Model, View e Controller |
| ⚙️ Regras de Negócio | Validações, cálculos automáticos e restrições |
| 🔗 Comunicação entre Classes | Integração entre os módulos |
| 🌐 Aplicação Web | Interface responsiva via navegador |
| 💉 Injeção de Dependência | Baixo acoplamento entre as camadas |
| 🗂️ Camada de Serviços | Regras de negócio separadas dos Controllers |

---

## ⚙️ Tecnologias Utilizadas

- C#
- ASP.NET MVC
- Bootstrap
- AutoMapper
- Programação Orientada a Objetos (POO)

---

## ▶️ Como Executar

### 1. Clone o repositório

```bash
git clone https://github.com/PingDev-51/Lista_De_Compra_Web.git
```

### 2. Acesse a pasta do projeto

```bash
cd lista-de-compras
```

### 3. Execute o projeto

```bash
dotnet run --project ListaDeCompras.WebApp
```

### 4. Acesse no navegador

```
https://localhost:5001
```

---

## 📋 Requisitos

- .NET SDK instalado
- Visual Studio 2022 ou superior

---

## 🎯 Objetivo de Aprendizado

Este projeto foi desenvolvido para praticar:

- ✔️ Programação Orientada a Objetos
- ✔️ Padrão de arquitetura MVC
- ✔️ Desenvolvimento de aplicações web com ASP.NET
- ✔️ Estilização responsiva com Bootstrap
- ✔️ Modelagem de entidades reais com regras de negócio
- ✔️ Injeção de dependência e camada de serviços
- ✔️ Organização modular e código limpo

---

## 👨‍💻 Autores

<div align="center">

Desenvolvido como parte dos estudos em **C# e Programação Orientada a Objetos e Desenvolvimento Web** na **Academia do Programador**.

<!-- Substitua pelos links reais dos autores -->
[![GitHub](https://img.shields.io/badge/GitHub-KauanGalvani-181717?style=for-the-badge&logo=github)](https://github.com/KauanGalvani)
[![GitHub](https://img.shields.io/badge/GitHub-k--silvax19-181717?style=for-the-badge&logo=github)](https://github.com/k-silvax19)

</div>
