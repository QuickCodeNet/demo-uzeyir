using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Persistence.Migrations
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
                name: "BENEFICIARIES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    NICKNAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BENEFICIARY_ACCOUNT_NUMBER = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BENEFICIARY_NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BANK_NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BANK_CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TYPE = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BENEFICIARIES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FEE_TYPES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FIXED_AMOUNT = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PERCENTAGE_RATE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FEE_TYPES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TRANSACTION_CHANNELS",
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
                    table.PrimaryKey("PK_TRANSACTION_CHANNELS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TRANSACTION_TYPES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DIRECTION = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRANSACTION_TYPES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PENDING_TRANSFERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TRANSFER_REFERENCE = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SOURCE_ACCOUNT_ID = table.Column<int>(type: "int", nullable: false),
                    BENEFICIARY_ID = table.Column<int>(type: "int", nullable: false),
                    AMOUNT = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SCHEDULED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    STATUS = table.Column<string>(type: "nvarchar(250)", nullable: false, defaultValueSql: "'SCHEDULED'"),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PENDING_TRANSFERS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PENDING_TRANSFERS_BENEFICIARIES_BENEFICIARY_ID",
                        column: x => x.BENEFICIARY_ID,
                        principalTable: "BENEFICIARIES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TRANSACTIONS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TRANSACTION_REFERENCE = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SOURCE_ACCOUNT_ID = table.Column<int>(type: "int", nullable: true),
                    DESTINATION_ACCOUNT_ID = table.Column<int>(type: "int", nullable: true),
                    TRANSACTION_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    TRANSACTION_CHANNEL_ID = table.Column<int>(type: "int", nullable: false),
                    AMOUNT = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CURRENCY_CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    STATUS = table.Column<string>(type: "nvarchar(250)", nullable: false, defaultValueSql: "'PENDING'"),
                    TRANSACTION_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    COMPLETED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRANSACTIONS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TRANSACTIONS_TRANSACTION_CHANNELS_TRANSACTION_CHANNEL_ID",
                        column: x => x.TRANSACTION_CHANNEL_ID,
                        principalTable: "TRANSACTION_CHANNELS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TRANSACTIONS_TRANSACTION_TYPES_TRANSACTION_TYPE_ID",
                        column: x => x.TRANSACTION_TYPE_ID,
                        principalTable: "TRANSACTION_TYPES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TRANSACTION_FEES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TRANSACTION_ID = table.Column<long>(type: "bigint", nullable: false),
                    FEE_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    FEE_AMOUNT = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    APPLIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRANSACTION_FEES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TRANSACTION_FEES_FEE_TYPES_FEE_TYPE_ID",
                        column: x => x.FEE_TYPE_ID,
                        principalTable: "FEE_TYPES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TRANSACTION_FEES_TRANSACTIONS_TRANSACTION_ID",
                        column: x => x.TRANSACTION_ID,
                        principalTable: "TRANSACTIONS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BENEFICIARIES_IsDeleted",
                table: "BENEFICIARIES",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_FEE_TYPES_IsDeleted",
                table: "FEE_TYPES",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_PENDING_TRANSFERS_BENEFICIARY_ID",
                table: "PENDING_TRANSFERS",
                column: "BENEFICIARY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PENDING_TRANSFERS_IsDeleted",
                table: "PENDING_TRANSFERS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSACTION_CHANNELS_IsDeleted",
                table: "TRANSACTION_CHANNELS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSACTION_FEES_FEE_TYPE_ID",
                table: "TRANSACTION_FEES",
                column: "FEE_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSACTION_FEES_IsDeleted",
                table: "TRANSACTION_FEES",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSACTION_FEES_TRANSACTION_ID",
                table: "TRANSACTION_FEES",
                column: "TRANSACTION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSACTION_TYPES_IsDeleted",
                table: "TRANSACTION_TYPES",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSACTIONS_IsDeleted",
                table: "TRANSACTIONS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSACTIONS_TRANSACTION_CHANNEL_ID",
                table: "TRANSACTIONS",
                column: "TRANSACTION_CHANNEL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSACTIONS_TRANSACTION_TYPE_ID",
                table: "TRANSACTIONS",
                column: "TRANSACTION_TYPE_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AUDIT_LOGS");

            migrationBuilder.DropTable(
                name: "PENDING_TRANSFERS");

            migrationBuilder.DropTable(
                name: "TRANSACTION_FEES");

            migrationBuilder.DropTable(
                name: "BENEFICIARIES");

            migrationBuilder.DropTable(
                name: "FEE_TYPES");

            migrationBuilder.DropTable(
                name: "TRANSACTIONS");

            migrationBuilder.DropTable(
                name: "TRANSACTION_CHANNELS");

            migrationBuilder.DropTable(
                name: "TRANSACTION_TYPES");
        }
    }
}
