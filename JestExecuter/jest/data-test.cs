using System.Collections.Generic;

namespace JestExecuter.jest
{
    public class Data_test
    {
        public Data_test()
        {
            path = @"D:\Others\Jest\jest.json";
        }

        private readonly string path;

        public object TestReadFile()
        {
            var result = UtilsLibrary.DataHelper.JsonToObject(path);
            var result_t = UtilsLibrary.DataHelper.JsonToDictionary<Dictionary<string, object>>(path);
            return new { obj = result, dic = result_t };
        }
    }
}
