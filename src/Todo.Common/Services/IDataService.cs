using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Common.Models;
using Todo.Common.Extensions;
using System.Text.Json;

namespace Todo.Common.Services
{
    public interface IDataService<T, TKey>
    {
        Task SaveAsync(TaskModel obj);
        Task<T> GetAsync(TKey id);
    }

    public interface IFileDataService : IDataService<TaskModel?, string>
    {
        
    }

    public class FileDataService : IFileDataService
    {
        private readonly string path;
        
        //todo, configure ilogger
        public FileDataService(string path)
        {
            this.path = path;
        }
        public async Task<TaskModel> GetAsync(string id)
        {
            try
            {
                string fileName = TaskModelExtensions.ToFileName(id);
                string combinedPath = Path.Combine(this.path, fileName);
                if(!File.Exists(combinedPath))
                {
                    Console.WriteLine($"File does not exist at {combinedPath}");
                    return null;
                }
                using StreamReader sr = new StreamReader(path);
                string text = await sr.ReadToEndAsync();

                if (string.IsNullOrWhiteSpace(text))
                {
                    Console.WriteLine($"Empty file at {combinedPath}");
                }

                return JsonSerializer.Deserialize<TaskModel>(text);
            }
            catch(IOException)
            {
                Console.WriteLine("getting file failed for " + id);
                throw;
            }
            catch(JsonException)
            {
                Console.WriteLine("Deserializing file failed");
                throw;
            }
            catch(Exception)
            {
                Console.WriteLine("There was an exception somewhere");
                throw;
            }
        }

        public async Task SaveAsync(TaskModel obj)
        {
            if(obj is null)
            {
                return;
            }

            try
            {
                string fileName = obj.ToFileName();
                string combinedPath = Path.Combine(this.path, fileName);
                using StreamWriter sw = new StreamWriter(this.path);
                string text = JsonSerializer.Serialize(obj);
                await sw.WriteAsync(text);
            }
            catch (IOException)
            {
                Console.WriteLine("file write failed");
                throw;
            }
            catch (JsonException)
            {
                Console.WriteLine("Deserializing file failed");
                throw;
            }
            catch (Exception)
            {
                Console.WriteLine("There was an exception somewhere");
                throw;
            }
        }
    }
}
