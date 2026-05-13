# Product Requirements Document (PRD): Shoe Store Management System (v2.0)

## 1. Project Overview
A professional, local-first desktop application for shoe store owners to manage a complex inventory of shoe models and variants, handle the complete product lifecycle from purchase order to sale, and generate deep business intelligence reports.

## 2. Objectives
- Implement a granular inventory system (Model $\rightarrow$ Variant) to track specific sizes and colors.
- Automate the retail lifecycle: Purchase Orders $\rightarrow$ Stock $\rightarrow$ Sales $\rightarrow$ Returns/Damages.
- Provide flexible pricing tools and a streamlined checkout process.
- Equip the owner with financial and operational insights via advanced reporting.
- Ensure data portability and recovery through robust export/import and backup mechanisms.

## 3. Target Audience
- Small to medium-sized shoe store owners and managers.

## 4. Functional Requirements

### 4.1 Inventory & Product Management
- **Model $\rightarrow$ Variant Hierarchy**: 
    - **Model**: General shoe information (Name, Brand, Base Material, Manufacturer).
    - **Variant (SKU)**: Specific combinations of Model + Size + Color. Each variant has its own stock level and unique barcode.
- **Advanced Search & Filtering**: A dedicated search interface allowing users to find shoes using filters for size, color, base material, brand, and price range.
- **Barcode System**: Automatic generation of barcodes for each SKU with the ability to print labels.

### 4.2 Inventory Lifecycle & Supply Chain
- **Purchase Order (PO) Tracking**: 
    - Create POs for manufacturers.
    - Track "Expected" vs. "Received" stock to identify shipping discrepancies.
- **Stock Adjustments**: 
    - **Returns**: Return sold items to inventory and process refunds.
    - **Exchanges**: Swap one SKU for another while maintaining accurate stock levels.
    - **Damages**: Mark items as "Damaged" to remove them from sellable stock while tracking loss.

### 4.3 Sales & Checkout Workflow
- **Dynamic Pricing**: Support for discounts (percentage or fixed amount) and promotional pricing.
- **Checkout Engine**: 
    - Automatic calculation of subtotal, taxes, and discounts.
    - **Admin Override**: The owner/admin can manually adjust the final price at the moment of checkout.
- **Transaction History**: Detailed logging of every sale, including the specific variants sold and the payment method used.

### 4.4 Business Intelligence & Reporting
- **Profit Margin Analysis**: Reports showing the difference between the manufacturer cost and the actual sale price per model/variant.
- **Inventory Aging**: Identification of "slow-moving" stock based on the date of receipt to help the owner plan clearances.
- **On-Demand Reports**: Ability to generate custom reports (Sales, Inventory, Profit) by selecting date ranges or specific categories.

### 4.5 Data Management & Reliability
- **Local Export/Import**: Ability to export the entire database to a portable file (e.g., JSON or SQL dump) and import it to restore state.
- **On-Demand Cloud Backup**: A manual trigger to sync the local database to a cloud provider (via API or file upload) to prevent data loss.

## 5. Non-Functional Requirements
- **Deployment**: Cross-platform desktop application (Windows/macOS/Linux).
- **Architecture**: Local-first; the application must be fully functional without an internet connection (except for cloud backups).
- **Data Integrity**: Atomic transactions for sales and stock adjustments to prevent inventory mismatch.

## 6. Proposed Technical Stack
- **Framework**: Tauri or Electron (Tauri recommended for smaller binary size and better performance).
- **Frontend**: React or Vue.js with a professional UI library (e.g., Tailwind CSS, Shadcn UI) for complex data tables.
- **Database**: SQLite (Relational storage is critical for the Model $\rightarrow$ Variant and PO relationships).
- **Barcode**: `bwip-js` for industrial-standard barcode generation.

## 7. Enhanced Data Model
- **Manufacturer**: `id`, `name`, `contact_info`, `address`.
- **ShoeModel**: `id`, `name`, `brand`, `base_material`, `manufacturer_id`, `description`.
- **ShoeVariant (SKU)**: `id`, `model_id`, `sku_code`, `size`, `color`, `cost_price`, `retail_price`, `stock_quantity`.
- **PurchaseOrder**: `id`, `manufacturer_id`, `order_date`, `expected_date`, `status` (Pending/Received/Partial).
- **POItem**: `id`, `po_id`, `variant_id`, `quantity_ordered`, `quantity_received`.
- **Sale**: `id`, `transaction_date`, `total_amount`, `discount_applied`, `payment_method`.
- **SaleItem**: `id`, `sale_id`, `variant_id`, `quantity`, `price_at_sale`.
- **StockAdjustment**: `id`, `variant_id`, `type` (Return/Exchange/Damage), `quantity`, `date`, `reason`.
