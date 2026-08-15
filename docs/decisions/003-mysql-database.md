# ADR 003 - Use MySQL as database

## Status
Accepted

## Decision
The Admin Portal will use the existing MySQL database from the Capstone project.

Entity Framework Core will connect to this MySQL database.

## Reason
The Capstone project already uses MySQL and the database schema already contains the required application data.

Reusing the existing database avoids unnecessary database migration and keeps the Admin Portal aligned with the original Capstone project.

## Alternatives considered
- PostgreSQL
- SQLite
- Creating a new database from scratch

## Date
2026-08-15