namespace FileIO
{
    public class FileReader
    {
        public static IEnumerable<TLine> ReadFile<TLine>(string filePath)
        {
            if(!File.Exists(filePath))
            {
                throw new FileNotFoundException("Could not find file", filePath);
            }

            FileStream fs = File.OpenRead(filePath);
        }
    }
}