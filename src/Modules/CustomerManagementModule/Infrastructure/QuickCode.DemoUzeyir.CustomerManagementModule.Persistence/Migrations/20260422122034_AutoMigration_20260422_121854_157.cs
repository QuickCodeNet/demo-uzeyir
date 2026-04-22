using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickCode.DemoUzeyir.CustomerManagementModule.Persistence.Migrations
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
                name: "CUSTOMER_TYPES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER_TYPES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DOCUMENT_TYPES",
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
                    table.PrimaryKey("PK_DOCUMENT_TYPES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUSTOMER_NUMBER = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FIRST_NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LAST_NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DATE_OF_BIRTH = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CUSTOMER_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    STATUS = table.Column<string>(type: "nvarchar(250)", nullable: false, defaultValueSql: "'PROSPECT'"),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMERS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CUSTOMERS_CUSTOMER_TYPES_CUSTOMER_TYPE_ID",
                        column: x => x.CUSTOMER_TYPE_ID,
                        principalTable: "CUSTOMER_TYPES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ADDRESSES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    ADDRESS_LINE_1 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ADDRESS_LINE_2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CITY = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    STATE = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    POSTAL_CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    COUNTRY_CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TYPE = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    IS_PRIMARY = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADDRESSES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ADDRESSES_CUSTOMERS_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "CUSTOMERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CONTACT_DETAILS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    TYPE = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    VALUE = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IS_VERIFIED = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTACT_DETAILS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CONTACT_DETAILS_CUSTOMERS_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "CUSTOMERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMER_RELATIONSHIPS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRIMARY_CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    RELATED_CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    RELATIONSHIP_TYPE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER_RELATIONSHIPS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CUSTOMER_RELATIONSHIPS_CUSTOMERS_PRIMARY_CUSTOMER_ID",
                        column: x => x.PRIMARY_CUSTOMER_ID,
                        principalTable: "CUSTOMERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CUSTOMER_RELATIONSHIPS_CUSTOMERS_RELATED_CUSTOMER_ID",
                        column: x => x.RELATED_CUSTOMER_ID,
                        principalTable: "CUSTOMERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IDENTIFICATION_DOCUMENTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    DOCUMENT_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    DOCUMENT_NUMBER = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ISSUE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EXPIRY_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ISSUING_COUNTRY = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DOCUMENT_URL = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    STATUS = table.Column<string>(type: "nvarchar(250)", nullable: false, defaultValueSql: "'PENDING_VERIFICATION'"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDENTIFICATION_DOCUMENTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IDENTIFICATION_DOCUMENTS_CUSTOMERS_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "CUSTOMERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IDENTIFICATION_DOCUMENTS_DOCUMENT_TYPES_DOCUMENT_TYPE_ID",
                        column: x => x.DOCUMENT_TYPE_ID,
                        principalTable: "DOCUMENT_TYPES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ADDRESSES_CUSTOMER_ID",
                table: "ADDRESSES",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ADDRESSES_IsDeleted",
                table: "ADDRESSES",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_CONTACT_DETAILS_CUSTOMER_ID",
                table: "CONTACT_DETAILS",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CONTACT_DETAILS_IsDeleted",
                table: "CONTACT_DETAILS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMER_RELATIONSHIPS_IsDeleted",
                table: "CUSTOMER_RELATIONSHIPS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMER_RELATIONSHIPS_PRIMARY_CUSTOMER_ID",
                table: "CUSTOMER_RELATIONSHIPS",
                column: "PRIMARY_CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMER_RELATIONSHIPS_RELATED_CUSTOMER_ID",
                table: "CUSTOMER_RELATIONSHIPS",
                column: "RELATED_CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMER_TYPES_IsDeleted",
                table: "CUSTOMER_TYPES",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMERS_CUSTOMER_TYPE_ID",
                table: "CUSTOMERS",
                column: "CUSTOMER_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMERS_IsDeleted",
                table: "CUSTOMERS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_DOCUMENT_TYPES_IsDeleted",
                table: "DOCUMENT_TYPES",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_IDENTIFICATION_DOCUMENTS_CUSTOMER_ID",
                table: "IDENTIFICATION_DOCUMENTS",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_IDENTIFICATION_DOCUMENTS_DOCUMENT_TYPE_ID",
                table: "IDENTIFICATION_DOCUMENTS",
                column: "DOCUMENT_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_IDENTIFICATION_DOCUMENTS_IsDeleted",
                table: "IDENTIFICATION_DOCUMENTS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ADDRESSES");

            migrationBuilder.DropTable(
                name: "AUDIT_LOGS");

            migrationBuilder.DropTable(
                name: "CONTACT_DETAILS");

            migrationBuilder.DropTable(
                name: "CUSTOMER_RELATIONSHIPS");

            migrationBuilder.DropTable(
                name: "IDENTIFICATION_DOCUMENTS");

            migrationBuilder.DropTable(
                name: "CUSTOMERS");

            migrationBuilder.DropTable(
                name: "DOCUMENT_TYPES");

            migrationBuilder.DropTable(
                name: "CUSTOMER_TYPES");
        }
    }
}
