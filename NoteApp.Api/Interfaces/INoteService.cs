using NoteApp.Api.Models;

namespace NoteApp.Api.Interfaces;

/// <summary>
/// Defines a contract that represents managing <see cref="NoteApp.Api.Models.Note"/> instances within the application.
/// </summary>
public interface INoteService
{
    /// <summary>
    /// Asynchronously creates a <see cref="List{T}"/> of <see cref="Note"/> instances from <see cref="Database"/>.
    /// </summary>
    /// <returns>An enumerable list of <see cref="Note"/>.</returns>
    Task<List<Note>> GetAllNotes();
    
    /// <summary>
    /// Asynchronously looks for an entity with defined index inside <see cref="Database"/>.
    /// If no entity is found, then null is returned.
    /// </summary>
    /// <param name="id">The index of the note to be found.</param>
    /// <returns>The note found, or null.</returns>
    Task<Note?> GetNoteById(int id);
    
    /// <summary>
    /// Adds the passed <see cref="Note"/> instance into <see cref="Database"/>.
    /// </summary>
    /// <param name="note">The instance to add.</param>
    Task AddNote(Note note);
    
    /// <summary>
    /// Updates <see cref="Note"/> entry from <see cref="Database"/> with the passed values.
    /// </summary>
    /// <param name="entry">The entry to modify.</param>
    /// <param name="value">The value to apply.</param>
    Task UpdateNote(Note entry, Note value);
    
    /// <summary>
    /// Deletes the passed <see cref="Note"/> instance from <see cref="Database"/>.
    /// </summary>
    /// <param name="note">The instance to delete.</param>
    Task DeleteNote(Note note);
}
