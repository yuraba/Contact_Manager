using McLaren.Models;
using McLaren.MyDataContext;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace McLaren.DAL;

public class FileRepository
{
    private readonly MyDbContext _context;

    public FileRepository(MyDbContext context)
    {
        _context = context;
    }
    public async Task<ActionResult<FileModel>> Create(FileModel file)
    {
        _context.Add(file);
        await _context.SaveChangesAsync();
        return file;
    }
    public async Task<ActionResult<IEnumerable<FileModel>>> GetFiles()
    {
        return await _context.Files.ToListAsync();
    }
    public async Task<ActionResult<FileModel>> Edit(FileModel file)
    {
        _context.Update(file); 
        await _context.SaveChangesAsync();
        return file;
    }
       public async Task<ActionResult<FileModel>> Delete(int? id)
    {
       

        var file = await _context.Files
            .FirstOrDefaultAsync(m => m.FileId == id);
        return file;
    }
}