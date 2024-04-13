namespace Zone.API.Controllers.Hubs.CanvasHub;

public interface ICanvasHub
{
    public Task SaveNotes();
    public Task RemoveNote(string noteId);
}