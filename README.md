
## Como rodar a aplicação

1) Necessário a instalação do banco de dados Postgres, a instalação deve ser feita na porta padrão **5432** e a senha para o banco deve ser **admin**

2) Fazer o clone do repositório com o comando: **git clone https://github.com/DanielCFreitas/ca-backend-test-nexer.git**

3) Criar as tabelas para o banco usando as migrations:

3.1) Fazer a instalação do **dotnet-ef** para conseguir gerar as tabelas que estão na aplicação através das migrations, com o comando: **dotnet tool install --global dotnet-ef**

3.2) Ir até a pasta que está o arquivo **.csproj** do projeto **NexusTest.Infraestructure**:
dotnet ef database update -s ..\NexusTest.Api\ 

3.3) Caso queira o script sql do DDL e não queira rodar as migrations segue a criação das tabelas:




```sql
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Customer" (
    "Id" uuid NOT NULL,
    "Name" VARCHAR(100) NOT NULL,
    "Email" VARCHAR(100) NOT NULL,
    "Address" VARCHAR(100) NOT NULL,
    CONSTRAINT "PK_Customer" PRIMARY KEY ("Id")
);

CREATE TABLE "Product" (
    "Id" uuid NOT NULL,
    "Name" VARCHAR(100) NOT NULL,
    CONSTRAINT "PK_Product" PRIMARY KEY ("Id")
);

CREATE TABLE "Billing" (
    "Id" uuid NOT NULL,
    "InvoiceNumber" VARCHAR(100) NOT NULL,
    "Date" timestamp with time zone NOT NULL,
    "DueDate" timestamp with time zone NOT NULL,
    "Currency" VARCHAR(10) NOT NULL,
    "CustomerId" uuid NOT NULL,
    CONSTRAINT "PK_Billing" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Billing_Customer_CustomerId" FOREIGN KEY ("CustomerId") REFERENCES "Customer" ("Id") ON DELETE CASCADE
);

CREATE TABLE "BillingLine" (
    "Id" uuid NOT NULL,
    "Description" VARCHAR(100) NOT NULL,
    "Quantity" integer NOT NULL,
    "UnitPrice" numeric NOT NULL,
    "BillingId" uuid NOT NULL,
    "ProductId" uuid NOT NULL,
    CONSTRAINT "PK_BillingLine" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_BillingLine_Billing_BillingId" FOREIGN KEY ("BillingId") REFERENCES "Billing" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_BillingLine_Product_ProductId" FOREIGN KEY ("ProductId") REFERENCES "Product" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_Billing_CustomerId" ON "Billing" ("CustomerId");

CREATE INDEX "IX_BillingLine_BillingId" ON "BillingLine" ("BillingId");

CREATE INDEX "IX_BillingLine_ProductId" ON "BillingLine" ("ProductId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240629154516_TabelasBaseParaAplicacao', '8.0.6');

COMMIT;
```
