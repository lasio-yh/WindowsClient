using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using MnStudio.Core.Models.File;
using MnStudio.Core.Contracts;

namespace MnStudio.Core.Services
{
    public class FileService : IFIleManager
    {
        public Document OnOpenFile(string path, string encoding)
        {
            try
            {
                var result = new Document();
                var obj = new XmlSerializer(typeof(Document));
                using (var reader = new StreamReader(path, System.Text.Encoding.GetEncoding(encoding)))
                {
                    result = (Document)obj.Deserialize(reader);
                }
                return result;
            }
            catch (AccessViolationException ex)
            {
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void OnSaveFile()
        {
            try
            {

            }
            catch (AccessViolationException ex)
            {

            }
            catch (Exception ex)
            {

            }
        }

        public void OnApplyFile()
        {
            try
            {

            }
            catch (AccessViolationException ex)
            {

            }
            catch (Exception ex)
            {

            }
        }
    }
}