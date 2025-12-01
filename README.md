# MetroClaim API 🚀

  Modern Corporate Reimbursement System built with ASP.NET Core 8,
  enforcing Clean Architecture and robust Approval Workflows.

[.NET] [ASP.NET Core] [SQL Server] [EF Core] [Swagger]

------------------------------------------------------------------------

📋 Overview

MetroClaim adalah backend API yang dirancang untuk mendigitalisasi
proses reimbursement perusahaan yang sebelumnya berjalan secara manual.
Sistem ini memastikan proses pengajuan, pengecekan, persetujuan, hingga
pencairan dana berjalan lebih terstruktur, aman, dan memiliki jejak
audit yang jelas.

------------------------------------------------------------------------

✨ Key Features

-   🛡️ Clean Architecture
-   🔄 Linear Approval Workflow: Submitted → Manager Approved → Finance
    Approved → Paid
-   👥 RBAC (Employee, Manager, Finance, Admin)
-   🧾 Digital Evidence (Base64)
-   🗑️ Soft Delete
-   💰 Disbursement Tracking
-   🔍 Audit Logs

------------------------------------------------------------------------

🏗️ Architecture & Database

    erDiagram
        USERS ||--|| ACCOUNTS : "1-to-1 (Auth)"
        USERS ||--|{ REIMBURSEMENTS : "Submits"
        USERS ||--|{ APPROVAL_LOGS : "Performs Action"
        CATEGORIES ||--|{ REIMBURSEMENTS : "Classifies"
        REIMBURSEMENTS ||--|{ APPROVAL_LOGS : "History"
        REIMBURSEMENTS ||--|| DISBURSEMENTS : "1-to-1 (Payment)"

        USERS {
            Guid Id
            string Fullname
            string Role
            Guid ManagerId
            bool IsDeleted
        }

        REIMBURSEMENTS {
            Guid Id
            decimal Amount
            string Status
            string Receipt
        }

        DISBURSEMENTS {
            Guid Id
            decimal AmountPaid
            string ReferenceNumber
        }

------------------------------------------------------------------------

🛠️ Tech Stack

-   .NET 8
-   EF Core 8
-   SQL Server
-   Swagger / OpenAPI
-   Repository Pattern, Unit of Work, DTOs, FluentValidation

------------------------------------------------------------------------

🚦 API Endpoints

🔐 Authentication & Users

🗂️ Categories

📝 Reimbursement

✅ Manager Approval

💸 Finance

------------------------------------------------------------------------

🚀 Getting Started

Prerequisites

.NET 8 SDK, SQL Server

Clone Project

    git clone https://github.com/yourusername/MetroClaim.git
    cd MetroClaim

Configure DB

    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Database=MetroClaimDb;Trusted_Connection=True;TrustServerCertificate=True;"
    }

Run Migrations

    dotnet ef database update

Run API

    dotnet run --project MetroClaim.Api

------------------------------------------------------------------------

🔍 Explore API

Open Swagger: https://localhost:xxxx/swagger/index.html

------------------------------------------------------------------------

🔜 Roadmap

-   ☐ JWT Authentication
-   ☐ SMTP Email Notification
-   ☐ Frontend React/Next.js

------------------------------------------------------------------------

❤️ Made with Love

Using .NET 8