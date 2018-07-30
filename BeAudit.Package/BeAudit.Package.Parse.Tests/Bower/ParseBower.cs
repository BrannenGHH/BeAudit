using System.IO;
using System.Linq;
using System.Text;
using BeAudit.Package.Enumerations;
using BeAudit.Package.Parse.Factories;
using Xunit;

namespace BeAudit.Package.Parse.Tests.Bower
{
    public class ParseBower
    {
        private PackagePropertiesFactory packageFactory;

        private readonly string bowerFile =
            @"{
          ""name"": ""blue-leaf"",
          ""description"": ""Physics-like animations for pretty particles"",
          ""main"": [
            ""js/motion.js"",
            ""sass/motion.scss""
          ],
          ""dependencies"": {
            ""get-size"": ""~1.2.2"",
            ""eventEmitter"": ""~4.2.11""
          },
          ""devDependencies"": {
            ""qunit"": ""~1.16.0""
          },
          ""moduleType"": [
            ""amd"",
            ""globals"",
            ""node""
          ],
          ""keywords"": [
            ""motion"",
            ""physics"",
            ""particles""
          ],
          ""authors"": [
            ""Betty Beta <bbeta@example.com>""
          ],
          ""license"": ""MIT"",
          ""ignore"": [
            ""**/.*"",
            ""node_modules"",
            ""bower_components"",
            ""test"",
            ""tests""
          ],
          ""private"": true
        }";

        public void SetUp()
        {
            packageFactory = new PackagePropertiesFactory();
        }

        [Fact]
        public void ParseDependencies()
        {
            SetUp();

            Stream bowerStream = new MemoryStream(Encoding.UTF8.GetBytes(bowerFile));

            var packages = packageFactory.CreatePackageIdentifier(PackageManager.Bower, bowerStream).ToList();

            Assert.NotEmpty(packages);
        }
    }
}