# .NET URL Shortener

## Project Description

This project is a **URL Shortener** application built with ASP.NET MVC and C#. The system allows users to shorten URLs, view details about them, and manage URLs based on their access level. The project includes role-based authentication, ensuring that regular users and admins have appropriate access rights.

Unlike a standard frontend-heavy app, this project uses **ASP.NET MVC** for both backend and frontend rendering.

---

## Technical Stack

* **Backend:**

  * ASP.NET MVC (Framework or Core)
  * C#
  * Entity Framework Core
  * MSSQL Database

* **Frontend:**

  * Razor Views (MVC)
  * HTML, CSS, JavaScript

---

## Functionality

### 1. Login View

* Users can log in using **Login** and **Password**.
* Role-based access:

  * **Admin users**
  * **Ordinary users**
* Authorization determines which actions a user can perform.

---

### 2. Short URLs Table View

* Displays all existing URLs with their shortened equivalents in a table.
* Functionality depends on user role:

  * **Anonymous users:** Can only view the table.
  * **Authorized users:**

    * Add new URLs (via "Add new URL" section).
    * View URL details by navigating to Short URL Info page.
    * Delete URLs **created by themselves**.
  * **Admin users:**

    * Add new URLs.
    * View URL details.
    * Delete **any URL**.
* Duplicate URLs are prevented. If a URL already exists, an error message is displayed.
* All changes (add, delete) are reflected immediately without page reload.
* **Frontend is implemented using MVC and Razor views** (Angular is not implemented).

---

### 3. Short URL Info View

* Accessible only to authorized users.
* Displays detailed information about a URL:

  * Created by (user)
  * Created date
  * Other relevant metadata
* Anonymous users cannot access this page.

---

### 4. About View

* Contains a description of the **URL shortening algorithm**.
* Visible to all users (even anonymous).
* Editable only by admin users via a simple Razor form.

---

## How to Run the Project Locally

### Getting Started

1. Clone the repository:

```bash
git clone https://github.com/Mkrager/Url-Shortener.git
```

2. Set up your development environment:

   * Install **.NET 8 SDK**
   * Ensure **MSSQL** is installed and running

3. Configure application settings:

   * Database connection string
   * Any other sensitive settings

4. Restore dependencies via NuGet:

```bash
dotnet restore
```

5. Run database migrations (Code-First approach):

```bash
dotnet ef database update
```

6. Run the application locally:

```bash
dotnet run
```

7. Open the browser and navigate to:

```
http://localhost:5000
```
