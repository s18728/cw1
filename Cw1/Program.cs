using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //string tmp2 = "Ala ma kota";
            //string tmp3 = "i psa";
            //int tmp4 = 4;
            //Console.WriteLine($"{tmp2} {tmp3 + tmp4}");

            //string path = @"C:\Users\s18728\Desktop\cw1";

            //var tmp6 = 'c';
            //var tmp7 = 2;
            //var tmp8 = true;

            ////int tmp9 = null;
            //int? tmp9 = null;

            //var newPerson = new Person { FirstName = "Jakub" };

            var url = args[0];

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var htmlContent = await response.Content.ReadAsStringAsync();

                        var regex = new Regex(".+@.+[.].+", RegexOptions.IgnoreCase);
                        var matches = regex.Matches(htmlContent);

                        foreach (var match in matches)
                        {
                            Console.WriteLine(match.ToString());
                        }
                    }
                }
            }
        }
    }
}
