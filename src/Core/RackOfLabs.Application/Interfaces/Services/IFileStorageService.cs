namespace RackOfLabs.Application.Interfaces.Services;

public interface IFileStorageService
{
    /// <summary>
    /// Save file to the storage
    /// </summary>
    /// <param name="path">The path to the file</param>
    /// <param name="name">File name with extension</param>
    /// <param name="file">Stream of the file</param>
    void Save(string path, string name, Stream file);
    /// <summary>
    /// Remove file from the storage
    /// </summary>
    /// <param name="path">The path to the file</param>
    /// <param name="name">File name with extension</param>
    void Remove(string path, string name);
    /// <summary>
    /// Remove files in storage recursively by path
    /// </summary>
    /// <param name="path">Path to the directory</param>
    void RemoveRecursively(string path);
    /// <summary>
    /// Get readonly file stream
    /// </summary>
    /// <param name="path">The path to the file</param>
    /// <param name="name">File name with extension</param>
    /// <returns>File stream</returns>
    Stream Get(string path, string name);
}