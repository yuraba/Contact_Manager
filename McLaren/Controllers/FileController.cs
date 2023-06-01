using McLaren.Models;
using McLaren.MyDataContext;
using McLaren.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace McLaren.Controllers;

[Route("/api/[controller]")]

public class FileController : Controller
{
    private readonly MyDbContext _context;
    private readonly FileService _fileService;
    public FileController(MyDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<FileModel>> Create([FromBody] FileModel product)
    {
        if (ModelState.IsValid)
        {
           await _fileService.Create(product);
        }
        return NotFound();
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FileModel>>> GetFiles()
    {
        return await _fileService.GetFiles();
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
                return await _fileService.Edit(file);
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