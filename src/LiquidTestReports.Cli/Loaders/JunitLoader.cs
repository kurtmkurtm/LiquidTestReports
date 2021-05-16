using LiquidTestReports.Core.Junit;
using System.IO;
using System.Xml.Serialization;

namespace LiquidTestReports.Cli.Loaders
{
    internal class JUnitLoader
    {
        internal static Testsuites FromFile(string file)
        {
            var ser = new XmlSerializer(typeof(Testsuites));
            using (var reader = new StreamReader(file))
            {
                if (ser.Deserialize(reader) is Testsuites results)
                    return results;
            }
            throw new InvalidDataException($"Provided file {file} could not be deserialised, check file is valid JUnit XML");
        }
    }

}
