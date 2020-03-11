using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace my_wep_api.Migrations
{
    public partial class ResumeAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Descriptions",
                keyColumn: "DescId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Descriptions",
                keyColumn: "DescId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Descriptions",
                keyColumn: "DescId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "TitleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "TitleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "TitleId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "TitleId",
                keyValue: 4);

            migrationBuilder.CreateTable(
                name: "CompaniesModel",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompaniesModel", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "DescriptionsModel",
                columns: table => new
                {
                    DescId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescriptionsModel", x => x.DescId);
                });

            migrationBuilder.CreateTable(
                name: "TitlesModel",
                columns: table => new
                {
                    TitleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TitlesModel", x => x.TitleId);
                });

            migrationBuilder.InsertData(
                table: "CompaniesModel",
                columns: new[] { "CompanyId", "CompanyName" },
                values: new object[,]
                {
                    { 1, "Migros Ticaret A.Ş." },
                    { 2, "Agito Yazılım & Danışmanlık" },
                    { 3, "Intertech Bilgi İşlem ve Pazarlama Ticaret A.Ş." }
                });

            migrationBuilder.InsertData(
                table: "DescriptionsModel",
                columns: new[] { "DescId", "Description" },
                values: new object[,]
                {
                    { 1, "Şirketin Alternatif Dağıtım Kanalları bölümünde Kullanıcı Deneyiminden sorumlulu ekipte görev aldım. Ms Sql ve Asp.Net ile web uygulaması geliştirdim. Bu görev boyunca ekibin kullanabileceği,işlevi ekip içindeki kullanıcıların birbirine görev atayıp bu görevleri takip edebileceği ASP.NET ve MS SQL tabanlı ve N - tier yaklaşımının kullanıldığı bir web uygulaması tasarlayıp hayata geçirdim." },
                    { 2, "Birden fazla sağlık sigortası şirketine geliştirmeler sağlayan Proje ve Ek Kapsam ekibinde Yazılım Uzman Yardımcısı olarak görev aldım. Oracle Database ve PL/SQL ile backend geliştirmede, IIS, ASP.NET ile web uygulaması ve Soap tabanlı web servisleri üzerine geliştirmelerde bulundum. BNP Paribas Cardif sigortacılık şirket için yazılım geliştirme ekibinde Yazılım Uzman Yardımcısı olarak görev aldım. Uygulama geliştirmede Oracle Database, PL/SQL, Oracle Forms Builder, Oracle Forms Reports ve Oracle Weblogic Server kullandım." },
                    { 3, "NN Hayat ve Emeklilik ile ING Bank arasında veri entegrasyonu projesinde backend yazılımcı olarak görev aldım. NN Hayat ve Emeklilik verileri anlık olarak kayıt edilip daha sonra asenkron bir yapı ile kontrolü sağlanıp ING Bank sistemi ile entegrasyonu sağlanmaktadır. Bu projede geçmiş verilerin SFTP ile aktarılmasında, sistemin geliştirilmesinde ve iyileştirilmesinde görev aldım." }
                });

            migrationBuilder.InsertData(
                table: "TitlesModel",
                columns: new[] { "TitleId", "EndDate", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Software Specialist" },
                    { 2, new DateTime(2019, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yazılım Uzmanı" },
                    { 3, new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yazılım Uzman Yardımcısı" },
                    { 4, new DateTime(2016, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stajyer Mühendis" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompaniesModel");

            migrationBuilder.DropTable(
                name: "DescriptionsModel");

            migrationBuilder.DropTable(
                name: "TitlesModel");

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "CompanyName" },
                values: new object[,]
                {
                    { 1, "Migros Ticaret A.Ş." },
                    { 2, "Agito Yazılım & Danışmanlık" },
                    { 3, "Intertech Bilgi İşlem ve Pazarlama Ticaret A.Ş." }
                });

            migrationBuilder.InsertData(
                table: "Descriptions",
                columns: new[] { "DescId", "Description" },
                values: new object[,]
                {
                    { 1, "Şirketin Alternatif Dağıtım Kanalları bölümünde Kullanıcı Deneyiminden sorumlulu ekipte görev aldım. Ms Sql ve Asp.Net ile web uygulaması geliştirdim. Bu görev boyunca ekibin kullanabileceği,işlevi ekip içindeki kullanıcıların birbirine görev atayıp bu görevleri takip edebileceği ASP.NET ve MS SQL tabanlı ve N - tier yaklaşımının kullanıldığı bir web uygulaması tasarlayıp hayata geçirdim." },
                    { 2, "Birden fazla sağlık sigortası şirketine geliştirmeler sağlayan Proje ve Ek Kapsam ekibinde Yazılım Uzman Yardımcısı olarak görev aldım. Oracle Database ve PL/SQL ile backend geliştirmede, IIS, ASP.NET ile web uygulaması ve Soap tabanlı web servisleri üzerine geliştirmelerde bulundum. BNP Paribas Cardif sigortacılık şirket için yazılım geliştirme ekibinde Yazılım Uzman Yardımcısı olarak görev aldım. Uygulama geliştirmede Oracle Database, PL/SQL, Oracle Forms Builder, Oracle Forms Reports ve Oracle Weblogic Server kullandım." },
                    { 3, "NN Hayat ve Emeklilik ile ING Bank arasında veri entegrasyonu projesinde backend yazılımcı olarak görev aldım. NN Hayat ve Emeklilik verileri anlık olarak kayıt edilip daha sonra asenkron bir yapı ile kontrolü sağlanıp ING Bank sistemi ile entegrasyonu sağlanmaktadır. Bu projede geçmiş verilerin SFTP ile aktarılmasında, sistemin geliştirilmesinde ve iyileştirilmesinde görev aldım." }
                });

            migrationBuilder.InsertData(
                table: "Titles",
                columns: new[] { "TitleId", "EndDate", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Software Specialist" },
                    { 2, new DateTime(2019, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yazılım Uzmanı" },
                    { 3, new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yazılım Uzman Yardımcısı" },
                    { 4, new DateTime(2016, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stajyer Mühendis" }
                });
        }
    }
}
