# **Map making Tool --- Backend**

This project is a full-stack web application designed to create, manage, and visualize maps, their layers, and individual cells.
It includes a backend API for data management and a frontend interface for interacting with maps.

**Link to the Frontend:** https://github.com/Gabriel2002Can/Frontend-map-making

# **Overview**:

The application allows users to:

- Create and list maps

- Add and manage layers within each map

- Automatically generate cells for each layer upon creation

- Visualize maps and layers through an interactive frontend

- **Future functionality will include the ability to add pins (markers) to the map that display text, images, or links when clicked.**

# **Architecture**

The project is divided into two main parts:

**Backend**

- Provides a REST API for managing maps, layers, and cells.

- Handles automatic cell generation whenever a new layer is created.

- Connects to a database that stores all map, layer, and cell data.

Typical endpoints include:

- GET /maps → Returns all maps

- POST /maps → Creates a new map

- GET /maps/{id}/layers → Returns all layers of a specific map

- POST /layers → Creates a new layer (and its cells)

- GET /layers/{id} → Returns a layer with all its cells

**Frontend**

- Allows users to visualize maps and layers in a user-friendly interface.

- Supports map creation directly from the UI.

Future updates will include:

- Layer editing tools

- Pin placement and customization

- Interactive map navigation

# **Technologies Used**

**Backend: .NET (C#)**

**Frontend: Vue**

**Database: Azure SQL**

**API: RESTful architecture**
