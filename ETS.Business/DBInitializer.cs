using ETS.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ETS.Data
{
    public class DBInitializer
    {
        public DBInitializer()
        {
            var context = new ETSContext();

            if (context.Database.EnsureDeleted())
            {
                context.Personels.AddRange(SeedPersonels());
                context.Database.Migrate();
                context.SaveChanges();
            }
        }

        private List<Personel> SeedPersonels()
        {
            var list = new List<Personel>();
            list.AddRange(new List<Personel>() {
                new Personel() { Name = "Süleyman", Surname = "Gümüş", BirthDate = DateTime.Parse("1994/05/05"), CreateDate = DateTime.Now, CreatedBy = "", IsMale = true, PhoneNumber = "5334836686"  } ,
                new Personel() { Name = "Turgut Yavuz", Surname = "ÜNLÜ", BirthDate = DateTime.Parse("1994/06/05"), CreateDate = DateTime.Now, CreatedBy = "", IsMale = true, PhoneNumber = "5334836686" },
                new Personel() { Name = "Yakup", Surname = "Ünlü", BirthDate = DateTime.Parse("1994/07/05"), CreateDate = DateTime.Now, CreatedBy = "", IsMale = true, PhoneNumber = "5334836686" },
                new Personel() { Name = "Hande", Surname = "Emren", BirthDate = DateTime.Parse("1995/07/05"), CreateDate = DateTime.Now, CreatedBy = "", IsMale = false, PhoneNumber = "5334836686" }
            });

            return list;
        }
    }
}
