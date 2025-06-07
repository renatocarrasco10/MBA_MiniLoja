# Feedback - Avaliação Geral

## Front End

### Navegação
  * Pontos positivos:
    - Projeto MVC (`Loja.UI`) com navegação e views completas para autenticação, produtos e categorias.
    - Funcionalidades acessíveis por rotas bem definidas.

  * Pontos negativos:
    - Nenhum.

### Design
  - Interface clara, funcional e coerente com o objetivo administrativo da aplicação.

### Funcionalidade
  * Pontos positivos:
    - CRUD de produtos e categorias implementado nas camadas MVC e API.
    - Identity funcional com autenticação via JWT na API e Cookies no MVC.
    - A criação do vendedor é feita junto com o usuário no MVC, com ID compartilhado.
    - SQLite implementado corretamente com migrations automáticas e seed de dados funcional no MVC.
    - Arquitetura enxuta com separação clara entre API, MVC e Data.

  * Pontos negativos:
    - A criação do vendedor não ocorre na API, apenas no MVC.
    - A API não atribui automaticamente o ID do usuário logado ao criar produtos.
    - Ao editar um produto, não é verificado se ele pertence ao vendedor autenticado, o que é uma falha de segurança.
    - A API não executa seed de dados.

## Back End

### Arquitetura
  * Pontos positivos:
    - Organização clara e enxuta: API, UI (MVC) e camada de dados (Data).
    - Uso apropriado de SQLite, Identity e configuração modular.

### Funcionalidade
  * Pontos positivos:
    - Funcionalidades principais implementadas com sucesso.

  * Pontos negativos:
    - Falhas em validações de segurança (produto/vendedor).
    - Incompletude funcional da API na criação do vendedor e seed.

### Modelagem
  * Pontos positivos:
    - Entidades bem estruturadas com relacionamentos consistentes.

  * Pontos negativos:
    - Nenhum relevante.

## Projeto

### Organização
  * Pontos positivos:
    - Projeto bem estruturado em `src`, com `.sln` na raiz.
    - Documentação `README.md` e `FEEDBACK.md` presentes.
    - Boa separação entre camadas.

  * Pontos negativos:
    - Nenhum.

### Documentação
  * Pontos positivos:
    - Arquivos de documentação claros e disponíveis.
    - Swagger presente na API.

### Instalação
  * Pontos positivos:
    - Migrations e seed automatizados no MVC com SQLite.

  * Pontos negativos:
    - Seed de dados não implementado na API.

---

# 📊 Matriz de Avaliação de Projetos

| **Critério**                   | **Peso** | **Nota** | **Resultado Ponderado**                  |
|-------------------------------|----------|----------|------------------------------------------|
| **Funcionalidade**            | 30%      | 9        | 2,7                                      |
| **Qualidade do Código**       | 20%      | 9        | 1,8                                      |
| **Eficiência e Desempenho**   | 20%      | 8        | 1,6                                      |
| **Inovação e Diferenciais**   | 10%      | 8        | 0,8                                      |
| **Documentação e Organização**| 10%      | 8        | 0,8                                      |
| **Resolução de Feedbacks**    | 10%      | 8        | 0,8                                      |
| **Total**                     | 100%     | -        | **8,5**                                  |

## 🎯 **Nota Final: 8,5 / 10**
