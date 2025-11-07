# Containerização do VoeAltoPipas

Este diretório contém os arquivos e instruções necessários para executar o projeto VoeAltoPipas em containers Docker.

## 📋 Pré-requisitos

- Docker instalado (versão 20.10.0 ou superior)
- Docker Compose v2.x

## 🚀 Quickstart

1. **Iniciar a aplicação**
   ```bash
   docker compose up -d
   ```

2. **Verificar se está rodando**
   ```bash
   docker compose ps
   ```

3. **Acessar a aplicação**
   - API: http://localhost:8080/api/produto
   - Swagger: http://localhost:8080/swagger

## 🛠️ Ambiente de Desenvolvimento

### Estrutura
```
docker/
  ├── README.md     # Esta documentação
  ├── init.sql      # Script de inicialização do banco
  └── Dockerfile    # Build da imagem da API
docker-compose.yml  # Configuração dos serviços
```

### Serviços

- **api**: ASP.NET Core API (porta 8080)
  - Endpoints REST para gerenciamento de produtos
  - Swagger UI disponível

- **db**: MySQL 8.0 (porta 3306)
  - Dados persistidos em volume Docker
  - Script de inicialização automática

### Variáveis de Ambiente

**API**:
- `ConnectionStrings__DefaultConnection`: String de conexão com o MySQL
  - Padrão: `Server=db;Database=voealtopipas_db;User=root;Password=RootPass123;`

**MySQL**:
- `MYSQL_ROOT_PASSWORD`: Senha do root
- `MYSQL_DATABASE`: Nome do banco de dados

## 🔄 Comandos Úteis

```bash
# Reconstruir a imagem da API
docker compose build api

# Ver logs
docker compose logs -f api    # Logs da API
docker compose logs -f db     # Logs do MySQL

# Parar todos os serviços
docker compose down

# Parar e remover volumes (reset do banco)
docker compose down -v

# Executar comando no MySQL
docker compose exec db mysql -uroot -pRootPass123 voealtopipas_db
```

## 📝 Notas

- O banco é inicializado automaticamente com produtos de exemplo
- As imagens dos produtos são armazenadas em `/root/imagens/` no container da API
- O Swagger está disponível para testar os endpoints

## 🔨 Customização

### Produtos Iniciais
Para modificar os produtos iniciais, edite `init.sql` e recrie os containers:
```bash
docker compose down -v
docker compose up -d
```

### Portas
Para mudar as portas, edite o `docker-compose.yml`:
```yaml
services:
  api:
    ports:
      - "8080:8080"  # Altere o primeiro número (porta do host)
```