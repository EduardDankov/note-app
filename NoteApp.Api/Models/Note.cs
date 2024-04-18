using System.ComponentModel.DataAnnotations;

namespace NoteApp.Api.Models;

/// <summary>
/// Represents a note within the application.
/// </summary>
public class Note()
{
    /// <summary>
    /// Unique identifier for the note within the system.
    /// </summary>
    public int NoteId { get; set; }

    /// <summary>
    /// Title of the note.
    /// </summary>
    /// <remarks>
    /// Required field. Minimum length of 3 characters and maximum length of 255 characters.
    /// </remarks>
    [Required]
    [MinLength(3)]
    [MaxLength(255)]
    public string? Title { get; set; }
    
    /// <summary>
    /// Content of the note.
    /// </summary>
    /// <remarks>
    /// Required field. Maximum length of 65535 characters.
    /// </remarks>
    [Required]
    [MaxLength(65535)]
    public string? Content { get; set; }
}
