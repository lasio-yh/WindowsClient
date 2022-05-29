using Core.Model;

namespace Core.Contracts
{
    public interface IFileService
    {
        T Read<T>(string folderPath, string fileName);
        ResultMapModel Save<T>(string folderPath, string fileName, T content);
        ResultMapModel Copy(string sourcepath, string sourcename, string targetpath, string targetname, int bufsize);
        ResultMapModel Delete(string folderPath, string fileName);
    }
}
