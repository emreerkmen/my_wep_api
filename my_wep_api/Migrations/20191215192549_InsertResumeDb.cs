using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace my_wep_api.Migrations
{
    public partial class InsertResumeDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
