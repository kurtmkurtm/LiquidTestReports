using Schemas.VisualStudio.TeamTest;
using System.IO;
using System.Xml.Serialization;

namespace LiquidTestReports.Cli.Loaders
{
    internal class TrxLoader
    {
        internal static TestRunType FromFile(string file)
        {
            var ser = new XmlSerializer(typeof(TestRunType));
            using (var reader = new StreamReader(file))
            {
                if (ser.Deserialize(reader) is TestRunType results)
                    return results;
            }
            throw new InvalidDataException($"Provided file {file} could not be deserialised, check file is valid TRX XML");
        }
    }

}
