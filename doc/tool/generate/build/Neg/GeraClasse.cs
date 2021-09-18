using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gcpbuild.Neg
{
    public class GeraClasse
    {
        private string _pastaLocal = "";
        private string _pastaTemplates = "";
        public string _pastaResultado = @"\Result\";
        public GeraClasse()
        {
            _pastaLocal = Directory.GetCurrentDirectory();
        }

        public void ReplaceTemplates(string nomeChave)
        {
            var lstFiles = Directory.GetFiles(_pastaLocal + _pastaTemplates);


            foreach (var filePath in lstFiles)
            {
                var file = new FileInfo(filePath);
                string fileNameResultado;
                
                if (file.Name.Contains("NomeModel"))
                    fileNameResultado = file.Name.Replace("NomeModel", nomeChave);
                else if (file.Name.Contains("nomemodel"))
                    fileNameResultado = file.Name.Replace("nomemodel", nomeChave.ToLower());
                else
                    fileNameResultado = file.Name;

                fileNameResultado = fileNameResultado.Replace(".txt", "");

                StringBuilder sb = new StringBuilder(File.ReadAllText(filePath));
                sb = sb.Replace("#nomemodel#", nomeChave.ToLower());
                sb = sb.Replace("#NOMEMODEL#", nomeChave.ToUpper());
                sb = sb.Replace("#NomeModel#", nomeChave);
                if (!Directory.Exists(_pastaLocal + _pastaTemplates + _pastaResultado))
                {
                    Directory.CreateDirectory(_pastaLocal + _pastaTemplates + _pastaResultado);
                }
                File.WriteAllText(_pastaLocal + _pastaTemplates + _pastaResultado + fileNameResultado, sb.ToString());
            }
        }
    }
}
