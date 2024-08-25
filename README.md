# DotNet Todos Api
A simple Dotnet api with CRUD operations for Todos

## Routes
Request schema for POST and PUT
```sh
{
  "title": "string",
  "description": "string"
}

```
### Todos
- GET retrieve all Todos 
    ```sh
    http://localhost:[PORT]/api/Todos
    ```
- GET retrieve a single Todo
    ```sh
    http://localhost:[PORT]/api/Todos/{id}
    ```
- POST create a Todo
    ```sh
    http://localhost:[PORT]/api/Todos
    ```
- PUT update a Todo
    ```sh
    http://localhost:[PORT]/api/Todos/{id}
    ```
- DELETE remove a Todo
    ```sh
    http://localhost:[PORT]/api/Todos/{id}
    ```

