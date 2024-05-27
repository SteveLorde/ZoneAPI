using Zone.Data.Models;

namespace Zone.Services.Services.Repositories.NotesRepo;

sealed class NotesRepo : INotesRepo
{
    public async Task GetNote(Guid noteId)
    {
        throw new NotImplementedException();
    }

    public async Task SaveNotes(List<Note> notes)
    {
        throw new NotImplementedException();
    }

    public async Task RemoveNote(Guid noteId)
    {
        throw new NotImplementedException();
    }
}