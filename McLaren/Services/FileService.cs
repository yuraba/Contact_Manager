using McLaren.DAL;
using McLaren.Models;
using Microsoft.AspNetCore.Mvc;

namespace McLaren.Services;

public class FileService
{
    private readonly FileRepository _fileRepository;

    public FileService(FileRepository fileRepository)
    {
        _fileRepository = fileRepository;
    }
    public async Task<ActionResult<FileModel>> Create(FileModel product)
    {
        return await _fileRepository.Create(product);
    }
    public async Task<ActionResult<IEnumerable<FileModel>>> GetFiles()
    {
       return await _fileRepository.GetFiles();
    }
    public async Task<ActionResult<FileModel>> Edit(FileModel file)
    {
        return await _fileRepository.Edit(file);
    }
    public async Task<ActionResult<FileModel>> Delete(int? id)
    {
        return await _fileRepository.Delete(id);
    }
}