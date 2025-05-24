using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace we_r_of_milo
{
    internal class FileManager
    {
        static string fileRoot = "files/";
        static int totalNumFiles = 0;
        static Dictionary<int, FileStream> openFiles = new Dictionary<int, FileStream>();

        public static FileInfo? GetFileStat(string path)
        {
            FileInfo? fi = null;
            try
            {
                if (Environment.OSVersion.Platform != PlatformID.Win32NT)
                    path = path.Replace('\\', '/');
                path = path.Replace("..", "(..)");
                Console.WriteLine(" statpath: " + fileRoot + path);
                fi = new FileInfo(fileRoot + path);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to stat file: " + ex);
                return null;
            }
            return fi;
        }

        public static int OpenFileReadOnly(string path)
        {
            try
            {
                if (Environment.OSVersion.Platform != PlatformID.Win32NT)
                    path = path.Replace('\\', '/');
                path = path.Replace("..", "(..)");
                FileStream fs = File.OpenRead(fileRoot + path);
                int fd = totalNumFiles++;
                lock (openFiles)
                {
                    openFiles[fd] = fs;
                }
                return fd;
            } catch (Exception ex)
            {
                Console.WriteLine("Failed to open file: " + ex);
                return -1;
            }
        }

        public static void PrintFiles()
        {
            lock (openFiles)
            {
                foreach (int fd in openFiles.Keys)
                {
                    Console.WriteLine(" {0}: {1}", fd, openFiles[fd].Name);
                }
            }
        }

        public static FileStream? GetFile(int fd)
        {
            if (!openFiles.ContainsKey(fd))
                return null;
            return openFiles[fd];
        }

        public static void CloseFile(int fd)
        {
            lock(openFiles)
            {
                openFiles[fd].Close();
                openFiles.Remove(fd);
            }
        }
    }
}
