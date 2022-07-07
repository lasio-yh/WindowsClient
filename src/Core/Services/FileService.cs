using Core.Contracts;
using Core.Model;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace Core.Services
{
    public class FileService : IFileService
    {
        /// <summary>
        /// 파일 불러오기
        /// </summary>
        /// <param name="folderPath">디렉토리 경로</param>
        /// <param name="fileName">파일명</param>
        /// <return>T</return>
        public T Read<T>(string folderPath, string fileName)
        {
            var path = Path.Combine(folderPath, fileName);
            if (!File.Exists(path)) 
                return default;

            var json = File.ReadAllText(path);
           
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// 파일 저장하기
        /// </summary>
        /// <param name="folderPath">디렉토리 경로</param>
        /// <param name="fileName">파일명</param>
        /// <param name="content">파일타입</param>
        /// <returns>ResultMapModel</returns>
        public ResultMapModel Save<T>(string folderPath, string fileName, T content)
        {
            try
            {
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                var fileContent = JsonConvert.SerializeObject(content);
                File.WriteAllText(Path.Combine(folderPath, fileName), fileContent, Encoding.UTF8);
                return new ResultMapModel { ResultId = "0x00", ResultMessage = "Succes" };
            }
            catch (Exception ex)
            {
                return new ResultMapModel { ResultId = "0x01", ResultMessage = ex.Message };
            }
        }

        /// <summary>
        /// 파일 복사하기
        /// </summary>
        /// <param name="sourcepath">대상 경로</param>
        /// <param name="sourcename">대상 파일명</param>
        /// <param name="targetpath">복사 할 경로</param>
        /// <param name="targetname">복사 할 파일명</param>
        /// <param name="bufsize">버퍼 크기</param>
        /// <return>ResultMapModel</return>
        public ResultMapModel Copy(string sourcePath, string sourceName, string targetPath, string targetName, int bufSize)
        {
            try
            {
                using (var sourceStream = new FileStream(Path.Combine(sourcePath, sourceName), FileMode.Open))
                {
                    var buf = new byte[bufSize];
                    using (var targetStream = new FileStream(Path.Combine(targetPath, targetName), FileMode.Create))
                    {
                        var idx = 0;
                        while ((idx = sourceStream.Read(buf, 0, buf.Length)) > 0)
                        {
                            targetStream.Write(buf, 0, idx);
                        }
                    }
                    buf = null;
                }

                return new ResultMapModel { ResultId = "0x00", ResultMessage = "Succes" };
            }
            catch (Exception ex)
            {
                return new ResultMapModel { ResultId = "0x01", ResultMessage = ex.Message };
            }
        }

        /// <summary>
        /// 파일 삭제하기
        /// </summary>
        /// <param name="folderPath">디렉토리 경로</param>
        /// <param name="fileName">파일명</param>
        /// <return>ResultMapModel</return>
        public ResultMapModel Delete(string folderPath, string fileName)
        {
            try
            {
                if (fileName != null && File.Exists(Path.Combine(folderPath, fileName))) 
                    File.Delete(Path.Combine(folderPath, fileName));
                
                return new ResultMapModel { ResultId = "0x00", ResultMessage = "Succes" };
            }
            catch (Exception ex)
            {
                return new ResultMapModel { ResultId = "0x01", ResultMessage = ex.Message };
            }
        }
    }
}
