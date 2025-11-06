using Domain.BaseEntitys;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.BaseEntitys;

internal sealed class BaseEntityItemConfiguration : IEntityTypeConfiguration<BaseEntityItem>
{
    public void Configure(EntityTypeBuilder<BaseEntityItem> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.DueDate).HasConversion(d => d != null ? DateTime.SpecifyKind(d.Value, DateTimeKind.Utc) : d, v => v);

        builder.HasOne<User>().WithMany().HasForeignKey(t => t.UserId);
    }
}
