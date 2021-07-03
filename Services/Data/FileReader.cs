using Microsoft.AspNetCore.Hosting;

namespace Services.Data
{
    public class FileReader
    {
        IWebHostEnvironment _environment;

        public FileReader(IWebHostEnvironment env)
        {
            _environment = env;
        }
    }
}
