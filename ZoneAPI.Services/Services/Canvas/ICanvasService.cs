using Zone.Data.Models;

namespace Zone.Services.Services.Canvas;

public interface ICanvasService
{
    public Task GetZoneNotes(Guid zoneId);
    public Task SaveNotes(Guid zoneId, List<Note> notes);
    public Task RemoveNote(Guid zoneId, Guid noteId);
}