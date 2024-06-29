CREATE TABLE "Customers"(
    "Id" UUID NOT NULL,
    "Name" VARCHAR(100) NOT NULL,
    "Email" VARCHAR(100) NOT NULL,
    "Address" VARCHAR(100) NOT NULL,
    PRIMARY KEY ("Id")
);

CREATE TABLE "Products" (
    "Id" UUID NOT NULL,
    "Name" VARCHAR(100) NOT NULL,
    PRIMARY KEY ("Id")
);

CREATE TABLE "Billing" (
    "Id" UUID NOT NULL,
    "InvoiceNumber" VARCHAR(100) NOT NULL,
    "Date" DATE NOT NULL,
    "DueDate" DATE NOT NULL,
    "TotalAmount" INT4 NOT NULL,
    "Currency" VARCHAR(10) NOT NULL,
    "CustomerId" UUID NOT NULL,
    PRIMARY KEY ("Id"),
    FOREIGN KEY ("CustomerId") REFERENCES "Customers"("Id")
);

CREATE TABLE "BillingLine" (
    "Id" UUID NOT NULL,
    "Description" VARCHAR(100) NOT NULL,
    "Quantity" INT4 NOT NULL,
    "UnitPrice" NUMERIC(5, 2) NOT NULL,
    "ProductId" UUID NOT NULL,
    "BillingId" UUID NOT NULL,
    PRIMARY KEY ("Id"),
    FOREIGN KEY ("ProductId") REFERENCES "Products"("Id"),
    FOREIGN KEY ("BillingId") REFERENCES "Billing"("Id")
);