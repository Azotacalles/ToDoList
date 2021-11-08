using System.ComponentModel;
using System.IO;
using System.Text.Json;
using ToDoList.Models;

namespace ToDoList.Services
{
    class FileIOService
    {
        private readonly string path;

        public FileIOService(string path)
        {
            this.path = path;
        }

        public BindingList<ToDoModel> LoadData()
        {
            if(!File.Exists(path))
            {
                File.CreateText(path).Dispose();
                return new BindingList<ToDoModel>();
            }
            using(StreamReader sr = File.OpenText(path))
            {
                string fileText = sr.ReadToEnd();
                return JsonSerializer.Deserialize<BindingList<ToDoModel>>(fileText);
            }
        }

        public void SaveData(BindingList<ToDoModel> todoDataList)
        {
            using(StreamWriter sw = File.CreateText(path))
            {
                string output = JsonSerializer.Serialize(todoDataList);
                sw.Write(output);
            }
        }
    }
}
