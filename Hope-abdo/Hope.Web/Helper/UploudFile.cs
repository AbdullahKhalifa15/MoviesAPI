namespace Hope.Web.Helper
{
    public static class UploudFile
    {
        public static string Uploud(string FolderName , IFormFile File)
        {
            try
            {
                string filepath = $"{Directory.GetCurrentDirectory()}/wwwroot/Img/{FolderName}";

                string filename= Guid.NewGuid() + Path.GetFileName(File.FileName);

                string finalpath= Path.Combine(filepath, filename);

                using (var Stream = new FileStream(finalpath, FileMode.Create))
                {
                    File.CopyTo(Stream);
                }
                return filename;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

    }
}
