using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickCode.DemoUzeyir.LoanManagementModule.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AutoMigration_20260422_121854_157 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AUDIT_LOGS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ENTITY_NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ENTITY_ID = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ACTION = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    USER_ID = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    USER_NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    USER_GROUP = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TIMESTAMP = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OLD_VALUES = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    NEW_VALUES = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    CHANGED_COLUMNS = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    IS_CHANGED = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CHANGE_SUMMARY = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    IP_ADDRESS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    USER_AGENT = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CORRELATION_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IS_SUCCESS = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ERROR_MESSAGE = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    HASH = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUDIT_LOGS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "COLLATERAL_TYPES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COLLATERAL_TYPES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LOAN_PRODUCTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MIN_AMOUNT = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    MAX_AMOUNT = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    MIN_TERM_MONTHS = table.Column<int>(type: "int", nullable: false),
                    MAX_TERM_MONTHS = table.Column<int>(type: "int", nullable: false),
                    INTEREST_RATE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOAN_PRODUCTS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LOAN_APPLICATIONS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    APPLICATION_NUMBER = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    LOAN_PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    REQUESTED_AMOUNT = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    REQUESTED_TERM_MONTHS = table.Column<int>(type: "int", nullable: false),
                    PURPOSE = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    STATUS = table.Column<string>(type: "nvarchar(250)", nullable: false, defaultValueSql: "'DRAFT'"),
                    SUBMITTED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DECISION_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOAN_APPLICATIONS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LOAN_APPLICATIONS_LOAN_PRODUCTS_LOAN_PRODUCT_ID",
                        column: x => x.LOAN_PRODUCT_ID,
                        principalTable: "LOAN_PRODUCTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "COLLATERALS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LOAN_APPLICATION_ID = table.Column<int>(type: "int", nullable: false),
                    COLLATERAL_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    MARKET_VALUE = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    VALUATION_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COLLATERALS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_COLLATERALS_COLLATERAL_TYPES_COLLATERAL_TYPE_ID",
                        column: x => x.COLLATERAL_TYPE_ID,
                        principalTable: "COLLATERAL_TYPES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COLLATERALS_LOAN_APPLICATIONS_LOAN_APPLICATION_ID",
                        column: x => x.LOAN_APPLICATION_ID,
                        principalTable: "LOAN_APPLICATIONS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LOANS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LOAN_ACCOUNT_NUMBER = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    APPLICATION_ID = table.Column<int>(type: "int", nullable: false),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    PRINCIPAL_AMOUNT = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    OUTSTANDING_BALANCE = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    INTEREST_RATE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TERM_MONTHS = table.Column<int>(type: "int", nullable: false),
                    DISBURSEMENT_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MATURITY_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    STATUS = table.Column<string>(type: "nvarchar(250)", nullable: false, defaultValueSql: "'ACTIVE'"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOANS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LOANS_LOAN_APPLICATIONS_APPLICATION_ID",
                        column: x => x.APPLICATION_ID,
                        principalTable: "LOAN_APPLICATIONS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "REPAYMENT_SCHEDULES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LOAN_ID = table.Column<int>(type: "int", nullable: false),
                    INSTALLMENT_NUMBER = table.Column<int>(type: "int", nullable: false),
                    DUE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PRINCIPAL_AMOUNT = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    INTEREST_AMOUNT = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TOTAL_AMOUNT = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    STATUS = table.Column<string>(type: "nvarchar(250)", nullable: false, defaultValueSql: "'SCHEDULED'"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REPAYMENT_SCHEDULES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_REPAYMENT_SCHEDULES_LOANS_LOAN_ID",
                        column: x => x.LOAN_ID,
                        principalTable: "LOANS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LOAN_PAYMENTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LOAN_ID = table.Column<int>(type: "int", nullable: false),
                    SCHEDULE_ID = table.Column<int>(type: "int", nullable: false),
                    PAYMENT_REFERENCE = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AMOUNT_PAID = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PAYMENT_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PAYMENT_METHOD = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOAN_PAYMENTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LOAN_PAYMENTS_LOANS_LOAN_ID",
                        column: x => x.LOAN_ID,
                        principalTable: "LOANS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LOAN_PAYMENTS_REPAYMENT_SCHEDULES_SCHEDULE_ID",
                        column: x => x.SCHEDULE_ID,
                        principalTable: "REPAYMENT_SCHEDULES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_COLLATERAL_TYPES_IsDeleted",
                table: "COLLATERAL_TYPES",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_COLLATERALS_COLLATERAL_TYPE_ID",
                table: "COLLATERALS",
                column: "COLLATERAL_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_COLLATERALS_IsDeleted",
                table: "COLLATERALS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_COLLATERALS_LOAN_APPLICATION_ID",
                table: "COLLATERALS",
                column: "LOAN_APPLICATION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LOAN_APPLICATIONS_IsDeleted",
                table: "LOAN_APPLICATIONS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_LOAN_APPLICATIONS_LOAN_PRODUCT_ID",
                table: "LOAN_APPLICATIONS",
                column: "LOAN_PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LOAN_PAYMENTS_IsDeleted",
                table: "LOAN_PAYMENTS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_LOAN_PAYMENTS_LOAN_ID",
                table: "LOAN_PAYMENTS",
                column: "LOAN_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LOAN_PAYMENTS_SCHEDULE_ID",
                table: "LOAN_PAYMENTS",
                column: "SCHEDULE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LOAN_PRODUCTS_IsDeleted",
                table: "LOAN_PRODUCTS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_LOANS_APPLICATION_ID",
                table: "LOANS",
                column: "APPLICATION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LOANS_IsDeleted",
                table: "LOANS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_REPAYMENT_SCHEDULES_IsDeleted",
                table: "REPAYMENT_SCHEDULES",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_REPAYMENT_SCHEDULES_LOAN_ID",
                table: "REPAYMENT_SCHEDULES",
                column: "LOAN_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AUDIT_LOGS");

            migrationBuilder.DropTable(
                name: "COLLATERALS");

            migrationBuilder.DropTable(
                name: "LOAN_PAYMENTS");

            migrationBuilder.DropTable(
                name: "COLLATERAL_TYPES");

            migrationBuilder.DropTable(
                name: "REPAYMENT_SCHEDULES");

            migrationBuilder.DropTable(
                name: "LOANS");

            migrationBuilder.DropTable(
                name: "LOAN_APPLICATIONS");

            migrationBuilder.DropTable(
                name: "LOAN_PRODUCTS");
        }
    }
}
