using Domain.Entities.BookEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration.BookConfig
{

    public class BookAuthorConfiguration:IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.HasKey(x => new {x.AuthorId, x.BookId});
        }
    }
}