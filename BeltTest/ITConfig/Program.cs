using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WixToolset.Dtf.WindowsInstaller;

namespace ITConfig
{
    internal class Program
    {
        static int Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Must specify the BeltTestPackage path and the Customer name");
                return -1;
            }

            var originalMsiPath = Path.GetFullPath(args[0]);
            var tempMsiPath = Path.GetTempFileName();
            var companyName = args[1];

            var outputMstPath = Path.ChangeExtension(originalMsiPath, ".mst");

            using (var db = new Database(originalMsiPath, tempMsiPath))
            {
                var query = $"UPDATE Property SET Value='{companyName}' WHERE Property='CUSTOMER'";
                db.Execute(query);

                db.Commit();
            }

            using (var originalDb = new Database(originalMsiPath))
            using (var updatedDb = new Database(tempMsiPath))
            {
                updatedDb.GenerateTransform(originalDb, outputMstPath);

                updatedDb.CreateTransformSummaryInfo(originalDb, outputMstPath,
                    TransformErrors.None,
                    TransformValidations.UpgradeCode | TransformValidations.NewEqualBaseVersion);
            }

            return 0;
        }
    }
}
