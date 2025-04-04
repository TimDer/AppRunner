namespace AppRunner
{
    static class JsonReader
    {
        public static T GetJsonDataFromFile<T>(string pathToFile)
        {
            string jsonString = File.ReadAllText(pathToFile);

            T? jsonData = System.Text.Json.JsonSerializer.Deserialize<T>(jsonString);

            if (jsonData == null)
            {
                throw new Exception("The contents of the provided file is not json");
            }

            return jsonData;
        }

        public static void SetJsonDataToFile<T>(this T obj, string pathToFile)
        {
            string jsonString = System.Text.Json.JsonSerializer.Serialize(obj);
            File.WriteAllText(pathToFile, jsonString);
        }
    }
}