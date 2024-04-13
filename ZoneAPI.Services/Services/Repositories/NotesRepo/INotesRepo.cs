using Zone.Data.Data.Models;

namespace Zone.Services.Services.Repositories.NotesRepo;

public interface INotesRepo
{
    public Task GetNote(Guid noteId);
    public Task SaveNotes(List<Note> notes);
    public Task RemoveNote(Guid noteId);
}