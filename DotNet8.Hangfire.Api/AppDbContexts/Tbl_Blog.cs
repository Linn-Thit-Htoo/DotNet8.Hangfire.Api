﻿namespace DotNet8.Hangfire.Api.AppDbContexts;

[Table("Tbl_Blog")]
public class Tbl_Blog
{
    [Key]
    public int BlogId { get; set; }
    public string BlogTitle { get; set; }
    public string BlogAuthor { get; set; }
    public string BlogContent { get; set; }
}
