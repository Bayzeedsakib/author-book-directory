using System;
using System.Collections.Generic;

namespace Author_Book_Directory.EF.Tables;

public partial class Book
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Isbn { get; set; } = null!;

    public double Price { get; set; }

    public int AuthorId { get; set; }

    public string Description { get; set; } = null!;

    public virtual Author Author { get; set; } = null!;
}
