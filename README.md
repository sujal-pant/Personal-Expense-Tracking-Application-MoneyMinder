# Personal Expense Tracking Application

This is a  desktop application built with **MAUI Blazor Hybrid** for tracking personal expenses, including cash inflows, outflows, and debts. The application allows users to categorize transactions, track balances, and view detailed statistics via a dynamic dashboard. It supports filtering, sorting, and searching transactions, as well as importing/exporting data in **JSON** format.

The app utilizes **MudBlazor** for rendering interactive charts, helping users visualize their financial data.

## Features

- **Cash Inflows/Outflows/Debt Tracking**: Track credit, debit, and debt transactions.
- **Sufficient Balance Check**: Ensures sufficient balance is available before processing outflows.
- **Debt Management**: Debts are cleared from cash inflows, and pending debts are highlighted.
- **Custom Tags/Labels**: Add custom tags to transactions for categorization (e.g., Rent, Groceries, Salary).
- **Optional Notes**: Option to add notes for each transaction.
- **Transaction Filtering**: Filter by transaction type, tags, date range, and more.
- **Transaction Sorting**: Sort transactions by date.
- **Search Transactions**: Search by transaction title, integrated with filtering and sorting.
- **Dashboard Statistics**:
  - Total number of transactions.
  - Total inflows, outflows, debts, cleared debts, and remaining debts.
  - Highest and lowest transactions by type (inflow, outflow, debt).
  - Pending debts with date range filtering.
- **Charts**: Visualize inflows, outflows, and debt trends using interactive charts powered by MudBlazor.
- **First Startup Setup**: Prompt for username, password, and preferred currency type on first use.
- **Data Import/Export**: Import/export transactions in **JSON** format.
- **Local Storage**: Store transaction data locally using **JSON** files.

## Requirements

- **MAUI Blazor Hybrid**: For building cross-platform hybrid desktop and mobile applications.
- **MudBlazor**: For rendering interactive charts and UI components.
- **.NET 6 or Higher**: The app is built using .NET MAUI, which requires .NET 6 or higher.
- **Visual Studio**: **Visual Studio 2022** (or later) is the recommended IDE for building and running MAUI applications.
- **SQLite (optional)**: For local data storage, though **JSON** files are used by default.

## Installation

### Clone the Repository

1. **Clone the repository** to your local machine:

   ```bash
   git clone https://https://github.com/sujal-pant/Personal-Expense-Tracking-Application-MoneyMinder.git

### Open the Solution

1. After cloning the repository, open **Visual Studio 2022** (or later).
2. Click on **File > Open > Project/Solution**.
3. Browse to the cloned repository folder and select the solution file (`MoneyMinder.sln`) to open the project in Visual Studio.

### First-Time Setup

On the first launch, the application will prompt you for the following details:
- **Username**: Enter your username.
- **Password**: Enter the password (use the default password if prompted (default passoword : a).
- **Currency Type**: Choose your preferred currency.
