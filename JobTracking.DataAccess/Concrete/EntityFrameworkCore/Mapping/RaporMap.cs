using JobTracking.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobTracking.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class RaporMap : IEntityTypeConfiguration<Rapor>
    {
        public void Configure(EntityTypeBuilder<Rapor> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Tanim).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Detay).HasColumnType("ntext");

            builder.HasOne(x => x.Gorev).WithMany(x => x.Raporlar).HasForeignKey(x => x.GorevId);
        }
    }
}
