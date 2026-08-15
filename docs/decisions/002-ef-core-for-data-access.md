# ADR 002 - Use EF Core for data access

## Status
Accepted

## Decision
The Admin Portal will use Entity Framework Core for data access.

Repositories will use DbContext and LINQ instead of MySqlConnector with handwritten SQL.

The application will keep the existing service and repository layers.

## Reason
EF Core reduces manual SQL and object mapping code.

Using EF Core also allows the project to apply LINQ and DbContext patterns learned in ASP.NET.

## Alternatives considered
- MySqlConnector with handwritten SQL
- Razor Pages directly using DbContext

## Date
2026-08-15