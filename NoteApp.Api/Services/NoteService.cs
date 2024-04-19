using Microsoft.EntityFrameworkCore;

using NoteApp.Api.Interfaces;
using NoteApp.Api.Models;

namespace NoteApp.Api.Services;

/// <summary>
/// Manages <see cref="Note"/> instances within the application database.
/// Implements <see cref="INoteService"/> contract.
/// </summary>
/// <param name="context">Injected <see cref="Database"/> context dependency.</param>
public class NoteService(Database context) : INoteService
{
    /// <inheritdoc cref="INoteService.GetAllNotes()"/>
    public async Task<List<Note>> GetAllNotes()
    {
        return await context.Notes.ToListAsync();
    }

    /// <inheritdoc cref="INoteService.GetNoteById(int)"/>
    public async Task<Note?> GetNoteById(int id)
    {
        return await context.Notes.FindAsync(id);
    }

    /// <inheritdoc cref="INoteService.AddNote(Note)"/>
    public async Task AddNote(Note note)
    {
        context.Notes.Add(note);
        await context.SaveChangesAsync();
    }

    /// <inheritdoc cref="INoteService.UpdateNote(Note, Note)"/>
    public async Task UpdateNote(Note entry, Note value)
    {
        context.Entry(entry).CurrentValues.SetValues(value);
        await context.SaveChangesAsync();
    }

    /// <inheritdoc cref="INoteService.DeleteNote(Note)"/>
    public async Task DeleteNote(Note note)
    {
        context.Notes.Remove(note);
        await context.SaveChangesAsync();
    }
}