using System.IO;

namespace _04.Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream reader = new FileStream("../../../Resorces/copyMe.png", FileMode.Open);
            FileStream writer = new FileStream("../../copied.png", FileMode.Create);

            byte[] buffer = new byte[4096];

            using (reader)
            {
                using (writer)
                {
                    while (true)
                    {
                        int raedBytesCount = reader.Read(buffer, 0, buffer.Length);
                        if (raedBytesCount == 0)
                            break;

                        writer.Write(buffer, 0, raedBytesCount);
                    }
                }
            }
        }
    }
}
