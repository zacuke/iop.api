using Iop.Api;
using System;
using Iop.Api.Util;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
 
using Microsoft.Extensions.Configuration;
using System.Configuration;
 
namespace Iop.Test
{
    public class Program
    {
        //for ds app
        private static   string _url  ;
        private static   string _appKey  ;
        private static   string _appSecret  ;

        //for particular buyer
        private static   string _code  ;

       
        public static async Task Main(string[] args)
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            IConfiguration configuration = configurationBuilder.AddUserSecrets<Program>(optional: false).Build();
            //string githubToken = configuration.GetSection("github")["accessToken"];
            _url = configuration.GetSection("url").Value;
            _appKey = configuration.GetValue<string>("appKey");
            _appSecret = configuration.GetValue<string>("appSecret");
            _code = configuration.GetValue<string>("code");

            var url = _url;
            var appkey = _appKey;
            var appSecret = _appSecret;

            //{
            //    IopClient client = new IopClient(url, appkey, appSecret);
            //    IopRequest request = new IopRequest();

            //    request.SetApiName("aliexpress.ds.feedname.get");
            //    request.AddApiParameter("app_signature", "your_signature");

            //    IopResponse response = client.Execute(request, GopProtocolEnum.GOP);

            //    Console.WriteLine(response.Body);
            //}

            ////  GetCategory();
            //{
            //    IopClient client = new IopClient(url, appkey, appSecret);
            //    IopRequest request = new IopRequest();

            //    request.SetApiName("aliexpress.ds.recommend.feed.get");
            //    request.AddApiParameter("country", "CA");
            //    request.AddApiParameter("target_currency", "USD");
            //    request.AddApiParameter("target_language", "EN");
            //    request.AddApiParameter("page_size", "50");
            //    request.AddApiParameter("sort", "priceAsc");
            //    request.AddApiParameter("page_no", "1");
            //    request.AddApiParameter("category_id", "21");
            //     request.AddApiParameter("feed_name", "DS_CyberMondayEssentials");

            //    IopResponse response = client.Execute(request, GopProtocolEnum.GOP);

            //    Console.WriteLine(response.Body);

            //}
            //IIopClient client = new IopClient(url, appkey, appSecret);
            //IopRequest request = new IopRequest();
            //request.SetApiName("aliexpress.solution.product.list.get");
            //request.AddApiParameter("aeop_a_e_product_list_query", "{\"gmt_modified_start\":\"2012-01-01 12:13:14\",\"gmt_modified_end\":\"2012-01-01 12:13:14\",\"off_line_time\":\"7\",\"gmt_create_start\":\"2012-01-01 12:13:14\",\"subject\":\"knew odd\",\"have_national_quote\":\"n\",\"ws_display\":\"expire_offline\",\"product_status_type\":\"onSelling\",\"owner_member_id\":\"aliqatest01\",\"gmt_create_end\":\"2012-01-01 12:13:14\",\"group_id\":\"1234\",\"product_id\":\"123\",\"excepted_product_ids\":[\"[32962333569,32813963253]\",\"[32962333569,32813963253]\"],\"sku_code\":\"123ABC\",\"current_page\":\"2\",\"page_size\":\"30\"}");
            //IopResponse response = client.Execute(request, accessToken);
            //Console.WriteLine(response.IsError());
            //Console.WriteLine(response.Body);

            // Console.Write(await GetAccessTokenAsync("code"));
            IIopClient client = new IopClient(_url, _appKey, _appSecret);
            IopRequest request = new IopRequest();
            request.SetApiName("aliexpress.ds.product.get");
            //request.SetApiName("aliexpress.ds.image.search");
            request.AddApiParameter("target_language", "EN");
            request.AddApiParameter("target_currency", "USD");
            request.AddApiParameter("product_cnt", "10");
            request.AddApiParameter("sort", "SALE_PRICE_ASC");
            request.AddApiParameter("shpt_to", "US");
            // request.AddApiParameter("ship_to_country", "US");
             request.AddApiParameter("product_id", "3256806488960331");
            // request.AddApiParameter("target_currency", "USD");
            // request.AddApiParameter("target_language", "en");
            IopResponse response = client.Execute(request, GopProtocolEnum.TOP);
            Console.WriteLine(response.IsError());
            Console.WriteLine(response.Body);

            //IopClient client = new IopClient("https://api-sg.aliexpress.com", "", "");
            //client.SetSignMethod(Constants.SIGN_METHOD_SHA256);

            //try
            //{
            //    IopRequest request = new IopRequest("/auth/token/create");
            //    request.AddApiParameter("code", "pickup");
            //    request.SetHttpMethod(Constants.METHOD_POST);
            //    request.SetSimplify("true");

            //    IopResponse response = client.Execute(request, "", GopProtocolEnum.GOP);
            //    Console.WriteLine(response.IsError());
            //    Console.WriteLine(response.Body);
            //}
            //catch (Exception e)
            //{
            //    Console.Write(e.ToString());
            //}

            //Console.Read();
        }
        public static void GetCategory()
        {
            var url = _url;
            var appkey = _appKey;
            var appSecret = _appSecret;
            IIopClient client = new IopClient(url, appkey, appSecret);
            IopRequest request = new IopRequest();
            request.SetApiName("aliexpress.ds.category.get");
            request.AddApiParameter("categoryId", "15");
            request.AddApiParameter("language", "en");
            request.AddApiParameter("app_signature", "your signature");
            IopResponse response = client.Execute(request, GopProtocolEnum.TOP);
            Console.WriteLine(response.IsError());
            Console.WriteLine(response.Body);
        }
        //public static async Task<string> GetAccessTokenAsync(string code)
        //{
        //    string action = "/auth/token/create";
        //    //var request = new
        //    //{
        //    //    app_key = _appKey,
        //    //    code = code,
        //    //    timestamp = "1234"
        //    //};

        //    IIopClient client = new IopClient(_url, _appKey, _appSecret);
        //    IopRequest request = new IopRequest();
        //    request.SetApiName(action);
            
        //    //var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
        //    // HttpClient _httpClient = new HttpClient();

        //    //var finalUrl = $"{_url}{action}";
        //    //Console.WriteLine(finalUrl);
        //    //var response = await _httpClient.PostAsync(finalUrl, content);
        //    //response.EnsureSuccessStatusCode();

        //    //var responseBody = await response.Content.ReadAsStringAsync();
        //    //Console.WriteLine($"Response JSON: {responseBody}");

        //    // You might want to parse the response and extract the access token here
        //    // var responseObject = JsonConvert.DeserializeObject<AccessTokenResponse>(responseBody);
        //    // return responseObject.AccessToken;

        //    return responseBody;
        //}
    }
}