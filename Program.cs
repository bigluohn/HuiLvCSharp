
using HtmlAgilityPack;
using System.Collections.Immutable;
using System.Text;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        ////中国银行
        static string url = "https://www.boc.cn/sourcedb/whpj/";

        //下面抓取网页的代码来源于：https://blog.csdn.net/Frankmei1/article/details/105234077
        static readonly HttpClient client = new HttpClient();

        static async Task Main()
        {
            string[] sCountry =
            {
                "新加坡元", "美元", "日元", "港币", "欧元", "英镑", "新台币"
            };
            string sFile = Directory.GetCurrentDirectory() + "\\外汇.txt";
            
            string sResult = "", sPubTime = "";
            try
            {                
                byte[] resp = await client.GetByteArrayAsync(url);
                string temp = Encoding.GetEncoding("utf-8").GetString(resp); //原文是GB2312，这里编译报错

                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(temp);
                var nodes = doc.DocumentNode.SelectNodes("//tr");
                //删除前面三项
                Console.WriteLine(nodes.Count);
                nodes.Remove(0);
                nodes.Remove(1);
                nodes.Remove(2);
                Console.WriteLine(nodes.Count);

                foreach (var sc in sCountry)
                {
                    for (int i = 0; i < nodes.Count; i++)
                    {
                        if (nodes[i].InnerText.Contains(sc))
                        {
                            string[] sl = nodes[i].InnerText.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                            //数组内容：0货币名称	1现汇买入价	2现钞买入价	3现汇卖出价	4现钞卖出价	
                            //5中行折算价	6发布日期	7发布时间,   只有5全部有内容，中行折算价
                            sResult = sResult + "\t" + sl[5].Trim();
                            if (sPubTime == String.Empty)
                                sPubTime = "\t" + sl[6].Trim();
                            continue;
                        }
                    }

                }
                sResult = DateTime.Now.ToString() + sResult + sPubTime;
                File.AppendAllText(sFile, sResult + Environment.NewLine);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\n抓取网页出现错误，" +e.Message);
            }
        }
    }
}