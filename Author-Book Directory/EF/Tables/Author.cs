using System;
using System.Collections.Generic;

namespace Author_Book_Directory.EF.Tables;

public partial class Author
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    //public object Author { get; internal set; }
}
