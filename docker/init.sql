-- init.sql: cria a tabela Produtos se não existir
CREATE TABLE IF NOT EXISTS `Produtos` (
  `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `Nome` VARCHAR(255) NOT NULL,
  `Preco` DECIMAL(18,2) NOT NULL,
  `Descricao` TEXT NOT NULL,
  `ImagemUrl` VARCHAR(500) NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Inserir dados iniciais de produtos
INSERT INTO `Produtos` (`Nome`, `Preco`, `Descricao`, `ImagemUrl`) VALUES
-- Pipas
('Pipa Colorida Grande', 45.90, 'Pipa profissional grande (80cm) feita com papel de seda premium e varetas de bambu selecionado. Ideal para ventos médios a fortes. Inclui rabiola de segurança.', '/imagens/pipa-colorida.jpg'),
('Pipa Capucheta', 29.90, 'Pipa estilo capucheta (50cm) leve e ágil, perfeita para manobras. Papel especial e armação reforçada. Ótima para iniciantes.', '/imagens/pipa-capucheta.jpg'),
('Pipa Paraquedas', 52.90, 'Pipa modelo paraquedas (100cm) com design estável e excelente sustentação. Material náilon impermeável e varetas flexíveis.', '/imagens/pipa-paraquedas.jpg'),

-- Linhas
('Linha 10 Premium 500m', 32.90, 'Linha especial nº 10 com 500 metros, resistente e testada. Ideal para pipas médias. Embalagem com carretel.', '/imagens/linha-10.jpg'),
('Linha 20 Profissional 1000m', 64.90, 'Linha profissional nº 20 com 1000 metros de alta resistência. Recomendada para pipas grandes.', '/imagens/linha-20.jpg'),

-- Carretéis
('Carretel Grande Madeira', 28.90, 'Carretel de madeira tratada tamanho grande, com capacidade para até 500m de linha. Pegada ergonômica.', '/imagens/carretel-madeira.jpg'),
('Carretel Plástico Profissional', 34.90, 'Carretel em plástico resistente com rolamento. Capacidade 1000m de linha. Design profissional.', '/imagens/carretel-plastico.jpg'),

-- Acessórios
('Kit Proteção Premium', 89.90, 'Kit completo com luva de proteção, óculos de segurança e cinto porta-carretel. Equipamentos certificados.', '/imagens/kit-protecao.jpg'),
('Rabiola Cetim 5m', 15.90, 'Rabiola de cetim colorido com 5 metros. Leve e durável, proporciona estabilidade à pipa.', '/imagens/rabiola.jpg'),
('Varetas Bambu 10un', 18.90, 'Conjunto com 10 varetas de bambu selecionado e tratado. Tamanhos diversos para manutenção.', '/imagens/varetas.jpg');
