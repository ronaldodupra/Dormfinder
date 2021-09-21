namespace DormFinder.Web.Entities
{
    public class FileEntry : BaseEntity
    {
        public int Id { get; set; }

        public string Filename { get; set; }

        public string MediaType { get; set; }

        public long Length { get; set; }

        public string Path { get; set; }

        public FileEntry(string path, string filename, string mediaType, long length)
        {
            Filename = filename;
            Path = path;
            MediaType = mediaType;
            Length = length;
        }

        public FileEntry()
        {
        }
    }
}
