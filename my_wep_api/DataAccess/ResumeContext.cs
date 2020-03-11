using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using my_wep_api.Configuration;
using my_wep_api.Entities;
using my_wep_api.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace my_wep_api.DataAccess
{
    public class ResumeContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public ResumeContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //public ResumeContext(DbContextOptions<ResumeContext> options)
        //: base(options)
        //{ }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//update-database -Context ResumeContext yaparken bu fonk'u yarum satırına al.
        {

            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("MyDbConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Descriptions>().HasData(new Descriptions
            {
                DescId = 1,
                Description = "Şirketin Alternatif Dağıtım Kanalları bölümünde Kullanıcı Deneyiminden sorumlulu ekipte görev aldım. Ms Sql ve Asp.Net ile web uygulaması geliştirdim. Bu görev boyunca ekibin kullanabileceği,işlevi ekip içindeki kullanıcıların birbirine görev atayıp bu görevleri takip edebileceği ASP.NET ve MS SQL tabanlı ve N - tier yaklaşımının kullanıldığı bir web uygulaması tasarlayıp hayata geçirdim."

            }, new Descriptions
            {
                DescId = 2,
                Description = "Birden fazla sağlık sigortası şirketine geliştirmeler sağlayan Proje ve Ek Kapsam ekibinde Yazılım Uzman Yardımcısı olarak görev aldım. Oracle Database ve PL/SQL ile backend geliştirmede, IIS, ASP.NET ile web uygulaması ve Soap tabanlı web servisleri üzerine geliştirmelerde bulundum. BNP Paribas Cardif sigortacılık şirket için yazılım geliştirme ekibinde Yazılım Uzman Yardımcısı olarak görev aldım. Uygulama geliştirmede Oracle Database, PL/SQL, Oracle Forms Builder, Oracle Forms Reports ve Oracle Weblogic Server kullandım.",
            }, new Descriptions
            {
                DescId = 3,
                Description = "NN Hayat ve Emeklilik ile ING Bank arasında veri entegrasyonu projesinde backend yazılımcı olarak görev aldım. NN Hayat ve Emeklilik verileri anlık olarak kayıt edilip daha sonra asenkron bir yapı ile kontrolü sağlanıp ING Bank sistemi ile entegrasyonu sağlanmaktadır. Bu projede geçmiş verilerin SFTP ile aktarılmasında, sistemin geliştirilmesinde ve iyileştirilmesinde görev aldım.",
            });

            modelBuilder.Entity<Titles>().HasData(new Titles
            {
                TitleId = 1,

                Title = "Software Specialist",

                StartDate = new DateTime(2019,08,1)

            },new Titles
            {
                TitleId = 2,

                Title = "Yazılım Uzmanı",

                StartDate = new DateTime(2019,02,1),

                EndDate = new DateTime(2019,08,1)

            }, new Titles
            {
                TitleId = 3,

                Title = "Yazılım Uzman Yardımcısı",

                StartDate = new DateTime(2017,07,1),

                EndDate = new DateTime(2019,02,1)

            }, new Titles
            {
                TitleId = 4,

                Title = "Stajyer Mühendis",

                StartDate = new DateTime(2016,07,1),

                EndDate = new DateTime(2016,08,1)

            }
            );

            modelBuilder.Entity<Companies>().HasData(new Companies
            {
                CompanyId = 1,

                CompanyName = "Migros Ticaret A.Ş.",
            }, new Companies
            {
                CompanyId = 2,

                CompanyName = "Agito Yazılım & Danışmanlık"
            }, new Companies
            {
                CompanyId = 3,

                CompanyName = "Intertech Bilgi İşlem ve Pazarlama Ticaret A.Ş."
            });
        }

        public DbSet<Resumes> Resumes { get; set; }
        public DbSet<Titles> Titles { get; set; }
        public DbSet<Companies> Companies { get; set; }
        public DbSet<Descriptions> Descriptions { get; set; }
    }

    //public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ResumeContext>
    //{
    //    public ResumeContext CreateDbContext(string[] args)
    //    {
    //        IConfigurationRoot configuration = new ConfigurationBuilder()
    //            .SetBasePath(Directory.GetCurrentDirectory())
    //            .AddJsonFile("appsettings.json")
    //            .Build();
    //        var builder = new DbContextOptionsBuilder<ResumeContext>();
    //        var connectionString = configuration.GetConnectionString("MyDbConnection");
    //        builder.UseSqlServer(connectionString);
    //        return new ResumeContext(builder.Options);
    //    }
    //}
}
