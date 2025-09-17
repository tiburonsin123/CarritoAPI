# CarritoAPI

## Requisitos
- .NET 6 SDK o superior
- Visual Studio 2022 o Visual Studio Code

## C�mo ejecutar
1. Clonar o descomprimir el proyecto.
2. Abrir la soluci�n `CarritoAPI.sln` en Visual Studio.
3. Ejecutar con IIS Express o `dotnet run` desde la carpeta del proyecto.
4. El API quedar� disponible en:
   - Swagger UI: https://localhost:5001/swagger
   - O en el puerto que indique la consola.

## Endpoints principales

### Productos
- `GET /api/test/product/{id}`  
  Devuelve un producto del cat�logo por ID.

### Carrito
- `GET /api/cart`  
  Lista los productos en el carrito.

- `POST /api/cart`  
  Agrega un producto al carrito (con validaci�n de reglas).  
  Body (ejemplo):
  json
  {
    "productId": 3546345,
    "quantity": 1,
    "groupAttributes": [
      {
        "groupAttributeId": "241887",
        "attributes": [
          { "attributeId": 968636, "quantity": 1 }
        ]
      }
    ]
  }
 - `PUT /api/cart/{cartItemId}`  
    Actualiza un producto del carrito (revalida reglas).

 -  `DELETE /api/cart/{cartItemId}` 
    Elimina un producto del carrito por ID.