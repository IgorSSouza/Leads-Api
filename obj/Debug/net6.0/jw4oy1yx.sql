START TRANSACTION;

ALTER TABLE `Saidas` ADD `ParcelaCartaoCreditoId` int NULL;

CREATE INDEX `IX_Saidas_ParcelaCartaoCreditoId` ON `Saidas` (`ParcelaCartaoCreditoId`);

ALTER TABLE `Saidas` ADD CONSTRAINT `FK_Saidas_ParcelasCartaoCredito_ParcelaCartaoCreditoId` FOREIGN KEY (`ParcelaCartaoCreditoId`) REFERENCES `ParcelasCartaoCredito` (`Id`);

DELETE FROM `__EFMigrationsHistory`
WHERE `MigrationId` = '20230519120937_UpdateParcelas';

COMMIT;

START TRANSACTION;

ALTER TABLE `ParcelasCartaoCredito` MODIFY COLUMN `dataVencimento` int NOT NULL;

DELETE FROM `__EFMigrationsHistory`
WHERE `MigrationId` = '20230518132844_UpdateDateTime';

COMMIT;

START TRANSACTION;

ALTER TABLE `ParcelasCartaoCredito` MODIFY COLUMN `valor` int NOT NULL;

DELETE FROM `__EFMigrationsHistory`
WHERE `MigrationId` = '20230518131502_UpdateValorNumeroParcelas';

COMMIT;

START TRANSACTION;

ALTER TABLE `Saidas` DROP COLUMN `Parcelas`;

DELETE FROM `__EFMigrationsHistory`
WHERE `MigrationId` = '20230518130346_AddColumnParcelas';

COMMIT;

START TRANSACTION;

ALTER TABLE `Saidas` DROP FOREIGN KEY `FK_Saidas_ParcelasCartaoCredito_ParcelaCartaoCreditoId`;

DROP TABLE `ParcelasCartaoCredito`;

ALTER TABLE `Saidas` DROP INDEX `IX_Saidas_ParcelaCartaoCreditoId`;

ALTER TABLE `Saidas` DROP COLUMN `ParcelaCartaoCreditoId`;

DELETE FROM `__EFMigrationsHistory`
WHERE `MigrationId` = '20230518125832_AddTableParcelas';

COMMIT;

START TRANSACTION;

ALTER TABLE `Saidas` DROP COLUMN `Status`;

ALTER TABLE `Entradas` DROP COLUMN `Status`;

ALTER TABLE `Transacoes` ADD `DataAtualizacao` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6);

ALTER TABLE `Transacoes` ADD `Status` int NOT NULL DEFAULT 0;

DELETE FROM `__EFMigrationsHistory`
WHERE `MigrationId` = '20230516125715_UpdateColumsAddStatus';

COMMIT;

START TRANSACTION;

ALTER TABLE `Transacoes` DROP FOREIGN KEY `FK_Transacoes_Entradas_EntradaId`;

ALTER TABLE `Transacoes` DROP FOREIGN KEY `FK_Transacoes_Saidas_SaidaId`;

ALTER TABLE `Transacoes` MODIFY COLUMN `SaidaId` int NOT NULL DEFAULT 0;

ALTER TABLE `Transacoes` MODIFY COLUMN `EntradaId` int NOT NULL DEFAULT 0;

ALTER TABLE `Transacoes` MODIFY COLUMN `DataAtualizacao` datetime(6) NOT NULL;

ALTER TABLE `Saidas` MODIFY COLUMN `DataAtualizacao` datetime(6) NOT NULL;

ALTER TABLE `Entradas` MODIFY COLUMN `DataAtualizacao` datetime(6) NOT NULL;

ALTER TABLE `Transacoes` ADD CONSTRAINT `FK_Transacoes_Entradas_EntradaId` FOREIGN KEY (`EntradaId`) REFERENCES `Entradas` (`Id`) ON DELETE CASCADE;

ALTER TABLE `Transacoes` ADD CONSTRAINT `FK_Transacoes_Saidas_SaidaId` FOREIGN KEY (`SaidaId`) REFERENCES `Saidas` (`Id`) ON DELETE CASCADE;

DELETE FROM `__EFMigrationsHistory`
WHERE `MigrationId` = '20230515185726_UpdateColumsNull';

COMMIT;

START TRANSACTION;

ALTER TABLE `Saidas` MODIFY COLUMN `Valor` double NOT NULL;

ALTER TABLE `Saidas` MODIFY COLUMN `Titulo` longtext CHARACTER SET utf8mb4 NULL;

ALTER TABLE `FormasPagamentos` MODIFY COLUMN `Nome` longtext CHARACTER SET utf8mb4 NULL;

ALTER TABLE `Entradas` MODIFY COLUMN `Valor` double NOT NULL;

ALTER TABLE `Entradas` MODIFY COLUMN `Titulo` longtext CHARACTER SET utf8mb4 NULL;

ALTER TABLE `Categorias` MODIFY COLUMN `Nome` longtext CHARACTER SET utf8mb4 NULL;

DELETE FROM `__EFMigrationsHistory`
WHERE `MigrationId` = '20230515140707_UpdateColums';

COMMIT;

START TRANSACTION;

ALTER TABLE `Transacoes` DROP COLUMN `Status`;

DELETE FROM `__EFMigrationsHistory`
WHERE `MigrationId` = '20230515125158_InitialCreateUpdate';

COMMIT;

START TRANSACTION;

DROP TABLE `Transacoes`;

DROP TABLE `Entradas`;

DROP TABLE `Saidas`;

DROP TABLE `Categorias`;

DROP TABLE `FormasPagamentos`;

DELETE FROM `__EFMigrationsHistory`
WHERE `MigrationId` = '20230512191333_InicialCreate';

COMMIT;

