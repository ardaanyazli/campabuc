import React from "react";
import {
  useReactTable,
  getCoreRowModel,
  getSortedRowModel,
  getFilteredRowModel,
  getPaginationRowModel,
  ColumnDef,
  flexRender,
  RowSelectionState,
  SortingState,
  PaginationState,
  ColumnFiltersState,
} from "@tanstack/react-table";
import {
  Table,
  TableHeader,
  TableBody,
  TableRow,
  TableHead,
  TableCell,
} from "@/components/ui/table";
import { Checkbox } from "@/components/ui/checkbox";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";

interface RowAction<TData> {
  label: string;
  onClick: (row: TData) => void;
  variant?: "outline" | "ghost" | "default";
}

interface DataTableProps<TData> {
  columns: ColumnDef<TData, any>[];
  data: TData[];
  initialPageSize?: number;
  pageSizeOptions?: number[];
  rowActions?: (row: TData) => RowAction<TData>[];
  actionsColumnHeader?: string;
}

/**
 * Enhanced DataTable with sorting, filtering, selection, pagination, and row actions
 */
export function DataTable<TData>({
  columns,
  data,
  initialPageSize = 10,
  pageSizeOptions = [10, 20, 50],
  rowActions,
  actionsColumnHeader = "Actions",
}: DataTableProps<TData>) {
  const [sorting, setSorting] = React.useState<SortingState>([]);
  const [rowSelection, setRowSelection] = React.useState<RowSelectionState>({});
  const [pagination, setPagination] = React.useState<PaginationState>({
    pageIndex: 0,
    pageSize: initialPageSize,
  });
  const [columnFilters, setColumnFilters] = React.useState<ColumnFiltersState>(
    [],
  );
  const [globalFilter, setGlobalFilter] = React.useState("");

  const table = useReactTable({
    data,
    columns,
    state: {
      sorting,
      rowSelection,
      pagination,
      columnFilters,
      globalFilter,
    },
    onSortingChange: setSorting,
    onRowSelectionChange: setRowSelection,
    onPaginationChange: setPagination,
    onColumnFiltersChange: setColumnFilters,
    onGlobalFilterChange: setGlobalFilter,
    getCoreRowModel: getCoreRowModel(),
    getSortedRowModel: getSortedRowModel(),
    getFilteredRowModel: getFilteredRowModel(),
    getPaginationRowModel: getPaginationRowModel(),
    enableRowSelection: true,
    getRowId: (row) => Object.values(row).join("-"),
  });

  return (
    <>
      {/* Toolbar: global filter and select/deselect actions */}
      <div className="flex items-center justify-between pb-4">
        <Input
          placeholder="Search..."
          value={globalFilter || ""}
          onChange={(e) => setGlobalFilter(e.target.value)}
          className="max-w-sm"
        />
        <div className="space-x-2">
          <Button
            size="sm"
            variant="outline"
            onClick={() => table.toggleAllRowsSelected(true)}
          >
            Select All
          </Button>
          <Button
            size="sm"
            variant="outline"
            onClick={() => table.toggleAllRowsSelected(false)}
          >
            Deselect All
          </Button>
        </div>
      </div>

      <Table>
        <TableHeader>
          {table.getHeaderGroups().map((headerGroup) => (
            <TableRow key={headerGroup.id}>
              {/* Selection column */}
              <TableHead>
                <Checkbox
                  checked={table.getIsAllRowsSelected()}
                  indeterminate={table.getIsSomeRowsSelected()}
                  onCheckedChange={(value) =>
                    table.toggleAllRowsSelected(!!value)
                  }
                />
              </TableHead>
              {headerGroup.headers.map((header) => (
                <TableHead key={header.id} colSpan={header.colSpan}>
                  {header.isPlaceholder ? null : (
                    <div
                      className={
                        header.column.getCanSort()
                          ? "cursor-pointer select-none"
                          : ""
                      }
                      onClick={header.column.getToggleSortingHandler()}
                    >
                      {flexRender(
                        header.column.columnDef.header,
                        header.getContext(),
                      )}
                      {{ asc: " 🔼", desc: " 🔽" }[
                        header.column.getIsSorted() as string
                      ] ?? null}
                    </div>
                  )}
                  {/* Column filter UI */}
                  {header.column.getCanFilter() ? (
                    <div>
                      {/* @ts-ignore */}
                      {flexRender(
                        header.column.columnDef.footer, // assume filter provided in footer slot
                        header.getContext(),
                      )}
                    </div>
                  ) : null}
                </TableHead>
              ))}
              {rowActions ? <TableHead>{actionsColumnHeader}</TableHead> : null}
            </TableRow>
          ))}
        </TableHeader>
        <TableBody>
          {table.getRowModel().rows.length ? (
            table.getRowModel().rows.map((row) => (
              <TableRow key={row.id}>
                {/* Selection cell */}
                <TableCell>
                  <Checkbox
                    checked={row.getIsSelected()}
                    indeterminate={row.getIsSomeSelected()}
                    onCheckedChange={(value) => row.toggleSelected(!!value)}
                  />
                </TableCell>
                {row.getVisibleCells().map((cell) => (
                  <TableCell key={cell.id}>
                    {flexRender(cell.column.columnDef.cell, cell.getContext())}
                  </TableCell>
                ))}
                {rowActions && (
                  <TableCell>
                    <div className="flex space-x-1">
                      {rowActions(row.original).map((action, idx) => (
                        <Button
                          key={idx}
                          size="sm"
                          variant={action.variant || "ghost"}
                          onClick={() => action.onClick(row.original)}
                        >
                          {action.label}
                        </Button>
                      ))}
                    </div>
                  </TableCell>
                )}
              </TableRow>
            ))
          ) : (
            <TableRow>
              <TableCell
                colSpan={columns.length + 1 + (rowActions ? 1 : 0)}
                className="h-24 text-center"
              >
                No data available.
              </TableCell>
            </TableRow>
          )}
        </TableBody>
      </Table>

      {/* Pagination controls */}
      <div className="flex items-center justify-between py-4">
        <div className="flex items-center space-x-2">
          <Button
            size="sm"
            variant="outline"
            onClick={() => table.previousPage()}
            disabled={!table.getCanPreviousPage()}
          >
            Previous
          </Button>
          <Button
            size="sm"
            variant="outline"
            onClick={() => table.nextPage()}
            disabled={!table.getCanNextPage()}
          >
            Next
          </Button>
        </div>
        <span className="text-sm">
          Page{" "}
          <strong>
            {table.getState().pagination.pageIndex + 1} of{" "}
            {table.getPageCount()}
          </strong>
        </span>
        <select
          className="border rounded p-1"
          value={table.getState().pagination.pageSize}
          onChange={(e) => table.setPageSize(Number(e.target.value))}
        >
          {pageSizeOptions.map((size) => (
            <option key={size} value={size}>
              Show {size}
            </option>
          ))}
        </select>
      </div>
    </>
  );
}
