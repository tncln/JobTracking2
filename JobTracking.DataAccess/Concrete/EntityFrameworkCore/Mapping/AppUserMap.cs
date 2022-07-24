using JobTracking.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobTracking.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(I => I.Name).HasMaxLength(100);
            builder.Property(x => x.Surname).HasMaxLength(100);
            //1 e çok ilişki var
            //hasmany çok olan AppUserda List<Gorevler> 
            //Withone tek olan ise görevler class ında AppUser

            //Yani user 1 - n Gorevler
            builder.HasMany(x => x.Gorevler).WithOne(x => x.AppUser)
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.SetNull); //Eğer user silinirse ne kadar görevi varsa silinmesin diye 
            //user silinirse SEtnull atanacak.
        }
    }
}
