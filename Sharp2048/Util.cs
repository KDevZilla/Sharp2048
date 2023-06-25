using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Sharp2048
{
    public class Util
    {
        public static string CurrentPath
        {
            get
            {
                String ExePath = new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath;
                return Path.GetDirectoryName(ExePath);
                //   logFilePath = logFilePath.Replace(".exe", "");
            }
        }
        public static string ScorePath => $"{CurrentPath}\\Score.bin";
        public static int BestScore()
        {
            DeserializeScore (Score )
        }
        public static void UpdateBestScore(int newBestScore)
        {

        }


        public static void SerializeScore(Score score, String filename)
        {
            //Create the stream to add object into it.  
            System.IO.Stream ms = File.OpenWrite(filename);
            //Format the object as Binary  

            BinaryFormatter formatter = new BinaryFormatter();
            //It serialize the employee object  
            formatter.Serialize(ms, score);
            ms.Flush();
            ms.Close();
            ms.Dispose();
        }

        public static void CreateNewScore(String filename)
        {
            Score score = new Score();
            SerializeScore(score, filename);
         
        }
        public static Score  DeserializeScore(String filename)
        {
            //Format the object as Binary  
            BinaryFormatter formatter = new BinaryFormatter();

            //Reading the file from the server  
            FileStream fs = File.Open(filename, FileMode.Open);

            object obj = formatter.Deserialize(fs);
            // Statistics sta = (Statistics)obj;
            fs.Flush();
            fs.Close();
            fs.Dispose();
            return(Score) obj;
        }
    }
}
