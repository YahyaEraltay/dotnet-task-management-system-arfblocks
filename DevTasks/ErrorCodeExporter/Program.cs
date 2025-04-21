public class Program
{
    public static async Task Main(string[] args)
    {
        System.Console.WriteLine($"args: {args[0]}");
        Dictionary<string, Type> pathsAndTypes = new Dictionary<string, Type>();
        if (args[0] == "task-management")
            pathsAndTypes = GetPathsAndTypes();

        foreach (KeyValuePair<string, Type> pathAndType in pathsAndTypes)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), pathAndType.Key);
            System.Console.WriteLine(path);
            var content = await Read(path);

            var output = GetErrorAsTypescriptFiles(content, pathAndType.Value);

            var isWrited = await Write(pathAndType.Key, output);

            System.Console.WriteLine($"Result: {isWrited}");
        }

        static Dictionary<string, Type> GetPathsAndTypes()
        {
            var pathAndTypes = new Dictionary<string, Type>()
            {
                {"../../tr.ts" , typeof(Domain.Errors.DomainErrors)},
            };

            return pathAndTypes;
        }

        static string GetErrorAsTypescriptFiles(Dictionary<string, string> lines, Type myType)
        {
            try
            {
                // Get an array of nested type objects in MyClass.
                Type[] nestType = myType.GetNestedTypes();

                var output = "export const errors = {";

                foreach (Type type in nestType)
                {
                    var properties = type.GetProperties().ToList();

                    properties.ForEach((property) =>
                        {
                            if (property.PropertyType == typeof(string))
                            {
                                var propertyName = Domain.Errors.ErrorCodeGenerator.GetFrontendName(property.Name);
                                var propertyValue = property.GetValue(null, null);

                                var line = lines.FirstOrDefault(l => l.Key == propertyName);

                                if (!line.Equals(new KeyValuePair<string, string>()))
                                    output += Environment.NewLine + $"\t{propertyName}: {line.Value},";
                                else
                                    output += Environment.NewLine + $"\t{propertyName}: '{propertyValue}',";
                            }
                        });
                }

                output += Environment.NewLine + "}";
                return output;
            }
            catch (Exception e)
            {
                var message = $"Error: {e.Message}";
                return message;
            }
        }

        static async Task<Dictionary<string, string>> Read(string path)
        {
            if (!File.Exists(path))
                throw new Exception($"File not exist: {path}");

            var content = new Dictionary<string, string>();

            var streamReader = new StreamReader(path);
            var templateContent = await streamReader.ReadToEndAsync();
            streamReader.Close();

            var templateContentKeyAndValue = templateContent.Replace("export const errors = {", "").Replace("};", "").Replace("\n", "").Split(',');

            for (int i = 0; i < templateContentKeyAndValue.Length; i++)
            {
                var contentKeyAndValue = templateContentKeyAndValue[i].Split(':');

                if (string.IsNullOrEmpty(templateContentKeyAndValue[i]) || string.IsNullOrWhiteSpace(templateContentKeyAndValue[i]) || !templateContentKeyAndValue[i].Contains(':'))
                    continue;

                content.Add(contentKeyAndValue[0].Trim(), contentKeyAndValue[1].Trim());
            }

            return content;
        }

        static async Task<bool> Write(string path, string template)
        {
            try
            {
                var streamWriter = new StreamWriter(path);
                await streamWriter.WriteAsync(template);
                streamWriter.Close();

                return true;
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}