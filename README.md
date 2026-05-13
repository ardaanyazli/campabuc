# CamPabuc v2 — Shoe Store Management System

A local-first desktop application for shoe store owners to manage inventory, track the complete product lifecycle (Purchase Order → Stock → Sales → Returns/Damages), and generate business intelligence reports.

Built with **.NET 10** (Clean Architecture) + **SQLite** + **Tauri** + **React/TypeScript** + **Tailwind CSS**.

---

## 1. PRD Compliance Status

| # | Requirement | Status |
|---|---|---|
| 4.1 | **Model → Variant Hierarchy** | ✅ Domain entities, backend CRUD API, frontend CRUD forms |
| 4.1 | **Advanced Search & Filtering** | ❌ Not yet implemented |
| 4.1 | **Barcode System** | 🔄 Backend `BarcodeGenerator` exists; frontend display/print pending |
| 4.2 | **Purchase Order Tracking** | 🔄 Backend entities & PO processing API done; frontend PO view pending |
| 4.2 | **Stock Adjustments (Returns/Exchanges/Damages)** | 🔄 Backend `/Inventory/adjust` endpoint done; frontend UI pending |
| 4.3 | **Dynamic Pricing** | ✅ Percentage & fixed discount inputs in checkout |
| 4.3 | **Checkout Engine (subtotal/tax/discount)** | ✅ Backend `CheckoutService` + frontend `CheckoutView` |
| 4.3 | **Admin Override** | ✅ Manual discount fields at checkout |
| 4.3 | **Transaction History** | ❌ No UI to view past sales |
| 4.4 | **Profit Margin Analysis** | ✅ Variant selector + margin display |
| 4.4 | **Inventory Aging** | ✅ Aging table (slow-moving indicators) |
| 4.4 | **On-Demand Reports** | ✅ Date-range sales summary |
| 4.5 | **Local Export/Import** | ✅ JSON export/import forms |
| 4.5 | **On-Demand Cloud Backup** | ✅ Backup trigger button |
| 5 | **Local-first (SQLite)** | ✅ SQLite, migration applied |
| 5 | **Atomic Transactions** | ✅ `IUnitOfWork` pattern in services |
| 6 | **Tauri/React/Tailwind** | ✅ Project scaffolded (webkit2gtk required for desktop launch) |

---

## 2. Project Structure

```
├── CamPabuc.Api/                  # .NET 10 Web API (Controllers)
├── CamPabuc.Application/          # Business logic, DTOs, interfaces
├── CamPabuc.Domain/               # Domain entities & enums
├── CamPabuc.Infrastructure/       # EF Core DbContext, Repositories
├── CamPabuc.Tests.Unit/           # xUnit + Moq unit tests
├── CamPabuc.Tests.Integration/    # WebApplicationFactory integration tests
├── frontend/                      # Tauri + React + TypeScript app
│   ├── src/
│   │   ├── api/                   # Axios HTTP client
│   │   ├── components/            # Shared components (Layout, Forms)
│   │   ├── views/                 # Page-level views
│   │   └── types/                 # TypeScript interfaces
│   └── src-tauri/                 # Tauri Rust shell
├── PRD.md                         # Original requirements document
└── campabuc.db                    # SQLite database (auto-created)
```

---

## 3. How to Run Locally

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)
- [Node.js 20+](https://nodejs.org/)
- [Tauri prerequisites](https://v2.tauri.app/start/prerequisites/) (for Linux: `webkit2gtk-4.1`, `libgtk-3-dev`, etc.)

### 3.1 Start the Backend API

```bash
cd CamPabuc.Api
dotnet run
```

The API starts at `http://localhost:5000`. Swagger UI is available at `http://localhost:5000/swagger` in Development mode.

*The SQLite database (`campabuc.db`) is created and migrated automatically on first run.*

### 3.2 Start the Frontend (Dev Server)

In a **separate terminal**:

```bash
cd frontend
npm install
npm run dev
```

This launches the Vite dev server (usually at `http://localhost:1420`). The React app connects to the .NET API at `http://localhost:5000`.

### 3.3 Desktop App (Tauri)

> ⚠️ Requires `webkit2gtk` and other Linux system dependencies.

```bash
cd frontend
npm run tauri dev
```

### 3.4 Run Tests

```bash
# Unit tests
dotnet test CamPabuc.Tests.Unit

# Integration tests
dotnet test CamPabuc.Tests.Integration
```

---

## 4. Key Architecture Decisions

| Decision | Rationale |
|---|---|
| **SQLite** | Local-first, no DB server required. Fully functional offline. |
| **Controller-based API** | Better testability with `WebApplicationFactory` than Minimal APIs. |
| **Clean Architecture** | Separation of Domain, Application, Infrastructure, and API layers for maintainability. |
| **IUnitOfWork** | Ensures atomic transactions across all stock-affecting operations. |
| **Tailwind CSS** | Utility-first styling for rapid professional UI development. |

---

## 5. Development Roadmap

1. ✅ Domain model & persistence
2. ✅ Application services & business logic
3. ✅ REST API & controllers
4. ✅ Unit tests
5. ✅ SQLite migration
6. ✅ Frontend scaffold (Tauri + React + Tailwind)
7. ✅ Core frontend views (Inventory, Checkout, Reports, Data Mgmt)
8. 🔄 **Missing features**: PO frontend, stock adjustments UI, transaction history, advanced search, barcode display
9. ⏳ **Desktop polish**: Native file dialogs, window menus, system tray
10. ⏳ **Production packaging**: Tauri bundling for Windows/macOS/Linux
