using gcpbuild.Neg;
using System;

namespace gcpbuild
{
    class Program
    {
        static void Main(string[] args)
        {
            ValidationArgs(args);

            string NomeEntidade = args[0];

            var cls = new GeraClasse();
            cls.ReplaceTemplates(NomeEntidade);
            Console.WriteLine($"Concluído, arquivo gerado na pasta '{cls._pastaResultado}'");

        }

        private static void ValidationArgs(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Operação inválida: 1 argumento é necessário para aplicar a #NomeModel# nos arquivos do template");
                Console.WriteLine("FECHAR");
                Console.ReadKey();
                Environment.Exit(1);
            }

            if(args[0] == "-dir")
            {
                var dirLocal = System.IO.Directory.GetCurrentDirectory();
                Console.WriteLine($"Pasta local: ´{dirLocal}´");
                Console.ReadKey();
                Environment.Exit(1);
            }
        }

        
    }
}
