using McLaren.Models;
using McLaren.MyDataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace McLaren.Controllers;

[Route("/api/[controller]")]

public class FileController : Controller
{
    private readonly MyDbContext _context;

    public FileController(MyDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<FileModel>> Create([FromBody] FileModel product)
    {
        if (ModelState.IsValid)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
        return NotFound();
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FileModel>>> GetAccounts()
    {
        if (_context.Files == null)
        {
            return NotFound();
        }
        return await _context.Files.ToListAsync();
    }
    [HttpPut]
    public async Task<ActionResult<FileModel>> Edit(int id, FileModel file)
    {
        if (id != file.FileId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(file);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilesExists(file.FileId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return file;
        }
        return NotFound();
    }
    [HttpDelete]
    public async Task<ActionResult<FileModel>> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var file = await _context.Files
            .FirstOrDefaultAsync(m => m.FileId == id);
        if (file == null)
        {
            return NotFound();
        }

        return file;
    }
    private bool FilesExists(int id)
    {
        return _context.Files.Any(e => e.FileId == id);
    }

    
}