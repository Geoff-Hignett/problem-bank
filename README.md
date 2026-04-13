# Problem Questions API

A lightweight ASP.NET Core Web API for storing and managing “problem questions” (flagged questions) from revision sets using Entity Framework.

## Overview

This API allows a frontend application to:

- ✅ Add a question to a “problem list”
- 📥 Retrieve all problem questions
- ❌ Remove a specific question
- 🧹 Clear all problem questions

Data is persisted using a database via Entity Framework Core.

## Tech Stack

- ASP.NET Core Web API
- Entity Framework Core
- SQLite (or configurable DB via AppDbContext)

## Base Route

`/api/problem-questions`

## Endpoints

### Get all problem questions

GET `/api/problem-questions`

Returns a list of all stored question IDs.

### Response

```id="4imw9x"
[
  "architecture-1-1",
  "javascript-2-3"
]
```

### Add a problem question

POST `/api/problem-questions`

Adds a question to the list (if it doesn’t already exist).

### Request Body

```id="4imw9x"
{
  "questionId": "architecture-1-1"
}
```

### Response

`200 OK` if added or already exists

### Delete a specific question

DELETE `/api/problem-questions/{questionId}`

Removes a single question from the database.

### Example

`DELETE /api/problem-questions/architecture-1-1`

### Response

- `204 No Content` → successfully deleted
- `404 Not Found` → question does not exist

### Clear all problem questions

DELETE `/api/problem-questions`

Removes all entries from the database.

### Response

`204 No Content`

## Setup

1. Install dependencies
2. Run migrations (if applicable):

`dotnet ef database update`

3. Start the API:

`dotnet run`

4. Open Swagger (in development)

`https://localhost:{port}/swagger`
