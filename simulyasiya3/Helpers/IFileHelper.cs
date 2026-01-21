namespace simulyasiya3.Helpers
{
    public interface IFileHelper
    {
        public string UniqueName(string filename);
        public string GeneratePath(string folder, string filename);
        public void Delete(string path);
        public Task UploadAsync(IFormFile file, string path);
    }
    public class FileHelper : IFileHelper
    {
        private readonly IWebHostEnvironment _env;

        public FileHelper(IWebHostEnvironment env)
        {
            _env = env;
        }

        public void Delete(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public string GeneratePath(string folder, string filename)
        {
            string path = Path.Combine(_env.WebRootPath, folder, filename);
                return path;
        }

        public string UniqueName(string filename)
        {
            string name = Guid.NewGuid().ToString() + "_" + filename;
            return name;
        }

        public async Task UploadAsync(IFormFile file, string path)
        {
            using FileStream stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);
        }
    }
}
