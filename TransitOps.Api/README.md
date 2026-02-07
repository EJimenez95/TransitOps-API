# TransitOps API

A **.NET 8 ASP.NET Core Web API** for managing transit incidents, built as a portfolio project to demonstrate **CRUD operations, Entity Framework Core, DTOs, enums, and clean API design**.

---

## Features

- Full **CRUD** operations for transit incidents
  - **GET /api/Incidents** → list all incidents
  - **GET /api/Incidents/{id}** → get a specific incident
  - **POST /api/Incidents** → create a new incident
  - **PUT /api/Incidents/{id}** → update an existing incident
  - **DELETE /api/Incidents/{id}** → delete an incident
- **DTOs** for clean separation of API models from database models
- **Severity enum** for type-safe incident levels (Low, Medium, High)
- **Validation** on all input fields
- **Swagger UI** for testing and documentation

---

## Tech Stack

- **.NET 8 / ASP.NET Core Web API**
- **Entity Framework Core** (SQL Server / LocalDB)
- **Visual Studio 2022**
- **Swagger / OpenAPI**

---

## Installation & Running

1. Clone the repository:  
```bash
git clone https://github.com/yourusername/transitops-api.git
cd transitops-api
```

2. Open the solution in **Visual Studio 2022**.

3. Ensure the connection string in `appsettings.json` points to your local SQL Server / LocalDB:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=TransitOpsDb;Trusted_Connection=True;"
}
```

4. Recreate the database (first time only):  
```powershell
Drop-Database
Add-Migration InitialCreate
Update-Database
```

5. Run the API (F5 / Debug).

6. Test endpoints in **Swagger UI**:  
```
https://localhost:{port}/swagger/index.html
```

---

## Example Requests

### Create Incident (POST)
```json
POST /api/Incidents
{
  "title": "Signal failure",
  "description": "Train delayed at station 3",
  "severity": "High"
}
```

### Get All Incidents (GET)
```json
GET /api/Incidents
```

Response:
```json
[
  {
    "id": 1,
    "title": "Signal failure",
    "description": "Train delayed at station 3",
    "severity": "High",
    "createdAt": "2026-02-05T20:00:00Z"
  }
]
```

### Update Incident (PUT)
```json
PUT /api/Incidents/1
{
  "title": "Updated Signal Failure",
  "description": "Delay resolved",
  "severity": "Medium"
}
```

### Delete Incident (DELETE)
```json
DELETE /api/Incidents/1
```

---

## Project Structure

```
TransitOps.Api/
├─ Controllers/
│  └─ IncidentsController.cs
├─ Data/
│  └─ TransitOpsDbContext.cs
├─ Models/
│  ├─ Incident.cs
│  └─ Severity.cs
├─ Dtos/
│  ├─ CreateIncidentDto.cs
│  ├─ UpdateIncidentDto.cs
│  └─ IncidentResponseDto.cs
├─ appsettings.json
└─ Program.cs
```

---

## Skills Demonstrated

- ASP.NET Core Web API development  
- Entity Framework Core + migrations  
- RESTful API design and routing  
- Data validation and DTO mapping  
- Swagger documentation  
- CRUD operations and enum handling

