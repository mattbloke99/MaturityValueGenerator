using System.Xml.Linq;

namespace MaturityValueGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Some people think comments are a code smell.
            //Where I think I might add a comment I usually break the method up such that the comment becomes the name of the new method.
            //I also try not to abreviate method names such that the method name describes what the method does.

            //The paths are hard coded. If this was being developed further then they might be passed in as command parameters or in the configuration file.

            PolicyLoaderService policyLoaderService = new PolicyLoaderService(@"C:\Users\Matt\source\repos\MaturityValueGenerator\MaturityData.csv");

            MaturityXmlService maturityCalculatorService = new MaturityXmlService(policyLoaderService.Policies);

            XDocument maturityValuesXml = maturityCalculatorService.CreateXml();

            maturityValuesXml.Save(@"C:\Users\Matt\source\repos\MaturityValueGenerator\MaturityValues.xml");
        }
    }
}
