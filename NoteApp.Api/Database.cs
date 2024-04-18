using Microsoft.EntityFrameworkCore;

using NoteApp.Api.Models;

namespace NoteApp.Api;

/// <summary>
/// Initializes a database context of the application.
/// Implements <see cref="DbContext"/> class with the specified options.
/// </summary>
/// <param name="options">The options for the database context.</param>
public class Database(DbContextOptions<Database> options) : DbContext(options)
{
    /// <summary>
    /// Storage for the instances of the <see cref="Note"/> entity.
    /// </summary>
    public DbSet<Note> Notes => Set<Note>();
}