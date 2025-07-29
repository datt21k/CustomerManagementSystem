-- Initial Database Schema

CREATE TABLE IF NOT EXISTS public."Customers"
(
    "Id" SERIAL PRIMARY KEY,
    "FirstName" VARCHAR(100) NOT NULL,
    "LastName" VARCHAR(100) NOT NULL,
    "Email" VARCHAR(255) NOT NULL UNIQUE,
    "PhoneNumber" VARCHAR(20),
    "StreetAddress" VARCHAR(200),
    "City" VARCHAR(100),
    "State" VARCHAR(100),
    "PostalCode" VARCHAR(20),
    "Country" VARCHAR(100),
    "Occupation" VARCHAR(200),
    "Company" VARCHAR(200),
    "CreatedAt" TIMESTAMP WITH TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" TIMESTAMP WITH TIME ZONE
);

-- Create index on Email
CREATE UNIQUE INDEX IF NOT EXISTS "IX_Customers_Email" ON public."Customers"("Email");

-- Create index on LastName for faster searches
CREATE INDEX IF NOT EXISTS "IX_Customers_LastName" ON public."Customers"("LastName");

-- Create index on CreatedAt for sorting
CREATE INDEX IF NOT EXISTS "IX_Customers_CreatedAt" ON public."Customers"("CreatedAt" DESC);
