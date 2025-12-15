# **Map Making Tool — Backend**

A REST API backend for the Map Making Tool that powers the creation, management, and storage of maps, floors, cells, rooms, and icons used by the frontend application.

**Link to the Frontend:** https://github.com/Gabriel2002Can/Frontend-map-making

---

## **Overview**

The backend is a lightweight ASP.NET Core Web API that persists all map data for the frontend editor and viewer. It exposes REST endpoints and uses Entity Framework Core to interact with a SQL Server database.

---

## **API Resources**

### **Maps**

The top-level container for organizing your floor plans.

**Available operations:**

- **Get all maps** — Retrieve a list of all maps with their metadata
- **Get a single map** — Fetch details of a specific map including its floors
- **Create a map** — Add a new map to the system
- **Update a map** — Modify map properties (e.g., rename)
- **Delete a map** — Remove a map and all associated data

---

### **Floors**

Each map can contain multiple floors representing different levels of a building.

**Available operations:**

- **Get floors for a map** — List all floors belonging to a specific map
- **Get a single floor** — Retrieve floor details including all cells
- **Create a floor** — Add a new floor with name, number, and dimensions
- **Update a floor** — Modify floor properties
- **Delete a floor** — Remove a floor and its cells

**Floor properties:**

- **Name** — Descriptive name (e.g., "Ground Floor", "Basement")
- **Number** — Numeric identifier for ordering
- **Dimensions** — Width and height of the grid (1-50 cells each)

---

### **Cells**

The building blocks of each floor — individual grid squares that make up the layout.

**Available operations:**

- **Get cells for a floor** — Retrieve all cells belonging to a floor
- **Bulk update cells** — Save multiple cell changes at once (optimized for the editor)

**Cell properties:**

- **Position** — X and Y coordinates on the grid
- **Fill state** — Whether the cell is filled or empty
- **Room assignment** — Which room the cell belongs to (if any)
- **Icon** — Optional icon placed on the cell

---

### **Rooms**

Named areas that group multiple cells together with visual styling.

**Room properties:**

- **Name** — Descriptive name for the room
- **Color** — Visual color for highlighting the room on the map

---

### **Icons**

Visual markers that can be placed on cells to indicate features.

**Icon uses:**

- Doors, stairs, elevators
- Points of interest
- Custom markers

---

## **Data Model**

The backend stores data in the following structure:

```
Map
 └── Floors
      └── Cells
           ├── Room (optional)
           └── Icon (optional)
```

- **Map** — Top-level container with name and timestamps
- **Floor** — Belongs to a Map, defines grid dimensions
- **Cell** — Grid position with fill state and optional associations
- **Room** — Grouping entity with name and color
- **Icon** — Marker type for cell decoration

---

## **How It Connects to the Frontend**

| Frontend Feature | Backend Support                        |
| ---------------- | -------------------------------------- |
| Map Management   | CRUD operations for maps               |
| Floor Creation   | Create floor with auto-generated cells |
| Floor Editor     | Bulk cell updates (fill, rooms, icons) |
| Floor View       | Read floor with all cell data          |
| Room Assignment  | Room creation and cell associations    |
| Icon Placement   | Icon storage per cell                  |

---

## **Getting Started**

### **Prerequisites**

- .NET SDK
- SQL Server

### **Running the API**

1. **Configure the database** — Set your connection string in `appsettings.json` under `ConnectionStrings:DefaultConnection`

2. **Restore dependencies**

   ```
   dotnet restore
   ```

3. **Apply database migrations** (optional — migrations run automatically on startup)

   ```
   dotnet ef database update
   ```

4. **Run the application**

   ```
   dotnet run
   ```

5. **Explore the API** — In development, Swagger UI is available for testing endpoints

---

## **Project Structure**

| Folder/File        | Purpose                                                |
| ------------------ | ------------------------------------------------------ |
| `Program.cs`       | Application startup, service registration, CORS policy |
| `Controllers/`     | REST API endpoints                                     |
| `Models/`          | Domain entities (Map, Floor, Cell, Room, Icon)         |
| `DTO/`             | Data transfer objects for API contracts                |
| `Data/`            | EF Core DbContext and database configuration           |
| `appsettings.json` | Configuration including connection strings             |

---

## **Configuration Notes**

- **CORS** — Configured to allow frontend origins (development and production)
- **Swagger** — Enabled in development mode for API exploration
- **Migrations** — Applied automatically on startup when using a relational database

---

## **Future Features**

- Pin placement and customization (markers with text, images, or links)
- Enhanced interactive map navigation
- Additional icon types and customization options
- Users and Roles
