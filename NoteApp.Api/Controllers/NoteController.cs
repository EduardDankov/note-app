using Microsoft.AspNetCore.Mvc;

using NoteApp.Api.Interfaces;
using NoteApp.Api.Models;

namespace NoteApp.Api.Controllers;

/// <summary>
/// Manages API requests regarding <see cref="Note"/> model.
/// </summary>
/// <param name="noteService">Injected <see cref="INoteService"/> dependency.</param>
[ApiController]
[Route("/api/v1/notes")]
public class NoteController(INoteService noteService) : ControllerBase
{
    /// <summary>
    /// Manages <i>GET /api/v1/notes</i> request to the server.
    /// <inheritdoc cref="INoteService.GetAllNotes()"/>
    /// </summary>
    /// <returns><b>200 OK</b> - <inheritdoc cref="INoteService.GetAllNotes()"/></returns>
    [HttpGet]
    public async Task<IActionResult> GetNotes()
    {
        return Ok(await noteService.GetAllNotes());
    }

    /// <summary>
    /// Manages <i>GET /api/v1/notes/:id</i> request to the server.
    /// <inheritdoc cref="INoteService.GetNoteById(int)"/>
    /// </summary>
    /// <param name="id"><inheritdoc cref="INoteService.GetNoteById(int)"/></param>
    /// <returns>
    /// The HTTP status and additional information based on the following conditions:
    /// <ul>
    ///     <li><b>Note exists:</b> 200 OK with the retrieved <see cref="Note"/> object in the response body.</li>
    ///     <li><b>Note does not exist:</b> 404 Not Found with an error message in the response body.</li>
    /// </ul>
    /// </returns>
    [HttpGet("{id}", Name = "GetNoteById")]
    public async Task<IActionResult> GetNoteById([FromRoute] int id)
    {
        Note? note = await noteService.GetNoteById(id);
        return note is not null
            ? Ok(note)
            : NotFound($"Note with ID: {id} does not exist.");
    }

    /// <summary>
    /// Manages <i>POST /api/v1/notes</i> request to the server.
    /// <inheritdoc cref="INoteService.AddNote(Note)"/>
    /// </summary>
    /// <param name="note"><inheritdoc cref="INoteService.AddNote(Note)"/></param>
    /// <returns><b>201 Created</b> - The created <see cref="Note"/> instance.</returns>
    [HttpPost]
    public async Task<IActionResult> CreateNote([FromBody] Note note)
    {
        await noteService.AddNote(note);
        return CreatedAtRoute("GetNoteById", new { id = note.NoteId }, note);
    }

    /// <summary>
    /// Manages <i>PUT /api/v1/notes/:id</i> request to the server.
    /// <inheritdoc cref="INoteService.UpdateNote(Note, Note)"/>
    /// </summary>
    /// <param name="id">The the index of the note to be modified.</param>
    /// <param name="note"><inheritdoc cref="INoteService.UpdateNote(Note, Note)"/></param>
    /// <returns>
    /// The HTTP status and additional information based on the following conditions:
    /// <ul>
    ///     <li><b>Note exists and successfully updated:</b> 204 No Content.</li>
    ///     <li><b>Note does not exist:</b> 404 Not Found with an error message in the response body.</li>
    ///     <li><b>Note exists but update failed:</b> 400 Bad Request with an error message in the response body.</li>
    /// </ul>
    /// </returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateNote([FromRoute] int id, [FromBody] Note note)
    { 
        Note? entry = await noteService.GetNoteById(id);

        if (entry is null)
        {
            return NotFound($"Note with ID: {id} does not exist.");
        }

        try
        {
            await noteService.UpdateNote(entry, note);
            return NoContent();
        }
        catch (InvalidOperationException exception)
        {
            return BadRequest(exception.Message);
        }
    }

    /// <summary>
    /// Manages <i>DELETE /api/v1/notes/:id</i> request to the server.
    /// <inheritdoc cref="INoteService.DeleteNote(Note)"/>
    /// </summary>
    /// <param name="id">The index of the note to be deleted.</param>
    /// <returns>
    /// The HTTP status and additional information based on the following conditions:
    /// <ul>
    ///     <li><b>Note exists and successfully deleted:</b> 204 No Content.</li>
    ///     <li><b>Note does not exist:</b> 404 Not Found with an error message in the response body.</li>
    /// </ul>
    /// </returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNote([FromRoute] int id)
    {
        Note? note = await noteService.GetNoteById(id);
        if (note is null)
        {
            return NotFound($"Note with ID: {id} does not exist.");
        }
        
        await noteService.DeleteNote(note);
        return NoContent();
    }
}