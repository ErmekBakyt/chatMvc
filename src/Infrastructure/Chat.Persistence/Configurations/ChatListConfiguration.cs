using Chat.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chat.Persistence.Configurations;

public class ChatListConfiguration :IEntityTypeConfiguration<ChatList>
{
    public void Configure(EntityTypeBuilder<ChatList> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.AppUser)
            .WithMany(x => x.Messages).HasForeignKey(x => x.ToUserId);
        builder.HasMany(x => x.Messages)
            .WithOne(x => x.ChatList).HasForeignKey(x => x.CommonChatListId);
    }
}