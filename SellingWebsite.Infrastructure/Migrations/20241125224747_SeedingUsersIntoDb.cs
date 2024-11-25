using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SellingWebsite.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingUsersIntoDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "ef9f34a9-2715-4904-ae29-e5ae05df36bf", "guest@mail.com", true, "Guest", "Guestov", false, null, "guest@mail.com", "guest@mail.com", "AQAAAAIAAYagAAAAEMejfb0sI/6vHqd2fBScRR1XG2TA0Y8Xjq7o58y4+zc9dPZ3BIpkNUSSlycWqi0ZRQ==", null, false, "de09674e-9956-4a80-951b-30224ebd6f3b", false, "guest@mail.com" },
                    { "e43ce836-997d-4927-ac59-74e8c41bbfd3", 0, "85fd8b86-3366-4bd6-97e7-43b50296d35e", "admin@mail.com", true, "Great", "Admin", false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAIAAYagAAAAEMs8ozR6x9/dGJHeq/OrTuiAwwnGYrhU8Ix6UwGpTWrjg9cUyMCcwaKSHECoEWgW7A==", null, false, "50f3a8aa-8102-41cf-9867-8a385047b2e9", false, "admin@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 2, "user:fullname", "Guest Guestov", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" },
                    { 3, "user:fullname", "Great Admin", "e43ce836-997d-4927-ac59-74e8c41bbfd3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3");
        }
    }
}
