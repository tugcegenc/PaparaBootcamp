# Product Management API


## 📌 Project Description
This is a **Product Management API** built with **.NET 8**, featuring CRUD operations for managing products. The API includes **Fluent Validation**, **Exception Handling Middleware**, **Fake User Authentication**, and **Swagger Documentation**.

## 🚀 Features
- 📌 **CRUD Operations** (Create, Read, Update, Delete)
- 📌 **In-Memory Database** for easy testing
- 📌 **Fluent Validation** for request validation
- 📌 **Exception Middleware** for centralized error handling
- 📌 **Swagger UI** for API documentation
- 📌 **Fake User Authentication System** with a custom attribute for securing endpoints

---

## ⚙️ Installation and Running

### 1️⃣ Clone the Repository
```sh
git clone https://github.com/your-repo/product-management-api.git
cd product-management-api
```

### 2️⃣ Restore Dependencies
```sh
dotnet restore
```

### 3️⃣ Run the Application
```sh
dotnet run
```

### 4️⃣ Open Swagger UI
Once the application is running, open your browser and go to:
```
http://localhost:5000/swagger/index.html
```

---

## 🛠️ API Endpoints

### 📌 **User Authentication**
#### 🔹 **Login**
**POST** `/api/auth/login`
```json
{
  "username": "admin",
  "password": "admin123"
}
```
**Response:**
```json
{
  "message": "Login successful",
  "userId": 1
}
```

---

### 📌 **Get All Products (Requires Authentication)**
**GET** `/api/products`
#### 🔹 Request Headers
```sh
-H "Username: admin"
-H "Password: admin123"
```
#### 🔹 Curl Example
```sh
curl -X GET "http://localhost:5000/api/products" \
     -H "Username: admin" \
     -H "Password: admin123"
```

### 📌 **Get Product by ID (Requires Authentication)**
**GET** `/api/products/{id}`
```sh
curl -X GET "http://localhost:5000/api/products/1" \
     -H "Username: admin" \
     -H "Password: admin123"
```

### 📌 **Add a New Product (Requires Authentication)**
**POST** `/api/products`
#### 🔹 Request Headers
```sh
-H "Username: admin"
-H "Password: admin123"
```
#### 🔹 Request Body
```json
{
  "name": "Smartphone",
  "description": "High-end smartphone",
  "price": 1000,
  "stock": 5
}
```
#### 🔹 Response
```json
{
  "id": 5,
  "name": "Smartphone",
  "description": "High-end smartphone",
  "price": 1000,
  "stock": 5
}
```

### 📌 **Update a Product (Requires Authentication)**
**PUT** `/api/products/{id}`
#### 🔹 Request Body
```json
{
  "name": "Updated Laptop",
  "description": "Updated Gaming Laptop",
  "price": 1800,
  "stock": 7
}
```

### 📌 **Delete a Product (Requires Authentication)**
**DELETE** `/api/products/{id}`
```sh
curl -X DELETE "http://localhost:5000/api/products/1" \
     -H "Username: admin" \
     -H "Password: admin123"
```

---

## 🚧 Technologies Used
- 🏗 **.NET 8**
- 🗃 **Entity Framework Core (In-Memory DB)**
- ✅ **Fluent Validation**
- ⚠ **Custom Exception Middleware**
- 🔒 **Fake User Authentication** (with `AuthorizeUser` attribute)
- 📄 **Swagger UI**

---

## 📝 License
This project is open-source and available under the MIT License.

---

🚀 **Now you are ready to use the Product Management API with authentication!** 🎉


# PaparaBootcamp
