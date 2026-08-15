# ADR 001 - Use layered architecture

## Status
Accepted

## Decision
The Admin Portal will use a layered architecture:

Razor Pages → Services → Repositories → EF Core / DbContext → MySQL

## Reason
To separate UI, business logic, and data access.

This also allows the project to use EF Core and LINQ while keeping
the existing service and repository structure.

## Alternatives considered
- Razor Pages directly using DbContext
- Repository layer with MySqlConnector and handwritten SQL

## Date
2026-08-15