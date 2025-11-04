# Backend-map API

Concise documentation of available endpoints, expected payloads, and responses.

- Base URLs (Development):
  - HTTP: http://localhost:5069
  - HTTPS: https://localhost:7219
- Swagger UI: {BaseUrl}/swagger

## Models

- Map
  - id: int
  - name: string
  - floors: Floor[]
  - numberOfFloors: int (computed)

- Floor
  - id: int
  - name: string
  - number: int
  - dimensionX: int
  - dimensionY: int
  - mapId: int
  - cells: Cell[]

- Cell
  - id: int
  - x: int
  - y: int
  - isFilled: bool
  - floorId: int

- FloorDTO (request body for creating a floor)
  - name: string
  - number: int
  - dimensionX: int
  - dimensionY: int
  - mapId: int

- CellsDTO (request body for updating cells)
  - floorId: int
  - cells: CellUpdateDTO[]

- CellUpdateDTO
  - x: int
  - y: int
  - isFilled: bool

Notes:
- `GET /api/map` and `GET /api/map/{id}` include `floors`. Floor `cells` are included only on `GET /api/floor/{floorId}`.

---

## Map endpoints

### GET `/api/map`
Returns all maps with their floors.

- Response 200 application/json: Array of Map

Example response (truncated):
```
[
  {
    "id": 1,
    "name": "Sample Map",
    "floors": [
      {
        "id": 1,
        "name": "Floor 1",
        "number": 1,
        "dimensionX": 10,
        "dimensionY": 10,
        "mapId": 1,
        "cells": null
      }
    ],
    "numberOfFloors": 1
  }
]
```

### GET `/api/map/{id}`
Returns a single map by id with its floors.

- Response 200 application/json: Map
- Response 404: Not Found

### POST `/api/map`
Creates a new map.

- Parameters: query or form
  - name: string (required)
- Body: none (simple type binding from query/form)
- Response 201 application/json: Created Map

Example request:
```
POST {BaseUrl}/api/map?name=Office%20Map
```

Example response:
```
{
  "id": 2,
  "name": "Office Map",
  "floors": [],
  "numberOfFloors": 0
}
```

### DELETE `/api/map/{id}`
Deletes a map by id (cascades to floors and cells).

- Response 204: No Content
- Response 404: Not Found

---

## Floor endpoints

### GET `/api/floor/{floorId}`
Returns a floor by id including its cells.

- Response 200 application/json: Floor
- Response 404: Not Found

Example response (truncated):
```
{
  "id": 1,
  "name": "Floor 1",
  "number": 1,
  "dimensionX": 10,
  "dimensionY": 10,
  "mapId": 1,
  "cells": [
    { "id": 1, "x": 1, "y": 1, "isFilled": false, "floorId": 1 },
    { "id": 2, "x": 1, "y": 2, "isFilled": true,  "floorId": 1 }
  ]
}
```

### POST `/api/floor`
Creates a new floor and populates cells for the given dimensions.

- Content-Type: application/json
- Body: FloorDTO
```
{
  "name": "Floor 2",
  "number": 2,
  "dimensionX": 10,
  "dimensionY": 12,
  "mapId": 1
}
```
- Response 201 application/json: Created Floor (with generated cells)

### DELETE `/api/floor/{floorId}`
Deletes a floor by id (cascades to cells).

- Response 204: No Content
- Response 404: Not Found

---

## Cell endpoints

### POST `/api/cell/update`
Bulk updates cells by coordinates on a specific floor.

- Content-Type: application/json
- Body: CellsDTO
```
{
  "floorId": 1,
  "cells": [
    { "x": 2, "y": 3, "isFilled": true },
    { "x": 2, "y": 4, "isFilled": false }
  ]
}
```
- Response 204: No Content

Notes:
- Only cells matching the given `floorId` and coordinates are updated.
- Cells not found are silently ignored.

---

## Status codes summary
- 200 OK: Successful GET.
- 201 Created: Resource created.
- 204 No Content: Successful delete/update with no body.
- 400 Bad Request: Invalid or missing payload (creation endpoints).
- 404 Not Found: Resource not found.
